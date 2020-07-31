using NNLearning.DrawingTools;
using NNLearning.Percetrons;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace NNLearning
{

    public partial class MainWindow : Window
    {
        public PointsGenerator Points { get; set; }

        public ShapesGenerator Shapes { get; set; }

        public PerceptorOne Sasa { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Shapes = new ShapesGenerator((int)Window.Width, (int)Window.Height);

            Points = new PointsGenerator(100, (int)Window.Width, (int)Window.Height,Shapes.A,Shapes.B);

            Points.DrawCircles(Screen);

            Sasa = new PerceptorOne(100, Points.Points, Shapes.A, Shapes.B);

            Shapes.DrawLine(Screen);

            Sasa.Draw(Points.Points, Screen);
        }


        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Sasa.Train(Points.Points);

            Sasa.Draw(Points.Points, Screen);
        }
    }
}
