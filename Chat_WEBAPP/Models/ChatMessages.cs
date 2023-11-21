namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChatMessages")]
    public class ChatMessages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatMessageID { get; set; }
        public int ChatID { get; set; }
        public int SenderID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Edited { get; set; }

        [ForeignKey("ChatID")]
        private Chat chat { get; set; }
        [ForeignKey("SenderID")]
        private User userSender { get; set; }
    }
}
