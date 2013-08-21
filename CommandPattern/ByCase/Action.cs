namespace CommandPattern.ByCase
{
    public class DrawObjAction
    {
        public ActionType ActionType { get; private set; }

        public DrawObj DrawObj { get; private set; }

        public DrawObjAction(ActionType type, DrawObj drawObj)
        {
            ActionType = type;
            DrawObj = drawObj.Clone() as DrawObj;
        }
    }
}
