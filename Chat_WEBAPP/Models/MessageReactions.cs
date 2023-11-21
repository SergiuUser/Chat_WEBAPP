namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MessageReactions")]
    public class MessageReactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int MessageReactionID { get; set; }
        private int MessageID { get; set; }
        private int UserID { get; set; }
        private int ReactionTypeID { get; set; }
        private DateTime CreatedAt { get; set; }
        [ForeignKey("MessageID")]
        private ChatMessages chatMessages { get; set; }
        [ForeignKey("UserID")]
        private User user { get; set; }
        [ForeignKey("ReactionTypeID")]
        private ReactionType reactionType { get; set; }
    }
}
