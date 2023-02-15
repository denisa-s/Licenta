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
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public DateTime HireDate { get; set; }
    }
}
