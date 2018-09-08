using System.Collections.Generic;
using News.Common;

namespace News.Services.IMP_Services
{
    public class IMP_SecurityServices : IServices_SecurityFeeds
    {
        private IRepositorySecurityFeeds _RespositorySecurityFeeds;

        public IMP_SecurityServices(IRepositorySecurityFeeds repositorySecurityFeeds)
        {
            _RespositorySecurityFeeds = repositorySecurityFeeds;
        }

        public void DeleteSecurityFeeds(long SecurityFeedID)
        {
            _RespositorySecurityFeeds.DeleteSecurityFeeds(SecurityFeedID);
        }

        public List<SecurityFeeds> GetAllSecurityFeeds(DTParameter model)
        {
            return _RespositorySecurityFeeds.GetAllSecurityFeeds(model);
        }

        public List<Models.ModelsDTO.SecurityFeedsDTO> getPaginated(DTParameter model)
        {
            return _RespositorySecurityFeeds.getPaginated(model);
        }

        public SecurityFeeds GetSecurityFeedsListByID(long SecurityFeedID)
        {
            return _RespositorySecurityFeeds.GetSecurityFeedsListByID(SecurityFeedID);
        }

        public List<SecurityFeeds> GetTopSecurityFeeds()
        {
            return _RespositorySecurityFeeds.GetTopSecurityFeeds();
        }

        public void SaveSecurityFeeds(SecurityFeeds securityfeeds)
        {
            _RespositorySecurityFeeds.SaveSecurityFeeds(securityfeeds);
        }

        public void SetTopSecurityFeeds(List<string> Ids, List<string> DeselectedIds)
        {
            _RespositorySecurityFeeds.SetTopSecurityFeeds(Ids, DeselectedIds);
        }
    }
}