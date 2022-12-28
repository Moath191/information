using information.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics;
using System.Net.Cache;

namespace information.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainXController : ControllerBase
    {
        private readonly ILogger<MainXController> _logger;
        private readonly MyDB db;
// /home/ageeb/dotnet/dotnet
        public MainXController(ILogger<MainXController> logger, MyDB _db)
        {
            _logger = logger;
            db = _db;
        }

        /// <summary>
        /// This Get Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> get(int? id = null)
        {
            try
            {
                if (id != null)
                {

                    var obj = await db.Stores.FirstOrDefaultAsync(e => e.Id == id);
                    //            var obj = Reg.Detalis_Sort(id.Value);
                    if (obj == null) return NotFound();
                    return Ok(obj);
                }
                else
                if (id == null)
                {
                    // var list = Reg.GetList();
                    var list = await db.Stores.ToListAsync();
                    return Ok(list);
                }
            }
            catch (Exception ex) {await Reg.CreateErr("MainX.get",db,ex); }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Store obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Please fill in the blanks");
                }
                // var s = Reg.Create_Sort(obj);
                db.Stores.Add(obj);
                await db.SaveChangesAsync();
                return Ok(obj);
            }
            catch (Exception ex)            {await Reg.CreateErr("MainX.Create",db,ex);            }
            return BadRequest();

        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Store obj)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Please fill in the blanks");
                }

                // var s = Reg.Update_Sort(id, obj);

                var s = await db.Stores.FirstOrDefaultAsync(e => e.Id == id);
                if (s != null)
                {
                    s.Name = obj.Name;
                    s.FamilyName = obj.FamilyName;
                    s.Address = obj.Address;
                    db.Entry<Store>(s).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Ok(s);

                }
                return NotFound();


            }
            catch (Exception ex)            {await Reg.CreateErr("MainX.Update",db,ex);            }
            return BadRequest();
        }

        [HttpDelete]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please fill in the blanks");
            }
            try
            {
                var obj = await db.Stores.FirstOrDefaultAsync(e => e.Id == id);
                if(obj!=null){
                    db.Stores.Remove(obj);
                    await db.SaveChangesAsync();
                return Ok(true);
                }


            }
            catch (Exception ex)            {await Reg.CreateErr("MainX.Delete",db,ex);            }
            return Ok(false);
        }
    }
}