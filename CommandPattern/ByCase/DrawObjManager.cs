using System;
using System.Linq;
using System.Collections.Generic;

namespace CommandPattern.ByCase
{
    public class DrawObjManager
    {
        #region Fields & Constants

        private readonly List<DrawObjAction> _undoList;

        private readonly List<DrawObjAction> _redoList;

        private readonly List<DrawObj> _drawObjList;

        private DrawObj _selectDrawObj;

        private int count;

        #endregion

        #region Construct & Destruct

        public DrawObjManager()
        {
            _drawObjList = new List<DrawObj>();

            _undoList = new List<DrawObjAction>();
            _redoList = new List<DrawObjAction>();

            _selectDrawObj = null;
            count = 0;
        }

        #endregion

        #region Public Method

        public DrawObj AddObj()
        {
            var drawObj = DoAdd();
            AddActionToList(OperationType.Normal, ActionType.Add, drawObj);
            return drawObj;
        }

        public void DeleteObj()
        {
            AddActionToList(OperationType.Normal, ActionType.Delete, _selectDrawObj);
            DoDelete(_selectDrawObj);
        }

        public void SelectDrawObj(DrawObj drawObj)
        {
            if (FindDrawObj(drawObj.Name) != null)
            {
                _selectDrawObj = drawObj;
            }
        }

        public void MoveObj(double offset)
        {
            AddActionToList(OperationType.Normal, ActionType.Move, _selectDrawObj);
            DoMove(_selectDrawObj, offset);
        }

        public void RotateObj(double rotateAngle)
        {
            AddActionToList(OperationType.Normal, ActionType.Rotate, _selectDrawObj);
            DoRotate(_selectDrawObj, rotateAngle);
        }

        public void ZoomObj(double zoomScale)
        {
            AddActionToList(OperationType.Normal, ActionType.Zoom, _selectDrawObj);
            DoZoom(_selectDrawObj, zoomScale);
        }

        #endregion

        #region Public Undo & Redo method

        public void Undo()
        {
            if (_undoList.Count > 0)
            {
                var action = _undoList.Last();
                if (action != null)
                {
                    Undo(action.ActionType, action.DrawObj);
                    _undoList.Remove(action);
                }
            }
        }

        public void Redo()
        {
            if (_redoList.Count > 0)
            {
                var action = _redoList.Last();
                if (action != null)
                {
                    Redo(action.ActionType, action.DrawObj);
                    _redoList.Remove(action);
                }
            }
        }

        #endregion

        #region Private Normal method

        private DrawObj FindDrawObj(string name)
        {
            foreach (var drawObj in _drawObjList)
            {
                if (drawObj.Name == name)
                {
                    return drawObj;
                }
            }

            return null;
        }

        private DrawObj DoAdd()
        {
            var drawObj = new DrawObj("DrawObj" + count);
            count = count + 1;

            AddNewObjToList(drawObj);
            return drawObj;
        }

        private void AddNewObjToList(DrawObj drawObj)
        {
            Console.WriteLine("Add " + drawObj.Name);
            _drawObjList.Add(drawObj);
            SelectDrawObj(drawObj);
        }

        private void DoDelete(DrawObj drawObj)
        {
            if (drawObj != null)
            {
                Console.WriteLine("Delete " + drawObj.Name);
                _drawObjList.Remove(drawObj);

                if (_drawObjList.Count > 0)
                {
                    SelectDrawObj(_drawObjList.First());
                }
            }
        }

        private void DoMove(DrawObj drawObj, double offset)
        {
            if (drawObj != null)
            {
                Console.WriteLine("Move {0} from {1} to {2} ", drawObj.Name, drawObj.Offset, offset);
                drawObj.Offset = offset;
            }
        }

        private void DoRotate(DrawObj drawObj, double rotateAngle)
        {
            if (drawObj != null)
            {
                Console.WriteLine("Rotate {0} from {1} to {2} ", drawObj.Name, drawObj.RotateAngle, rotateAngle);
                drawObj.RotateAngle = rotateAngle;
            }
        }

