namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MessageReactions")]
    public class MessageReactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageReactionID { get; set; }
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public int ReactionTypeID { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("MessageID")]
        public ChatMessages chatMessages { get; set; }
        [ForeignKey("UserID")]
        public User user { get; set; }
        [ForeignKey("ReactionTypeID")]
        public ReactionType reactionType { get; set; }
    }
}
