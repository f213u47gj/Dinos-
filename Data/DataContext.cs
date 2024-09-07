using DinoGame.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DinoDino.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Score> Scores { get; set; } = default!;
    }

}
