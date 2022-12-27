using information.Models;
using Microsoft.AspNetCore.Mvc;
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

        public MainXController(ILogger<MainXController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This Get Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult get(int? id = null)
        {
            try
            {
                if (id != null)
                {

                    var obj = Reg.Detalis_Sort(id.Value);
                    if (obj == null) return NotFound();
                    return Ok(obj);
                }
                else
                if (id == null)
                {
                    var list = Reg.GetList();
                    return Ok(list);
                }
            }
            catch { }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Create(Store obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("ارجو تعبئة الفراغات");
                }
                var s = Reg.Create_Sort(obj);
                return Ok(s);
            }
            catch
            {

            }
            return BadRequest();

        }

        [HttpPut]
        public IActionResult Update(int id, Store obj)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("ارجو تعبئة الفراغات");
                }

                var s = Reg.Update_Sort(id, obj);
                return Ok(s);


            }
            catch
            {

            }
            return BadRequest();
        }

        [HttpDelete]
        // [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("ارجو تعبئة الفراغات");
            }
            try
            {
                return Ok(Reg.Delete_Sort(id));

            }
            catch
            {

            }
            return BadRequest();
        }
    }
}