        private void DoZoom(DrawObj drawObj, double zoomScale)
        {
            if (drawObj != null)
            {
                Console.WriteLine("Zoom {0} from {1} to {2} ", drawObj.Name, drawObj.ZoomScale, zoomScale);
                drawObj.ZoomScale = zoomScale;
            }
        }

        #endregion

        #region Private Redo & Undo method

        private void AddUndoAction(DrawObjAction action)
        {
            _undoList.Add(action);
        }

        private void AddRedoAction(DrawObjAction action)
        {
            _redoList.Add(action);
        }

        private void EmptyRedoAction()
        {
            _redoList.Clear();
        }

        private void AddActionToList(OperationType operationType, ActionType type, DrawObj drawObj)
        {
            if (drawObj != null)
            {
                switch (operationType)
                {
                    case OperationType.Normal:
                        AddUndoAction(new DrawObjAction(type, drawObj));
                        EmptyRedoAction();
                        break
                            ;
                    case OperationType.Undo:
                        AddUndoAction(new DrawObjAction(type, drawObj));
                        break;

                    case OperationType.Redo:
                        AddRedoAction(new DrawObjAction(type, drawObj));
                        break;
                }
            }
        }

        private void DoUndoRedoAdd(OperationType operationType, ActionType actionType, DrawObj drawObj)
        {
            var cloneObj = drawObj.Clone() as DrawObj;
            AddNewObjToList(cloneObj);
            AddActionToList(operationType, actionType, cloneObj);
        }

        private void DoUndoRedoDelete(OperationType operationType, ActionType actionType, DrawObj drawObj)
        {
            var findObj = FindDrawObj(drawObj.Name);
            if (findObj != null)
            {
                AddActionToList(operationType, actionType, findObj);
                DoDelete(findObj);
            }
        }

        private void DoUndoRedoMove(OperationType operationType, DrawObj drawObj)
        {
            var findObj = FindDrawObj(drawObj.Name);
            if (findObj != null)
            {
                AddActionToList(operationType, ActionType.Move, findObj);
                DoMove(findObj, drawObj.Offset);
            }
        }

        private void DoUndoRedoRotate(OperationType operationType, DrawObj drawObj)
        {
            var findObj = FindDrawObj(drawObj.Name);
            if (findObj != null)
            {
                AddActionToList(operationType, ActionType.Rotate, findObj);
                DoRotate(findObj, drawObj.RotateAngle);
            }
        }

        private void DoUndoRedoZoom(OperationType operationType, DrawObj drawObj)
        {
            var findObj = FindDrawObj(drawObj.Name);
            if (findObj != null)
            {
                AddActionToList(operationType, ActionType.Zoom, findObj);
                DoZoom(findObj, drawObj.ZoomScale);
            }
        }

        private void Undo(ActionType type, DrawObj drawObj)
        {
            switch (type)
            {
                case ActionType.Add:
                    DoUndoRedoDelete(OperationType.Redo, ActionType.Add, drawObj);
                    break;

                case ActionType.Delete:
                    DoUndoRedoAdd(OperationType.Redo, ActionType.Delete, drawObj);
                    break;

                case ActionType.Move:
                    DoUndoRedoMove(OperationType.Redo, drawObj);
                    break;

                case ActionType.Rotate:
                    DoUndoRedoRotate(OperationType.Redo, drawObj);
                    break;

                case ActionType.Zoom:
                    DoUndoRedoZoom(OperationType.Redo, drawObj);
                    break;
            }
        }

        private void Redo(ActionType type, DrawObj drawObj)
        {
            switch (type)
            {
                case ActionType.Add:
                    DoUndoRedoAdd(OperationType.Undo, ActionType.Add, drawObj);
                    break;

                case ActionType.Delete:
                    DoUndoRedoDelete(OperationType.Undo, ActionType.Delete, drawObj);
                    break;

                case ActionType.Move:
                    DoUndoRedoMove(OperationType.Undo, drawObj);
                    break;

                case ActionType.Rotate:
                    DoUndoRedoRotate(OperationType.Undo, drawObj);
                    break;

                case ActionType.Zoom:
                    DoUndoRedoZoom(OperationType.Undo, drawObj);
                    break;
            }
        }

        #endregion
    }
}
