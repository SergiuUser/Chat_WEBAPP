using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_WEBAPP.Models
{
    [Table("Users")]
    public class BlockedUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] public int BlockedUserID { get; set; }
        [ForeignKey("UserID")]
        [Required] public User UserID { get; set; }
        [ForeignKey("UserID")]
        [Required] public User BlockedID { get; set; }
        [Required] public DateTime BlokedAt { get; set; }

    }
}
