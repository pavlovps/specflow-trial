using System;
using System.Collections.Generic;

namespace core
{
    public static class FeatureSelector
    {
        public static Feature SelectTheMostICEScoredFeature(List<Feature> features)
        {
            if (features == null) throw new ArgumentNullException("No features");
            if (features.Count == 0) throw new ArgumentOutOfRangeException("Features list is empty");

            var result = features[0];

            for (int i = 1; i < features.Count; i++)
            {
                if (ICEScoreCalculator.GetICEScore(features[i]) > ICEScoreCalculator.GetICEScore(result))
                {
                    result = features[i];
                }
            }

            return result;
        }
    }
}
