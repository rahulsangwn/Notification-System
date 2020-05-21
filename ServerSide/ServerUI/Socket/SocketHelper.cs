using BusinessLogicLayer.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.Socket
{
    public class SocketHelper
    {
        UserProcessor _uprocessor = new UserProcessor();
        RecipientsProcessor _rprocessor = new RecipientsProcessor();

        internal int VerifyIdentiy(string recivedText)
        {
            return _uprocessor.Identify(recivedText);
        }

        internal byte[] GetNotifications(int userId, char mode)
        {
            return _rprocessor.GetNotifications(userId, mode);
        }
    }
}
