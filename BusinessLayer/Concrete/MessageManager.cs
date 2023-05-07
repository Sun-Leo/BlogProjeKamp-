using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
    public class MessageManager : IMessageServices
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message t)
        {
            _messageDal.Add(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetInboxByWriter(string p)
        {
            return _messageDal.GetInboxByWriter(p);
        }

        public List<Message> TGetList()
        {
            return new List<Message>();
        }

        public List<Message> TGetListAll(int id)
        {
            return _messageDal.GetListAll(x=>x.MessageID == id);
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
