using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }
        List<Keyboard> Keyboards { get; set; }
        int GetProductId();
    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();
        public List<Keyboard> Keyboards { get; set; } = new List<Keyboard>();
        public int GetProductId() => Keyboards.Any()
        ? Keyboards.Max(x => x.Id) + 1
        : 1;
    }
}
