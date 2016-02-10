using System.Windows.Controls;
namespace Visualiser.Moveable
{ 
    using System.Windows.Forms;
    using DataStructures.Matrices.Generics;

    public partial class MatrixControl
    {
        private string name;
        public MatrixControl(string name)
        {
            InitializeComponent();
            Expander.Header = name;
            this.name = name;
        }

        public void setGrid<T>(Matrix<T> matrix)
        {
            DataGrid.DataContext = new ArrayDataView(matrix);

        }
    }
}
