namespace PetrofMusicStore.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Instrument Type")]
        public string ProductType { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "CustomErrorMessage")]
        [DisplayName("Instrument Brand")]
        public string ProductBrand { get; set; }
    }
}