using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Task2.Models;

namespace Task2.Repository
{
    class MsSqlAdoMotorcycleRepository : IMotorcycleRepository
    {
        private readonly SqlConnection _connection;
        public MsSqlAdoMotorcycleRepository()
        {
            try
            {
                var connectionString= ConfigurationManager.ConnectionStrings["LocalDBConnectionString"].ConnectionString;
                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                Environment.Exit(1);
            }
        }

        public void CreateMotorcycle(Motorcycle moto)
        {
            string sqlExpression = $"INSERT INTO Motorcycles (Id,Name,Model,Year,Odometre) VALUES ('{moto.Id}', '{moto.Name}','{moto.Model}','{moto.Year}','{moto.Odometre}')";
            GetSqlCommand(sqlExpression).ExecuteNonQuery();
            Log.Information($"{moto} created");
        }

        public void DeleteMotorcycle(Motorcycle moto)
        {
            string sqlExpression = $"DELETE FROM Motorcycles WHERE Id='{moto.Id}'";
            GetSqlCommand(sqlExpression).ExecuteNonQuery();
            Log.Information($"{moto} deleted");

        }

        public Motorcycle GetMotorcycleById(Guid id)
        {
            string sqlExpression = $"SELECT * FROM Motorcycles WHERE Id='{id}'";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, _connection);
            DataTable dt = new DataTable();
            Motorcycle moto = null;
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                moto = new Motorcycle
                {
                    Id = (Guid)dt.Rows[0]["Id"],
                    Name = (string)dt.Rows[0]["Name"],
                    Model = (string)dt.Rows[0]["Model"],
                    Year = (DateTime)dt.Rows[0]["Year"],
                    Odometre = (int)dt.Rows[0]["Odometre"]
                };
            }
            Log.Information($"{moto} got by id");
            return moto;
        }

        public IEnumerable<Motorcycle> GetMotorcycles()
        {
            string sqlExpression = "SELECT * FROM Motorcycles";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, _connection);
            DataTable dt = new DataTable();

            var resultList = new List<Motorcycle>();
            adapter.Fill(dt);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var moto = new Motorcycle
                {
                    Id = (Guid)dt.Rows[i]["Id"],
                    Name = (string)dt.Rows[i]["Name"],
                    Model = (string)dt.Rows[i]["Model"],
                    Year = (DateTime)dt.Rows[i]["Year"],
                    Odometre = (int)dt.Rows[i]["Odometre"]
                };
                resultList.Add(moto);
            }
            Log.Information($"All motorcycles got");
            return resultList;
        }

        public void UpdateMotorcycle(Motorcycle moto)
        {
            string sqlExpression = $"UPDATE Motorcycles SET Name='{moto.Name}',Model='{moto.Model}',Year='{moto.Year}',Odometre='{moto.Odometre}' WHERE Id='{moto.Id}'";
            GetSqlCommand(sqlExpression).ExecuteNonQuery();
            Log.Information($"{moto} updated");
        }

        private SqlCommand GetSqlCommand(string expr) => new SqlCommand(expr, _connection);
    }
}
