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

        internal bool VerifyIdentiy(string recivedText)
        {
            return _uprocessor.Identify(recivedText);
        }
    }
}
