using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApplication.MultiTenant.Web.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }   

        public bool Completed { get; set; }
    }
}
