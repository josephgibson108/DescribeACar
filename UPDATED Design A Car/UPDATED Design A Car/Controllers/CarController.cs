using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPDATED_Design_A_Car.DAO;
using UPDATED_Design_A_Car.Models;

namespace UPDATED_Design_A_Car.Controllers
{
    [Route("car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarDao carDao;
        public CarController(ICarDao carDao)
        {
            this.carDao = carDao;
        }

        [HttpGet()]
        public ActionResult<List<Car>> GetAllCars()
        {
            List<Car> allCars = carDao.GetAllCars();

            // null, empty list, or full list
            if (allCars == null)
            {
                return StatusCode(500);
            }
            else if (allCars.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return allCars;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Car> RetrieveCar(int id)
        {
            Car car = carDao.GetCar(id);

            if (car != null)
            {
                return car;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]
        public ActionResult<Car> AddCar(Car car)
        {
            Car added = carDao.CreateCar(car);
            return Created($"/car/{added.CarId}", added);
        }

        [HttpPut("{id}")]
        public ActionResult<Car> UpdateExistingCar(int id, Car car)
        {
            Car existingCar = carDao.GetCar(id);
            if (existingCar == null) // if the car does not exist
            {
                return NotFound();
            }

            Car updatedCar = carDao.UpdateCar(id, car);

            return updatedCar;
        }

        [HttpDelete("{id}")] // /car/:id
        public ActionResult DeleteCarFromDB(int id)
        {
            Car existingCar = carDao.GetCar(id);

            if (existingCar == null)
            {
                return NotFound();
            }

            bool result = carDao.DeleteCar(id);

            if (result)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
