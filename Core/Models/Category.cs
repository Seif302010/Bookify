namespace Bookify.Core.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category : BaseModel
    {

        [MaxLength(100, ErrorMessage = "Maximum Length is 100")]
        public string Name { get; set; } = null!;
        public ICollection<BookCategory> Books { get; set; } = new List<BookCategory>();
    }
}
