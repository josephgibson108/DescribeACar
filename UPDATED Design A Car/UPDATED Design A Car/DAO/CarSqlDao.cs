using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPDATED_Design_A_Car.Models;
using System.Data.SqlClient;

// Added methods for getting, creating, updating, and deleting cars from the car database

namespace UPDATED_Design_A_Car.DAO
{
    public class CarSqlDao : ICarDao
    {
        private readonly string connectionString;
        public CarSqlDao(string connString)
        {
            connectionString = connString;
        }

        public List<Car> GetAllCars()
        {
            List<Car> carsList = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM CarDetails", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    carsList = new List<Car>();
                    while (reader.Read())
                    {
                        carsList.Add(CreateCarFromReader(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            

            return carsList;
        }
        // get car from the database
        public Car GetCar(int carId)
        {
            // establish the SQL connection
            Car car = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM CarDetails WHERE car_id = @car_id;", conn);
                cmd.Parameters.AddWithValue("@car_id", carId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    car = CreateCarFromReader(reader); // create a car object from the information passed in by the database
                }
            }

            return car;
        }

        public Car CreateCar(Car car)
        {
            int newCarId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO CarDetails (Make, Model, Year, URL) " +
                                                "OUTPUT INSERTED.car_id " +
                                                "VALUES (@make, @model, @year, @url);", conn);
                cmd.Parameters.AddWithValue("@make", car.Make);
                cmd.Parameters.AddWithValue("@model", car.Model);
                cmd.Parameters.AddWithValue("@year", car.Year);
                cmd.Parameters.AddWithValue("@url", car.URL);

                newCarId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return GetCar(newCarId);
        }
        
        public Car UpdateCar(int carId, Car car)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE CarDetails " +
                                                "SET Make = @make, Model = @model, Year = @year, URL = @url " +
                                                "WHERE car_id = @car_id;", conn);
                cmd.Parameters.AddWithValue("@make", car.Make);
                cmd.Parameters.AddWithValue("@model", car.Model);
                cmd.Parameters.AddWithValue("@year", car.Year);
                cmd.Parameters.AddWithValue("@url", car.URL);
                cmd.Parameters.AddWithValue("@car_id", carId);

                cmd.ExecuteNonQuery();
            }

            Car checkCar = GetCar(carId);
            
            
            return checkCar;
        }

        public bool DeleteCar(int carId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM CarDetails WHERE car_id = @car_id;", conn);
                cmd.Parameters.AddWithValue("@car_id", carId);

                cmd.ExecuteNonQuery();
            }

            // If there is still information at the location of this car, it was not deleted properly
            if (GetCar(carId) != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private Car CreateCarFromReader(SqlDataReader reader)
        {
            Car car = new Car();
            car.CarId = Convert.ToInt32(reader["car_id"]);
            car.Make = Convert.ToString(reader["Make"]);
            car.Model = Convert.ToString(reader["Model"]);
            car.Year = Convert.ToInt32(reader["Year"]);
            car.URL = Convert.ToString(reader["URL"]);

            return car;
        }
    }
}
