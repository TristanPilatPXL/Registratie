using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
        using System.Windows.Data;
        using System.Windows.Documents;
        using System.Windows.Input;
        using System.Windows.Media;
        using System.Windows.Media.Imaging;
        using System.Windows.Navigation;
        using System.Windows.Shapes;
        using WpfApp1.Models;

        namespace WpfApp1
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                    LoadOlodsInListBox();
                }

                private void LoadOlodsInListBox()
                {
                    var olods = CreateOlodList();
                    olodListBox.ItemsSource = olods;
                }

        private List<Olod> CreateOlodList()
        {
            return new List<Olod>()
    {
        new Olod() {
            Name = "C# Essentials",
            Credits = 7
        },
        new Olod() {
            Name = "C# Advanced",
            Credits = 6
        },
        new Olod() {
            Name = "C# Web1",
            Credits = 7
        },
        new Olod() {
            Name = "C# Mobile",
            Credits = 6
        },
        new Olod() {
            Name = "C# Web2",
            Credits = 4
        },
    };
        }
    }
        }