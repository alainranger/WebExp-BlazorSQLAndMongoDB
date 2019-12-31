using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSQLAndMongoDB.Data
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
    }
}
