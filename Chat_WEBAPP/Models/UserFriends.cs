namespace Chat_WEBAPP.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserFriends")]
    public class UserFriends
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FrindID { get; set; }
        public int UserID { get; set; }
        public int FriendID { get; set; }
        public DateTime AddedAt { get; set; }

        [ForeignKey("UserID")]
        public User user { get; set; }
       [ForeignKey("FriendID")]
        public User friend { get; set; }
    }
}
