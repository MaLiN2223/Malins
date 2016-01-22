namespace MatrixVisualiser
{
    using System.Windows.Forms;
    using DataStructures.Matrices;

    public partial class MVisualiserWindow : Form
    {
        public MVisualiserWindow(Matrix<int> matrix)
        {
            InitializeComponent();
            if (matrix == null)
                MessageBox.Show("Problme!");
            else
            {
                this.Grid.ReadOnly = true;
                var columns = matrix.ColumnCount;
                this.Grid.ColumnCount = columns;
                for (var i = 0; i < columns; ++i)
                {
                    this.Grid.Columns[i].Name = i.ToString();
                }
                for (var i = 0; i < matrix.RowCount; ++i)
                {
                    var row = new object[columns];
                    for (var j = 0; j < columns; ++j)
                    {
                        row[j] = matrix[i, j].ToString();
                    }
                    this.Grid.Rows.Add(row);
                }
            }
        }
    }
}