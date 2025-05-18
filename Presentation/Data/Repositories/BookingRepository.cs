using Microsoft.EntityFrameworkCore;
using Presentation.Data.Contexts;
using Presentation.Data.Entities;
using Presentation.Interfaces;
using Presentation.Models;
using System.Linq.Expressions;

namespace Presentation.Data.Repositories;

public class BookingRepository(DataContext context) : BaseRepository<BookingEntity>(context), IBookingRepository
{
    public override async Task<RepoResult<IEnumerable<BookingEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _table
                .Include(i => i.BookingOwner)
                .ThenInclude(i => i!.BookingOwnerAddress)
                .ToListAsync();
            return new RepoResult<IEnumerable<BookingEntity>> { Success = true, Data = entities };
        }
        catch (Exception ex)
        {
            return new RepoResult<IEnumerable<BookingEntity>> { Success = false, Error = ex.Message };
        }
    }

    public override async Task<RepoResult<BookingEntity>> GetAsync(Expression<Func<BookingEntity, bool>> expression)
    {
        try
        {
            var entity = await _table
                .Include(i => i.BookingOwner)
                .ThenInclude(i => i!.BookingOwnerAddress)
                .FirstOrDefaultAsync(expression) ?? throw new Exception("Entity not found");
            return new RepoResult<BookingEntity> { Success = true, Data = entity };
        }
        catch (Exception ex)
        {
            return new RepoResult<BookingEntity> { Success = false, Error = ex.Message };
        }
    }
}
