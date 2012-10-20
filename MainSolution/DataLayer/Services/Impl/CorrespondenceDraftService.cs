using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ITGateWorkDesk.Data.DAO.Impl;
using ITGateWorkDesk.Data.Domain;
using ITGateWorkDesk.Data.Services.Base;

namespace ITGateWorkDesk.Data.Services.Impl
{
    public class CorrespondenceDraftService : ServiceBase<CorrespondenceDraftDao, CorrespondenceDraft, int>
    {
        public IList<CorrespondenceDraft> GetAllByUserID(int userID)
        {
            return GetAll().Where(c => c.User.IditgUser == userID).ToList();
        } 

        public IList<CorrespondenceDraft> GetAllByOrgunit(int orgunit)
        {
            return GetAll().Where(c => c.Orgunit.IdOrgUnit == orgunit).ToList();
        } 
    }
}
