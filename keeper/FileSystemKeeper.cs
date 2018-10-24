using core.Board;
using Newtonsoft.Json;
using System.IO;

namespace keeper
{
    public class FileSystemKeeper : IKeeper
    {
        public string FileName { get; }

        public FileSystemKeeper(string fileName)
        {
            FileName = fileName;
        }

        public void Save(Board board)
        {
            var serializedBoard = JsonConvert.SerializeObject(board.ToDTO());

            Directory.CreateDirectory(Path.GetDirectoryName(FileName));

            File.WriteAllText(FileName, serializedBoard);
        }

        public Board Load()
        {
            var serializedBoard = File.ReadAllText(FileName);

            var dto = JsonConvert.DeserializeObject<BoardDTO>(serializedBoard);

            return new Board(dto);
        }
    }
}
