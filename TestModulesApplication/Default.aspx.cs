using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestModulesApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Long Request
        private void longReuqestTester(TimeSpan length)
        {
            var start = DateTime.Now;
            System.Threading.Thread.Sleep(length);
            lblLongRequestMesage.Text = "Total time: " + DateTime.Now.Subtract(start);
        }

        protected void btnShort_Click(object sender, EventArgs e)
        {
            longReuqestTester(TimeSpan.FromMilliseconds(100));
        }

        protected void btnMedium_Click(object sender, EventArgs e)
        {
            longReuqestTester(TimeSpan.FromMilliseconds(1000));
        }

        protected void btnLong_Click(object sender, EventArgs e)
        {
            longReuqestTester(TimeSpan.FromMilliseconds(3000));
        }
        #endregion

        #region Cookie Verifier
        protected void btnSetCookie_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(new HttpCookie("CookieVerifier", txtCookieValue.Text));
        }

        protected void btnGetCookie_Click(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["CookieVerifier"];
            txtCookieValue.Text = cookie != null ? cookie.Value : string.Empty;
        }
        #endregion
    }
}