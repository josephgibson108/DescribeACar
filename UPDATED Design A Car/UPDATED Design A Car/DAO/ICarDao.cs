using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPDATED_Design_A_Car.Models;

namespace UPDATED_Design_A_Car.DAO
{
    public interface ICarDao
    {
        Car GetCar(int carId);
        Car CreateCar(Car car);
        Car UpdateCar(int carId, Car car);
        bool DeleteCar(int carId);
        List<Car> GetAllCars();

    }
}
