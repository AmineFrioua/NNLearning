using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PerceptorSecondExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Label> Labels;

        public PerceptorTwo Sasa;

        public int i = 0;

        private static readonly Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            Labels = new List<Label>(50);


            for (int i = 0; i < 50; i++)
            {
                Labels.Add(new Label());
                   Labels[i].Content = RandomString(4);

                if (i >= 0 && i < 10) PanelOne.Children.Add(Labels[i]);
                if (i >= 10 && i < 20) PanelTwo.Children.Add(Labels[i]);
                if (i >= 20 && i < 30) PanelThree.Children.Add(Labels[i]);
                if (i >= 30 && i < 40) PanelFor.Children.Add(Labels[i]);
                if (i >= 40 && i < 50) PanelFive.Children.Add(Labels[i]);
            }

            Sasa = new PerceptorTwo(Labels);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sasa.Train();
            i++;
            Num.Content = i.ToString();
        }
    }
}
