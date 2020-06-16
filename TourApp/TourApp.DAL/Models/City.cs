using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourApp.DAL.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<Route> FromCities { get; set; }
        public virtual ICollection<Route> ToCities { get; set; }
    }
}
