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
    public partial class QuizSelection : System.Web.UI.Page
    {
        #region Variables
        SqlConnection _conn;
        SqlCommand _cmd;
        SqlDataAdapter _adp;
        DataSet _ods;

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
           
            if (Page.IsValid)
            {
                Response.Write("passes !!");
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
                _adp = new SqlDataAdapter(_strQury, DbConCls.getDbConn());
                _adp.Fill(_ods);
                drpQuizeType.DataSource = _ods;
                drpQuizeType.DataTextField = "QuizeType";
                drpQuizeType.DataValueField = "Id";
                drpQuizeType.DataBind();
            }
            catch (Exception ex)
            {

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