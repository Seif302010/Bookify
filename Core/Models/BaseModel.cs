namespace Bookify.Core.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? LastUpdateOn { get; set; }
    }
}