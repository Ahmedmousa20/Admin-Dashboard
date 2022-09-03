using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.APIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRep employee , IMapper mapper)
        {
            this.employee = employee;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("~/Api/GetEmployees")]
        public IActionResult GetEmployees()
        {
            //string[] Arr = {"Ahmed", "Ali"};
            //return Arr;
            try
            {
                var data = employee.Get();
                var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return Ok(new ApiResponse<IEnumerable<EmployeeVM>>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrieved",
                    Data = model
                });

            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message
                });
            }
        }


        [HttpGet]
        [Route("~/Api/GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            //string[] Arr = {"Ahmed", "Ali"};
            //return Arr;
            try
            {
                var data = employee.GetById(id);
                var model = mapper.Map<EmployeeVM>(data);
                return Ok(new ApiResponse<EmployeeVM>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrieved",
                    Data = model
                });

            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("~/Api/AddEmployee")]
        public IActionResult AddEmployee(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    employee.Create(data);
                    return Ok(new ApiResponse<EmployeeVM>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Created",
                        Data = model
                    });
                }
                return Ok(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Not Valid",
                    Message = "Data Invalid"
                });

            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Created",
                    Error = ex.Message
                });
            }
        }

    }
}
