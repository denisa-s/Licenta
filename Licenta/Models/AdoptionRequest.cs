using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class AdoptionRequest
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int ID_dog { get; set; }
        public int ID_employee { get; set; }
        public int ID_guest { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
