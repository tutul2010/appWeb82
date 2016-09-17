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
    public static class DbSqlQuery
    {
        public const string _sSqlExistPhNo = "";
    }
}