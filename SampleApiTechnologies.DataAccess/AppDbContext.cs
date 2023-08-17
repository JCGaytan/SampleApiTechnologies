using Microsoft.EntityFrameworkCore;
using SampleApiTechnologies.Entities;

namespace SampleApiTechnologies.DataAccess
{
    /// <summary>
    /// Represents the application's database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet of ProgrammingLanguage entities in the database.
        /// </summary>
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used for configuring the context.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // The base class constructor is responsible for initializing the context with the provided options.
        }
    }
}