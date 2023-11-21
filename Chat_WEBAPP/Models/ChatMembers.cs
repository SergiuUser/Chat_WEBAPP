namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChatMembers")]
    public class ChatMembers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int ChatMemberID { get; set; }
        private int ChatID { get; set; }
        private int MemberID { get; set; }
        private int RoleID { get; set; }
        private DateTime JoiedAt { get; set; }

        [ForeignKey("ChatID")]
        private Chat chat { get; set; }
        [ForeignKey("MemberID")]
        private User userMember { get; set; }
        [ForeignKey("RoleID")]
        private ChatRoles role { get; set;}
    }
}
