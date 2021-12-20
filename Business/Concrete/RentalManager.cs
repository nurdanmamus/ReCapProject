using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal; 

        public RentalManager(IRentalDal rentalDal)
        { 
            _rentalDal = rentalDal;
        }

        public IResult AddRental(Rental rental) 
        {
            if (rental.ReturnDate==null)
            {
                return new ErrorResult();
            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }
    }
}
