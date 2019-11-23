using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public class dataaccess
    {
        SqlConnectionStringBuilder conSource = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["source"].ConnectionString);
        SqlConnectionStringBuilder conDestination = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["destination"].ConnectionString);
        string source = ConfigurationManager.ConnectionStrings["source"].ConnectionString;
        string destination = ConfigurationManager.ConnectionStrings["destination"].ConnectionString;
        SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader reda;
    public static string returnMessage,message;
    

        public int tableHasData(string qry)
        {
            int countresult = 0;
            con = new SqlConnection(source);
            con.Open();
            cmd = new SqlCommand(qry, con);
            countresult = (int)cmd.ExecuteScalar();
            con.Close();
            return countresult;
        }
    public int hasData(string qry)
    {
        int countresult = 0;
        con = new SqlConnection(destination);
        con.Open();
        cmd = new SqlCommand(qry, con);
        countresult = (int)cmd.ExecuteScalar();
        con.Close();
        return countresult;
    }
    public int hasemaildata(string qry)
    {
        int countresult = 0;
        con = new SqlConnection(source);
        con.Open();
        cmd = new SqlCommand(qry, con);
        countresult = (int)cmd.ExecuteScalar();
        con.Close();
        return countresult;
    }
    public string  hasemail(string qry)
    {
        string emailid = "";
        con = new SqlConnection(destination);
        con.Open();
        cmd = new SqlCommand(qry, con);
        emailid = reda.IsDBNull(0) ? "" : reda.GetString(0);
        con.Close();
        return emailid;
    }
    public string getDbName(string str)
        {
            string destinationDB = "";

            if (str == "source")
            {
                destinationDB = conSource.InitialCatalog;
            }
            else if (str == "destination")
            {
                destinationDB = conDestination.InitialCatalog;
            }
            else
            {
                destinationDB = "NoDatebase";
            }

            return destinationDB;
        }

        public int updateDataToProcessSource(string qry)
        {
            int completeupdate = 0;
            try
            {

                con = new SqlConnection(source);
                cmd = new SqlCommand(qry, con);
                con.Open();
                completeupdate = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

            }
            catch (Exception)
            {

                completeupdate = 0;
            }

            return completeupdate;
        }
        public int updateDataToProcess(string qry)
        {
            int completeupdate = 0;
            try
            {
                con = new SqlConnection(destination);
                cmd = new SqlCommand(qry, con);
                con.Open();
                completeupdate = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception)
            {
                completeupdate = 0;
            }

            return completeupdate;
        }
        public int doInserts(string qry)
        {
            int moved = 0;
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(qry, con);
                moved = cmd.ExecuteNonQuery();
                con.Close();
                //moved = 1;
            }
            catch (Exception ex)
            {
                moved = 0;
            }
            return moved;
        }
    public void DoUpdates(string qry)
    {
        try
        {
            con = new SqlConnection(destination);
            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //moved = 1;
        }
        catch(Exception ex)
        {
            ex.Message.ToString();
        }
      
        
    }
    public string DoUpdates(int v)
    {
        string qry = "SELECT [email] FROM [dbo].[emails] where  [id]='"+v+"'";
        try
        {
            con = new SqlConnection(destination);
            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

        return qry;
    }
    public int insertToGLBatchLines(string qry)
        {
            int moveGL = 0;
            try
            {
                con = new SqlConnection(destination);
                cmd = new SqlCommand(qry, con);
                con.Open();
                moveGL = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {

                moveGL = 0;
            }
            return moveGL;
        }
        public string getEmails(string qry)
        {

        string result = "soalatise@softcodes.com.ng";
        try
        {
            con = new SqlConnection(source);
            cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataReader reda = cmd.ExecuteReader();
            if (reda.Read())
            {
                result = reda.IsDBNull(0) ? result : reda.GetString(0);
            }
            reda.Close();
            con.Close();
        }
        catch (Exception ex)
        {

            ex.ToString();
        }

        return result;
    }
        public bool checkSqlConnectivity()
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(destination))
            {
                try
                {

                    if (connection.State != ConnectionState.Open || connection.State != ConnectionState.Connecting || connection.State != ConnectionState.Fetching)
                    {
                        connection.Open();
                        result = true;
                    }
                    else
                    {
                        connection.Close();
                        result = false;
                    }
                }
                catch (Exception ex)
                {
                returnMessage = display(ex.Message.ToString());
                }
                finally
                {

                }
                return result;

            }
        }
        public int ReadBatch(string qry)
        {
            int result = 0;
            try
            {
                con = new SqlConnection(destination);
                cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader reda = cmd.ExecuteReader();
                if (reda.Read())
                {
                    result = reda.IsDBNull(0) ? 0 : reda.GetInt32(0);
                }
                reda.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                result = 0;
            }

            return result;
        }
    public int ReadBatche(string qry)
    {
        int result = 0;
        try
        {
            con = new SqlConnection(source);
            cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataReader reda = cmd.ExecuteReader();
            if (reda.Read())
            {
                result = reda.IsDBNull(0) ? 0 : reda.GetInt32(0);
            }
            reda.Close();
            con.Close();
        }
        catch (Exception ex)
        {

            result = 0;
        }

        return result;
    }
    public int createBatch(string val)
        {
            var created = 0;
            try
            {

                string qry = "insert into _btblJrBatches(cBatchNo,cBatchDesc,iInputTaxID,iInputTaxAccID,iOutputTaxID,iOutputTaxAccID,bCalcTax,iTrCodeID,bClearBatch,iDateLineOpt,dDefDate,iRefLineOpt,cDefRef,iDescLineOpt,cDefDesc,bCheckedOut,iMaxRecur,bPromptGlobalChanges,dDateBatchCreated,iAgentBatchCreated,iAgentCheckedOut,bAccrualBatch,iAccrualDateOpt,iAccrualRefOpt,bInterBranchBatch,iBranchLoanAccountID,bRevaluationBatch,_btblJrBatches_iBranchID,dProcessedDate,cBatchRef)";
                qry += "SELECT  Concat('JB00','" + val + "'),'BatchOnline','3','104','1','104','0','2','1','1',Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)),'1','','1','','0','0','0',Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)),'1','1','0','0','1','0','0','0','0','1899-12-30 00:00:00.000','JBR0000" + val + "'";
                con = new SqlConnection(destination);
                cmd = new SqlCommand(qry, con);
                con.Open();
                created = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            return created;
        }
    public void gvbind(string qry, GridView GridView1)
    {

        con = new SqlConnection(source);
        SqlCommand cmd = new SqlCommand(qry,con);
        con.Open();
        SqlDataAdapter adpata = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adpata.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView1.Rows[0].Cells[0].Text = "No Records Found";
        }

    }
    public string display(string mesg)
    {
        return mesg;
    }
   public int creatBatch(string dbName, string message)
    {

        //get the last [idARAPBatches] from the batch Table
        // then increment it by one and concatenate with ARB.
        //lastID = GetBatchNO(databaseName);
        //new batch value. increment by 1
        
        //string newBatchNo = "ARB" + lastID.ToString();

        int updatedValue = 0;
        try
        {
          string  qry = " INSERT INTO [" + dbName + "].[dbo].[_etblARAPBatches]" +
                 " ([iDCModule]" +//1
                                  //  ",[cBatchNo]" +//2
                  ",[cBatchDesc]" +//3
                  ",[bClearAfterPost]" +//4
                  ",[bAllowDupRef]" +//5
                  ",[iCurrencyID]" +//6
                  ",[bCurrencySingle]" +//7
                  ",[iNewLineDateOpt]" +//8
                  ",[dNewLineDateDef]" +//9
                  ",[iNewLineRefOpt]" +//10
                  ",[cNewLineRefDef]" +//11
                  ",[bNewLineRefInc]" +//12
                  ",[iNewLineDescOpt]" +//13
                  ",[cNewLineDescDef]" +//14
                  ",[bNewLineDescInc]" +//15
                  ",[iNewLineTrCodeOpt]" +//16
                  ",[iNewLineTrCodeDefID]" +//17
                  ",[bNewLineTrCodeForce]" +//18
                                            // ",[cOriginalBatchNo]" +//19
                  ",[cOriginalbatchDesc]" +//20
                  ",[iAgentCreatorID]" +//21
                  ",[bShowGLContra]" +//22
                  ",[bEditGLContra]" +//23
                  ",[bAllowGLContraSplit]" +//24
                  ",[bEnterTaxOnGlContraSplit]" +//25
                  ",[bIncludeLinkedAccounts]" +//26
                  ",[bEnterExclOnGlContraSplit]" +//27
                  ",[bValidateOverTerms]" +//28
                  ",[bValidateOverLimit]" +//29
                  ",[bInterBranchBatch]" +//30
                  ",[iBranchLoanAccountID]" +//31
                  ",[bModuleAR]" +//32
                  ",[bModuleAP]" +//33
                  ",[bModuleGL]" +//34
                  ",[iInputTaxID]" +//35
                  ",[iInputTaxAccID]" +//36
                  ",[iOutputTaxID]" +//37
                  ",[iOutputTaxAccID]" +//38
                  ",[bCalcTax]" +//39
                  ",[iDefaultModule]" +//40
                  ",[_etblARAPBatches_iBranchID]) output Inserted.[idARAPBatches] " +//41
                   " VALUES" +
                  "('0'" +//1
                          // ",'" + newBatchNo + "'" +//2
                  ",'Customers Batch" + "-" + message + "'" +//3
                  ",'1'" +//4
                  ",'0'" +//5
                  ",'0'" +//6
                  ",'0'" +//7
                  ",'0'" +//8
                  ", GETDATE()" +//9
                  ",'0'" +//10
                  ",''" +//11
                  ",'0'" +//12
                  ",'0'" +//13
                  ",''" +//14
                  ",'0'" +//15
                  ",'0'" +//16
                  ",'0'" +//17
                  ",'0'" +//18
                          // ",'" + newBatchNo + "'" +//19
                  ",'Accounts Receivable Batch'" +//20
                  ",'1'" +//21
                 ",'0'" +//22
                 ",'0'" +//23
                 ",'0'" +//24
                 ",'0'" +//25
                 ",'0'" +//26
                 ",'1'" +//27
                 ",'1'" +//28
                 ",'1'" +//29
                 ",'0'" +//30
                 ",'0'" +//31
                 ",'1'" +//32
                 ",'1'" +//33
                 ",'1'" +//34
                 ",'1'" +//35
                 ",'104'" +//36
                 ",'1'" +//37
                 ",'104'" +//38
                 ",'0'" +//39
                 ",'0'" +//40
                 ",'0')";//41
            con = new SqlConnection(destination);
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            updatedValue= cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
             message = ex.Message.ToString();
        }
        return updatedValue;
    }
    public int InsertTOBatchLines(int i, int j, string databaseName)
    {
        int tobatchLines = 0;
        try
        {
            string sql = " insert into [" + databaseName + "].[dbo].[_etblARAPBatchLines]" +
                  "([iBatchID]" +// 1
                  ",[idLinePermanent]" +//2
                  ",[dTxDate]" +//3
                  ",[iAccountID]" +//4
                  ",[iAccountCurrencyID]" +//5
                  ",[iTrCodeID]" +//6
                  ",[iGLContraID]" +//7
                  ",[bPostDated]" +//8
                  ",[cReference]  " +//9
                  ",[cDescription]" +//10
                  ",[cOrderNumber]" +//11
                  ",[fAmountExcl]" +//12
                  ",[iTaxTypeID]" +//13
                  ",[fAmountIncl]" +//14
                  ",[fExchangeRate]" +//15
                  ",[fAmountExclForeign]" +//16
                  ",[fAmountInclForeign]" +//17
                  ",[fAccountExchangeRate]" +//18
                  ",[fAccountForeignAmountExcl]" +//19
                  ",[fAccountForeignAmountIncl]" +//20
                  ",[iDiscGLContraID]" +//21
                  ",[fDiscPercent]" +//22
                  ",[fDiscAmountExcl]" +//23
                  ",[iDiscTaxTypeID]" +//24
                  ",[fDiscAmountIncl]" +//25
                  ",[fDiscAmountExclForeign]" +//26
                  ",[fDiscAmountInclForeign]" +//27
                  ",[fAccountForeignDiscAmountExcl]" +//28
                  ",[fAccountForeignDiscAmountIncl]" +//29
                  ",[iProjectID]" +//30
                  ",[iSalesRepID]" +//31
                  ",[iBatchSettlementTermsID]" +//32
                  ",[iModule]" +//33
                  ",[iTaxAccountID]" +//34
                  ",[bIsDebit]" +//35
                  ",[iMBPropertyID]" +//36
                  ",[iMBPortionID]" +//37
                  ",[iMBServiceID]" +//38
                  ",[iMBPropertyPortionServiceID]" +//39
                  ",[_etblARAPBatchLines_iBranchID])" +//40	  	  
                  "SELECT" +
                  " '" + i + "'" +//1
                  ", '" + j + "'" +//2
                  ",[transactiondate]" +//3
                  ",customerid" +//4
                  ",'0'" +//"+//"+//5
                  ",[iTrCodeID]" +//"+//"+//6
                  ",[iGLContraID]" +//"+//"+//7
                  ",'0'" +//"+//"+//8
                  ",[reference]" +//"+//"+//9
                  ",[description]" +//"+//"+//10
                  ",[ordernumber]" +//"+//"+//11
                  ",[creditamount]" +//"+//"+//12
                  ",'0'" +//"+//"+//13
                  ",[creditamount]" +//"+//"+//14
                  ",'1'" +//"+//"+//15
                  ",[creditamount]" +//"+//"+//16
                  ",[creditamount]" +//"+//"+//17
                  ",'0'" +//"+//"+//18
                  ",'0'" +//"+//"+//19
                  ",'0'" +//"+//"+//20
                  ",[iDiscGLContraID]" +//"+//"+//21
                  ",'0'" +//"+//"+//22
                  ",'0'" +//"+//"+//23
                  ",'0'" +//"+//"+//24
                  ",'0'" +//"+//"+//25
                  ",'0'" +//"+//"+//26
                  ",'0'" +//"+//"+//27
                  ",'0'" +//"+//"+//28
                  ",'0'" +//"+//"+//29
                  ",'0'" +//"+//"+//30
                  ",'0'" +//"+//"+//31
                  ",'0'" +//"+//"+//32
                  ",'0'" +//"+//"+//33
                  ",'0'" +//"+//"+//34
                  ",'0'" +//"+//"+//35
                  ",'0'" +//"+//"+//36
                  ",'0'" +//"+//"+//37
                  ",'0'" +//"+//"+//38
                  ",'0'" +//"+//"+//39
                  ",'0'" +//"+//"+//40 
                 " From Gltransactions WHERE [transactiontype]='R' ";
            con = new SqlConnection(destination);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            tobatchLines= cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
          
        }
        return tobatchLines;
    }
    public void UpdateBatchRef(string databaseName, int i)
    {
        //new batch value. increment by 1
        //int newID = lastID + 1;
        string newBatchNo = "ARB" + i.ToString();
      
        string val = "ARBR00" + i.ToString();
        string qry = "UPDATE [dbo].[_etblARAPBatches]  SET [cBatchRef]= '" + val + "',[cBatchNo]= '" + newBatchNo + "' ,[coriginalBatchNo]= '" + newBatchNo + "'   WHERE [idARAPBatches]='" + i + "'";
        con = new SqlConnection(destination);
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public int InsertTOBatchLinesLoan(int i, int j, string databaseName)
    {
        int tobatchLines = 0;
        try
        {
            string sql = " insert into [" + databaseName + "].[dbo].[_etblARAPBatchLines]" +
                  "([iBatchID]" +// 1
                  ",[idLinePermanent]" +//2
                  ",[dTxDate]" +//3
                  ",[iAccountID]" +//4
                  ",[iAccountCurrencyID]" +//5
                  ",[iTrCodeID]" +//6
                  ",[iGLContraID]" +//7
                  ",[bPostDated]" +//8
                  ",[cReference]  " +//9
                  ",[cDescription]" +//10
                  ",[cOrderNumber]" +//11
                  ",[fAmountExcl]" +//12
                  ",[iTaxTypeID]" +//13
                  ",[fAmountIncl]" +//14
                  ",[fExchangeRate]" +//15
                  ",[fAmountExclForeign]" +//16
                  ",[fAmountInclForeign]" +//17
                  ",[fAccountExchangeRate]" +//18
                  ",[fAccountForeignAmountExcl]" +//19
                  ",[fAccountForeignAmountIncl]" +//20
                  ",[iDiscGLContraID]" +//21
                  ",[fDiscPercent]" +//22
                  ",[fDiscAmountExcl]" +//23
                  ",[iDiscTaxTypeID]" +//24
                  ",[fDiscAmountIncl]" +//25
                  ",[fDiscAmountExclForeign]" +//26
                  ",[fDiscAmountInclForeign]" +//27
                  ",[fAccountForeignDiscAmountExcl]" +//28
                  ",[fAccountForeignDiscAmountIncl]" +//29
                  ",[iProjectID]" +//30
                  ",[iSalesRepID]" +//31
                  ",[iBatchSettlementTermsID]" +//32
                  ",[iModule]" +//33
                  ",[iTaxAccountID]" +//34
                  ",[bIsDebit]" +//35
                  ",[iMBPropertyID]" +//36
                  ",[iMBPortionID]" +//37
                  ",[iMBServiceID]" +//38
                  ",[iMBPropertyPortionServiceID]" +//39
                  ",[_etblARAPBatchLines_iBranchID])" +//40	  	  
                  "SELECT" +
                  " '" + i + "'" +//1
                  ", '" + j + "'" +//2
                  ",[transactiondate]" +//3
                  ",customerid" +//4
                  ",'0'" +//"+//"+//5
                  ",[iTrCodeID]" +//"+//"+//6
                  ",[iGLContraID]" +//"+//"+//7
                  ",'0'" +//"+//"+//8
                  ",[reference]" +//"+//"+//9
                  ",[description]" +//"+//"+//10
                  ",[ordernumber]" +//"+//"+//11
                  ",[debitamount]" +//"+//"+//12
                  ",'0'" +//"+//"+//13
                  ",[debitamount]" +//"+//"+//14
                  ",'1'" +//"+//"+//15
                  ",[debitamount]" +//"+//"+//16
                  ",[debitamount]" +//"+//"+//17
                  ",'0'" +//"+//"+//18
                  ",'0'" +//"+//"+//19
                  ",'0'" +//"+//"+//20
                  ",[iDiscGLContraID]" +//"+//"+//21
                  ",'0'" +//"+//"+//22
                  ",'0'" +//"+//"+//23
                  ",'0'" +//"+//"+//24
                  ",'0'" +//"+//"+//25
                  ",'0'" +//"+//"+//26
                  ",'0'" +//"+//"+//27
                  ",'0'" +//"+//"+//28
                  ",'0'" +//"+//"+//29
                  ",'0'" +//"+//"+//30
                  ",'0'" +//"+//"+//31
                  ",'0'" +//"+//"+//32
                  ",'0'" +//"+//"+//33
                  ",'0'" +//"+//"+//34
                  ",'1'" +//"+//"+//35
                  ",'0'" +//"+//"+//36
                  ",'0'" +//"+//"+//37
                  ",'0'" +//"+//"+//38
                  ",'0'" +//"+//"+//39
                  ",'0'" +//"+//"+//40 
                 " From Gltransactions WHERE [transactiontype]='L' ";
            con = new SqlConnection(destination);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            tobatchLines = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {

        }
        return tobatchLines;
    }
}



