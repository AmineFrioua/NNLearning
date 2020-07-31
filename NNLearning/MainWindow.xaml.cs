using NNLearning.DrawingTools;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace NNLearning
{

    public partial class MainWindow : Window
    {
        public PointsGenerator PointsGenerator { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            PointsGenerator = new PointsGenerator(100, (int)Window.Width, (int)Window.Height);

            PointsGenerator.DrawCircles(Screen);


        }


    }
}
