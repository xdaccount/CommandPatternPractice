namespace CommandPattern
{
    public enum ActionType
    {
        Default,
        Add,
        Delete,
        Move,
        Rotate,
        Zoom
    }

    public enum OperationType
    {
        Normal,
        Undo,
        Redo
    }
}
