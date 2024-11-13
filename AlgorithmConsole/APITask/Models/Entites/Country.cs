using System.ComponentModel.DataAnnotations.Schema;

namespace APITask.Models.Entites
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public ICollection<CountryDetail> CountryDetails { get; set; }
    }
}