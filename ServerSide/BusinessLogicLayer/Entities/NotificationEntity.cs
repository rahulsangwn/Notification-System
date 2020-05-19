using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    [Serializable]
    public class NotificationEntity
    {
        public int Id { get; set; }
        public string NotifBody { get; set; }
    }
}
