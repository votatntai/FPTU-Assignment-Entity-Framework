namespace Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Idols
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(500)]
        [Required]
        public string Description { get; set; }

        public string Gender { get; set; }

        [Required]
        public int? Phone { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public double? Star { get; set; }
    }
}
