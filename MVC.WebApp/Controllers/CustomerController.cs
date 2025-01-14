﻿using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.WebApp.Models;

namespace MVC.WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetData());
        }



        [HttpPost]
        public IActionResult Create([FromBody] CustomerUpsertDto CustomerDto)
        {
            var customer = new Customer
            {
                CompanyName = CustomerDto.CompanyName,
                Country = CustomerDto.Country,
            };

            var resultcustomer = _repository.Create(customer);

            if (resultcustomer is not null)
            {
                return Created($"baseurl", resultcustomer.CustomerID);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update([FromBody] CustomerUpsertDto CustomerDto)
        {
            var customer = new Customer
            {
                CustomerID=CustomerDto.CustomerID,
                CompanyName = CustomerDto.CompanyName,
                Country = CustomerDto.Country,
            };

            var resultcustomer = _repository.Create(customer);

            if (resultcustomer is not null)
            {
                return Created($"baseurl", resultcustomer.CustomerID);
            }
            return BadRequest();
        }
    }
}
