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
    public partial class _Default : Page
    {
        #region Variables
        SqlConnection _conn;
        SqlCommand _cmd;
        SqlDataAdapter _adp;
        DataSet _ods;
        studentCls _objStu;    
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            //int i = 10, j = 0,y;
            //y = i / j;
          if(Session["StudentData"] != null)
            {
                
                Session.Clear();
                Session.Abandon();
            }

            lblMsg.Text = string.Empty;
            Page.Title = "Register for Online Exam Quiz";
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string _strDbCon = DbConCls.getDbConn();
            if (drpSkill.SelectedIndex==0)
            {
                lblMsg.Text = "Please select a Skill !";
                drpSkill.Focus();
                return;
            }               
            if(Page.IsValid)
            {
                try
                {
                    _objStu = new studentCls();
                    _objStu.Fnm = txtFNm.Text.Trim().Replace("'", "''");
                    _objStu.Lnm = txtLNm.Text.Trim().Replace("'", "''");
                    _objStu.EducationalLvl = txtEduLvl.Text.Trim().Replace("'", "''");
                    _objStu.Skill = drpSkill.SelectedValue;
                    _objStu.ContactNo = double.Parse(txtContNo.Text.Trim().ToString());
                    _objStu.Email = txtEmail.Text.Trim().Replace("'", "''");
                    //do contact_no unique validation and if not exist then go to quixe taking page
                    if (!isExistPh(_objStu.ContactNo))
                    {
                        //redirect to Quiz Selection page
                        Session["StudentData"] = _objStu;
                        Response.RedirectToRoute("QuizSelectionRoute");
                    }
                    else
                    {
                        lblMsg.Text = "Please Enter another Ph No for taking Quixe !!";
                        txtContNo.Text = "";
                        txtContNo.Focus();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionUtility.LogException(ex, "_Default Page");
                }
            }
        }
        #endregion

        #region Methods

        private bool isExistPh(double contactNo)
        {
            Boolean flg=false;
            try
            {
                _ods = new DataSet();
                string _strQury = DbSqlQuery._sSqlExistPhNo + contactNo;
                _conn = new SqlConnection(DbConCls.getDbConn());
                _cmd = new SqlCommand(_strQury, _conn);
                _adp = new SqlDataAdapter(_strQury, DbConCls.getDbConn());                
                _adp.Fill(_ods);
                if (int.Parse(_ods.Tables[0].Rows[0]["cnt"].ToString()) > 0)
                    flg = true;              
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "_Default Page - isExistPh methods ");
            }
            finally
            {
                _conn.Close();
                _cmd.Dispose();
                _adp.Dispose();
            }           
            return flg;
        }
        #endregion
    }
}