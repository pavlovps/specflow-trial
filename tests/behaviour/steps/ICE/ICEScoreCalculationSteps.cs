using core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace behaviour.steps.ICE
{
    [Binding]
    public class ICEScoreCalculationSteps
    {
        private Feature _feature;

        [Given(@"having a feature")]
        public void GivenHavingAFeature()
        {
            _feature = new Feature();
        }
        
        [When(@"feature's impact equals (.*)")]
        public void WhenFeatureSImpactEquals(int p0)
        {
            _feature.Impact = p0;
        }
        
        [When(@"feature's confidence equals (.*)")]
        public void WhenFeatureSConfidenceEquals(int p0)
        {
            _feature.Confidence = p0;
        }
        
        [When(@"feature's ease equals (.*)")]
        public void WhenFeatureSEaseEquals(int p0)
        {
            _feature.Ease = p0;
        }
        
        [Then(@"the score should be (.*)")]
        public void ThenTheScoreShouldBe(int p0)
        {
            var ICEScore = ICEScoreCalculator.GetICEScore(_feature);

            Assert.AreEqual(p0, ICEScore);
        }
    }
}
