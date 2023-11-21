namespace Chat_WEBAPP.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserFriends")]
    public class UserFriends
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int FrindID { get; set; }
        private int UserID { get; set; }
        private int FriendID { get; set; }
        private DateTime AddedAt { get; set; }

        [ForeignKey("UserID")]
        private User user { get; set; }
       [ForeignKey("FriendID")]
       private User friend { get; set; }
    }
}
