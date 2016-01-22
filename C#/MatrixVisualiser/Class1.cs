using System.Diagnostics;
using DataStructures.Matrices;
using MatrixVisualiser;
using Microsoft.VisualStudio.DebuggerVisualizers;

[assembly: DebuggerVisualizer(
    typeof (MVisualiser),
    typeof (VisualizerObjectSource),
    Target = typeof (Matrix<int>)
    )]

namespace MatrixVisualiser
{
    using DataStructures.Matrices.Integers;
    using Microsoft.VisualStudio.DebuggerVisualizers;

    public class MVisualiser : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var oper = (Matrix) objectProvider.GetObject();
            var window = new MVisualiserWindow(oper);
            windowService.ShowDialog(window);
        }
    }
}