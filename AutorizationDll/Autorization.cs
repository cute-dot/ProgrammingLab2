using Newtonsoft.Json;

namespace AutorizationDll;

public class Autorization
{
    public int CheakAndAutorize(string log, string pass)
    {
        int status;
        var json = File.ReadAllText(@"C:\Users\sasha\RiderProjects\ProgrammingLab2\ProgrammingLab2\UsersList.json");
        var list = JsonConvert.DeserializeObject<List<User>>(json);
        var selectedUsers = from u in list 
            where u.Login == log 
            where u.Password == pass 
            select u;
        foreach (User user in selectedUsers)
        {
            status = user.Status;
            return status;
        }

        return 0;
    }
}