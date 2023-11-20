namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChatMessages")]
    public class ChatMessages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] public int ChatMessageID { get; set; }
        [ForeignKey("ChatID")]
        [Required] public Chat ChatID { get; set; }
        [ForeignKey("ChatID")]
        [Required] public Chat SenderID { get; set; }
        [Required] public string Content { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
        [Required] public int Edited { get; set; }
    }
}
