namespace DatingAPI.Models
{
    public class BaseModel
    {

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = new DateTime();
    }
}
