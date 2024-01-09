using DateTimeCheck.Data.Context;
using NodaTime;

namespace DateTimeCheck.Data.Model;

public class Thing
{
    public int Id { get; set; }
    public ZonedDateTime? When { get; set; }

    public override string ToString() => $"Id: {Id} When {When?.ToString("uuuu-MM-dd HH:mm:ss;FFFFFFFFF", null)}";
}