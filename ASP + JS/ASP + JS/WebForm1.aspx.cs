﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP___JS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnClick.Attributes.Add("onClick", "showMessage()");
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {

        }
    }
}