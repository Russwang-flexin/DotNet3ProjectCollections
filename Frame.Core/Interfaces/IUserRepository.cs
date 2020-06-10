using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.EFCore.Common;
using Frame.EFCore.Entity;
using Frame.EFCore.Query;

namespace Frame.EFCore.Interfaces
{
    public interface IUserRepository 
    {
        Task<User> LoginAsync(string account, string passWord);

        Task<object> GetPermissionByAccountAsync(string account);

        Task<PaginatedList<User>> GetAllUsersAsync(UserParameters parameters);

        Task<User> GetUserByIdAsync(int id);

        void AddUserAsync(User user);
        void DeleteAsync(User user);
        void UpdateAsync(User user);
    }
}
