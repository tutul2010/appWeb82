using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.App_Code
{
    public static class DbConCls
    {
        public static string getDbConn()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["QuizDBConn"].ConnectionString.ToString();
        }
    }
    public partial class DbSqlQuery
    {
        public  static string _sSqlExistPhNo = "SELECT ISNULL(COUNT(stuDtl.contactNo),'0') as cnt from dbo.studentDtl as stuDtl WHERE stuDtl.contactNo=@contactNo";
        public static string _sSqlQuizType = "select qes.Id,qes.QuizeType from dbo.Quize as qes(nolock) ";
        public static string _sSqlGetQuixQtns = "SELECT * from dbo.QuizeTest as QuizeTest WHERE QuizeTest.quixId=@quixId";

    }
}