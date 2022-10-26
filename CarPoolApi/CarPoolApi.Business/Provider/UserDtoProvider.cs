using CarPoolApi.Data.Models;
using Swashbuckle.AspNetCore.Filters;

namespace CarPoolApi;

public class UserDtoProvider : IExamplesProvider<UserDtoModel>
{
    public UserDtoModel GetExamples()
    {
        return new UserDtoModel()
        {
            FirstName = "John",
            LastName = "Doe",
            LocationName = "New York"
        };
    }
}