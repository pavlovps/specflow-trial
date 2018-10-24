using core.Board.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace core.Board
{
    public class Board
    {
        private Column _backlog;
        private Column _todo;
        private Column _inwork;
        private Column _resolved;
        private Column _closed;

        public event EventHandler<string> InfoMessage;

        public Board()
            : this(100, 100, 100, 100)
        { }

        public Board(BoardDTO dTO)
            : this(dTO.TodoWIP, dTO.InWorkWIP, dTO.ResolvedWIP, dTO.ClosedWIP)
        {
            foreach(var task in dTO.Backlog)
            {
                _backlog.AddTask(task);
            }

            foreach (var task in dTO.Todo)
            {
                _todo.AddTask(task);
            }

            foreach (var task in dTO.InWork)
            {
                _inwork.AddTask(task);
            }

            foreach (var task in dTO.Resolved)
            {
                _resolved.AddTask(task);
            }

            foreach (var task in dTO.Closed)
            {
                _closed.AddTask(task);
            }
        }

        public Board(int todoWIP, int inworkWIP, int resolvedWIP, int closedWIP)
        {
            _backlog = new Column(0);
            _todo = new Column(todoWIP);
            _inwork = new Column(inworkWIP);
            _resolved = new Column(resolvedWIP);
            _closed = new Column(closedWIP);
        }

        public BoardDTO ToDTO()
        {
            var dto = new BoardDTO
            {
                TodoWIP = _todo.WIP,
                InWorkWIP = _inwork.WIP,
                ResolvedWIP = _resolved.WIP,
                ClosedWIP = _closed.WIP,

                Backlog = new List<Feature>(_backlog.Tasks),
                Todo = new List<Feature>(_todo.Tasks),
                InWork = new List<Feature>(_inwork.Tasks),
                Resolved = new List<Feature>(_resolved.Tasks),
                Closed = new List<Feature>(_closed.Tasks)
            };

            return dto;
        }

        public void ClearBacklog()
        {
            _backlog.ClearColumn();
        }

        public void AddFeatureToBacklog(Feature feature)
        {
            _backlog.AddTask(feature);
        }

        public void RemoveFeatureFromBacklog(Feature feature)
        {
            _backlog.RemoveTask(feature);
        }

        public void PromoteFeatureToTodo(Feature feature)
        {
            _todo.AddTask(feature);
            _backlog.RemoveTask(feature);
        }

        public void DropFeatureFromTodo(Feature feature)
        {
            _backlog.AddTask(feature);
            _todo.RemoveTask(feature);

            KeepWorkQueue();
        }

        public void PromoteFeatureToInWork(Feature feature)
        {
            _inwork.AddTask(feature);
            _todo.RemoveTask(feature);

            KeepWorkQueue();
            
            if (_todo.Tasks.Count == 0 && _backlog.Tasks.Count == 0)
            {
                InfoMessage?.Invoke(this, "No planned work to do");
            }
        }

        public void DropFeatureFromInWork(Feature feature)
        {
            _todo.AddTask(feature);
            _inwork.RemoveTask(feature);
        }

        public void PromoteFeatureToResolved(Feature feature)
        {
            _resolved.AddTask(feature);
            _inwork.RemoveTask(feature);
        }

        public void DropFeatureFromResolved(Feature feature)
        {
            _todo.AddTask(feature);
            _resolved.RemoveTask(feature);
        }

        public void PromoteFeatureToClosed(Feature feature)
        {
            _closed.AddTask(feature);
            _resolved.RemoveTask(feature);

            if (_backlog.Tasks.Count == 0 && _todo.Tasks.Count == 0 && _inwork.Tasks.Count == 0 && _resolved.Tasks.Count == 0)
            {
                InfoMessage?.Invoke(this, "This is it");
            }
        }

        public ReadOnlyCollection<Feature> Backlog
        {
            get
            {
                return _backlog.Tasks;
            }
        }

        public ReadOnlyCollection<Feature> Todo
        {
            get
            {
                return _todo.Tasks;
            }
        }

        public ReadOnlyCollection<Feature> InWork
        {
            get
            {
                return _inwork.Tasks;
            }
        }

        public ReadOnlyCollection<Feature> Resolved
        {
            get
            {
                return _resolved.Tasks;
            }
        }

        public ReadOnlyCollection<Feature> Closed
        {
            get
            {
                return _closed.Tasks;
            }
        }

        public int TodoWIP
        {
            set { _todo.WIP = value; }
            get { return _todo.WIP; }
        }

        public int InWorkWIP
        {
            set { _inwork.WIP = value; }
            get { return _inwork.WIP; }
        }

        public int ResolvedWIP
        {
            set { _resolved.WIP = value; }
            get { return _resolved.WIP; }
        }

        public int ClosedWIP
        {
            set { _closed.WIP = value; }
            get { return _closed.WIP; }
        }

        public void Release()
        {
            if (_closed.Tasks.Count == 0) throw new EmptyReleaseException("No features to release");

            while (_closed.Tasks.Count > 0)
            {
                _closed.RemoveTask(_closed.Tasks[0]);
            }
        }

        private void KeepWorkQueue()
        {
            if (_todo.Tasks.Count == 0 && _backlog.Tasks.Count > 0)
            {
                var theMostICEScoreTask = FeatureSelector.SelectTheMostICEScoredFeature(new List<Feature>(_backlog.Tasks));

                PromoteFeatureToTodo(theMostICEScoreTask);

                InfoMessage?.Invoke(this, $"Task '{theMostICEScoreTask.Name}' promoted to TODO");
            }
        }
    }
}
