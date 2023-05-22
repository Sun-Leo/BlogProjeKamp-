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
    public class Message2Manager : IMessage2Services
    {
        private readonly IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public List<Message2> GetSendBoxListByWriter(int id)
        {
            return _message2Dal.GetSendBoxListByWriter(id);
        }

        public void TAdd(Message2 t)
        {
            _message2Dal.Add(t);
        }

        public void TDelete(Message2 t)
        {
            _message2Dal.Delete(t);
        }

        public Message2 TGetById(int id)
        {
           return _message2Dal.GetById(id);
        }

        public List<Message2> TGetInboxListByWriter(int id)
        {
            return _message2Dal.GetInboxListByWriter(id);
        }

        public List<Message2> TGetList()
        {
            return _message2Dal.GetList();
        }

        public List<Message2> TGetListAll(int id)
        {
            return _message2Dal.GetListAll(x=>x.MessageID == id);
        }

        public List<Message2> TGetListMessageWithWriter(int id)
        {
            return _message2Dal.GetListMessageWithWriter(id);
        }

        public void TUpdate(Message2 t)
        {
            _message2Dal.Update(t);
        }
    }
}
