using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<BookingDataContext>
{
    public BookingDataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookingDataContext>();

        var connectionString = Environment.GetEnvironmentVariable("SqlConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new BookingDataContext(optionsBuilder.Options);
    }


}