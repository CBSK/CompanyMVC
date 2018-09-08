using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Models.Models;

namespace News.Repository.IRepository
{
    public interface IRepository_User
    {
        List<Users> Getuserlist();

        Users GetuserlistByID(int UserId);
    }
}
