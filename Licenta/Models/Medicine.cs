using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Medicine
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string MeasureUnits { get; set; }
        public string PresentationType { get; set; }
        public string AdministrationMode { get; set; }
        public string Description { get; set; }
    }
}
