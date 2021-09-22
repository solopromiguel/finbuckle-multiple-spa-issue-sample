using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Mvc;
using SpaApplication.MultiTenant.Web.MultiTenant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApplication.MultiTenant.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMultiTenantStore<ClientTenantInfo> _multiTenantStore;
        public HomeController(IMultiTenantStore<ClientTenantInfo> multiTenantStore)
        {
            _multiTenantStore = multiTenantStore;
        }

        [HttpGet("getAllTenants")]
        public async Task<IActionResult> getAllTenants(string returnUrl = null)
        {
            var tenants = await _multiTenantStore.GetAllAsync();
            return Ok(tenants);            
        }
    }
}
