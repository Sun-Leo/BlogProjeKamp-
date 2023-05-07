using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessageRepository : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetInboxByWriter(string p)
        {
            Context context = new Context();
            return context.Messages.Where(x=>x.Receiver==p).ToList();
        }
    }
}
