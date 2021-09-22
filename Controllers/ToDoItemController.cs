using Microsoft.AspNetCore.Mvc;
using SpaApplication.MultiTenant.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApplication.MultiTenant.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ToDoItemController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _db.ToDoItems.ToList();
            return Ok(data);
        }
    }
}
