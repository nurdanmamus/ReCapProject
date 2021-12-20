using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager: IBrandService  
    {
        IBrandDal _iBrandDal;

        public BrandManager(IBrandDal iBrandDal) 
        {
            _iBrandDal = iBrandDal; 
        }

        public IResult AddBrand(Brand brand) 
        {
            _iBrandDal.Add(brand);
            return new SuccessResult();  
        }

        public IResult DeleteBrand(Brand brand)
        {
            _iBrandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAllBrands()
        {
            return new SuccessDataResult<List<Brand>>(_iBrandDal.GetAll().ToList());   
        }

        public IDataResult<Brand> GetBrandById(int id)  
        {
            return new SuccessDataResult<Brand>(_iBrandDal.Get(b => b.Id == id));
        }

        public IResult UpdateBrand(Brand brand)
        {
            _iBrandDal.Update(brand);
            return new SuccessResult(); 
        }
    }
}
