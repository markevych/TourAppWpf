using System.ComponentModel.DataAnnotations.Schema;

namespace TourApp.DAL.Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double VisaPrice { get; set; }
    }
}
