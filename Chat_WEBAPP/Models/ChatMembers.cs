namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChatMembers")]
    public class ChatMembers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] public int ChatMemberID { get; set; }
        [ForeignKey("ChatID")]
        [Required] public Chat ChatID { get; set; }
        [ForeignKey("UserID")]
        [Required] public User MemberID { get; set; }
        [ForeignKey("ChatRoleID")]
        [Required] public ChatRoles RoleID { get; set; }
        [Required] public DateTime JoiedAt { get; set; }
    }
}
