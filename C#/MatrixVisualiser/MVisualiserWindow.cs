using System.Diagnostics;
using System.Windows.Forms;
using DataStructures.Matrices;

namespace MatrixVisualiser
{
    public partial class MVisualiserWindow : Form
    {
        public MVisualiserWindow(Matrix<int> matrix)
        {
            InitializeComponent();
            if (matrix == null)
                MessageBox.Show("Problme!");
            else
            {
                Grid.ReadOnly = true;
                int columns = matrix.ColumnCount;
                Grid.ColumnCount = columns;
                for (int i = 0; i < columns; ++i)
                {
                    Grid.Columns[i].Name = i.ToString();
                }
                for (int i = 0; i < matrix.RowCount; ++i)
                {
                    object[] row = new object[columns];
                    for (int j = 0; j < columns; ++j)
                    {
                        row[j] = matrix[i, j].ToString();
                    }
                    Grid.Rows.Add(row);
                }
            }
        }
    }
}
