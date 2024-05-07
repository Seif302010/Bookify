using Bookify.Core.Consts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookify.Core.ViewModels
{
    public class BookFormViewModel
    {
        public int Id { get; set; }
        [MaxLength(500, ErrorMessage = Errors.MAxLength)]
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }
        public IEnumerable<SelectListItem>? Authors { get; set; }
        [MaxLength(200, ErrorMessage = Errors.MAxLength)]
        public string Publisher { get; set; } = null!;
        public DateTime PublishingDate { get; set; } = DateTime.Now;
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        [MaxLength(50)]
        public string Hall { get; set; } = null!;
        public bool IsAvailabelForRental { get; set; }
        public string Description { get; set; } = null!;
        public IList<int> SelectedCategories { get; set; } = new List<int>();
        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
