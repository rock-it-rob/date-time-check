using DateTimeCheck.Data.Context;
using DateTimeCheck.Data.Model;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using NodaTime.Extensions;

namespace App.Services;

public class ThingService : IThingService
{
    private readonly DataDbContext _context;

    public ThingService(DataDbContext context) => _context = context;

    public async Task<Thing> CreateAsync()
    {
        var thing = new Thing() { When = SystemClock.Instance.InUtc().GetCurrentZonedDateTime() };
        _context.Add(thing);
        await _context.SaveChangesAsync();
        return thing;
    }

    public async Task<int> UpdateAsync(Thing thing)
    {
        _context.Update(thing);
        return await _context.SaveChangesAsync();
    }

    public async Task<Thing?> GetById(int id) =>
        await _context
            .Things
            .AsNoTracking()
            .SingleOrDefaultAsync(t => t.Id == id);
}