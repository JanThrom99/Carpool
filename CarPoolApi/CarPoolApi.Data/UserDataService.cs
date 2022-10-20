﻿using CarPoolApi.Data.Models;

namespace CarPoolApi.Data
{
    public class UserDataService
    {
        public string personDataPath = CarPoolApi.Data.Properties.Resources.personDataPath;

        public List<UserModel> GetAllUsers()
        {
            var users = new List<UserModel>();

            var lines = File.ReadAllLines(personDataPath);
            foreach (var line in lines)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    var newUserEntry = new UserModel();
                    var splittedLine = line.Split(';');
                    newUserEntry.Id = splittedLine[0];
                    newUserEntry.FirstName = splittedLine[1];
                    newUserEntry.LastName = splittedLine[2];
                    newUserEntry.LocationName = splittedLine[3];
                    users.Add(newUserEntry);
                }
            }
            return users;
        }

        public UserModel CreateUser(UserModel user)
        {
            var newUser = new UserModel()
            {
                Id = GetNewUserId(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                LocationName = user.LocationName
            };
            File.AppendAllText(personDataPath, $"\n{newUser.ToDataString()}");
            return newUser;
        }

        public UserModel? DeleteUser(string userId)
        {
            var oldUsers = GetAllUsers();
            var newUsers = new List<string>();
            UserModel? deletedUser = null;
            File.WriteAllText(personDataPath, "");
            foreach (var user in oldUsers)
            {
                if (!(user.Id == userId))
                {
                    newUsers.Add(user.ToDataString());
                }
                else
                {
                    deletedUser = user;
                }
            }
            File.AppendAllLines(personDataPath, newUsers);
            if (deletedUser == null)
            {
                return null;
            }
            return deletedUser;
        }

        public UserModel? UpdateUser(UserModel newUser)
        {
            var oldUsers = GetAllUsers();
            var newUsers = new List<string>();
            UserModel? userToUpdate = null;
            File.WriteAllText(personDataPath, "");
            foreach (var user in oldUsers)
            {
                if (!(user.Id == newUser.Id))
                {
                    newUsers.Add(user.ToDataString());
                }
                else
                {
                    newUsers.Add(newUser.ToDataString());
                    userToUpdate = newUser;
                }
            }
            File.AppendAllLines(personDataPath, newUsers);
            if (userToUpdate == null)
            {
                return null;
            }
            return userToUpdate;
        }

        public string GetNewUserId() //TODO use DTOs in Business and regular in data 
        {
            int highestId = 0;
            var currentUsers = GetAllUsers();

            foreach (var user in currentUsers)
            {
                if (Convert.ToInt32(user.Id.Split('#').Last()) > highestId)
                {
                    highestId = Convert.ToInt32(user.Id.Split('#').Last());
                }
            }
            var newId = Convert.ToInt32(highestId) + 1;
            return $"ID#{newId}"; ;
        }
    }
}
