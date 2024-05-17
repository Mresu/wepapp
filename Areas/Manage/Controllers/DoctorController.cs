using Medico.DAL;
using Medico.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using System.Numerics;

namespace Medico.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DoctorController : Controller
    {
        private AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public DoctorController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
       
        public IActionResult Index()
        {
            return View(_context.doctors.ToList());
        }
         public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctors doctor)
        {
            if(doctor == null)
            {
                return View();
            }
            string path = _environment.WebRootPath + @"\limon\doctorlimon\";
            string filename = doctor.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                doctor.ImgFile.CopyTo(stream);
            }

            doctor.iMGuRL = path;

            _context.doctors.Add(doctor);
            _context.SaveChanges();
            return RedirectToAction("Index");   


        }
        public IActionResult Update(int id)
        {
            Doctors doctors = _context.doctors.FirstOrDefault(X => X.Id == id);
            if(doctors==null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(Doctors newdoctors)
        {
            var olddoctor = _context.doctors.FirstOrDefault(X => X.Id == newdoctors.Id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            string path = _environment.WebRootPath + @"\limon\doctorlimon\";
            FileInfo fileinfo = new FileInfo(path);
            if (fileinfo.Exists)
            {
                fileinfo.Delete();
            }
            if (newdoctors.ImgFile != null)
            {
                string filename = Guid.NewGuid() + newdoctors.ImgFile.FileName;
                using (FileStream stream = new FileStream(path + filename, FileMode.Create))
                {
                    newdoctors.ImgFile.CopyTo(stream);
                }
                newdoctors.ImgUrl = filename;
            }
            olddoctor.FullName = newdoctors.FullName;
            olddoctor.Position = newdoctors.Position;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
    
}
