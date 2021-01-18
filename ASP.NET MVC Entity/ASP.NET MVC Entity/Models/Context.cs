using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ASP.NET_MVC_Entity.Models
{
    public class Context:DbContext
    {
        public DbSet<Person> people { get; set; }
    }
}