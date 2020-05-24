using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class CommunicationModesAccess
    {
        NotificationContext _context = new NotificationContext();

        public string GetName(int mode)
        {
            var name = _context.CommunicationModes.First(m => m.Value == mode).Name;
            return name;
        }
    }
}
