using core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace behaviour.steps.ICE
{
    [Binding]
    public class FeatureSelectorSteps
    {
        private List<Feature> _features;
        private Feature _selectedFeature;

        [Given(@"empty list")]
        public void GivenEmptyList()
        {
            _features = new List<Feature>();
        }
        
        [Given(@"list with a single feature")]
        public void GivenListWithASingleFeature()
        {
            _features = new List<Feature>
            {
                new Feature
                {
                    Name = "singlefeature",
                    Ease = 3,
                    Confidence = 5,
                    Impact = 9
                }
            };
        }
        
        [Given(@"list contains multiple features")]
        public void GivenListContainsMultipleFeatures()
        {
            _features = new List<Feature>
            {
                new Feature
                {
                    Name = "feature1",
                    Ease = 3,
                    Confidence = 5,
                    Impact = 9
                },
                new Feature
                {
                    Name = "feature2",
                    Ease = 3,
                    Confidence = 7,
                    Impact = 4
                },
                new Feature
                {
                    Name = "feature3",
                    Ease = 7,
                    Confidence = 7,
                    Impact = 7
                },
                new Feature
                {
                    Name = "feature4",
                    Ease = 3,
                    Confidence = 3,
                    Impact = 3
                },
                new Feature
                {
                    Name = "feature6",
                    Ease = 1,
                    Confidence = 2,
                    Impact = 3
                }
            };
        }
        
        [Given(@"list contains multiple features with few having the same score")]
        public void GivenListContainsMultipleFeaturesWithFewHavingTheSameScore()
        {
            _features = new List<Feature>
            {
                new Feature
                {
                    Name = "feature1",
                    Ease = 3,
                    Confidence = 5,
                    Impact = 9
                },
                new Feature
                {
                    Name = "feature2",
                    Ease = 5,
                    Confidence = 9,
                    Impact = 3
                },
                new Feature
                {
                    Name = "feature3",
                    Ease = 1,
                    Confidence = 1,
                    Impact = 1
                },
                new Feature
                {
                    Name = "feature4",
                    Ease = 9,
                    Confidence = 3,
                    Impact = 5
                },
                new Feature
                {
                    Name = "feature6",
                    Ease = 1,
                    Confidence = 2,
                    Impact = 3
                }
            };
        }

        [Given(@"list contains multiple features with the most on the first position")]
        public void GivenListContainsMultipleFeaturesWithTheMostOnTheFirstPosition()
        {
            _features = new List<Feature>
            {
                new Feature
                {
                    Name = "feature1",
                    Ease = 9,
                    Confidence = 9,
                    Impact = 9
                },
                new Feature
                {
                    Name = "feature2",
                    Ease = 5,
                    Confidence = 9,
                    Impact = 3
                },
                new Feature
                {
                    Name = "feature3",
                    Ease = 7,
                    Confidence = 7,
                    Impact = 7
                },
                new Feature
                {
                    Name = "feature4",
                    Ease = 9,
                    Confidence = 3,
                    Impact = 5
                },
                new Feature
                {
                    Name = "feature6",
                    Ease = 1,
                    Confidence = 2,
                    Impact = 3
                }
            };
        }

        [Given(@"list contains multiple features with the most on the last position")]
        public void GivenListContainsMultipleFeaturesWithTheMostOnTheLastPosition()
        {
            _features = new List<Feature>
            {
                new Feature
                {
                    Name = "feature1",
                    Ease = 1,
                    Confidence = 1,
                    Impact = 1
                },
                new Feature
                {
                    Name = "feature2",
                    Ease = 5,
                    Confidence = 9,
                    Impact = 3
                },
                new Feature
                {
                    Name = "feature3",
                    Ease = 7,
                    Confidence = 7,
                    Impact = 7
                },
                new Feature
                {
                    Name = "feature4",
                    Ease = 9,
                    Confidence = 3,
                    Impact = 5
                },
                new Feature
                {
                    Name = "feature5",
                    Ease = 9,
                    Confidence = 9,
                    Impact = 9
                }
            };
        }

        [When(@"searching for the most valued feature")]
        public void WhenSearchingForTheMostValuedFeature()
        {
            try
            {
                _selectedFeature = FeatureSelector.SelectTheMostICEScoredFeature(_features);
            }
            catch
            {
                _selectedFeature = new Feature
                {
                    Name = "exception fired"
                };
            }
        }
        
        [Then(@"exception raised")]
        public void ThenExceptionRaised()
        {
            Assert.AreEqual("exception fired", _selectedFeature.Name);
        }
        
        [Then(@"this task is selected")]
        public void ThenThisTaskIsSelected()
        {
            Assert.AreEqual("singlefeature", _selectedFeature.Name);
        }
        
        [Then(@"the most valued feature is selected")]
        public void ThenTheMostValuedFeatureIsSelected()
        {
            Assert.AreEqual("feature3", _selectedFeature.Name);
        }
        
        [Then(@"first of the most valued features is selected")]
        public void ThenFirstOfTheMostValuedFeaturesIsSelected()
        {
            Assert.AreEqual("feature1", _selectedFeature.Name);
        }

        [Then(@"first feature is returned")]
        public void ThenFirstFeatureIsReturned()
        {
            Assert.AreEqual("feature1", _selectedFeature.Name);
        }

        [Then(@"last feature is returned")]
        public void ThenLastFeatureIsReturned()
        {
            Assert.AreEqual("feature5", _selectedFeature.Name);
        }
    }
}
