using core.Board;

namespace keeper
{
    public interface IKeeper
    {
        void Save(Board board);
        Board Load();
    }
}
