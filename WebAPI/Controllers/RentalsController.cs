using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("addRental")] 
        public IActionResult AddRental(Rental rental)  
        {
            var result = _rentalService.AddRental(rental); 
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
