using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationwithidenty.Data;
using WebApplicationwithidenty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplicationwithidenty.Controllers
{
    public class StudentsController : Controller
    {
        Data.ApplicationDbContext db;
        public StudentsController(Data.ApplicationDbContext Db)
        {
            db = Db;
            RoleManager<ApplicationRole> _roleManager = new RoleManager<ApplicationRole>(
      new RoleStore<ApplicationRole>( db));
        }
       

        UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));

        //ApplicationDbContext _db = new ApplicationDbContext();


        //public  Task<IApplicationRole>  bool RoleExists(string name)
        //{
        //    return await _roleManager.RoleExistsAsync(name);
        //}


        //public async Task<IActionResult>   CreateRole(string name, string description = "")
        //{
        //    var user = new ApplicationUser { UserName = "", Email =""};
        //    var role = new ApplicationRole { Name = name   };
        //    // Swap ApplicationRole for IdentityRole:
        //    var idResult = await _roleManager.CreateAsync(role);
        //    return idResult.Succeeded;
        //}


        public bool CreateUser(ApplicationUser user, string password)
        {
            var idResult = _userManager.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userId, string roleName)
        {
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userId)
        {
            var user = _userManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();

            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                _userManager.RemoveFromRole(userId, role.Role.Name);
            }
        }

        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            IEnumerable< Students> litStudents=  from a in _context.Students.AsEnumerable() select a ;
            return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.SingleOrDefaultAsync(m => m.StudentsID == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentsID,StudentName")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.SingleOrDefaultAsync(m => m.StudentsID == id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentsID,StudentName")] Students students)
        {
            if (id != students.StudentsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.StudentsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.SingleOrDefaultAsync(m => m.StudentsID == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.Students.SingleOrDefaultAsync(m => m.StudentsID == id);
            _context.Students.Remove(students);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.StudentsID == id);
        }
    }
}
