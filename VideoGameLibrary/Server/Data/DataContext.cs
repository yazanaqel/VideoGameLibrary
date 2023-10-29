using VideoGameLibrary.Shared;

namespace VideoGameLibrary.Server.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }

    public DbSet<VideoGame> VideoGames { get; set; }
}
