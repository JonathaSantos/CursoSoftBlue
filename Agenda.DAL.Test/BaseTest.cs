using Agenda.Domain;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class BaseTest
    {
        private string _script;
        private string _con;
        private string _catalogTest;

        public BaseTest()
        {
            _script = @"DB_Agenda_Test_Create_Corrigido.sql";
            _con = ConfigurationManager.ConnectionStrings["conSetUpTest"].ConnectionString;
            _catalogTest = ConfigurationManager.ConnectionStrings["conSetUpTest"].ProviderName;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            CreateDBTest();
        }

        [Test]
        public void Test()
        {
            // Monta - arrange

            // Executa - act

            // Verifica - Assert
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DeleteDbTest();
        }

        public void CreateDBTest()
        {
            using (var con = new SqlConnection(_con))
            {
                con.Open();
                var scriptSql = File
                    .ReadAllText($@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}{_script}")
                    //.Replace($"DefaultDataPath", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    //.Replace($"DefaultLogPath", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    //.Replace($"DefaultFilePrefix", _catalogTest)
                    //.Replace($"DatabaseName", _catalogTest)
                    .Replace($"WITH (DATA_COMPRESSION = PAGE", string.Empty)
                    .Replace($"SET NOEXEC ON ", string.Empty)
                    .Replace($"GO\r\n", "|");

                ExecuteScriptSql(con, scriptSql);
            }
        }

        private void ExecuteScriptSql(SqlConnection con, string scriptSql)
        {
            using (var cmd = con.CreateCommand())
            {
                foreach (var sql in scriptSql.Split('|'))
                {
                    cmd.CommandText = sql;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine($"sql: {sql}");
                        Console.WriteLine($"e.mensage: {e.Message}");
                    }
                }
            }
        }

        private void DeleteDbTest()
        {
            using (var con = new SqlConnection(_con))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $@"USE [master];
                                        DECLARE @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';' 
                                       FROM sys.dm_exec_session
                                        WHERE database_id = db_id('{_catalogTest}')
                                        EXEC(@kill);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"DROP DATABASE {_catalogTest}";
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
