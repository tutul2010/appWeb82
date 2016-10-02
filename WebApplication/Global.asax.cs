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
            // Add Routes.
            RegisterCustomRoutes(RouteTable.Routes);
        }
        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("QuizHomeRoute", "Default", "~/Default.aspx"); //0
            routes.MapPageRoute("QuizSelectionRoute", "QuizSelection", "~/QuizSelection.aspx"); //1
            routes.MapPageRoute("QuizExamRoute", "QuizExam/{QuizId}", "~/QuizExamTest.aspx");//2
            routes.MapPageRoute("QuizExamResultRoute", "QuizResult", "~/QuizExamResult.aspx");//3
        }
        void Application_Error(object sender, EventArgs e)
        {
            // Log an error msg if application raises any error
            // Get the exception object.
            Exception exc = Server.GetLastError();
            if (exc == null)
                return;
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
                Server.Transfer("~/Error/HttpErrorPage.aspx");
            }
            // For other kinds of errors give the user some information            
            ExceptionUtility.LogException(exc, exc.Source.ToString());
            //ExceptionUtility.NotifySystemOps(exc);
            // Clear the error from the server
            Server.ClearError();
            // Go to error page
            Response.Redirect("~/Error/ErrorPage.aspx");
        }
        void Session_start(object sender, EventArgs e)
        {
            // application session  start
        }
        void Session_End(object sender, EventArgs e)
        {
            // application session end 
            Session.Clear();
            Session.Abandon();
        }
    }
}