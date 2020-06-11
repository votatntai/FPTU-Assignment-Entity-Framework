namespace Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Comments
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string Content { get; set; }

        public DateTime? Date { get; }

        public int? IdolID { get; set; }

        [StringLength(256)]
        public string Email { get; set; }
    }
}
