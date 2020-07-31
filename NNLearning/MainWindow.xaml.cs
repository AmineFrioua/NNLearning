using NNLearning.DrawingTools;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace NNLearning
{

    public partial class MainWindow : Window
    {
        public PointsGenerator Points { get; set; }

        public ShapesGenerator Shapes { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Points = new PointsGenerator(100, (int)Window.Width, (int)Window.Height);

            Shapes = new ShapesGenerator((int)Window.Width, (int)Window.Height);

            Points.DrawCircles(Screen);

            Shapes.DrawLine(Screen);
        }


    }
}
