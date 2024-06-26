﻿namespace Bookify.Core.Models
{
    [Index(nameof(Title), nameof(AuthorId), IsUnique = true)]
    public class Book : BaseModel
    {
        [MaxLength(500)]
        public string Title { get; set; } = null!;

        [MaxLength(200)]
        public string Publisher { get; set; } = null!;
        public DateTime PublishingDate { get; set; }
        public string? ImageUrl { get; set; }
        [MaxLength(50)]
        public string Hall { get; set; } = null!;
        public bool IsAvailabelForRental { get; set; }
        public string Description { get; set; } = null!;
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public ICollection<BookCategory> Categories { get; set; } = new List<BookCategory>();
    }
}
