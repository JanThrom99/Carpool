using System;
using System.IO;
using CarPoolApi.Data.Models;

namespace CarPoolApi.Data
{
    public class UserDataService
    {
        public List<UserModel> GetUsers()
        {
            var users = new List<UserModel>();

            var lines = File.ReadAllLines(CarPoolApi.Data.Properties.Resources.personDataPath);
            foreach (var line in lines)
            {
                var newUserEntry = new UserModel();
                var splittedLine = line.Split(';');
                newUserEntry.Id = splittedLine[0];
                newUserEntry.Name = splittedLine[1];
                users.Add(newUserEntry);
            }
            return users;
            //TODO read file and give back users
        }
    }
}
