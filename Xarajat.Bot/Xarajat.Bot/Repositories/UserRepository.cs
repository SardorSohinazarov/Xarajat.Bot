using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Xarajat.Data.Context;

namespace Xarajat.Bot.Repositories;

public class UserRepository
{
    private readonly XarajatDbContext _xarajatBbContext;

    public UserRepository(XarajatDbContext xarajatBbContext)
    {
        _xarajatBbContext = xarajatBbContext;
    }

    public async Task<Data.Entities.User?> GetUserByChatId(long chatId) 
        => await _xarajatBbContext.Users
            .FirstOrDefaultAsync(user => user.ChatId == chatId);

    public async Task AddUserAsync(Data.Entities.User user)
    {
        await _xarajatBbContext.Users.AddAsync(user);
    }

    public async Task UpdateUser(Data.Entities.User user)
    {
        _xarajatBbContext.Update(user);
        await _xarajatBbContext.SaveChangesAsync(); 
    }
}
