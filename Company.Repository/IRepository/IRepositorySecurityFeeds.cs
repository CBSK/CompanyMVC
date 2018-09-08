using System.Collections.Generic;
using News.Models.Models;
using News.Common;
using News.Models.ModelsDTO;

namespace News.Repository.IRepository
{
    public interface IRepositorySecurityFeeds
    {
        SecurityFeeds GetSecurityFeedsListByID(long SecurityFeedID);
        List<SecurityFeeds> GetAllSecurityFeeds(DTParameter model);
        List<SecurityFeeds> GetTopSecurityFeeds();
        void SetTopSecurityFeeds(List<string> Ids, List<string> DeselectedIds);
        void SaveSecurityFeeds(SecurityFeeds securityfeeds);
        void DeleteSecurityFeeds(long SecurityFeedID);
        List<SecurityFeedsDTO> getPaginated(DTParameter model);

    }
}
