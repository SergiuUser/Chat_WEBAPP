using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_WEBAPP.Models
{
    [Table("BlockedUsers")]
    public class BlockedUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlockedUserID { get; set; }
        public int UserID { get; set; }
        public int BlockedID { get; set; }
        public DateTime BlocketAt    { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
        [ForeignKey("BlockedID")]
        public User BlockedUser { get; set; }




    }
}
