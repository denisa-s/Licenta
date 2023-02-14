using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Licenta.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CNP { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string phone_number { get; set; }
        public DateTime birth_date { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public string email { get; set; }
        public int salary { get; set; }
        public DateTime hire_date { get; set; }
        public string marital_status { get; set; }
        public string housing_type { get; set; }
    }
}
