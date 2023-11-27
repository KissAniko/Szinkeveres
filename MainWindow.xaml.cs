using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RGB
{
    public partial class MainWindow : Window
    {
        private Color currentColor;

        public MainWindow()
        {
            InitializeComponent();
            InitializeEventHandlers();
            UpdateColor();
        }

        private void InitializeEventHandlers()
        {
            slPiros.ValueChanged += Slider_ValueChanged;
            slZold.ValueChanged += Slider_ValueChanged;
            slKék.ValueChanged += Slider_ValueChanged;


            btnMentes.Click += BtnMentes_Click;
            btnTorol.Click += BtnTorol_Click;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColor();
        }

        private void BtnMentes_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "szinkeveres.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {

                    writer.WriteLine($"Red: {currentColor.Red}");
                    writer.WriteLine($"Green: {currentColor.Green}");
                    writer.WriteLine($"Blue: {currentColor.Blue}");
                }

                MessageBox.Show($"Kevert szín adatai sikeresen mentve ide: {filePath}", "Mentés sikeres", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a mentés során: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateColor()
        {
            byte red = (byte)slPiros.Value;
            byte green = (byte)slZold.Value;
            byte blue = (byte)slKék.Value;

            currentColor = new Color(red, green, blue);

            // Aktuális színek frissítése
            tbPiros.Text = red.ToString();
            tbZold.Text = green.ToString();
            tbKek.Text = blue.ToString();

            // Színkeverő doboz frissítése
            SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(red, green, blue));
            rctKevertSzín.Fill = brush;

            // textBox frissítése
            tbSzinkod.Text = $"#{red:X2}{green:X2}{blue:X2}";

        }
        private void BtnTorol_Click(object sender, RoutedEventArgs e)
        {
            // Össze csúszka törlésse és 0-ra állítása
            slPiros.Value = 0;
            slZold.Value = 0;
            slKék.Value = 0;
            UpdateColor();
        }
    }
}
