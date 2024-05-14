using System;
using System.IO;
using System.Reflection;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using AutorizationDll;
namespace ProgrammingLab2.Views;
public partial class ProgrammWindow : Window
{
    private int status;
    public ProgrammWindow(int status)
    {
        this.status = status;
        InitializeComponent();
        Assembly asm = Assembly.LoadFrom("AutorizationDll.dll");
        Type? menuConstructorType = asm.GetType("AutorizationDll.MenuConstructor");
        if (menuConstructorType is not null)
        {
            dynamic menuConstructor = Activator.CreateInstance(menuConstructorType);
            menuConstructor.BuildMenu(status,
                "C:\\Users\\sasha\\RiderProjects\\ProgrammingLab2\\ProgrammingLab2\\Menu1.txt");
            menuConstructor.ChangeForUser(this.status);
            Menu menu = menuConstructor.Menu;
            Call.Children.Add(menu);
        }
        // var menu = new AutorizationDll.MenuConstructor();
        // menu.BuildMenu(status, "C:\\Users\\sasha\\RiderProjects\\ProgrammingLab2\\ProgrammingLab2\\Menu1.txt");
        // menu.ChangeForUser(status);
        // Call.Children.Add(menu.Menu);

    }
}