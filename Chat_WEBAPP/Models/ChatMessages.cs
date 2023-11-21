namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChatMessages")]
    public class ChatMessages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int ChatMessageID { get; set; }
        private int ChatID { get; set; }
        private int SenderID { get; set; }
        private string Content { get; set; }
        private DateTime CreatedAt { get; set; }
        private int Edited { get; set; }

        [ForeignKey("ChatID")]
        private Chat chat { get; set; }
        [ForeignKey("SenderID")]
        private User userSender { get; set; }
    }
}
