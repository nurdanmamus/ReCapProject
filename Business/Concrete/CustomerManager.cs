﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService 
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(); 
        }

        public IResult DeleteCustomer(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(); 
        }

        public IDataResult<List<Customer>> GetAllCustomers()
        { 
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetCustomerById(int customerId)  
        { 
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.UserId==customerId));
        }

        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(); 
        }
    }
}
