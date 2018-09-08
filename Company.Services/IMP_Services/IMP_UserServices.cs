using News.Services.IServices;
using News.Repository;
using News.Repository.IRepository;
using News.Models.Models;
using System.Collections.Generic;

namespace News.Services.IMP_Services
{
    public class IMP_UserServices:IServices_User
    {
        IRepository_User _userRespository;
        public IMP_UserServices(IRepository_User repositoryUsers)
        {
            _userRespository = repositoryUsers;
        }
        public List<Users> Getuserlist()
        {
            return _userRespository.Getuserlist();
        }

        public Users GetuserlistByID(int UserId)
        {
            return _userRespository.GetuserlistByID(UserId);
        }
    }
}
