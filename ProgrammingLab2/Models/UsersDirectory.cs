using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ProgrammingLab2.Models;

public static class UsersDirectory
{
    public static void AddNewUser()
    {
        User user = new User("Alex", "123", 2);
        User user1 = new User("Sasha", "456", 1);
        var json = File.ReadAllText(@"C:\Users\sasha\RiderProjects\ProgrammingLab2\ProgrammingLab2\UsersList.json");
        var list = JsonConvert.DeserializeObject<List<User>>(json);
        if (list == null)
        {
            list = new List<User>();
        }
        list.Add(user);
        list.Add(user1);
        var newjson = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(@"C:\Users\sasha\RiderProjects\ProgrammingLab2\ProgrammingLab2\UsersList.json",newjson);
    }
}