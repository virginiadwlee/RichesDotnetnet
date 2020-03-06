﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_AccountDetails : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Based on the users roll, use the appropriate master (which includes more or less menu items)
        if (User.IsInRole("admin"))
        {
            this.Page.MasterPageFile = "~/Admin/AdminMaster.master";
        }
        else
        {
            this.Page.MasterPageFile = "~/Users/UsersMaster.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewAccountSummary.DataSource = DataAccess.TransactionDB.GetTransactionDataForAccountNumber(Request.QueryString["acctno"]);
        GridViewAccountSummary.DataBind();

    }
}