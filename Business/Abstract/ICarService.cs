using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService 
    {
        IDataResult<List<Car>> GetAllCars();
        IDataResult<Car> GetCarById(int id);
        IResult AddCar(Car car);
        IResult UpdateCar(Car car); 
        IResult DeleteCar(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id); 
        IDataResult<List<CarDetailDto>> GetCarDetails(); 
    }
}
