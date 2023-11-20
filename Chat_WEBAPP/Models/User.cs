namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] public int UserID { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public BinaryData PasswordHash { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
        [Required] public DateTime LastUpdated { get; set; }

    }
}
