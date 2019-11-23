using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class settings : System.Web.UI.Page
{
    dataaccess dat = new dataaccess();
    static int invcode=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            showGrid();
        }
       

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        int invcode = 0;
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        invcode = (int)GridView1.DataKeys[gRow.RowIndex].Value;
        dat.doInserts("delete from [dbo].[emails] where id='"+invcode+"'");
        showGrid();
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        text1.Text="";
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        invcode = (int)GridView1.DataKeys[gRow.RowIndex].Value;
        text1.Text = dat.getEmails("SELECT [email] FROM [dbo].[emails] where [ID]="+invcode.ToString()+"");
        Button1.Text = "Update Email";
        
       

    }

    private string LoadTextBox(int invcode)
    {
        return dat.DoUpdates(invcode);
    }

    private void showGrid()
    {
        dat.gvbind("SELECT [id],[email] FROM [dbo].[emails]", GridView1);
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
        if(IsPostBack)
        {

        }
    }
    private void AddEmail(string email)
    {
        dat.doInserts("INSERT INTO [dbo].[emails]([email],[isadmin])  VALUES('"+email+"','0')");
        text1.Text = "";
    }
    private void UpdateEmail(string email,int V)
    {
        dat.doInserts("UPDATE [dbo].[emails] SET [email]='" + email + "' WHERE [ID]="+V+"");
        text1.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string email = string.IsNullOrWhiteSpace(text1.Text) ? "No Value" : text1.Text.Replace("'", "''");
        int exist = dat.tableHasData("SELECT COUNT([id]) FROM [dbo].[emails] where email='" + email + "'");
        if(Button1.Text== "Add Email")
        {
            if (exist != 0)
            {

            }
            else
            {
                AddEmail(email);
            }
        }
        if(Button1.Text=="Update Email")
        {
            if (exist != 0)
            {
                
            }
            else
            {
                UpdateEmail(email, invcode);
                
            }
            Button1.Text = "Add Email";
        }


        showGrid();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}