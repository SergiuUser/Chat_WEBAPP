namespace Chat_WEBAPP.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserFriends")]
    public class UserFriends
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] public int FrindID { get; set; }
        [ForeignKey("UserID")]
        [Required] public User UserID { get; set; }
        [ForeignKey("UserID")]
        [Required] public User FriendID { get; set; }
        [Required] public DateTime AddedAt { get; set; }
    }
}
