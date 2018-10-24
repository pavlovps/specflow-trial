using core;
using core.Board;
using core.Board.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace behaviour.steps.KANBAN
{
    [Binding]
    public class BoardTaskPipeSteps
    {
        private Board _board;
        private Exception _lastException;
        private string _lastMessage = string.Empty;

        [Given(@"backlog having (.*) tasks")]
        public void GivenBacklogHavingTasks(int p0)
        {
            _board = new Board(100, 100, 100, 100);

            for (int i = 0; i < p0; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"feature{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });
            }
        }

        [Given(@"backlog having (.*) tasks and todo list having (.*) tasks")]
        public void GivenBacklogHavingTasksAndTodoListHavingTasks(int p0, int p1)
        {
            _board = new Board(100, 100, 100, 100);

            for (int i = 0; i < p1; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInTODO{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);
            }

            for (int i = 0; i < p0; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"feature{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });
            }
        }
        
        [Given(@"todo column WIP is (.*)")]
        public void GivenTodoColumnWIPIs(int p0)
        {
            _board.TodoWIP = p0;
        }
        
        [Given(@"todo list having (.*) tasks and in work list having (.*) tasks")]
        public void GivenTodoListHavingTasksAndInWorkListHavingTasks(int p0, int p1)
        {
            _board = new Board(100, 100, 100, 100);

            for (int i = 0; i < p1; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInWork{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);
            }

            for (int i = 0; i < p0; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInTODO{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);
            }
        }
        
        [Given(@"in work column WIP is (.*)")]
        public void GivenInWorkColumnWIPIs(int p0)
        {
            _board.InWorkWIP = p0;
        }
        
        [Given(@"in work list having (.*) tasks and resolved list having (.*) tasks")]
        public void GivenInWorkListHavingTasksAndResolvedListHavingTasks(int p0, int p1)
        {
            _board = new Board(100, 100, 100, 100);

            for (int i = 0; i < p1; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInResolved{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);

                _board.PromoteFeatureToResolved(task);
            }

            for (int i = 0; i < p0; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInWork{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);
            }
        }
        
        [Given(@"resolved column WIP is (.*)")]
        public void GivenResolvedColumnWIPIs(int p0)
        {
            _board.ResolvedWIP = p0;
        }
        
        [Given(@"resolved list having (.*) tasks and closed list having (.*) tasks")]
        public void GivenResolvedListHavingTasksAndClosedListHavingTasks(int p0, int p1)
        {
            _board = new Board(100, 100, 100, 100);

            for (int i = 0; i < p1; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInClosed{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);

                _board.PromoteFeatureToResolved(task);

                _board.PromoteFeatureToClosed(task);
            }

            for (int i = 0; i < p0; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInResolved{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);

                _board.PromoteFeatureToResolved(task);
            }
        }
        
        [Given(@"closed column WIP is (.*)")]
        public void GivenClosedColumnWIPIs(int p0)
        {
            _board.ClosedWIP = p0;
        }
        
        [Given(@"todo list having (.*) tasks and resolved list having (.*) tasks")]
        public void GivenTodoListHavingTasksAndResolvedListHavingTasks(int p0, int p1)
        {
            _board = new Board(100, 100, 100, 100);

            for (int i = 0; i < p1; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInResolved{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);

                _board.PromoteFeatureToResolved(task);
            }

            for (int i = 0; i < p0; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInTODO{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);
            }
        }
        
        [Given(@"closed list having (.*) tasks")]
        public void GivenClosedListHavingTasks(int p0)
        {
            _board = new Board(100, 100, 100, 100);

            for (int i = 0; i < p0; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInClosed{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);

                _board.PromoteFeatureToResolved(task);

                _board.PromoteFeatureToClosed(task);
            }
        }
        
        [Given(@"backlog task Chatbot impact is (.*) ease is (.*) confidence is (.*)")]
        public void GivenBacklogTaskChatbotImpactIsEaseIsConfidenceIs(int p0, int p1, int p2)
        {
            if (_board == null) _board = new Board(100, 100, 100, 100);

            _board.AddFeatureToBacklog(
                new Feature
                {
                    Name = "Chatbot",
                    Impact = p0,
                    Ease = p1,
                    Confidence = p2
                });
        }
        
        [Given(@"backlog task Dashboard impact is (.*) ease is (.*) confidence is (.*)")]
        public void GivenBacklogTaskDashboardImpactIsEaseIsConfidenceIs(int p0, int p1, int p2)
        {
            if (_board == null) _board = new Board(100, 100, 100, 100);

            _board.AddFeatureToBacklog(
                new Feature
                {
                    Name = "Dashboard",
                    Impact = p0,
                    Ease = p1,
                    Confidence = p2
                });
        }
        
        [Given(@"backlog task Mobile client impact is (.*) ease is (.*) confidence is (.*)")]
        public void GivenBacklogTaskMobileClientImpactIsEaseIsConfidenceIs(int p0, int p1, int p2)
        {
            if (_board == null) _board = new Board(100, 100, 100, 100);

            _board.AddFeatureToBacklog(
                new Feature
                {
                    Name = "Mobile",
                    Impact = p0,
                    Ease = p1,
                    Confidence = p2
                });
        }
        
        [Given(@"backlog task Cloud impact is (.*) ease is (.*) confidence is (.*)")]
        public void GivenBacklogTaskCloudImpactIsEaseIsConfidenceIs(int p0, int p1, int p2)
        {
            if (_board == null) _board = new Board(100, 100, 100, 100);

            _board.AddFeatureToBacklog(
                new Feature
                {
                    Name = "Cloud",
                    Impact = p0,
                    Ease = p1,
                    Confidence = p2
                });
        }
        
        [Given(@"backlog having (.*) tasks and todo list having (.*) tasks and in work list having (.*) tasks and resolved list having (.*) tasks and closed list having (.*) tasks")]
        public void GivenBacklogHavingTasksAndTodoListHavingTasksAndInWorkListHavingTasksAndResolvedListHavingTasksAndClosedListHavingTasks(int p0, int p1, int p2, int p3, int p4)
        {
            _board = new Board(100, 100, 100, 100);

            for (int i = 0; i < p4; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInClosed{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);

                _board.PromoteFeatureToResolved(task);

                _board.PromoteFeatureToClosed(task);
            }
            
            for (int i = 0; i < p3; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInResolved{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);

                _board.PromoteFeatureToResolved(task);
            }

            for (int i = 0; i < p2; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInWork{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);

                _board.PromoteFeatureToInWork(task);
            }

            for (int i = 0; i < p1; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInTODO{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });

                var task = _board.Backlog[0];

                _board.PromoteFeatureToTodo(task);
            }

            for (int i = 0; i < p0; i++)
            {
                _board.AddFeatureToBacklog(
                    new Feature
                    {
                        Name = $"featureInBacklog{i}",
                        Ease = i,
                        Confidence = i,
                        Impact = i
                    });
            }
        }

        [When(@"promote last todo task to in work")]
        public void WhenPromoteLastTodoTaskToInWork()
        {
            _board.InfoMessage += (sender, e) => { _lastMessage = e; };

            while (_board.Todo.Count > 0)
            {
                var task = _board.Todo[0];

                _board.PromoteFeatureToInWork(task);
            }

            var triggerFeature = new Feature();

            _board.AddFeatureToBacklog(triggerFeature);

            _board.PromoteFeatureToTodo(triggerFeature);

            _board.PromoteFeatureToInWork(triggerFeature);
        }

        [When(@"adding task to backlog")]
        public void WhenAddingTaskToBacklog()
        {
            _board.AddFeatureToBacklog(new Feature());
        }
        
        [When(@"removing task from backlog")]
        public void WhenRemovingTaskFromBacklog()
        {
            _board.RemoveFeatureFromBacklog(_board.Backlog[0]);
        }
        
        [When(@"promote task from backlog to todo list")]
        public void WhenPromoteTaskFromBacklogToTodoList()
        {
            try
            {
                _lastException = null;

                _board.PromoteFeatureToTodo(_board.Backlog[0]);
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }
        
        [When(@"drop task from todo list")]
        public void WhenDropTaskFromTodoList()
        {
            _board.DropFeatureFromTodo(_board.Todo[0]);
        }
        
        [When(@"promote task from todo list to in work list")]
        public void WhenPromoteTaskFromTodoListToInWorkList()
        {
            try
            {
                _lastException = null;

                _board.PromoteFeatureToInWork(_board.Todo[0]);
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }
        
        [When(@"promote task from in work list to resolved list")]
        public void WhenPromoteTaskFromInWorkListToResolvedList()
        {
            try
            {
                _lastException = null;

                _board.PromoteFeatureToResolved(_board.InWork[0]);
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }
        
        [When(@"drop task from in work list")]
        public void WhenDropTaskFromInWorkList()
        {
            try
            {
                _lastException = null;

                _board.DropFeatureFromInWork(_board.InWork[0]);
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }
        
        [When(@"promote task from resolved list to closed list")]
        public void WhenPromoteTaskFromResolvedListToClosedList()
        {
            try
            {
                _lastException = null;

                _board.InfoMessage += (sender, e) => { _lastMessage = e; };

                _board.PromoteFeatureToClosed(_board.Resolved[0]);
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }
        
        [When(@"drop task from resolved list")]
        public void WhenDropTaskFromResolvedList()
        {
            try
            {
                _lastException = null;

                _board.DropFeatureFromResolved(_board.Resolved[0]);
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }
        
        [When(@"release")]
        public void WhenRelease()
        {
            try
            {
                _lastException = null;

                _board.Release();
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }
        }
        
        [Then(@"backlog having (.*) tasks")]
        public void ThenBacklogHavingTasks(int p0)
        {
            Assert.AreEqual(p0, _board.Backlog.Count);
        }
        
        [Then(@"todo list having (.*) tasks")]
        public void ThenTodoListHavingTasks(int p0)
        {
            Assert.AreEqual(p0, _board.Todo.Count);
        }
        
        [Then(@"WIP is full exception is raised")]
        public void ThenWIPIsFullExceptionIsRaised()
        {
            Assert.IsInstanceOfType(_lastException, typeof(ColumnWIPReachedException));
        }
        
        [Then(@"in work list having (.*) tasks")]
        public void ThenInWorkListHavingTasks(int p0)
        {
            Assert.AreEqual(p0, _board.InWork.Count);
        }
        
        [Then(@"resolved list having (.*) tasks")]
        public void ThenResolvedListHavingTasks(int p0)
        {
            Assert.AreEqual(p0, _board.Resolved.Count);
        }
        
        [Then(@"closed list having (.*) tasks")]
        public void ThenClosedListHavingTasks(int p0)
        {
            Assert.AreEqual(p0, _board.Closed.Count);
        }
        
        [Then(@"Empty release exception raised")]
        public void ThenEmptyReleaseExceptionRaised()
        {
            Assert.IsInstanceOfType(_lastException, typeof(EmptyReleaseException));
        }
        
        [Then(@"todo list task ICE score is (.*)")]
        public void ThenTodoListTaskICEScoreIs(int p0)
        {
            var iceScore = ICEScoreCalculator.GetICEScore(_board.Todo[0]);

            Assert.AreEqual(p0, iceScore);
        }
        
        [Then(@"todo list task name is Mobile client")]
        public void ThenTodoListTaskNameIsMobileClient()
        {
            var taskName = _board.Todo[0].Name;

            Assert.IsTrue(taskName.Contains("Mobile"));
        }
        
        [Then(@"Congratulate with no tasks to process")]
        public void ThenCongratulateWithNoTasksToProcess()
        {
            Assert.IsTrue(_lastMessage.Contains("No planned work to do"));
        }
        
        [Then(@"Congratulate with no work to do")]
        public void ThenCongratulateWithNoWorkToDo()
        {
            Assert.IsTrue(_lastMessage.Contains("This is it"));
        }

        [Then(@"backlog dont have Mobile client task")]
        public void ThenBacklogDontHaveMobileClientTask()
        {
            var hasMobileClientTask = _board.Backlog.Any(task => task.Name.Contains("Mobile"));

            Assert.IsFalse(hasMobileClientTask);
        }

        [Then(@"promotion message has been sent")]
        public void ThenPromotionMessageHasBeenSent()
        {
            Assert.IsTrue(_lastMessage.Contains("TODO"));
        }
    }
}
