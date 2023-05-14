using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class CardDetail
    {
        [PrimaryKey]
        [AutoIncrement] 
        public int ID { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string ValidUntil { get; set; }
        public string SecurityCode { get; set; }
        public string Email { get; set; }
    }
}
