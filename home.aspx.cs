using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;


public partial class home : System.Web.UI.Page
{
    dataaccess dat = new dataaccess();
    public string showmenah;
    static int idARAPBatchesValue = 0;
    string srcdb = "";
    string destdb = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       // DoEmail();
        bool checkDatabase = dat.checkSqlConnectivity();
      //  showmenah = dataaccess.returnMessage;//different somthing entirely. Not related to the preceding line
        if (checkDatabase != false)
        {
            int hasData = dat.tableHasData("SELECT COUNT(id) FROM [dbo].[Gltransactions]"); //holds total number of uploaded data from transaction table.
            if (hasData > -1)
            {
                srcdb = dat.getDbName("source");
                destdb = dat.getDbName("destination");
                if (srcdb != "NoDatebase" && destdb != "NoDatebase")
                {
                    //cleardestination db.
                    TruncateGlTransactoions();
                    int movement = MoveData();

                    if (movement != 0)
                    {
                        int updateDataMoved = UpdateData();
                        int updateCustomerID = UpdateCustomerWithID();
                        int nocustomerid = CustomerID();
                        if (nocustomerid > 0)
                        {
                            //add customer to customer tables
                            AddNewCustomer();
                            updateCustomerID = UpdateCustomerWithID();
                        }
                        else
                        {
                            Label1.Text += "No Update Done";
                        }

                        int outcome=DoBatchOrBatchLines();
                        if(outcome>0)
                        {
                            TruncateGlTransactoions();
                         int result= MoveToArchive();
                            if(result!=0)
                            {
                                DeleteProcessedData();
                            }
                            Label1.Text +="<br/> <h3>"+ outcome.ToString() + " data has been successfully integrated!</h3>";
                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        Label1.Text += "No data to move";
                    }

                }
            }
        }
        else
        {
            Label1.Text = "No database is provided";
        }
    }

    private void DeleteProcessedData()
    {
        dat.doInserts("DELETE FROM [" + srcdb + "].[dbo].[Gltransactions] WHERE  not  ([transactiondate] is null or [customercode] is null or  [customername] is null) AND [processed]=1");
    }

    private void TruncateGlTransactoions()
    {

        var deletefromGltransactions = dat.insertToGLBatchLines("TRUNCATE TABLE Gltransactions");
    }
    private int MoveToArchive()
    {
        int domovements = 0;
        string qry = "INSERT INTO[" + srcdb + "].[dbo].[ArchivedGltransactions]([transactiondate],[customercode],[customername],[description],[reference],[debitamount],[creditamount],[processed],[transactiontype],[ordernumber]) SELECT[transactiondate],[customercode],[customername],[description],[reference],[debitamount],[creditamount],[processed],[transactiontype],[ordernumber] FROM[" + srcdb + "].[dbo].[Gltransactions] WHERE  not  ([transactiondate] is null or [customercode] is null or  [customername] is null) AND [processed]=1";
       return domovements = dat.doInserts(qry);
    }
    private void DoEmail( )
    {
      int totalid = dat.hasemaildata("SELECT Count(email) from emails where isadmin='False'");
       
        string[] totalemail=new string[totalid];
        //totalemail
        foreach (var item in totalemail)
        {

        }
    }

    private int DoBatchOrBatchLines()
    {
        int results = 0;
        int result = 0;
        int total = 0;
        dat.DoUpdates("UPdate [GTL].[dbo].[GLTransactions] set iTrCodeID= (SELECT [idTrCodes]  FROM [GTL].[dbo].[TrCodes] where code ='PM' and imodule=5),iGLContraID=(SELECT [Account2Link]  FROM [GTL].[dbo].[TrCodes] where code ='PM' and imodule=5) where transactiontype='R'");
        dat.DoUpdates("UPdate [GTL].[dbo].[GLTransactions] set iTrCodeID= (SELECT [idTrCodes]  FROM [GTL].[dbo].[TrCodes] where code ='IN' and imodule=5),iGLContraID=(SELECT [Account2Link]  FROM [GTL].[dbo].[TrCodes] where code ='IN' and imodule=5) where transactiontype='L'");

        var GeneratedNO = GetIdLinePermanentValue(30889, 99999);
        idARAPBatchesValue = dat.ReadBatch("SELECT [idARAPBatches] FROM ["+ destdb+ "].[dbo].[_etblARAPBatches] where [cBatchDesc]='Customers Batch-Integration'");
        if(idARAPBatchesValue > 0)
        {
            results= dat.InsertTOBatchLinesLoan(idARAPBatchesValue, GeneratedNO, destdb);
            result =  dat.InsertTOBatchLines(idARAPBatchesValue, GeneratedNO, destdb);
            

        }
        else
        {
            //idARAPBatchesValue = dat.ReadBatch("SELECT MAX([idARAPBatches]) FROM [" + destdb + "].[dbo].[_etblARAPBatches]");
            //idARAPBatchesValue = idARAPBatchesValue + 1;

            idARAPBatchesValue= dat.creatBatch(destdb, "Integration");

            idARAPBatchesValue = dat.ReadBatch("SELECT [idARAPBatches] FROM [" + destdb + "].[dbo].[_etblARAPBatches] where [cBatchDesc]='Customers Batch-Integration'");
            
            results = dat.InsertTOBatchLinesLoan(idARAPBatchesValue, GeneratedNO, destdb);

            result = dat.InsertTOBatchLines(idARAPBatchesValue, GeneratedNO, destdb);

            dat.UpdateBatchRef(destdb, idARAPBatchesValue);
        }
        return total=results+result;
    }

    public int GetIdLinePermanentValue(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    private void AddNewCustomer()
    {
        dat.doInserts("INSERT INTO[" + destdb + "].[dbo].[CLIENT]( [Account],[name]) SELECT distinct [customercode],customername  FROM [" + destdb + "].[dbo].[Gltransactions] WHERE [customerid] is null");
    }

    private int CustomerID()
    {
      return  dat.hasData("SELECT COUNT(*) FROM [" + destdb + "].[dbo].Gltransactions WHERE customerid is null");
    }
    private int UpdateData()
    {
        int updateid = 0;
        return updateid = dat.updateDataToProcessSource("UPDATE [dbo].[Gltransactions] SET [processed] = 1 WHERE [processed]=0");
    }

    private int MoveData()
    {
        int movedata = 0;
        return  movedata = dat.doInserts("INSERT INTO[" + destdb + "].[dbo].[Gltransactions]( [transactiondate],[customercode],[customername],[description],[reference],[debitamount],[creditamount],[processed],[transactiontype],[ordernumber]) SELECT[transactiondate],[customercode],[customername],[description],[reference],[debitamount],[creditamount],[processed],[transactiontype],[ordernumber] FROM[" + srcdb + "].[dbo].[Gltransactions] WHERE  not  ([transactiondate] is null or [customercode] is null or  [customername] is null) AND [processed]=0");
    }
    private int UpdateCustomerWithID()
    {
        return dat.updateDataToProcess("UPDATE [" + destdb + "].[dbo].Gltransactions SET customerid = Client.DCLink FROM   Client INNER JOIN Gltransactions ON Client.Account = Gltransactions.customercode");
    }

    }

