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
    public class ColorManager:IColorService   
    {
        IColorDal _iColorDal; 

        public ColorManager(IColorDal iColorDal)
        { 
            _iColorDal = iColorDal; 
        }

        public IResult AddColor(Color color)
        {
            _iColorDal.Add(color);
            return new SuccessResult();
        }

        public IResult DeleteColor(Color color)
        {
            _iColorDal.Delete(color);
            return new SuccessResult(); 
        }

        public IDataResult<List<Color>> GetAllColors() 
        {
            return new SuccessDataResult<List<Color>>(_iColorDal.GetAll().ToList());
        }

        public IDataResult<Color> GetColorById(int id)
        {
            return new SuccessDataResult<Color>(_iColorDal.Get(c => c.Id == id));  
        }

        public IResult UpdateColor(Color color)
        {
            _iColorDal.Update(color);
            return new SuccessResult();
        }
    }
}
