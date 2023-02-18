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
    }
}
