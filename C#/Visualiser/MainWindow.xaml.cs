using System.Windows;

namespace Visualiser
{
    using DataStructures.Matrices.Generics;
    using Moveable;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var matrix = Factory.Empty<int>(10, 10);
            Stack.Children.Add(new MatrixControl<int>("name", matrix));
        }
    }
}
