using Microsoft.Data.SqlClient;
using ProjetoMVC.Models;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.Arm;

namespace ProjetoMVC.Classes
{
    public class UpdateEquipes()
    {
        public string AtualizaDadosEquipes(int IdEquipe, List<string> list)
        {
            var buscaEquipe = new EquipesModel();
            var connectionString = "Data Source=Note-JP;Initial Catalog=Formula1;User ID=sa;Password=toppen;Trust Server Certificate=True";

            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                using var cmd = new SqlCommand("SP_Update_DadosEquipesViaWikipedia", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Adicionar parâmetros
                cmd.Parameters.AddWithValue("@IdEquipe", IdEquipe);
                cmd.Parameters.AddWithValue("@GrandesPremios", list[0]);
                cmd.Parameters.AddWithValue("@TitulosConstrutores", list[1]);
                cmd.Parameters.AddWithValue("@TitulosPilotos", list[2]);
                cmd.Parameters.AddWithValue("@Vitorias", list[3]);
                cmd.Parameters.AddWithValue("@Podios", list[4]);
                cmd.Parameters.AddWithValue("@PolePosition", list[5]);
                cmd.Parameters.AddWithValue("@VoltasRapidas", list[6]);
                // Executar o comando
                cmd.ExecuteNonQuery();
                return "Dados atualizados com sucesso.";
            }
            catch (Exception ex)
            {
                // Logar o erro conforme necessário
                return $"Erro ao atualizar dados: {ex.Message}";
            }
        }
    }
}
