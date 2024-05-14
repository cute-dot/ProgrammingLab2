using System;
using System.Reactive;
using System.Reflection;

using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
// using ProgrammingLab2.Models;
using ProgrammingLab2.Views;
using ReactiveUI;

using AutorizationDll;
namespace ProgrammingLab2.ViewModels;
public class MainWindowViewModel : ViewModelBase
{
    private string _password;
    private string _login;
    public string Password
    {
        get { return _password; }
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
    public string Login
    {
        get => _login;
        set => this.RaiseAndSetIfChanged(ref _login, value);
    }
    public MainWindowViewModel()
    {
        
        LoginCommand = ReactiveCommand.Create(Autorization);
        
    }
    public ReactiveCommand<Unit, Unit> LoginCommand
    {
        get;
    }

    // public void Autorization()
    // {
    //     UsersDirectory.AddNewUser();
    // }
    // public void Autorization()
    // {
    //     Autorization auto = new Autorization();
    //     var status = auto.CheakAndAutorize(Login, Password);
    //     if (status == 0)
    //     {
    //         var errorBox = MessageBoxManager.GetMessageBoxStandard("Ошибка",
    //             "Неверный Логин или пароль");
    //         var result = errorBox.ShowAsync();
    //     }
    //     else
    //     {
    //         var progWindow = new ProgrammWindow(status);
    //         progWindow.Show();
    //         Console.WriteLine(status);
    //     }
    // }
    
    public void Autorization()
    {
        // Autorization auto = new Autorization();
        // var status = auto.CheakAndAutorize(Login, Password);
        // if (status == 0)
        // {
        //     var errorBox = MessageBoxManager.GetMessageBoxStandard("Ошибка",
        //         "Неверный Логин или пароль");
        //     var result = errorBox.ShowAsync();
        // }
        // else
        // {
        //     var progWindow = new ProgrammWindow(status);
        //     progWindow.Show();
        //     Console.WriteLine(status);
        // }
        
        Assembly asm = Assembly.LoadFrom("AutorizationDll.dll");
        Type? t = asm.GetType("AutorizationDll.Autorization");
        object? obj = asm.CreateInstance("AutorizationDll.Autorization", false, BindingFlags.CreateInstance, null, new object[]{}, null, null);
        
        if (t is not null)
        {
            MethodInfo? cheakAndAutorize = obj.GetType().GetMethod("CheakAndAutorize");
            object? status_obj = cheakAndAutorize?.Invoke(obj, new Object[]{Login, Password} );
            var status = Convert.ToInt32(status_obj);
            if (status == 0)
            {
                var errorBox = MessageBoxManager.GetMessageBoxStandard("Ошибка",
                    "Неверный Логин или пароль");
                var result = errorBox.ShowAsync();
            }
            else
            {
                var progWindow = new ProgrammWindow(status);
                progWindow.Show();
                Console.WriteLine(status);
            }
        }
    }
}