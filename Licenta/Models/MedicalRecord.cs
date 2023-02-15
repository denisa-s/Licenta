using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class MedicalRecord
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Disease { get; set; }
        public string Details { get; set; }
        public int ID_dog { get; set; }
    }
}
