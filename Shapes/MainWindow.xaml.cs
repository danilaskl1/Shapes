using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Shape shape;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShapeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawShape((int)Size.Value);
        }

        private void Size_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(Canvas != null)
                DrawShape((int)Size.Value);
        }

        private void Spin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SpinShape();
        }

        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Canvas != null && shape != null)
                CanvasUpdate();
        }

        private void DrawShape(int shapeScale = 1)
        {
            Canvas.Children.Clear();

            if (ShapeSelect.SelectedIndex == 0)
            {
                shape = new Ellipse
                {
                    Width = 100 * shapeScale,
                    Height = 100 * shapeScale,
                    Fill = Brushes.Gold,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
            }
            else if (ShapeSelect.SelectedIndex == 1)
            {
                shape = new Rectangle()
                {
                    Width = 100 * shapeScale,
                    Height = 100 * shapeScale,
                    Fill = Brushes.Gold,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
            }
            else if (ShapeSelect.SelectedIndex == 2)
            {
                shape = new Polygon()
                {
                    Points = { new Point { X = 1, Y = 1 }, new Point { X = 100 * shapeScale, Y = 1 }, new Point { X = 100 * shapeScale, Y = 100 * shapeScale} },
                    Fill = Brushes.Gold,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Width = 100 * shapeScale,
                    Height = 100 * shapeScale,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
            }

            if (shape != null)
            {
                Canvas.Children.Add(shape);
                CanvasUpdate();
            }
        }

        private void SpinShape()
        {
            RotateTransform rotateTrnsf = new RotateTransform(Spin.Value);
            rotateTrnsf.CenterX = 100 * Size.Value / 2;
            rotateTrnsf.CenterY = 100 * Size.Value / 2;
            Canvas.Children[0].RenderTransform = rotateTrnsf;
        }

        private void CanvasUpdate()
        {
            Canvas.SetTop(shape, mainWindow.Height / 2 - (shape.Height / 2) - 16);
            Canvas.SetLeft(shape, (mainWindow.Width - 135) / 2 - (shape.Width / 2));
            SpinShape();
        }
    }
}