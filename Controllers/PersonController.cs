using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_web_app2.Models;

namespace todo_web_app2.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonContext _Db;

        public PersonController(PersonContext Db)
        {
            _Db = Db;
            
        }
        public IActionResult PersonList()
        {
            //var perList = _Db.tbl_Person.ToList();
            var perList = from a in _Db.tbl_Person
                          join b in _Db.tbl_Device
                          on a.dev_Id equals b.device_Id
                          into Dev
                          from b in Dev.DefaultIfEmpty()

                          select new Person
                          {
                              person_Id = a.person_Id,
                              person_Name = a.person_Name,
                              is_Active = a.is_Active,
                              dev_Id = a.dev_Id,
                              device_Name = b == null ? "Empty" :b.device_Name

                          };
            try
            {
                return View(perList);
            }
            catch(Exception ex)
            {
                /*return View();*/
                //Console.WriteLine(ex);

                return null;
            }


        }
        
        public IActionResult Create(Person obj)
        {
            loadDevice();
            return View(obj);
        }

        [HttpPost]
        public  async Task<IActionResult> AddPerson (Person obj)
        {

            try
            {
                if (obj.person_Id == 0)
                {
                    _Db.tbl_Person.Add(obj);
                    await _Db.SaveChangesAsync();
                   
                }
                else
                {
                    _Db.Entry(obj).State = EntityState.Modified;
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("PersonList");
               // return View();
                
            }
            catch(Exception ex)
            {
                return RedirectToAction("PersonList");
            }
        }

        private void loadDevice()
        {
            try
            {
                List<Devices> devices = new List<Devices>();
                devices = _Db.tbl_Device.ToList();

                devices.Insert(0, new Devices { device_Id = 0, device_Name = "Please Select" });

                ViewBag.DevList = devices;
            }
            catch(Exception ex)
            {
               
            }
        }

        public async Task<IActionResult> Delete_Person(int id)
        {
            try
            {
                var specific_Person =await _Db.tbl_Person.FindAsync(id);
               // await Console.Out.WriteLineAsync(+id);
                if (specific_Person!=null)
                {
                    _Db.tbl_Person.Remove(specific_Person);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("PersonList");
            }
            catch(Exception ex)
            {
                return RedirectToAction("PersonList");
            }
        }


    }
}
