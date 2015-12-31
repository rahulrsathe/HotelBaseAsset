using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_ViewMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        UserAuth clsUsrAuth = new UserAuth();
        try
        {
             Orders clsOrders = new Orders();
            GridView1.DataSource = clsOrders.getTest1(int.Parse(Session[Constants.SVAR_HOTEL_ID].ToString()));
            GridView1.DataBind();

            GridView2.DataSource = clsOrders.getTest2(int.Parse(Session[Constants.SVAR_HOTEL_ID].ToString()));
            GridView2.DataBind();
           
        }
        finally
        {
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //use this way
            e.Row.ToolTip = e.Row.Cells[0].Text.ToString() +" "+ e.Row.Cells[1].Text.ToString();
            //or use this way
           // e.Row.Attributes.Add("title", "My FooBar tooltip");
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = 10;
    }
}