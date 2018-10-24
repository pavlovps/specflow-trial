using core.Board.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace core.Board
{
    public class Column
    {
        private List<Feature> _tasks = new List<Feature>();
        private int _wip;

        public Column(int WIP)
        {
            _wip = WIP;
        }

        public void AddTask(Feature feature)
        {
            if (feature == null) throw new ArgumentNullException("No feature");
            if (_wip > 0 && _tasks.Count == _wip) throw new ColumnWIPReachedException($"Column can no longer accept tasks, WIP of {_wip} has been reached");

            _tasks.Add(feature);
        }

        public void RemoveTask(Feature feature)
        {
            if (feature == null) throw new ArgumentNullException("No feature");
            if (!_tasks.Contains(feature)) throw new ArgumentOutOfRangeException("No such feature");

            _tasks.Remove(feature);
        }

        public int WIP
        {
            get
            {
                return _wip;
            }

            set
            {
                if (value < _tasks.Count) throw new ArgumentOutOfRangeException("New WIP is less than number of tasks in the column");

                _wip = value;
            }
        }

        public void ClearColumn()
        {
            _tasks.Clear();
        }

        public ReadOnlyCollection<Feature> Tasks
        {
            get
            {
                var tasks = new ReadOnlyCollection<Feature>(_tasks);

                return tasks;
            }
        }
    }
}
