using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace WebApplication3.Services
{
    public class DatabaseService : IDatabaseService
    {
        private IConfiguration _configuration;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddAnimal(Animal animal)
        {
            string index = null;

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT MAX(IdAnimal) FROM Animal";
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                index = Convert.ToString(dr[0]);
            }
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "INSERT INTO Animal VALUES (@IdAnimal, @Name, @Description, @Category, @Area)";
                com.Parameters.AddWithValue("@IdAnimal", Int32.Parse(index) + 1);
                com.Parameters.AddWithValue("@Name", animal.Name);
                com.Parameters.AddWithValue("@Description", animal.Description);
                com.Parameters.AddWithValue("@Category", animal.Category);
                com.Parameters.AddWithValue("@Area", animal.Area);
                con.Open();
                com.ExecuteNonQuery();

            }

        }

        public void DeleteAnimal(int index)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "DELETE FROM Animal WHERE IdAnimal = @id";
                com.Parameters.AddWithValue("@id", index);
                con.Open();
                com.ExecuteNonQuery();

            }
        }

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            var res = new List<Animal>();
            if (orderBy == null)
            {
                orderBy = "Name";
            }

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Animal ORDER BY " + orderBy + " ASC ";
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    res.Add(new Animal
                    {
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    });
                }
            }

            return res;
        }

        public void UpdateAnimal(int index, Animal animal)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "UPDATE Animal SET Name = @Name, Description = @Description, " +
                    "Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";
                com.Parameters.AddWithValue("@IdAnimal", index);
                com.Parameters.AddWithValue("@Name", animal.Name);
                com.Parameters.AddWithValue("@Description", animal.Description);
                com.Parameters.AddWithValue("@Category", animal.Category);
                com.Parameters.AddWithValue("@Area", animal.Area);
                con.Open();
                com.ExecuteNonQuery();
            }
        }

        public bool ValidateValue(string value)
        {
            if (value == "name" || value == "description" || value == "category" || value == "area" || value == null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
