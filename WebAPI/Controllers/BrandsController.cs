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
    public class BrandsController : ControllerBase
    {
        //Loosely coupled 
        //naming convention 
        //IoC controller, Inversion of Control  
        IBrandService _brandService; 

        public BrandsController(IBrandService brandService)
        { 
            _brandService = brandService;
        }

        [HttpGet("GetAllBrands")]  
        public IActionResult GetAllBrands() 
        {
            var result = _brandService.GetAllBrands();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetBrandById")]  
        public IActionResult GetBrandById(int brandId)
        {
            var result = _brandService.GetBrandById(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addBrand")]  
        public IActionResult AddBrand(Brand brand) 
        {
            var result = _brandService.AddBrand(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }

        [HttpPost("updateBrand")] 
        public IActionResult UpdateBrand(Brand brand)
        {
            var result = _brandService.UpdateBrand(brand);
            if (result.Success)
            {
                return Ok(result);  
            }
            return BadRequest(result);
        }
        [HttpPost("deleteBrand")]
        public IActionResult DeleteBrand(Brand brand)
        {
            var result = _brandService.DeleteBrand(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }
    }
}
