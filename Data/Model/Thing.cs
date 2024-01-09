using DateTimeCheck.Data.Context;

namespace DateTimeCheck.Data.Model;

public class Thing
{
    public int Id { get; set; }
    public DateTime? When { get; set; }

    public override string ToString() => $"Id: {Id} When {When?.ToString("O")}";
}