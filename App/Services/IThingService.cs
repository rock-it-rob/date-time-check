using DateTimeCheck.Data.Model;

namespace App.Services;

public interface IThingService
{
    public Task<Thing> CreateAsync();
    public Task<int> UpdateAsync(Thing thing);
    public Task<Thing?> GetById(int id);
}