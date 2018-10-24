using System.Collections.Generic;

namespace core.Board
{
    public class BoardDTO
    {
        public List<Feature> Backlog { get; set; }
        public List<Feature> Todo { get; set; }
        public List<Feature> InWork { get; set; }
        public List<Feature> Resolved { get; set; }
        public List<Feature> Closed { get; set; }

        public int TodoWIP { get; set; }
        public int InWorkWIP { get; set; }
        public int ResolvedWIP { get; set; }
        public int ClosedWIP { get; set; }
    }
}
