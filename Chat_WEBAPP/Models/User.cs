namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int UserID { get; set; }
         public string Username { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         [Required]
         [EmailAddress]
         public string Email { get; set; }
         public DateTime CreatedAt { get; set; }
         public DateTime LastUpdated { get; set; }
         [Required]
         public string PasswordHash { get; set; }
         public string AuthRole {  get; set; }

    }
}
