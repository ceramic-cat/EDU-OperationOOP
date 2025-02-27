using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Keyboard> Keyboards { get; set; }
        List<Mouse> Mice {  get; set; }
        List<Mousepad> Mousepads { get; set; }
    }

    public class Database : IDatabase
    {
        public List<Keyboard> Keyboards { get; set; } = new List<Keyboard>();
        public List<Mouse> Mice { get; set; } = new List<Mouse>();
        public List<Mousepad> Mousepads { get; set; } = new List<Mousepad> { };

    }
}
