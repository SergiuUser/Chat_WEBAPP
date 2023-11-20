namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MessageReactions")]
    public class MessageReactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] public int MessageReactionID { get; set; }
        [ForeignKey("ChatMessageID")]
        [Required] public ChatMessages MessageID { get; set; }
        [ForeignKey("UserID")]
        [Required] public User UserID { get; set; }
        [ForeignKey("ReactionTypeID")]
        [Required] public ReactionType ReactionTypeID { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
    }
}
