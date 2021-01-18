using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_Entity.Models
{
    public class Person
    {
        [Key]
        public int iCode { get; set; }
        public string sName { get; set; }
        public string sEmail { get; set; }
    }
}