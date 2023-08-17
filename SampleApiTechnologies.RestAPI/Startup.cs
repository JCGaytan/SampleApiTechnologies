using Microsoft.EntityFrameworkCore;
using SampleApiTechnologies.DataAccess;
using SampleApiTechnologies.Entities;

namespace SampleApiTechnologies.RestAPI
{
    /// <summary>
    /// The startup class for configuring the application services and middleware.
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures the services for dependency injection.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add the database context using SQLite
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            // Add controllers for handling API requests
            services.AddControllers();

            // Add API documentation using Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        /// <summary>
        /// Configures the application and its middleware pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Enable Swagger and Swagger UI in development environment
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Ensure the database and schema are created
                dbContext.Database.EnsureCreated();

                if (!dbContext.ProgrammingLanguages.Any())
                {
                    // Seed the database with sample programming languages
                    dbContext.ProgrammingLanguages.AddRange(
                       new ProgrammingLanguage { Name = "Python", Description = "General-purpose programming language known for its readability." },
                       new ProgrammingLanguage { Name = "JavaScript", Description = "High-level, interpreted scripting language for web development." },
                       new ProgrammingLanguage { Name = "Java", Description = "Popular object-oriented programming language." },
                       new ProgrammingLanguage { Name = "C#", Description = "Modern programming language developed by Microsoft." },
                       new ProgrammingLanguage { Name = "C++", Description = "General-purpose programming language with a focus on performance." },
                       new ProgrammingLanguage { Name = "PHP", Description = "Server-side scripting language for web development." },
                       new ProgrammingLanguage { Name = "Swift", Description = "Programming language developed by Apple for iOS/macOS app development." },
                       new ProgrammingLanguage { Name = "Ruby", Description = "Dynamic, object-oriented programming language." },
                       new ProgrammingLanguage { Name = "Rust", Description = "Systems programming language with a focus on safety and performance." },
                       new ProgrammingLanguage { Name = "Go", Description = "Open-source programming language designed for concurrency and efficiency." },
                       new ProgrammingLanguage { Name = "Kotlin", Description = "Modern programming language that runs on the Java Virtual Machine (JVM)." },
                       new ProgrammingLanguage { Name = "TypeScript", Description = "Superset of JavaScript that adds optional static typing." },
                       new ProgrammingLanguage { Name = "SQL", Description = "Language for managing and querying relational databases." },
                       new ProgrammingLanguage { Name = "Perl", Description = "High-level, general-purpose programming language." },
                       new ProgrammingLanguage { Name = "Scala", Description = "Modern programming language that combines functional and object-oriented programming." },
                       new ProgrammingLanguage { Name = "Lua", Description = "Scripting language designed for embedded use in applications." },
                       new ProgrammingLanguage { Name = "Objective-C", Description = "Programming language used for iOS/macOS app development." },
                       new ProgrammingLanguage { Name = "Haskell", Description = "Purely functional programming language with strong static typing." },
                       new ProgrammingLanguage { Name = "Dart", Description = "Programming language developed by Google for building mobile, web, and desktop apps." },
                       new ProgrammingLanguage { Name = "COBOL", Description = "Business-oriented programming language often used for legacy systems." }
                   );
                    dbContext.SaveChanges();
                }
            }

            // Configure middleware pipeline
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}