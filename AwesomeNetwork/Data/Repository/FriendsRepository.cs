using AwesomeNetwork.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AwesomeNetwork.Data.Repository
{
    public class FriendsRepository : Repository<Friend>
    {
        public FriendsRepository(ApplicationDbContext db)
      : base(db)
        {
            
        }
        

        public async Task AddFriendAsync (User target, User friend)
        {
            var friends = await Set.FirstOrDefaultAsync(x => x.UserId == target.Id && x.CurrentFriendId == friend.Id);

            if (friends == null)
            {
                var item = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = friend,
                    CurrentFriendId = friend.Id,
                };
               
                await CreateAsync(item);
            }
        }
        
        public async Task<List<User>> GetFriendsByUserAsync(User target)
        {
            var friends = Set.Include(x => x.CurrentFriend).Where(x => x.User.Id == target.Id).Select(x => x.CurrentFriend);

            return await friends.ToListAsync();
        }


        public async Task DeleteFriendAsync(User target, User friend)
        {
            var friends = await Set.FirstOrDefaultAsync(x => x.UserId == target.Id && x.CurrentFriendId == friend.Id);

            if (friends != null)
            {
               await DeleteAsync(friends);
            }
        }

    }
}
