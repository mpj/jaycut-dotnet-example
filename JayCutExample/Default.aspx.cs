using System;

namespace JayCutExample
{
    public partial class Default : System.Web.UI.Page
    {
        protected string JayCutAuthority { get; set; }
        protected string JayCutLoginUri { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            var jayCutter = new JayCutter
            {
                // Check your API Signup welcome email for the 
                // details below.
                JayCutApiKey = "YOURAPIKEY",
                JayCutApiSecret = "YOURSECRET",
                JayCutUriAuthority = "YOURSITENAME.api.jaycut.com" 
            };

            JayCutAuthority = jayCutter.JayCutUriAuthority;
            JayCutLoginUri = jayCutter.JayCutLoginUriSimple();
            
            // And this is how you would integrate it with your own community:
            // JayCutLoginUri = jayCutter.JayCutLogUriForUser(YourUserSystem.GetCurrentlyLoggedInUserID());
            
            
        }
    }

    

    
}
