using System;
namespace core
{
    public static class ICEScoreCalculator
    {
        public static int GetICEScore(Feature feature)
        {
            if (feature == null) throw new ArgumentNullException("No feature provided");

            return feature.Confidence * feature.Ease * feature.Impact;
        }
    }
}
