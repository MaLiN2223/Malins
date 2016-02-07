using System.Windows.Controls;
namespace Visualiser.Moveable
{
    using System.Windows;

    public class MatrixControl<T> : UserControl
    {
        private Grid grid;
        private Expander expander;
        private DataGrid dataGrid;
        private void InitializeComponent()
        {
            grid = new Grid();
            grid.RowDefinitions.Add(
                new RowDefinition
                {
                    Height = new GridLength(30)
                }
            );
            grid.RowDefinitions.Add(
                new RowDefinition
                {
                    Height = GridLength.Auto
                }
             );

            expander = new Expander();
            grid.Children.Add(expander);

            dataGrid = new DataGrid();
            grid.Children.Add(dataGrid);




        }
        public MatrixControl(string name, object matrix)
        {
            InitializeComponent();
            expander.Header = name;
        }
    }
}
