namespace APITask.Models.DTOs
{
    public class CountryDTO
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public ICollection<CountryDetailDTO> CountryDetails { get; set; }
    }
}