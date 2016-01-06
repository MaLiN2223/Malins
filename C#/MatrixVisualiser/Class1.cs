using DataStructures.Matrices;
using DataStructures.Matrices.Integers;
using Microsoft.VisualStudio.DebuggerVisualizers;
[assembly: System.Diagnostics.DebuggerVisualizer(
typeof(MatrixVisualiser.MVisualiser),
typeof(VisualizerObjectSource),
Target = typeof(Matrix<int>)
)]
namespace MatrixVisualiser
{
    public class MVisualiser : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            Matrix oper = (Matrix)objectProvider.GetObject();
            MVisualiserWindow window = new MVisualiserWindow(oper);
            windowService.ShowDialog(window);
        }
    }
}
