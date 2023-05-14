using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Order
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string AddressDetails { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Total { get; set; }
        public string Email { get; set; }
    }
}
