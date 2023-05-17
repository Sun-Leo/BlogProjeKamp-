using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessage2Services: IGenericServices<Message2>
    {
        List<Message2> TGetInboxListByWriter(int id);
        List<Message2> TGetListMessageWithWriter(int id);


    }
}
