﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal: IGenericDal<Message2>
    {
        List<Message2> GetInboxListByWriter(int id);
        List<Message2> GetSendBoxListByWriter(int id);
        List<Message2> GetListMessageWithWriter(int id);
    }
}
