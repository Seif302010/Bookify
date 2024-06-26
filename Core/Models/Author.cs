﻿namespace Bookify.Core.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Author : BaseModel
    {
        [MaxLength(100, ErrorMessage = "Maximum Length is 100")]
        public string Name { get; set; } = null!;
    }
}