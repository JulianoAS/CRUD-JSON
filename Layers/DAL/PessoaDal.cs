using Layers.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.DAL
{
    internal class PessoaDal
    {
        Scon sCon = new Scon();

        internal long Incluir(Pessoa pessoa)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("Nome", pessoa.Nome));
            parametros.Add(new SqlParameter("Sobrenome", pessoa.Sobrenome));
            parametros.Add(new SqlParameter("CPF", pessoa.CPF));
            parametros.Add(new SqlParameter("RG", pessoa.RG));
            parametros.Add(new SqlParameter("CEP", pessoa.CEP));
            parametros.Add(new SqlParameter("Logradouro", pessoa.Logradouro));
            parametros.Add(new SqlParameter("Cidade", pessoa.Cidade));
            parametros.Add(new SqlParameter("Estado", pessoa.Estado));
            parametros.Add(new SqlParameter("Email", pessoa.Email));
            parametros.Add(new SqlParameter("Telefone", pessoa.Telefone));
            parametros.Add(new SqlParameter("Celular", pessoa.Celular));

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection con = new SqlConnection(sCon.GetSCon()))
            {
                try
                {
                    cmd.CommandText = "sp_Inserir_Pessoa";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;


                    foreach (var item in parametros)
                    {
                        cmd.Parameters.Add(item);
                    }

                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception Erro)
                {
                    throw Erro;
                }
            }
        }

        internal void Deletar(long id)
        {
            ;
            using (SqlConnection con = new SqlConnection(sCon.GetSCon()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.CommandText = "sp_Deletar_Pessoa";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@ID", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception Erro)
                    {
                        throw Erro;
                    }
                }
            }
        }

        internal void Atualizar(Pessoa pessoa)
        {

            using (SqlConnection con = new SqlConnection(sCon.GetSCon()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {

                        cmd.CommandText = "sp_Atualizar_Pessoa";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Id", pessoa.Id);
                        cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                        cmd.Parameters.AddWithValue("@Sobrenome", pessoa.Sobrenome);
                        cmd.Parameters.AddWithValue("@CPF", pessoa.CPF);
                        cmd.Parameters.AddWithValue("@RG", pessoa.RG);
                        cmd.Parameters.AddWithValue("@CEP", pessoa.CEP);
                        cmd.Parameters.AddWithValue("@Logradouro", pessoa.Logradouro);
                        cmd.Parameters.AddWithValue("@Cidade", pessoa.Cidade);
                        cmd.Parameters.AddWithValue("@Estado", pessoa.Estado);
                        cmd.Parameters.AddWithValue("@Email", pessoa.Email);
                        cmd.Parameters.AddWithValue("@Telefone", pessoa.Telefone);
                        cmd.Parameters.AddWithValue("@Celular", pessoa.Celular);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception Erro)
                    {
                        throw Erro;
                    }
                }
            }
        }

        internal List<Pessoa> ListPessoa()
        {
            List<Pessoa> listpessoa = new List<Pessoa>();
            using (SqlConnection con = new SqlConnection(sCon.GetSCon()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_List_Pessoa";
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Pessoa pessoa = new Pessoa();
                                pessoa.Id = Convert.ToInt32(dr["Id"].ToString());
                                pessoa.Nome = dr["Nome"].ToString();
                                pessoa.Sobrenome = dr["Sobrenome"].ToString();
                                pessoa.CPF = dr["CPF"].ToString();
                                pessoa.RG = dr["RG"].ToString();
                                pessoa.CEP = dr["CEP"].ToString();
                                pessoa.Logradouro = dr["Logradouro"].ToString();
                                pessoa.Cidade = dr["Cidade"].ToString();
                                pessoa.Estado = dr["Estado"].ToString();
                                pessoa.Celular = dr["Celular"].ToString();
                                pessoa.Telefone = dr["Telefone"].ToString();
                                pessoa.Email = dr["Email"].ToString();
                                listpessoa.Add(pessoa);
                            }


                            return listpessoa;
                        }

                    }
                    catch (Exception Erro)
                    {
                        throw Erro;

                    }
                }
            }
        }

        internal Pessoa LerPessoa(long id)
        {
            Pessoa pessoa = new Pessoa();
            using (SqlConnection con = new SqlConnection(sCon.GetSCon()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Ler_Pessoa";
                        cmd.Parameters.AddWithValue("@ID", id);
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                pessoa.Id = Convert.ToInt32(dr["Id"].ToString());
                                pessoa.Nome = dr["Nome"].ToString();
                                pessoa.Sobrenome = dr["Sobrenome"].ToString();
                                pessoa.CPF = dr["CPF"].ToString();
                                pessoa.RG = dr["RG"].ToString();
                                pessoa.CEP = dr["CEP"].ToString();
                                pessoa.Logradouro = dr["Logradouro"].ToString();
                                pessoa.Cidade = dr["Cidade"].ToString();
                                pessoa.Estado = dr["Estado"].ToString();
                                pessoa.Celular = dr["Celular"].ToString();
                                pessoa.Telefone = dr["Telefone"].ToString();
                                pessoa.Email = dr["Email"].ToString();
                            }
                            return pessoa;
                        }
                    }
                    catch (Exception Erro)
                    {
                        throw Erro;
                    }

                }
            }

        }
    }
}
