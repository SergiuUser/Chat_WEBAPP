namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Chats")]
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] public int ChatID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Type { get; set; }
        [ForeignKey("UserID")]
        [Required] public User CreatorID { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
        [Required] public DateTime LastUpdated { get; set;}
    }
}
