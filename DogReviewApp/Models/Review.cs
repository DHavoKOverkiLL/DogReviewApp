namespace DogReviewApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public decimal Rating { get; internal set; }
        public ICollection<Reviewer> Reviewer { get; set;}
        public Dog Dog { get; set; }
    }
}