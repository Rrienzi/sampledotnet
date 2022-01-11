using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.DataAccess
{
    interface IUserDetailsRepository
    {
        public Task<List<UserDetails>> GetAllUserDetails();
        public Task<UserDetails> GetUserDetailById(int id);
        public Task<UserDetails> GetUserFriendsById(int id);
        public Task InsertUserDetail(UserDetails userDetails);
        public Task UpdateUserDetail(UserDetails userDetails, int id);
        public Task DeleteUserDetail(int id);
    }
}
