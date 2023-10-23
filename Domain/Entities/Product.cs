using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "The product name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The stock is required.")]
        public int Stock { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "The price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The discount is required.")]
        [Range(0, 100)]
        public int Discount { get; set; }

        public decimal FinalPrice
        {
            get => Price * (100 - Discount) / 100;
        }

        [Required(ErrorMessage = "The Status is required.")]
        public Guid StatusId { get; set; }

        public virtual Status Status { get; set; }
    }
}
