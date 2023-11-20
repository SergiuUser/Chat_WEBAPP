namespace Chat_WEBAPP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChatRoles")]
    public class ChatRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] public int ChatRoleID { get; set; }
        [Required] public string RoleName { get; set; }
    }
}
