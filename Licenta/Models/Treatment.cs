using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Treatment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ID_dog { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ID_medicine { get; set; }
        public int ID_employee { get; set; }
        public int ID_medrec { get; set; }
    }
}
