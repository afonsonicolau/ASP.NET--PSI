using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exemplo1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHello_Click(object sender, EventArgs e)
        {
            if(txtMessage.Text != "")
            {
                Label1.Text = "<h2>Welcome " + txtMessage.Text + "!</h2>";
            }
            else
            {
                Label1.Text = "<h2>Write your name first.</h2>";
            }
        }
    }
}