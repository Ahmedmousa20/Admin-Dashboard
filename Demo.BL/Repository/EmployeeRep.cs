using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BL.Interface;

namespace Demo.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DemoContext db;

        public EmployeeRep(DemoContext db)
        {
            this.db = db;
        }

        public IEnumerable<Employee> Get()
        {
            var data = GetEmployee();
            return data;
        }

        public Employee GetById(int id)
        {
            var data = db.Employee.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public void Create(Employee obj)
        {
            db.Employee.Add(obj);
            db.SaveChanges();
        }


        public void Edit(Employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void Delete(Employee obj)
        {
            db.Employee.Remove(obj);
            db.SaveChanges();
        }






        // ============================= Refactor ============================
        private IEnumerable<Employee> GetEmployee()
        {
            return db.Employee.Include("Department").Select(a => a);
            //Include()=> دى لازم اعملها لما اكون عايز اجيب داتا من جدول مرتبط مع جدول تاني
            //employeeالى انا ربطت الجدول دا بيه الى هوا المفروض هنا ف ال forgienKey وبكتب فيها ال 
            //ورا بعض عادى Include ممكن اعمل اكتر من 
        }
    }
}
