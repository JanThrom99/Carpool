using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Data.Models
{
    public class LocationModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string ToDataString()
        {
            return $"{Id};{Name}";
        }
    }
}
