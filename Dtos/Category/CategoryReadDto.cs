namespace Categories.Dtos
{
    public class CategoryReadDto
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string categoryDesc { get; set; }
        public string imgLink { get; set; }
        public string location { get; set; }
        public string createdDate { get; set; }
        public string lastUpdatedDate { get; set; }
    }
}