using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.BL.Repository
{
    public class DapartmentRep: IDepartmentRep
    {
        //DemoContext db = new DemoContext();
        private readonly DemoContext db;
        public DapartmentRep(DemoContext db)
        {
            this.db = db;
        }

        public IEnumerable<Department> Get()
        {
            //before AutoMapper
            //var data = db.Department.Select(a => new DepartmentVM
            //{
            //    Id = a.Id,
            //    Name=a.Name,
            //    Code=a.Code
            //});

            //return data;

            return db.Department.Select(a => a);
        }

        public Department GetById(int id)
        {
            //before AutoMapper
            //var data = db.Department.Where(a => a.Id == id).Select(a => new DepartmentVM
            //{
            //    Id = a.Id,
            //    Name = a.Name,
            //    Code = a.Code
            //}).FirstOrDefault();

            //return data;

            var data = db.Department.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
        
        public void Create(Department obj)
        {
            //before AutoMapper
            //Department d = new Department();

            //d.Name = obj.Name;
            //d.Code = obj.Code;

            //db.Department.Add(d);
            //db.SaveChanges();

            db.Department.Add(obj);
            db.SaveChanges();
        }

        public void Edit(Department obj)
        {
            //before AutoMapper
            //var OldData = db.Department.Find(obj.Id);

            //Department d = new Department();
            //OldData.Name = obj.Name;
            //OldData.Code = obj.Code;
            //db.SaveChanges();

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(Department obj)
        {
            //before AutoMapper
            //var OldData = db.Department.Find(obj.Id);
            //db.Department.Remove(OldData);
            //db.SaveChanges();

            db.Department.Remove(obj);
            db.SaveChanges();


        }





    }
}
