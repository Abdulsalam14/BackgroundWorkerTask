namespace WebApplication5.Entities
{
    public class OmdbResponse
    {
        public List<Movie> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }
}
