using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.BL.Repository;
using Demo.BL.Models;
using Demo.BL.Interface;
using AutoMapper;
using Demo.DAL.Entity;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentRep department;
        private readonly IMapper mapper;

        
        public DepartmentController(IDepartmentRep Department , IMapper mapper)
        {
            this.department = Department;
            this.mapper = mapper;
        }
        
        public IActionResult Index()
        {
            #region before AutoMapper
            //var data = department.Get();

            //return View(data);
            #endregion



            var data = department.Get();
            var model = mapper.Map<IEnumerable<DepartmentVM>>(data);
            return View(model);
        }

        //يعني بترجع صفحه مش بتعمل حاجه تاني بس انا بكتبها هنا عشان متلغبطش  get method هوا هنا تلقائي بيعرف ان دي 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /*post دى انا عاملها عشان يفهم ان الفورم هتروح لانهى اكشن عشان تسجل الداتا فيها المفروض بترح للاكشن الى من نوع  */
        //برضو وبكدا هوا هيعرف هيروح Postفراحت للفانكشن دى لان انا عالمها من نوع postفعشان الفورم الى انا عاملها من نوع 
        //من الاتنين الى ان عاملهم Create لانهى 
        [HttpPost]   
        public IActionResult Create(DepartmentVM model)
        {

            #region before AutoMapper
            //try
            //{
            //    if (ModelState.IsValid) /*دى معانا لو الداتا الى جايه تمام ضيف ولو الى جايه دى مش تمام رجع الصفحه تاني*/
            //    {
            //        department.Create(model);
            //        return RedirectToAction("Index");
            //    }

            //    return View(model);
            //}

            //catch (Exception ex)
            //{
            //    // الى انا ماليتها فاضيه inputs ميرجعش بالصفحه وال save انا هنا الموديل لان الداتا لو محصلهاش 
            //    //لا انا عايزها ترجع بنفس الداتا الى انا كنت كاتبها عشات تتحفظ
            //    return View(model);
            //}
            #endregion

            try
            {
                if (ModelState.IsValid) 
                {
                    var Data = mapper.Map<Department>(model);
                    department.Create(Data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }

            catch (Exception ex)
            {
                
                return View(model);
            }

        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            #region befor AutoMapper
            //var data = department.GetById(id);
            //return View(data);
            #endregion

            var data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            #region before AutoMapper
            //var Data = department.GetById(id);
            //return View(Data);
            #endregion

            var Data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(Data);
            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            #region before AutoMapper
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        department.Edit(model);
            //        return RedirectToAction("Index");

            //    }

            //    return View(model);

            //}
            //catch (Exception ex)
            //{

            //    return View(model);
            //}
            #endregion

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                    department.Edit(data);
                    return RedirectToAction("Index");

                }

                return View(model);

            }
            catch (Exception ex)
            {

                return View(model);
            }


        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            #region before AutoMapper
            //var Data = department.GetById(id);
            //return View(Data);
            #endregion
            var Data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(Data);
            return View(model);

        }

        [HttpPost]
        public IActionResult Delete(DepartmentVM model)
        {
            #region before AutoMapper
            //try
            //{
            //    department.Delete(model);
            //    return RedirectToAction("Index");

            //}
            //catch (Exception ex)
            //{
            //    return View(model);

            //}
            #endregion
            try
            {
                var data = mapper.Map<Department>(model);
                department.Delete(data);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(model);
               
            }
        }
    }
}
