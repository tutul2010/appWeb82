using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.App_Code;

namespace WebApplication
{
    public partial class QuizExamTest : Page
    {
        #region Variables
        SqlConnection _conn;
        SqlCommand _cmd;
        SqlDataAdapter _adp;
        DataSet _ods;

        #endregion

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
                if (!string.IsNullOrEmpty(Page.RouteData.Values["QuizId"].ToString()))
                {
                    int result = -1;
                    result = int.Parse(Page.RouteData.Values["QuizId"].ToString());
                    populateQuizQtnsAns(result);
                }
            }
        }
        #endregion

        #region Methods
        private void populateQuizQtnsAns(int _iQuizId)
        {
            _ods = new DataSet();
            string _strQury = DbSqlQuery._sSqlGetQuixQtns;
            _conn = new SqlConnection(DbConCls.getDbConn());
            _cmd = new SqlCommand(_strQury, _conn);
            _cmd.Parameters.AddWithValue("@quixId", _iQuizId);
            _adp = new SqlDataAdapter(_cmd);
            _adp.Fill(_ods);

            _conn.Close();
            _cmd.Dispose();
            _adp.Dispose();
        }
        #endregion
    }
}