using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SpaApplication.MultiTenant.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApplication.MultiTenant.Web.Data
{
    public partial class ApplicationDbContext : MultiTenantDbContext
    {
        public ApplicationDbContext(ITenantInfo tenantInfo) : base(tenantInfo)
        {

        }

        private readonly TenantInfo _tenantInfo;
        public ApplicationDbContext(TenantInfo tenantInfo, DbContextOptions<ApplicationDbContext> options) : base(tenantInfo, options)
        {
            _tenantInfo = tenantInfo ?? throw new NullReferenceException(nameof(tenantInfo));
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrWhiteSpace(_tenantInfo.ConnectionString)) throw new NullReferenceException(nameof(_tenantInfo.ConnectionString));

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_tenantInfo.ConnectionString).EnableSensitiveDataLogging();
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }


        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            private static readonly string _designTimeConnectionString = $"Data Source=localhost; Initial Catalog=SpaApplication.MultiTenant.idsa.Core; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";

            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(_designTimeConnectionString);

                var t = new TenantInfo();
                t.Id = Guid.Empty.ToString();
                t.Identifier = Guid.Empty.ToString();
                t.Name = Guid.Empty.ToString();
                t.ConnectionString = _designTimeConnectionString;

                return new ApplicationDbContext(t,
                optionsBuilder.Options);
            }
        }
    }
}
