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
    public class CorrespondenceNoteService : ServiceBase<CorrespondenceNoteDao, CorrespondenceNote, int>
    {
        public CorrespondenceNoteService() { }
    }
}
