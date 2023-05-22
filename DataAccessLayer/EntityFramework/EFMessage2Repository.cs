﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetInboxListByWriter(int id)
        {
            Context context = new Context();
            return context.Message2s.Where(x=>x.ReceiverID == id).ToList(); 
        }

        public List<Message2> GetListMessageWithWriter(int id)
        {
            Context context= new Context();
            return context.Message2s.Include(x=>x.SenderUser).Where(x=>x.ReceiverID == id).ToList();
        }

        public List<Message2> GetSendBoxListByWriter(int id)
        {
            Context context = new Context();
            return context.Message2s.Include(x=>x.ReceiverUser).Where(x=>x.SenderID == id).ToList();

        }
    }
}
