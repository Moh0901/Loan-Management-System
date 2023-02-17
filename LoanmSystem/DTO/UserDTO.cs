using System.ComponentModel.DataAnnotations;

namespace LoanmSystem.DTO
{
    public class UserDTO
    {
        /*[Required]
        [StringLength(maximumLength: 20, MinimumLength = 5)]*/
        public string? name { get; set; }

        /*[Required]
        [StringLength(maximumLength: 20, MinimumLength = 5)]*/
        public string? username { get; set; }

       /* [Required]
        [StringLength(maximumLength: 20, MinimumLength = 5)]*/
        public string? password { get; set; }

        /*[Required]*/
        public string? role { get; set; }
    }
}
