using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.App_Code;

namespace WebApplication
{
    public partial class QuizExamTest : Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StudentData"] == null)
            {
                Response.RedirectToRoute("QuizHomeRoute");
            }
            Page.Title = "Quiz Exam Test";
            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Page.RouteData.Values["QuizId"].ToString()))
                    {
                        //string _strQuizId = Page.RouteData.Values["QuizId"].ToString();
                        populateQuizQtnsAns(Page.RouteData.Values["QuizId"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    ExceptionUtility.LogException(ex, "QuizExamTest Page Error");
                }
            }
        }
        #endregion

        #region Methods
        private void populateQuizQtnsAns(string _strQuizId)
        {
            try
            {
                int result = -1;
                int.TryParse(_strQuizId, out result);

            }
            catch (FormatException ex)
            {
               ExceptionUtility.LogException(ex, "QuizExamTest Page-populateQuizQtnsAns method Error !!");
            }
        }
        #endregion
    }
}