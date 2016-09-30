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
    public partial class QuizSelection : Page
    {
        #region Variables
        SqlConnection _conn;
        SqlCommand _cmd;
        SqlDataAdapter _adp;
        DataSet _ods;
        studentCls _objStu;
        #endregion

        #region Events
        protected void Page_Init(object sender, EventArgs e)
        {
            Page.Title = "Quiz Selection";
            populatedQuizType();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StudentData"] == null)
            {
                Response.RedirectToRoute("QuizHomeRoute");
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            _objStu = new studentCls();
            if (Page.IsValid)
            {
                try
                {
                    if(Session["StudentData"] != null)
                    {
                        _objStu = (studentCls)Session["StudentData"];
                    }
                    _objStu.QuizeId = int.Parse(drpQuizeType.SelectedValue.ToString());
                    Session["StudentData"] = _objStu;
                    //redirect to Quiz Exam Test page with quixId
                    Response.RedirectToRoute("QuizExamRoute", new { QuizId = drpQuizeType.SelectedValue.ToString() });
                }
                catch (Exception ex)
                {
                    ExceptionUtility.LogException(ex, "QuizSelection Page Error !!");
                }
            }
        }
        #endregion

        #region Methods
           private void populatedQuizType()
        {
            string _strQury = DbSqlQuery._sSqlQuizType;
            try
            {
                _ods = new DataSet();
                _conn = new SqlConnection(DbConCls.getDbConn());
                _cmd = new SqlCommand(_strQury, _conn);
                _adp = new SqlDataAdapter(_cmd);
                _adp.Fill(_ods);
                drpQuizeType.Items.Clear();
                drpQuizeType.DataSource = _ods;
                drpQuizeType.DataTextField = "QuizeType";
                drpQuizeType.DataValueField = "Id";
                drpQuizeType.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "QuizSelection  Page-populatedQuizType method Error !!");
            }
            finally
            {
                _conn.Close();
                _cmd.Dispose();
                _adp.Dispose();
            }
            drpQuizeType.Items.Insert(0, new ListItem("Select Quize Type", "0"));
        }
        #endregion
    }
}