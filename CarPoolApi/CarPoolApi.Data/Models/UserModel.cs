using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Data.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LocationName { get; set; }

        public string ToDataString()
        {
            return $"{Id};{FirstName};{LastName};{LocationName}";
        }
    }
}
