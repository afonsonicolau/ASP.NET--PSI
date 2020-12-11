using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tabuada
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 1; i < 11; i++)
                {
                    ddlNumbers.Items.Add(i.ToString());
                }
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            //if(ddlNumbers.Text != "")
            //{
            //    lbTable.Items.Clear();

            //    int number = int.Parse(ddlNumbers.Text);
            //    int result = 0;

            //    for (int i = 1; i < 11; i++)
            //    {
            //        result = i * number;
            //        lbTable.Items.Add(i.ToString() + " x " + number.ToString() + " = " + result.ToString());

            //        // Show results on table
            //        tblMultiplication.Rows[i].Cells[0].Text = number.ToString();
            //        tblMultiplication.Rows[i].Cells[4].Text = result.ToString();
            //    }
            //}return;

            Table table = new Table();
            
            int result = 0;
            int number = int.Parse(ddlNumbers.Text);

            for (int i = 0; i <= 10; i++)
            {
                TableRow row = new TableRow();

                // Cell format
                TableCell cell = new TableCell();

                cell.Text = number.ToString() + "x" + i.ToString() + " = ";
                row.Cells.Add(cell);

                // Cell result
                cell = new TableCell();

                result = i * number;
                cell.Text = result.ToString();

                row.Cells.Add(cell);
                table.Rows.Add(row);
            }
            PlaceHolder1.Controls.Add(table);
        }
    }
}