namespace ClassLibrary1;

public class User
{
    private string login;
    private string password;
    private int status;

    public string Login
    {
        get => login;
        set => login = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Password
    {
        get => password;
        set => password = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Status
    {
        get => status;
        set => status = value;
    }

    public User(string login, string password, int status)
    {
        this.login = login;
        this.password = password;
        this.status = status;
    }
}