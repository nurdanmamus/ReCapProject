using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService 
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal; 
        }

        [SecuredOperation("product.add,admin")] 
        [ValidationAspect(typeof(CarValidator))]  
        public IResult AddCar(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _iCarDal.Add(car);
            return new SuccessResult(); 
        }

        public IResult DeleteCar(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAllCars() 
        {
           return new SuccessDataResult<List<Car>>(_iCarDal.GetAll().ToList()); 
        }

        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c => c.Id == id)); 
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()   
        {
            return new SuccessDataResult<List<CarDetailDto>>( _iCarDal.GetCarDetails());  
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id) 
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.ColorId == id));
        }

        public IResult UpdateCar(Car car) 
        {
           _iCarDal.Update(car);
            return new SuccessResult(); 
        }
    }
}
