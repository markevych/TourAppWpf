using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourApp.DAL.Models
{
    public class Route
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int FromCityId { get; set; }
        public City FromCity { get; set; }

        public int ToCityId { get; set; }
        public City ToCity { get; set; }

        public bool IsFlight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
    }
}
