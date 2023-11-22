using Chat_WEBAPP.Controllers;
using Chat_WEBAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat_WEBAPP.Context
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions dbContextOptions)
                : base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BlockedUsers> BlockedUsers { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMembers> ChatMembers { get; set; }
        public DbSet<ChatMessages> ChatMessages { get; set; }
        public DbSet<ChatRoles> ChatRoles { get; set; } 
        public DbSet<MessageReactions> MessageReactions { get; set; }
        public DbSet<ReactionType> reactionTypes { get; set; }  
        public DbSet<UserFriends> UserFriends { get; set; }   
        public DbSet<UserAuthController> UserAuth { get; set; }   
    }
}
