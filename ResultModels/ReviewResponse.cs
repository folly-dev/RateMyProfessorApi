namespace WebApiTutorials.ResultModels
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public string Course { get; set; }
        public decimal Quality { get; set; }
    }
}