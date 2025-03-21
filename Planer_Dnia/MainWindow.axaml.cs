using System.Diagnostics;
using System.Drawing;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Planer_Dnia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }


    public int i = 0;
    
    private void CreateNewGrid(object? sender, RoutedEventArgs e)
    {
        i++;
        string NazwaZad = NazwaZadania.Text;
        int Kategoria;
        if (RadioPraca.IsChecked == true)
        {
            Kategoria = 0;
        }

        else if (RadioRelaks.IsChecked == true)
        {
            Kategoria = 1;
        }

        else if (RadioZakupy.IsChecked == true)
        {
            Kategoria = 2;
        }

        else if (RadioHobby.IsChecked == true)
        {
            Kategoria = 3;
        }

        else
        {
            Kategoria = 4;
        }
        
        var border = new Border()
        {
            Background = Brushes.Green,  
            BorderBrush = Brushes.Black, 
            BorderThickness = new Thickness(2), 
            CornerRadius = new CornerRadius(10), 
            Margin = new Thickness(10) 
        };
        
        
        
        var grid = new Grid()
        {
            Background = Brushes.Green,
            Margin = new Thickness(10),
            
        };
        
        grid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
        grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        
        var textBlock = new TextBlock{ Text = NazwaZad,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            Margin = new Thickness(10),
            FontWeight = FontWeight.Bold,
            
        };
        var comboBox =  new ComboBox { Items = { "Praca","Relaks","Zakupy","Hobby","Nie wybrano kategori"},
            Name = "wybor",
            SelectedIndex = Kategoria
            
        };
        var ukonczone = new CheckBox
        {
            Content = "Ukończone?"
            
        };
        var usun = new Button
        {
            Content = "Usuń"
            
        };
        
        usun.Click += (sender, args) =>
        {
            var button = (Button)sender;
            var parentGrid = (Grid)button.Parent;
            var parentBorder = (Border)parentGrid.Parent;
            NewGrids.Children.Remove(parentBorder);
        };

        
        
        Grid.SetColumn(textBlock, 0);
        Grid.SetRow(textBlock, 0);
        Grid.SetColumn(comboBox, 0);
        Grid.SetRow(comboBox, 1);
        Grid.SetColumn(ukonczone, 0);
        Grid.SetRow(ukonczone, 2);
        Grid.SetColumn(usun, 0);
        Grid.SetRow(usun, 3);
        
        grid.Children.Add(textBlock);
        grid.Children.Add(comboBox);
        grid.Children.Add(ukonczone);
        grid.Children.Add(usun);
        
                
        border.Child = grid;
        NewGrids.Children.Add(border);
        
    }

    
}