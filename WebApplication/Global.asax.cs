using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication.App_Code;


namespace WebApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_Error(object sender, EventArgs e)
        {
            // Log an error msg if application raises any error
            // Get the exception object.
            Exception exc = Server.GetLastError();
            // Handle HTTP errors
            if (exc.GetType() == typeof(HttpException))
            {
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                Server.Transfer("../Error/HttpErrorPage.aspx");
            }

            // For other kinds of errors give the user some information
            // but stay on the default page        
            Response.Write("<h2>Global Page Error</h2>\n");
            Response.Write( "<p>  Some Error Has occured .Please contact with system admin or </p>\n");
            Response.Write("Return to the <a href='Default.aspx'>" +
                            "Default Page</a>\n");
                
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "DefaultPage");
            //ExceptionUtility.NotifySystemOps(exc);
            // Clear the error from the server
            Server.ClearError();

        }
        void Session_start(object sender, EventArgs e)
        {
            // application session  start
        }
        void Session_End(object sender, EventArgs e)
        {
            // application session end 
        }
    }
}