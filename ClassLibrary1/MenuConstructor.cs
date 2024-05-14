using Avalonia.Controls;
using Avalonia.Media;

namespace ClassLibrary1;

public class MenuConstructor
{
    private Menu _menu = new Menu();
    public Menu Menu
    {
        get => _menu;
        set => _menu = value ?? throw new ArgumentNullException(nameof(value));
    }
    public void BuildMenu(int status, string filePath)
    {
        MenuItem fileMenuItem = new MenuItem();
        MenuItem item = new MenuItem();
        foreach (var str in File.ReadLines(filePath))
        {
            var strLine = str.Split(' ');
            fileMenuItem = new MenuItem();
            fileMenuItem.Width = 130;
            fileMenuItem.Height = 30;
            fileMenuItem.Foreground = Brushes.Black;
            fileMenuItem.Background = Brushes.WhiteSmoke;
            fileMenuItem.Header = strLine[1];
            Console.WriteLine(strLine.Length);
            if (strLine.Length == 3 && strLine[2] != " ")
            {
                fileMenuItem.Click += (sender, args) =>
                {
                    Console.WriteLine("Вызван метод:" + strLine[2]);
                };
            }
            if (strLine[0] == "0")
            {
                _menu.Items.Add(fileMenuItem);
                item = fileMenuItem;
            }
            else
            {
                MenuItem last = item;
                for (int j = 0; j < Convert.ToInt32(strLine[0])-1; j++)
                {
                    last = (MenuItem)last.Items[last.Items.Count-1];
                }
                last.Items.Add(fileMenuItem);
            }
            
        }
    }

    public void FindMenu(string name, string status, ItemCollection items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (((MenuItem)items[i]).Header.Equals(name))
            {
                if (Convert.ToInt32(status) == 1)
                {
                    ((MenuItem)items[i]).IsEnabled = false;
                }
                else
                {
                    ((MenuItem)items[i]).IsVisible = false;
                }
                return;
            }
            FindMenu(name, status, ((MenuItem)items[i]).Items);
        }
    }
    public void ChangeForUser(int status)
    {
        switch (status)
        {
            case 1:
            {
                var str = File.ReadLines("C:\\Users\\sasha\\RiderProjects\\ProgrammingLab2\\ProgrammingLab2\\Status1.txt");
                foreach (var item in str)
                {
                    var panel = item.Split(' ');
                    FindMenu(panel[1], panel[0], Menu.Items);
                }
                break;
            }
            case 2:
            {
                var str = File.ReadLines("C:\\Users\\sasha\\RiderProjects\\ProgrammingLab2\\ProgrammingLab2\\Status2.txt");
                foreach (var item in str)
                {
                    var panel = item.Split(' ');
                    FindMenu(panel[1], panel[0], Menu.Items);
                }
                break;
            }
        }
    }
}