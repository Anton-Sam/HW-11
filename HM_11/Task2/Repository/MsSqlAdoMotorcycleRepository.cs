using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Task2.Models;

namespace Task2.Repository
{
    class MsSqlAdoMotorcycleRepository : IMotorcycleRepository
    {
        private readonly SqlConnection _connection;
        public MsSqlAdoMotorcycleRepository()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MotorcycleDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public void CreateMotorcycle(Motorcycle moto)
        {
            string sqlExpression = $"INSERT INTO Motorcycles (Id,Name,Model,Year,Odometre) VALUES ('{moto.Id}', '{moto.Name}','{moto.Model}','{moto.Year}','{moto.Odometre}')";
            SqlCommand command = new SqlCommand(sqlExpression, _connection);
            command.ExecuteNonQuery();
        }

        public void DeleteMotorcycle(Motorcycle moto)
        {
            string sqlExpression = $"DELETE FROM Motorcycles WHERE Id='{moto.Id}'";
            SqlCommand command = new SqlCommand(sqlExpression, _connection);
            command.ExecuteNonQuery();
        }

        public Motorcycle GetMotorcycleById(Guid id)
        {
            string sqlExpression = $"SELECT * FROM Motorcycles WHERE Id='{id}'";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return new Motorcycle
                {
                    Id = (Guid)dt.Rows[0]["Id"],
                    Name = (string)dt.Rows[0]["Name"],
                    Model = (string)dt.Rows[0]["Model"],
                    Year = (DateTime)dt.Rows[0]["Year"],
                    Odometre = (int)dt.Rows[0]["Odometre"]
                };
            }
            return null;
        }

        public IEnumerable<Motorcycle> GetMotorcycles()
        {
            string sqlExpression = "SELECT * FROM Motorcycles";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, _connection);
            DataTable dt = new DataTable();

            var resultList = new List<Motorcycle>();
            adapter.Fill(dt);
            for (var i=0;i<dt.Rows.Count;i++)
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
            return resultList;
        }

        public void UpdateMotorcycle(Motorcycle moto)
        {
            string sqlExpression = $"UPDATE Motorcycles SET Name='{moto.Name}',Model='{moto.Model}',Year='{moto.Year}',Odometre='{moto.Odometre}' WHERE Id='{moto.Id}'";
            SqlCommand command = new SqlCommand(sqlExpression, _connection);
            command.ExecuteNonQuery();
        }
    }
}
