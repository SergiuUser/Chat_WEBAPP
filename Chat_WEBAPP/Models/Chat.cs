namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Chats")]
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatID { get; set; }
        public string ChName { get; set; }
        public string ChDescription { get; set; }
        public string Chtype { get; set; }
        public int CreatorID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set;}

        [ForeignKey("CreatorID")]
        public User userCreator { get; set; }

    }
}
