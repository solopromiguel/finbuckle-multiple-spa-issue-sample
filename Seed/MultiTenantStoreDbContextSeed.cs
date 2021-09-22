using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SpaApplication.MultiTenant.Web.Data;
using SpaApplication.MultiTenant.Web.MultiTenant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApplication.MultiTenant.Web.Seed
{
    public static class MultiTenantStoreDbContextSeed
    {
        public static async void SeedDataBaseMultitenantIsSeeded(this IApplicationBuilder applicationBuilder)
        {
            var scopeServices = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider;
            var store = scopeServices.GetRequiredService<IMultiTenantStore<ClientTenantInfo>>();

            var clients = await store.GetAllAsync();

            if (!clients.Any())
            {

                var client = new ClientTenantInfo { 
                    Id = Guid.Empty.ToString(), 
                    Identifier = Guid.Empty.ToString(), 
                    Name = Guid.Empty.ToString(), 
                    ConnectionString = "Data Source=localhost; Initial Catalog=SpaApplication.MultiTenant.idsa.Core; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False;"
                };
                
                store.TryAddAsync(client).Wait();

                using (var db = new ApplicationDbContext(client))
                {
                    //db.Database.EnsureDeleted();
                    //db.Database.EnsureCreated();
                    db.ToDoItems.Add(new Models.ToDoItem {
                        Id = DateTime.Now.Minute,
                        Title = "Title",
                        Completed = true

                    });
                    db.Database.EnsureDeleted();
                    //await db.EnsureSeedData();
                    db.SaveChanges();
                }

                //store.TryAddAsync(new Clients { Id = "tenant-initech-341ojadsfa", Identifier = "initech", Name = "Initech LLC", ConnectionString = "initech_conn_string" }).Wait();
            }

        }
    }
}
