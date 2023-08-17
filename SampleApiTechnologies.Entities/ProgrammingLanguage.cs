namespace SampleApiTechnologies.Entities
{
    /// <summary>
    /// Represents a programming language entity.
    /// </summary>
    public class ProgrammingLanguage
    {
        /// <summary>
        /// Gets or sets the unique identifier for the programming language.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the programming language.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the programming language.
        /// </summary>
        public string Description { get; set; }
    }
}