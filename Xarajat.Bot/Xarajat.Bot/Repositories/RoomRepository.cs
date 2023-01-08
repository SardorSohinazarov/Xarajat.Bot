using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Xarajat.Data.Context;
using Xarajat.Data.Entities;

namespace Xarajat.Bot.Repositories;

public class RoomRepository
{
    private readonly XarajatDbContext _xarajatBbContext;

    public RoomRepository(XarajatDbContext xarajatBbContext)
    {
        _xarajatBbContext = xarajatBbContext;
    }

    public async Task<Room?> GetRoomById(int id) 
        => await _xarajatBbContext.Rooms.FindAsync(id);

    public async Task AddRoomAsync(Room room)
    {
        await _xarajatBbContext.Rooms.AddAsync(room);
        await _xarajatBbContext.SaveChangesAsync(); 
    }

    public async Task UpdateRoomAsync(Room room)
    {
        _xarajatBbContext.Update(room);
        _xarajatBbContext.SaveChanges();
    }
}
