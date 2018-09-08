using News.Common;
using News.Models.Models;
using News.Models.ModelsDTO;
using News.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace News.Repository.IMP_Repository
{
    public class IMP_SecurityFeedsRepository : IRepositorySecurityFeeds
    {
        public APIdbContext _ABIDBContext = null;
        public IMP_SecurityFeedsRepository(APIdbContext abiDBcontext)
        {
            _ABIDBContext = abiDBcontext;
        }

        public SecurityFeeds GetSecurityFeedsListByID(long SecurityFeedID)
        {
            using (var dbContext = new APIdbContext())
            {
                try
                {
                    var values = dbContext.SecurityFeeds.FirstOrDefault(s => s.SecurityFeedID == SecurityFeedID);
                    return values;
                }
                catch (Exception ex) { throw ex; }
            }
        }
        //public List<SecurityFeedsDTO> GetAllSecurityFeeds(DTParameter model)
        //{

        //    using (var dbContext = new APIdbContext())
        //    {
        //        try
        //        {
        //            var values = dbContext.SecurityFeeds.Skip(model.Start).Take(model.Length).ToList();
        //            return values;
        //        }
        //        catch (Exception ex) { throw ex; }
        //    }
        //}


        public List<SecurityFeeds> GetTopSecurityFeeds()
        {
            using (var dbContext = new APIdbContext())
            {
                try
                {
                    var result = new List<SecurityFeeds>();
                    var selected = dbContext.SecurityFeeds.Where(w => w.IsTop ?? false).OrderByDescending(o => o.CreatedOn).ToList();
                    var notSelected = dbContext.SecurityFeeds.Where(w => !w.IsTop ?? false).OrderByDescending(o => o.CreatedOn).ToList();

                    result.AddRange(selected);
                    result.AddRange(notSelected);

                    //var values = dbContext.SecurityFeeds.OrderByDescending(o => o.CreatedOn).Skip(0).Take(15).ToList();
                    return result;
                }
                catch (Exception ex) { throw ex; }
            }
        }
        public void SetTopSecurityFeeds(List<string> Ids, List<string> DeselectedIds)
        {
            foreach (var item in Ids)
            {
                var id = Convert.ToInt64(item);
                var SecurityFeed = _ABIDBContext.SecurityFeeds.Where(s => s.SecurityFeedID == id).FirstOrDefault();
                if (SecurityFeed != null)
                {
                    using (var dbContext = new APIdbContext())
                    {
                        SecurityFeed.IsTop = true;
                        _ABIDBContext.Set<SecurityFeeds>().Attach(SecurityFeed);
                        _ABIDBContext.Entry(SecurityFeed).State = EntityState.Modified;
                        _ABIDBContext.SaveChanges();
                    }
                }

            }

            foreach (var item in DeselectedIds)
            {
                var id = Convert.ToInt64(item);
                var SecurityFeed = _ABIDBContext.SecurityFeeds.Where(s => s.SecurityFeedID == id).FirstOrDefault();
                if (SecurityFeed != null)
                {
                    using (var dbContext = new APIdbContext())
                    {
                        SecurityFeed.IsTop = false;
                        _ABIDBContext.Set<SecurityFeeds>().Attach(SecurityFeed);
                        _ABIDBContext.Entry(SecurityFeed).State = EntityState.Modified;
                        _ABIDBContext.SaveChanges();
                    }
                }

            }
        }
        public void SaveSecurityFeeds(SecurityFeeds securityfeeds)
        {

            try
            {
                if (securityfeeds != null)
                {
                    using (var dbContext = new APIdbContext())
                    {

                        if (securityfeeds.SecurityFeedID == 0 || securityfeeds.SecurityFeedID == null)
                        {
                            // _context.OrderEntryHeader.Add(orderheadermaster);
                            dbContext.Entry(securityfeeds).State = EntityState.Added;
                            dbContext.Set<SecurityFeeds>().Add(securityfeeds);
                        }
                        else if (securityfeeds.SecurityFeedID > 0)
                        {
                            // _context.Entry(orderheadermaster).State = EntityState.Modified;
                            dbContext.Set<SecurityFeeds>().Attach(securityfeeds);
                            dbContext.Entry(securityfeeds).State = EntityState.Modified;
                        }
                        dbContext.SaveChanges();

                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeleteSecurityFeeds(long SecurityFeedID)
        {
            var DeleteSecurityFeeds = _ABIDBContext.SecurityFeeds.Where(s => s.SecurityFeedID == SecurityFeedID).FirstOrDefault();
            if (DeleteSecurityFeeds != null)
            {
                using (var dbContext = new APIdbContext())
                {
                    _ABIDBContext.Set<SecurityFeeds>().Attach(DeleteSecurityFeeds);
                    _ABIDBContext.Entry(DeleteSecurityFeeds).State = EntityState.Deleted;
                    _ABIDBContext.SaveChanges();
                }
            }

        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {

                if (disposing)
                {

                    _ABIDBContext.Dispose();

                }

            }

            this.disposed = true;

        }
        public void Dispose()
        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }


        List<SecurityFeeds> IRepositorySecurityFeeds.GetAllSecurityFeeds(DTParameter model)
        {
            throw new NotImplementedException();
        }

        public List<SecurityFeedsDTO> getPaginated(DTParameter model)
        {
            CultureInfo culture = new CultureInfo("en-GB");
            using (var dbContext = new APIdbContext())
            {
                var data = dbContext.SecurityFeeds.Select(x => new
                {
                    x.SecurityFeedID,
                    x.ImagePath,
                    x.ContentTitle,
                    x.CreatedOn,
                    x.ContentDescription
                }).AsQueryable();
                model.recordsTotal = data.Count();
                if (!string.IsNullOrEmpty(model.Search.Value))
                {
                    data = data.Where(x => x.SecurityFeedID.ToString().Contains(model.Search.Value)
                    || x.ImagePath.Contains(model.Search.Value)
                    || x.ContentTitle.Contains(model.Search.Value)
                        //|| x.CreatedOn.Contains(model.Search.Value)
                    || x.ContentDescription.Contains(model.Search.Value)
                    );
                }

                if (model.Order.Any())
                {
                    var sortingColumn = model.Order.FirstOrDefault();
                    var sortingRow = model.Columns.ToArray()[sortingColumn.Column];
                    switch (sortingRow.Data)
                    {
                        case "ImagePath":
                            if (sortingColumn.Dir.Contains("asc"))
                                data = data.OrderBy(x => x.ImagePath);
                            else
                                data = data.OrderByDescending(x => x.ImagePath);
                            break;
                        case "ContentTitle":
                            if (sortingColumn.Dir.Contains("asc"))
                                data = data.OrderBy(x => x.ContentTitle);
                            else
                                data = data.OrderByDescending(x => x.ContentTitle);
                            break;

                        case "ContentDescription":
                            if (sortingColumn.Dir.Contains("asc"))
                                data = data.OrderBy(x => x.ContentDescription);
                            else
                                data = data.OrderByDescending(x => x.ContentDescription);
                            break;

                        default:
                            data = data.OrderByDescending(x => x.CreatedOn);
                            break;
                    }
                }
                model.recordsFiltered = data.Count();
                var result = data
                     .Skip(model.Start)
                     .Take(model.Length).ToList();
                return result.Select(x => new SecurityFeedsDTO()
                {
                    SecurityFeedID = x.SecurityFeedID,
                    ContentTitle = x.ContentTitle,
                    ContentDescription = x.ContentDescription,
                    ImagePath = x.ImagePath,
                    CreatedOn = x.CreatedOn,
                    DisplayCreatedOn = x.CreatedOn.ToString("dd/MM/yyyy")
                }).ToList();
            }
        }
    }
}
