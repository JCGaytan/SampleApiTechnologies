using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApiTechnologies.DataAccess;
using SampleApiTechnologies.Entities;

namespace SampleApiTechnologies.RestAPI.Controllers
{
    /// <summary>
    /// API controller for managing programming languages.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProgrammingLanguagesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgrammingLanguagesController"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ProgrammingLanguagesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets a list of programming languages with optional pagination and search.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgrammingLanguage>>> GetProgrammingLanguages(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string search = "")
        {
            IQueryable<ProgrammingLanguage> query = _dbContext.ProgrammingLanguages;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(language =>
                    language.Name.Contains(search) ||
                    language.Description.Contains(search));
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var languages = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Items = languages
            };

            return Ok(result);
        }

        /// <summary>
        /// Gets a programming language by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgrammingLanguage>> GetProgrammingLanguage(int id)
        {
            var language = await _dbContext.ProgrammingLanguages.FindAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        /// <summary>
        /// Creates a new programming language.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ProgrammingLanguage>> CreateProgrammingLanguage(ProgrammingLanguage language)
        {
            _dbContext.ProgrammingLanguages.Add(language);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProgrammingLanguage), new { id = language.Id }, language);
        }

        /// <summary>
        /// Updates an existing programming language by its ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgrammingLanguage(int id, ProgrammingLanguage language)
        {
            if (id != language.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(language).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammingLanguageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a programming language by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgrammingLanguage(int id)
        {
            var language = await _dbContext.ProgrammingLanguages.FindAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            _dbContext.ProgrammingLanguages.Remove(language);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Checks if a programming language exists by its ID.
        /// </summary>
        private bool ProgrammingLanguageExists(int id)
        {
            return _dbContext.ProgrammingLanguages.Any(e => e.Id == id);
        }
    }
}
