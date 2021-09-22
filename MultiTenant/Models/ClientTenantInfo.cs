using Finbuckle.MultiTenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApplication.MultiTenant.Web.MultiTenant.Models
{
    public class ClientTenantInfo : TenantInfo
    {
        public string Number { get; set; }
    }
}
