using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Demo.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;
        private readonly IDistrictRep district;
        private readonly ICityRep city;

        public EmployeeController(IStringLocalizer<SharedResource> localizer , IEmployeeRep Employee , IDepartmentRep department , IMapper Mapper ,IDistrictRep District , ICityRep city)
        {
            this.localizer = localizer;
            employee = Employee;
            this.department = department;
            mapper = Mapper;
            district = District;
            this.city = city;
        }

        public IActionResult Index()
        {
            var data = employee.Get();
            var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.PhotoName = FileUploader.UploadFile("/wwwroot/Files/Imgs" , model.Photo);
                    model.CvName = FileUploader.UploadFile("/wwwroot/Files/Docs" , model.Cv);
                    var data = mapper.Map<Employee>(model);
                    employee.Create(data);
                    //TempData["x"] = localizer["DASHBOARD"];
                    return RedirectToAction("Index");
                }

                ViewBag.DepartmentList = new SelectList(department.Get(), "Id" , "Name");
                return View(model);
            }
            catch (Exception)
            {

                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
                return View(model);
            }
           
        }

       

        [HttpGet]
        public IActionResult Details(int id)
        {
            
                var data = employee.GetById(id);
                var model = mapper.Map<EmployeeVM>(data);
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);
                return View(model);

            
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
                var data = employee.GetById(id);
                var model = mapper.Map<EmployeeVM>(data);
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);
                return View(model);

        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM Employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<Employee>(Employee);
                    employee.Edit(model);
                    return RedirectToAction("Index");
                }
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", Employee.DepartmentId);
                return View();
                

            }
            catch (Exception)
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", Employee.DepartmentId);
                return View();
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var data = employee.GetById(id);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);
            return View(model);

        }

        [HttpPost]
        public IActionResult Delete(EmployeeVM Employee)
        {
            try
            {
                var model = mapper.Map<Employee>(Employee);
                FileUploader.RemoveFile("/wwwroot/Files/Docs/", model.CvName);
                FileUploader.RemoveFile("/wwwroot/Files/Imgs/", model.PhotoName);
                //employee.Delete(model); ==> دى كدا انا حذت الموظف من الداتابيز فلازم احذف
                //الفايلات الخاصه بيه عندى عل الجهاز برضو فبعمل الى فوقى دا
                employee.Delete(model);
                
                

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", Employee.DepartmentId);
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public JsonResult GetCityDataByCountryId(int CtryId)
        {
            var data = city.Get(a => a.CountryId == CtryId);
            var model = mapper.Map<IEnumerable<CityVM>>(data) ;
            return Json(model);
        }

        [HttpPost]
        public JsonResult GetDistrictDataByCityId(int CtyId)
        {
            var data = district.Get(a => a.CityId == CtyId);
            var model = mapper.Map<IEnumerable<DistrictVM>>(data);
            return Json(model);
        }


    }

}
