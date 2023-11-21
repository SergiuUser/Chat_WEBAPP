namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChatMembers")]
    public class ChatMembers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatMemberID { get; set; }
        public int ChatID { get; set; }
        public int MemberID { get; set; }
        public int RoleID { get; set; }
        public DateTime JoinedAt { get; set; }

        [ForeignKey("ChatID")]
        public Chat chat { get; set; }
        [ForeignKey("MemberID")]
        public User userMember { get; set; }
        [ForeignKey("RoleID")]
        public ChatRoles role { get; set;}
    }
}
