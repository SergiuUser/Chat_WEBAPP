using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_WEBAPP.Models
{
    [Table("BlockedUsers")]
    public class BlockedUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int BlockedUserID { get; set; }
        private int UserID { get; set; }
        private int BlockedID { get; set; }
        private DateTime BlokedAt { get; set; }

        [ForeignKey("UserID")]
        private User User { get; set; }
        [ForeignKey("BlockedID")]
        private User BlockedUser { get; set; }




    }
}
