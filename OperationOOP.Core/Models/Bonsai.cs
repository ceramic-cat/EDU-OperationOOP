namespace OperationOOP.Core.Models;
public class Bonsai
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int AgeYears { get; set; }
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }
    public BonsaiStyle Style { get; set; }
    public CareLevel CareLevel { get; set; }
}

public enum BonsaiStyle
{
    Chokkan,    // Formal Upright
    Moyogi,     // Informal Upright
    Shakan,     // Slanting
    Kengai,     // Cascade
    HanKengai   // Semi-cascade
}

public enum CareLevel
{
    Beginner,
    Intermediate,
    Advanced,
    Master
} 