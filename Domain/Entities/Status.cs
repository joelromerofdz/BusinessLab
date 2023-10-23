using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Status : BaseEntity
    {
        public bool StatusKey { get; set; }

        [Required(ErrorMessage = "The status name is required.")]
        public string StatusName { get; set; }
    }
}
