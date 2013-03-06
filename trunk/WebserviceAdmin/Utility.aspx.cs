using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebserviceAdmin
{
    public partial class Utility : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(hiddenDate.Value))
            {
                lbStar.Visible = true;
                lbError.Visible = true;
            }
            else
            {
                var strDate = hiddenDate.Value.Split('/');
                var datetime = new DateTime(Convert.ToInt32(strDate[2]), Convert.ToInt32(strDate[1]),
                                            Convert.ToInt32(strDate[0]));
                lbTicks.Text = "Ticks of <b>"+hiddenDate.Value+"</b> = <b>"+datetime.Ticks.ToString()+"</b>";
                lbStar.Visible = false;
                lbError.Visible = false;
            }
        }
    }
}