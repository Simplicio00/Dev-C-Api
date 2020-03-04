using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        // private string stringConexao = "Data Source=DEV301\\SQLEXPRESS; initial catalog=Inlock_Games_Manha; user Id=sa; pwd=sa@132";
        private string stringConexao = "Data Source=DEV101\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        public JogosDomain BuscarPorId(int id)
        {
            string query = $"SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Estudios.IdEstudio, NomeEstudio FROM Jogos " +
                $"INNER JOIN Estudios on Estudios.IdEstudio = Jogos.IdEstudio" +
                $" where IdJogo like {id}";
            SqlConnection connection = new SqlConnection(stringConexao);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader leitor = command.ExecuteReader();
            if (leitor.Read())
            {
                JogosDomain jogo = new JogosDomain
                {
                    IdJogo = Convert.ToInt32(leitor[0]),
                    NomeJogo = Convert.ToString(leitor[1]),
                    Descricao = Convert.ToString(leitor[2]),
                    DataLancamento = Convert.ToDateTime(leitor[3]),
                    Valor = Convert.ToString(leitor[4]),
                    IdEstudio = Convert.ToInt32(leitor[5]),
                    Estudios = new EstudiosDomain
                    {
                        IdEstudio = Convert.ToInt32(leitor[5]),
                        NomeEstudio = Convert.ToString(leitor[6])
                    }
                };
                return jogo;
            }
            connection.Close();
            return null;
        }

        public JogosDomain Delete(int id)
        {
            SqlConnection connection = new SqlConnection(stringConexao);
            string query = $"delete from Jogos where IdJogo like {id}";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return null;
        }

        public List<JogosDomain> Get()
        {

            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Estudios.IdEstudio, NomeEstudio FROM Jogos " +
                                        "INNER JOIN Estudios on Estudios.IdEstudio = Jogos.IdEstudio ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            NomeJogo = rdr[1].ToString(),
                            Descricao = rdr[2].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[3]),
                            Valor = rdr[4].ToString(),

                            IdEstudio = Convert.ToInt32(rdr[5]),
                            Estudios = new EstudiosDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr[5]),
                                NomeEstudio = rdr[6].ToString()
                            }
                        };
                        jogos.Add(jogo);
                    }
                }
            }
            return jogos;
        }

        public void Post(JogosDomain jogos)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(NomeJogo ,Descricao, DataLancamento, Valor, IdEstudio) VALUES (@N, @D, @Dt, @V, @ID)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@N", jogos.NomeJogo);
                cmd.Parameters.AddWithValue("@D", jogos.Descricao);
                cmd.Parameters.AddWithValue("@Dt", jogos.DataLancamento);
                cmd.Parameters.AddWithValue("@V", jogos.Valor);
                cmd.Parameters.AddWithValue("@ID", jogos.IdEstudio);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

    }
}
