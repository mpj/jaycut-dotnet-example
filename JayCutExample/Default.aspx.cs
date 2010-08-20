using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JayCut
{
    public partial class Default : System.Web.UI.Page
    {
        protected string JayCutAuthority { get; set; }
        protected string JayCutLoginUri { get; set; }
    
        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var jayCutter = new JayCutter
            {
                JayCutApiKey = "FQplNhQvR",
                JayCutApiSecret = "iMvNY53FSBTb82vQctkbMtPzp117xVTsHzNsRNB7wVgHzeA8RlpVQ2Xniyu1FmcM",
                JayCutUriAuthority = "mpj.api.jaycut.com"
            };
            JayCutAuthority = jayCutter.JayCutUriAuthority;
            JayCutLoginUri = jayCutter.JayCutLoginUriSimple();
            
            // And this is how you would integrate it with your own community:
            // JayCutLoginUri = jayCutter.JayCutLogUriForUser(YourUserSystem.GetCurrentlyLoggedInUserID());
            

           

        }
    }

    

    
}
