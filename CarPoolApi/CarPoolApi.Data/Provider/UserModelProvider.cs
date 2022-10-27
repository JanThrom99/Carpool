using CarPoolApi.Data.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolApi.Data.Provider
{
    public class UserModelProvider : IExamplesProvider<UserModel>
    {
        public UserModel GetExamples()
        {
            return new UserModel()
            {
                Id = "ID#1",
                FirstName = "John",
                LastName = "Doe",
                LocationName = "New York"
            };
        }
    }
}
