using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace WebOS.FallHub.Core
{
    /// <summary>
    /// access the sqlite coredaba
    /// </summary>
    public class LocalData
    {
        static string cnnstr = "Data Source=coredata.db;Version=3;Pooling=False;Max Pool Size=100;";
        public static Dictionary<string, string> RemoteUrls = new Dictionary<string, string>();
        
        public static void LoadUrls()
        {
            string sql = "select key,url from link";
            var cnn = new SQLiteConnection(cnnstr);
            try
            {
                cnn.Open();
                var list = Dapper.SqlMapper.Query(cnn, sql);
                foreach (var q in list)
                {
                    RemoteUrls.Add(q.key, ServerInfo.AppPath + q.url);
                }
            }
            catch (DataException ex)
            {

            }
            finally
            {
                cnn.Close();
            }

        }

        /// <summary>
        /// load server info and config info
        /// </summary>
        public static void LoadServerConfig() { 

            string sql=@"select name,host from server where name='defaultserver' ";
            var cnn = new SQLiteConnection(cnnstr);
            try
            {
                cnn.Open();
                var list = Dapper.SqlMapper.Query(cnn, sql );
                if (list != null && list.Any())
                {
                    var server = list.FirstOrDefault();
                    ServerInfo.AppPath=server.host;
                }
                sql = "select * from config ";
                var listconfig = Dapper.SqlMapper.Query(cnn, sql);
                if (listconfig != null && listconfig.Any()) {
                    var deskey = listconfig.FirstOrDefault(c => c.key == "DESKey");
                    ServerInfo.DesKey = deskey.value;
                }
            }
            catch (DataException ex)
            {

            }
            finally
            {
                cnn.Close();
            }

        }


        /// <summary>
        /// load user profile by loginid from coredata
        /// </summary>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public static dynamic LoadUserProfile(string loginid)
        {
            dynamic userProfile = default(dynamic);
            string sql = @"select  *  from profile    where loginid=@loginid";
            var cnn = new SQLiteConnection(cnnstr);
            try
            {
                cnn.Open();
                var list = Dapper.SqlMapper.Query(cnn, sql, new { loginid = loginid });
                if (list != null && list.Any())
                {
                    userProfile = list.FirstOrDefault();
                }
            }
            catch (DataException ex)
            {

            }
            finally
            {
                cnn.Close();
            }
            return userProfile;
        }

        /// <summary>
        /// add profile for current user
        /// </summary>
        /// <param name="profile"></param>
        public static void SaveConfigByKey(string key, string val, string loginid)
        {
            string sql = "select id from pofile where loginid=@loginid";
            var cnn = new SQLiteConnection(cnnstr);
            try
            {
                cnn.Open();
                var arlist = Dapper.SqlMapper.Query(cnn, sql, new { loginid = loginid });
                if (arlist != null && arlist.Count() > 0)//item exist
                {
                    var id = arlist.FirstOrDefault();
                    sql = "update profile set " + key + "=@val where id=@id";
                    Dapper.SqlMapper.Execute(cnn, sql, new { val = val, id = id });
                }
                else//item not exist ,insert in
                {
                    sql = "insert into profile (loginid," + key + ")values(@loginid,@val)";
                    Dapper.SqlMapper.Execute(cnn, sql, new { loginid = loginid, val = val });
                }
            }
            catch (DataException ex)
            {
                //Utils.BrowActionController.GetInstance
            }
            finally
            {
                cnn.Close();
            }

        }

        /// <summary>
        /// load local config from coredata
        /// </summary>
        /// <returns></returns>
        public static dynamic LoadConfig()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// save loginuser info to coredata
        /// </summary>
        /// <param name="User"></param>
        public static void SaveLoginInfo(dynamic User)
        {
            string sql1 = string.Format("select id from user where loginid='{0}'", User.loginid);
            string sql = string.Format("insert into user ( name,loginid,psw,sta,createtime) values('{0}','{1}','{2}','{3}','{4}')", User.name, User.loginid, User.psw, 0, DateTime.UtcNow.Ticks);
            var cnn = new SQLiteConnection(cnnstr);
            try
            {
                cnn.Open();
                var arlist = Dapper.SqlMapper.Query(cnn, sql1);

                if (arlist != null && arlist.Count() > 0)
                {
                    sql = "update user set createtime=@time where id=@id";
                    Dapper.SqlMapper.Execute(cnn, sql, new { time = DateTime.UtcNow.Ticks, id = arlist.FirstOrDefault().id });

                }
                else
                {
                    Dapper.SqlMapper.Execute(cnn, sql);
                }
            }
            catch (DataException ex)
            {
                //Utils.BrowActionController.GetInstance
            }
            finally
            {
                cnn.Close();
            }
        }

        /// <summary>
        /// get local user info 
        /// </summary>
        /// <returns></returns>
        public static dynamic LoadLastLoginLocalUser()
        {
            dynamic usr = null;
            string sql = "select name,loginid,psw from user order by createtime desc";
            var cnn = new SQLiteConnection(cnnstr);
            try
            {
                cnn.Open();
                var list = Dapper.SqlMapper.Query(cnn, sql);
                if (list != null && list.Count() > 0)
                {
                    var person = list.FirstOrDefault();
                    usr = person;
                }
            }
            catch (DataException ex)
            {
                //Utils.BrowActionController.GetInstance
            }
            finally
            {
                cnn.Close();
            }
            return usr;
        }

        /// <summary>
        /// get local user list from coredata
        /// </summary>
        /// <returns></returns>
        public static List<dynamic> LoadLocalUserList()
        {
            List<dynamic> ar = new List<dynamic>();
            string sql = "select name,loginid,psw from user order by createtime desc";
            var cnn = new SQLiteConnection(cnnstr);
            try
            {
                cnn.Open();
                var list = Dapper.SqlMapper.Query(cnn, sql);
                if (list != null && list.Count() > 0)
                {
                    var person = list.FirstOrDefault();
                    ar.Add(person);
                }
            }
            catch (DataException ex)
            {
                //Utils.BrowActionController.GetInstance
            }
            finally
            {
                cnn.Close();
            }
            return ar;
        }

    }
}
