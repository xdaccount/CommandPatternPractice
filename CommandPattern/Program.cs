using CommandPattern.ByCase;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var drawObjManager = new DrawObjManager();
            var drawObj0 = drawObjManager.AddObj();
            var drawObj1 = drawObjManager.AddObj();
            var drawObj2 = drawObjManager.AddObj();
            drawObjManager.SelectDrawObj(drawObj1);
            drawObjManager.MoveObj(3.0);
            drawObjManager.Undo();
            var drawObj3 = drawObjManager.AddObj();
            var drawObj4 = drawObjManager.AddObj();
            var drawObj5 = drawObjManager.AddObj();
            drawObjManager.Undo();
            drawObjManager.RotateObj(24.0);
            drawObjManager.SelectDrawObj(drawObj5);
            drawObjManager.ZoomObj(1.5);
            drawObjManager.Undo();
            drawObjManager.Undo();
            drawObjManager.Redo();
            drawObjManager.SelectDrawObj(drawObj2);
            drawObjManager.ZoomObj(1.5);
            drawObjManager.MoveObj(1.5);
            drawObjManager.Undo();
            drawObjManager.Undo();
            drawObjManager.Redo();

            int m = 3;
        }
    }
}
