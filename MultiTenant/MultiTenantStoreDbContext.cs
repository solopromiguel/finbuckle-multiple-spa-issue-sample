using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using SpaApplication.MultiTenant.Web.MultiTenant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApplication.MultiTenant.Web.MultiTenant
{
    public class MultiTenantStoreDbContext : EFCoreStoreDbContext<ClientTenantInfo>
    {
        public MultiTenantStoreDbContext(DbContextOptions<MultiTenantStoreDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClientTenantInfo> ClientTenantInfos { get; set; }
    }
}
