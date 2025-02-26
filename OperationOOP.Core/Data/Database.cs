using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Keyboard> Keyboards { get; set; }
    }

    public class Database : IDatabase
    {
        public List<Keyboard> Keyboards { get; set; } = new List<Keyboard>();

    }
}
