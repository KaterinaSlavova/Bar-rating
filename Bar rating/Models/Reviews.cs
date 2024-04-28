namespace Bar_rating.Models
{
    public class Reviews 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public string UserId { get; set; }
        public virtual AppUser? User { get; set; }
        public int BarId { get; set; }
        public virtual Bars? Bars { get; set; }
    }
}
