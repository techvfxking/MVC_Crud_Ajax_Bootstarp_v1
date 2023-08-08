using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Crud_Ajax_Bootstarp_v1.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}