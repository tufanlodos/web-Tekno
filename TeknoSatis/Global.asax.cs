using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TeknoDAL.Context;

namespace TeknoSatis
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            using (TeknoContext ent = new TeknoContext())
            {
                ent.Database.CreateIfNotExists();
            }
        }
    }
}