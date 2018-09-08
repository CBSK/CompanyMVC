using System.Collections.Generic;

namespace News.Services.IServices
{
    public interface IServices_User
    {
        List<Users> Getuserlist();

        Users GetuserlistByID(int UserId);
    }
}