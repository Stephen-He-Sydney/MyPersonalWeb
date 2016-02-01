using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Data.SqlClient;
using System.Configuration;

namespace PersonalDemo.Web.Cache
{
    public static class SqlCacheHelper
    {
        public static void FetchFromDb<T>(string key, IList<T> values)
        {
            SqlCacheDependency SqlDep = null;
            string conn = ConfigurationManager.ConnectionStrings["PersonalDemoContext"].ConnectionString;
            SqlDependency.Start(conn);

            try
            {
                SqlDep = new SqlCacheDependency("PersonalDemo", key);
            }
            catch (DatabaseNotEnabledForNotificationException)
            {
                try
                {
                    SqlCacheDependencyAdmin.EnableNotifications(conn);
                }
                catch (UnauthorizedAccessException)
                {
                    //Response.Redirect("ErrorPage.htm");
                }
            }
            catch (TableNotEnabledForNotificationException)
            {
                try
                {
                    SqlCacheDependencyAdmin.EnableTableForNotifications(conn, "dbo." + key);
                }
                catch (SqlException)
                {
                    //Response.Redirect("ErrorPage.htm");
                }
            }
            finally
            {
                HttpRuntime.Cache.Insert(key, values, SqlDep);
            }
        }
    }
}