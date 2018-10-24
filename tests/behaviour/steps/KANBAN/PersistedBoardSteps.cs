using core;
using core.Board;
using keeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace behaviour.steps.KANBAN
{
    [Binding]
    public class PersistedBoardSteps
    {
        private Board _board;
        private string _fileName;

        public PersistedBoardSteps()
        {
            _board = new Board();
        }

        [Given(@"closed list has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void GivenClosedListHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var feature = new Feature
            {
                Name = p0,
                Impact = p1,
                Ease = p2,
                Confidence = p3
            };

            _board.AddFeatureToBacklog(feature);
            _board.PromoteFeatureToTodo(feature);
            _board.PromoteFeatureToInWork(feature);
            _board.PromoteFeatureToResolved(feature);
            _board.PromoteFeatureToClosed(feature);
        }
        
        [Given(@"resolved list has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void GivenResolvedListHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var feature = new Feature
            {
                Name = p0,
                Impact = p1,
                Ease = p2,
                Confidence = p3
            };

            _board.AddFeatureToBacklog(feature);
            _board.PromoteFeatureToTodo(feature);
            _board.PromoteFeatureToInWork(feature);
            _board.PromoteFeatureToResolved(feature);
        }
        
        [Given(@"in work list has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void GivenInWorkListHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var feature = new Feature
            {
                Name = p0,
                Impact = p1,
                Ease = p2,
                Confidence = p3
            };

            _board.AddFeatureToBacklog(feature);
            _board.PromoteFeatureToTodo(feature);
            _board.PromoteFeatureToInWork(feature);
        }
        
        [Given(@"todo list has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void GivenTodoListHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var feature = new Feature
            {
                Name = p0,
                Impact = p1,
                Ease = p2,
                Confidence = p3
            };

            _board.AddFeatureToBacklog(feature);
            _board.PromoteFeatureToTodo(feature);
        }
        
        [Given(@"backlog has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void GivenBacklogHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var feature = new Feature
            {
                Name = p0,
                Impact = p1,
                Ease = p2,
                Confidence = p3
            };

            _board.AddFeatureToBacklog(feature);
        }        

        [Given(@"closed WIP is (.*)")]
        public void GivenClosedWIPIs(int p0)
        {
            _board.ClosedWIP = p0;
        }

        [Given(@"resolved WIP is (.*)")]
        public void GivenResolvedWIPIs(int p0)
        {
            _board.ResolvedWIP = p0;
        }

        [Given(@"in work WIP is (.*)")]
        public void GivenInWorkWIPIs(int p0)
        {
            _board.InWorkWIP = p0;
        }

        [Given(@"todo WIP is (.*)")]
        public void GivenTodoWIPIs(int p0)
        {
            _board.TodoWIP = p0;
        }

        [Given(@"board doesnt exist")]
        public void GivenBoardDoesntExist()
        {
            _board = null;
        }

        [Given(@"tmp file exists having '(.*)'")]
        public void GivenTmpFileExistsHaving(string p0)
        {
            _fileName = Path.GetTempPath() + Guid.NewGuid().ToString() + ".json";

            File.WriteAllText(_fileName, p0);
        }

        [When(@"I save board to tmp file")]
        public void WhenISaveBoardToTmpFile()
        {
            _fileName = Path.GetTempPath() + Guid.NewGuid().ToString() + ".json";

            new FileSystemKeeper(_fileName).Save(_board);
        }

        [When(@"tmp file is loaded to board")]
        public void WhenTmpFileIsLoadedToBoard()
        {
            _board = new FileSystemKeeper(_fileName).Load();
        }

        [When(@"'(.*)' is loaded to board")]
        public void WhenIsLoadedToBoard(string p0)
        {
            _board = new FileSystemKeeper(p0).Load();
        }

        [Then(@"tmp file contains '(.*)'")]
        public void ThenTmpFileContains(string p0)
        {
            var fileContent = File.ReadAllText(_fileName);

            Assert.AreEqual(p0, fileContent);
        }

        [Then(@"board exists")]
        public void ThenBoardExists()
        {
            Assert.AreNotEqual(null, _board);
        }

        [Then(@"closed list has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void ThenClosedListHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var thisTask = _board.Closed.Single(task =>
                task.Name == p0 &&
                task.Impact == p1 &&
                task.Ease == p2 &&
                task.Confidence == p3);
        }

        [Then(@"closed WIP is (.*)")]
        public void ThenClosedWIPIs(int p0)
        {
            Assert.AreEqual(p0, _board.ClosedWIP);
        }

        [Then(@"resolved list has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void ThenResolvedListHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var thisTask = _board.Resolved.Single(task =>
                task.Name == p0 &&
                task.Impact == p1 &&
                task.Ease == p2 &&
                task.Confidence == p3);
        }

        [Then(@"resolved WIP is (.*)")]
        public void ThenResolvedWIPIs(int p0)
        {
            Assert.AreEqual(p0, _board.ResolvedWIP);
        }

        [Then(@"in work list has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void ThenInWorkListHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var thisTask = _board.InWork.Single(task =>
                task.Name == p0 &&
                task.Impact == p1 &&
                task.Ease == p2 &&
                task.Confidence == p3);
        }

        [Then(@"in work WIP is (.*)")]
        public void ThenInWorkWIPIs(int p0)
        {
            Assert.AreEqual(p0, _board.InWorkWIP);
        }

        [Then(@"todo list has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void ThenTodoListHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var thisTask = _board.Todo.Single(task =>
                task.Name == p0 &&
                task.Impact == p1 &&
                task.Ease == p2 &&
                task.Confidence == p3);
        }

        [Then(@"todo WIP is (.*)")]
        public void ThenTodoWIPIs(int p0)
        {
            Assert.AreEqual(p0, _board.TodoWIP);
        }

        [Then(@"backlog has '(.*)' task with impact (.*) ease (.*) confidence (.*)")]
        public void ThenBacklogHasTaskWithImpactEaseConfidence(string p0, int p1, int p2, int p3)
        {
            var thisTask = _board.Backlog.Single(task =>
                task.Name == p0 &&
                task.Impact == p1 &&
                task.Ease == p2 &&
                task.Confidence == p3);
        }
    }
}