using CrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            _context = context;
        }
        public IActionResult StudentList()
        {
            try
            {
                // We need to display data from Student and Departments both tables so we will use Join using LINQ query to display data.

                var studList = from a in _context.tbl_Student
                               join b in _context.tbl_Departments
                               on a.DeptID equals b.Id
                               into Dept
                               from b in Dept.DefaultIfEmpty()

                               select new Student
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Fname = a.Fname,
                                   Email = a.Email,
                                   Description = a.Description,
                                   Mobile = a.Mobile,
                                   DeptID = a.DeptID,
                                   Department = (b == null ? "" : b.Department)
                               };

                return View(studList);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return View();
            }
        }

        public IActionResult Create(int? id, string name, string fname, string email, string mobile, string description, int deptID)
        {
            var obj = new Student
            {
                Id = id,
                Name = name,
                Fname = fname,
                Email = email,
                Mobile = mobile,
                Description = description,
                DeptID = deptID
            };
            LoadDepartments();
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditStudent(Student obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(obj.Id == 0) // Checks weather it is new insertion or update operation. If Id = 0 then it is INsertion else Updation.
                    {
                        await _context.tbl_Student.AddAsync(obj);
                        _context.SaveChanges();
                        TempData["SuccessMessage"] = "Student added successfully.";
                    }
                    else
                    {
                        _context.tbl_Student.Update(obj);
                        _context.SaveChanges();
                        TempData["SuccessMessage"] = "Student updated successfully.";
                    }
                }
                return RedirectToAction("StudentList");
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        public void LoadDepartments()
        {
            try
            {
                var deptList = new List<Departments>();
                deptList = _context.tbl_Departments.ToList();
                deptList.Insert(0, new Departments { Id = 0, Department = "Please select"}); // Default 0th value for Dropdown

                ViewBag.DeptList = deptList;
            }
            catch(Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var record = new Student();
                record = await _context.tbl_Student.FindAsync(Id);
                if(record!=null)
                {
                    _context.tbl_Student.Remove(record);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Student deleted successfully.";
                }
                return RedirectToAction("StudentList", record);
            }
            catch(Exception e)
            {
                Console.Write(e);
                throw;
            }
        }
    }
}