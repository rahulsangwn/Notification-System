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
            return _context.CommunicationModes.Where(m => m.Value == mode).Select(m => m.Name).ToString();
        }
    }
}
