using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_FormaPagamento
    {
        public static CD_FormaPagamento _instancia = null;

        private CD_FormaPagamento()
        {

        }

        public static CD_FormaPagamento Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_FormaPagamento();
                }
                return _instancia;
            }
        }

        public List<FormaPagamento> ObterFormaPagamento()
        {
            List<FormaPagamento> rptListaFormaPagamento = new List<FormaPagamento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObterFormasPagamento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaFormaPagamento.Add(new FormaPagamento()
                        {
                            IdFormaPagto = Convert.ToInt32(dr["IdFormaPagto"].ToString()),
                            Descricao = dr["Descricao"].ToString(),
                            QtParcelas = Convert.ToInt32(dr["QtParcelas"].ToString()),
                            Ativo = Convert.ToBoolean(dr["Ativo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaFormaPagamento;

                }
                catch (Exception ex)
                {
                    rptListaFormaPagamento = null;
                    return rptListaFormaPagamento;
                }
            }
        }

        public bool RegistrarFormaPagamento(FormaPagamento oFormaPagamento)
        {
            bool resposta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarFormaPagamento", oConexion);
                    cmd.Parameters.AddWithValue("Descricao", oFormaPagamento.Descricao);
                    cmd.Parameters.AddWithValue("QtParcelas", oFormaPagamento.QtParcelas);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resposta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    resposta = false;
                }
            }
            return resposta;
        }

        public bool ModificarFormaPagamento(FormaPagamento oFormaPagamento)
        {
            bool resposta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarFormaPagamento", oConexion);
                    cmd.Parameters.AddWithValue("IdFormaPagto", oFormaPagamento.IdFormaPagto);
                    cmd.Parameters.AddWithValue("Descricao", oFormaPagamento.Descricao);
                    cmd.Parameters.AddWithValue("QtParcelas", oFormaPagamento.QtParcelas);
                    cmd.Parameters.AddWithValue("Ativo", oFormaPagamento.Ativo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resposta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    resposta = false;
                }

            }

            return resposta;

        }

        public bool EliminarFormaPagamento(int IdFormaPagto)
        {
            bool resposta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarFormaPagamento", oConexion);
                    cmd.Parameters.AddWithValue("IdFormaPagto", IdFormaPagto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resposta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    resposta = false;
                }

            }

            return resposta;

        }
    }
}
