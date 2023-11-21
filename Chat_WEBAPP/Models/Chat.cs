namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Chats")]
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int ChatID { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private string Type { get; set; }
        private int CreatorID { get; set; }
        private DateTime CreatedAt { get; set; }
        private DateTime LastUpdated { get; set;}

        [ForeignKey("CreatorID")]
        private User userCreator { get; set; }

    }
}
