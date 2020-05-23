using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide.Data
{
    public class NotificationEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Notification { get; set; }
        public DateTime Date { get; set; }
    }
}
