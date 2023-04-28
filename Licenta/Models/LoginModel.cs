using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Licenta.Models
{
    public class LoginModel
    {
        [PrimaryKey]
        public string UserName { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string AddressDetails { get; set; }
        public string MaritalStatus { get; set; }
        public string HousingType { get; set; }
    }
}
