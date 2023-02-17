using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace Licenta.Models
{
    public class ListSize
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Dog))]
        public int DogID { get; set; }
        public int SizeID { get; set; }
    }
}
