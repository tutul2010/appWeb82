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
                //do contact_no unique validation and insert data
            if(Page.IsValid)
            {
                _objStu = new studentCls();
                _objStu.Fnm = txtFNm.Text.Trim().Replace("'", "''");
                _objStu.Lnm = txtLNm.Text.Trim().Replace("'", "''");
                _objStu.EducationalLvl = txtEduLvl.Text.Trim().Replace("'", "''");
                _objStu.Skill = drpSkill.SelectedValue;
                _objStu.ContactNo =int.Parse(txtContNo.Text.Trim().Replace("'", "''"));
                _objStu.Email = txtEmail.Text.Trim().Replace("'", "''");

                if (isExistPh(_objStu.ContactNo))
                {
                }
                 
            }
        }


        #endregion

        #region Methods
        private bool isExistPh(int contactNo)
        {
            Boolean flg;


            //return flg;
            return true;
        }
        #endregion
    }
}