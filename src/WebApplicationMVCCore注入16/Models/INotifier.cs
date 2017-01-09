using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMVCCore注入16.Models
{
   public interface INotifier
    {
          void abc();
    }
    public interface ISMSNotifier:INotifier
    {
        
    }
}
