using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int totaalCredits;//staat hier voor te grbuiken in ander methode
        private string naam = "";        // ← Voeg toe als class field
        private string sex = "";         // ← Ook handig om te bewaren
        private string birthdate = "";

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
        private void olodListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int totaalCredits = 0;  // ← Begin op 0! 

            // Loop door alle geselecteerde items
            foreach (var item in olodListBox.SelectedItems)
            {
                var olod = (Olod)item;
                totaalCredits += olod.Credits;  // ← Let op de += (plus-equals)
            }

            // Update het label met het totaal
            studiepuntenLabel.Content = totaalCredits;
        }

        private void inschrijven(object sender, RoutedEventArgs e)
        {
            naam = NameTextBox.Text;
            birthdate = Date.SelectedDate?.ToString() ?? "";
            sex = "";
            if (Male.IsChecked == true)
            {
                sex = "M";
            }
            if (Female.IsChecked == true)
            {
                sex = "V";
            }
            if (Other.IsChecked == true)
            {
                sex = "X";
            }

            Student.Items.Add($"{naam} ({sex}) {studiepuntenLabel.Content} studiepunten");// in de dropdown menu

            // dropdown menu text
            Student.SelectedItem = ($"{naam} ({sex}) {studiepuntenLabel.Content} studiepunten");

            
            



            //leeg maken
            NameTextBox.Clear();
            Male.IsChecked = false;
            Female.IsChecked = false;
            Other.IsChecked = false;
            Bachelor.IsChecked = false;
            Graduaat.IsChecked = false;
            Date.SelectedDate = null;
        }
        private void Student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Student.SelectedItem != null && Student.SelectedItem != ja)
            {
                textblock.Text = ($"Naam: {naam}");
                textblock.Text += ($"\nGeboortedatum: {birthdate}");
                textblock.Text += ($"\nGeslacht: {sex}");
                textblock.Text += ($"\nOlods: ");
                foreach (var item in olodListBox.SelectedItems)
                {
                    var olod = (Olod)item;
                    textblock.Text += ($"\n- {olod.Name}");
                }
            }
            else
            {
                textblock.Text = "";
            }
        }

        private void verwijderen(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
