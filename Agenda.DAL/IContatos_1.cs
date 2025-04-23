using Agenda.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Agenda.DAL
{
    public class IContatos
    {
        string _strConexao;
      

        public IContatos()
        {
            //_strConexao = @"Data Source=JONATHANOTE\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=true;TrustServerCertificate=True;User ID=sa;Password=123456;";
            _strConexao = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        }

        public void Adcionar(Contato contato)
        {
            using (var con = new SqlConnection(_strConexao))
            {
                con.Execute($"insert into Contato (Id, Nome) values ('{contato.Id.ToString()}','{contato.Nome}')");
                
                //con.Open();

                //string sql = $"insert into Contato (Id, Nome) values ('{contato.Id.ToString()}','{contato.Nome}')";

                //SqlCommand cmd = new SqlCommand(sql, con);

                //cmd.ExecuteNonQuery();

            }

        }

        public Contato ObterContato(Guid id)
        {
            var contatoNovo = new Contato();

            using (var con = new SqlConnection(_strConexao))
            {
                //contatoNovo = con.QueryFirst<Contato>($"select Id, Nome from Contato where Id = '{id.ToString()}'");
                contatoNovo = con.QueryFirst<Contato>("select Id, Nome from Contato where Id = @Id", new {Id = id });


                //con.Open();

                //string sql = $"select Id, Nome from Contato where Id = '{id.ToString()}'";

                //SqlCommand cmd = new SqlCommand(sql, con);

                ////return cmd.ExecuteScalar().ToString();
                //var sqlDataReader = cmd.ExecuteReader();

                //sqlDataReader.Read();

                //contatoNovo = new Contato()
                //{

                //    Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                //    Nome = sqlDataReader["Nome"].ToString(),
                //};


            }

            return contatoNovo;

        }

        public List<Contato> ObterTodosContato()
        {
            var listaContato = new List<Contato>();
            
            using (var con = new SqlConnection(_strConexao))
            {
                // usando o Dapper
                listaContato = con.Query<Contato>("select Id, Nome from Contato").ToList();

                /// Sem o Dapper
                //con.Open();

                //string sql = $"select Id, Nome from Contato ";

                //SqlCommand cmd = new SqlCommand(sql, con);

                ////return cmd.ExecuteScalar().ToString();
                //var sqlDataReader = cmd.ExecuteReader();

                //while (sqlDataReader.Read())
                //{
                //    var contatoNovo = new Contato()
                //    {

                //        Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                //        Nome = sqlDataReader["Nome"].ToString(),
                //    };

                //    listaContato.Add(contatoNovo);

                //}
            }

            return listaContato;

        }
    }
}
