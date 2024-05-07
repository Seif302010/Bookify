namespace Bookify.Core.ViewModels
{
    public class AuthorViewModel : BaseModel
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}

