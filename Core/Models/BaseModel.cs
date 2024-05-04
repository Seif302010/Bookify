namespace Bookify.Core.Models
{
    public class BaseModel
    {
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? LastUpdateOn { get; set; }
    }
}