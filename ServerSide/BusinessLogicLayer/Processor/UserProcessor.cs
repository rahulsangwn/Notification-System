using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Processor
{
    public class UserProcessor
    {
        UserAccess _user = new UserAccess();

        public int Identify(string receivedText)
        {
            receivedText = receivedText.Replace("\0", string.Empty);
            string[] text = receivedText.Split(':');

            if (text[0] == "Email" || text[0] == "Portal")
            {
                return _user.IsValidEmail(text[1]);
            } 
            else if (text[0] == "SMS")
            {
                return _user.IsValidPhone(text[1]);
            }

            return 0;
        }
    }
}
