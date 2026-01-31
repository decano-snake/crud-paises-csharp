using CrudPaises.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CrudPaises.Data
{
    public class PaisRepository
    {
        private readonly string connectionString =
            "Server=DESKTOP-FG954PD\\SQLEXPRESS01;Database=CrudPaisesDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Inserir(Pais pais)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var sql = @"INSERT INTO Pais (nome_pais, populacao, area_total)
                        VALUES (@nome, @popula, @area)";

            using var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@nome", pais.Nome_pais);
            cmd.Parameters.AddWithValue("@popula", pais.Populacao);
            cmd.Parameters.AddWithValue("@area", pais.Area_total);

            cmd.ExecuteNonQuery();
        }

        public List<Pais> Listar()
        {
            var lista = new List<Pais>();

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var sql = @"SELECT codigo_pais, nome_pais, populacao, area_total
                        FROM Pais
                        ORDER BY codigo_pais";

            using var cmd = new SqlCommand(sql, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Pais
                {
                    Codigo_pais = reader.GetInt32(0),
                    Nome_pais = reader.GetString(1),
                    Populacao = reader.GetInt64(2),
                    Area_total = reader.GetDouble(3)
                });
            }

            return lista;
        }

        public Pais? BuscarPorCodigo(int codigo)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var sql = @"SELECT codigo_pais, nome_pais, populacao, area_total
                        FROM Pais
                        WHERE codigo_pais = @codigo";

            using var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@codigo", codigo);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Pais
            {
                Codigo_pais = reader.GetInt32(0),
                Nome_pais = reader.GetString(1),
                Populacao = reader.GetInt64(2),
                Area_total = reader.GetDouble(3)
            };
        }

        public bool Atualizar(Pais pais)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var sql = @"UPDATE Pais
                        SET nome_pais = @nome,
                            populacao = @popula,
                            area_total = @area
                        WHERE codigo_pais = @codigo";

            using var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@codigo", pais.Codigo_pais);
            cmd.Parameters.AddWithValue("@nome", pais.Nome_pais);
            cmd.Parameters.AddWithValue("@popula", pais.Populacao);
            cmd.Parameters.AddWithValue("@area", pais.Area_total);

            int linhas = cmd.ExecuteNonQuery();
            return linhas > 0;
        }

        public bool Excluir(int codigo)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var sql = @"DELETE FROM Pais WHERE codigo_pais = @codigo";

            using var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@codigo", codigo);

            int linhas = cmd.ExecuteNonQuery();
            return linhas > 0;
        }
    }
}