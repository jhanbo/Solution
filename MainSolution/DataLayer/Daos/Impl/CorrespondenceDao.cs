using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ITGateWorkDesk.Data.DAO.Base;
using ITGateWorkDesk.Data.Domain;
using System.Linq;
using NHibernate.Linq;

namespace ITGateWorkDesk.Data.DAO.Impl
{
    public class CorrespondenceDao : DaoBase<Correspondence, Int32>
    {
        public IEnumerable<Correspondence> GetInternalIncomingList(int orgunitID, int userID)
        {
            return (from c in GetAll()
                    where
                        c.IsInternal == 1 && c.IsDecision == 0 && c.CorrespondenceToOrgs != null &&
                        c.CorrespondenceToOrgs.Where(ct => ct.ToCcType.Equals("TO")).Select(
                            ctt => ctt.OrganizationUnit.IdOrgUnit).Contains(orgunitID)
                    select c);

        }
        public IEnumerable<Correspondence> GetInternalOutcomingList(int orgunitID, int userID)
        {
            return (from c in GetAll()
                    where c.IsInternal == 1 && c.IsDecision == 0 && c.Orgunit.IdOrgUnit == orgunitID
                    select c);
           
        }
        public IEnumerable<Correspondence> GetExternalOutcomingList(int orgunitID, int userID)
        {
            return (from c in GetAll()
                    where c.IsInternal == 0 && c.IsDecision == 0 && c.Orgunit.IdOrgUnit == orgunitID
                    select c);
        }
        public IEnumerable<Correspondence> GetExternalIncomingList(int orgunitID, int userID)
        {
            return (from c in GetAll()
                    where
                        c.IsInternal == 0 && c.IsDecision == 0 && c.CorrespondenceToOrgs != null &&
                        c.CorrespondenceToOrgs.Where(ct => ct.ToCcType.Equals("TO")).Select(
                            ctt => ctt.OrganizationUnit.IdOrgUnit).Contains(orgunitID)
                    select c);
        }

        public IEnumerable<Correspondence> GetIncomingDecisions(int orgunitID,int userID)
        {
            return (from c in GetAll()
                    where
                        c.IsDecision == 1 && c.CorrespondenceToOrgs != null &&
                        c.CorrespondenceToOrgs.Select(ctt => ctt.OrganizationUnit.IdOrgUnit).Contains(orgunitID)
                    select c);
        }

        public IEnumerable<Correspondence> GetOutcomingDecisions(int orgunitID, int userID)
        {
            return (from c in GetAll()
                    where c.IsDecision == 1 && c.Orgunit.IdOrgUnit == orgunitID
                    select c);
        }

        public int Count(Expression<Func<Correspondence, bool>> where)
        {
            return HibernateTemplate.SessionFactory
                .GetCurrentSession()
                .Query<Correspondence>()
                .Where(where)
                .Count();

        }
    }
}

