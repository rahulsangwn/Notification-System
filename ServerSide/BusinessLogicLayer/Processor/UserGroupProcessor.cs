using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Processor
{
    public class UserGroupProcessor
    {
        UserGroupAccess _group = new UserGroupAccess();

        public string GetSubscriptions(int userId)
        {
            var groups = _group.GetGroups(userId);
            StringBuilder orgGroups = new StringBuilder();
            foreach(var orgGroupId in groups)
            {
                orgGroups.Append(":" + orgGroupId);
            }

            return orgGroups.ToString();
        }

        public void SetSubscriptions(string subscriptions, int userId)
        {
            //Converting subscriptions into an array
            var data = subscriptions.Split(':');
            int[] orgGroupIds = new int[data.Length - 1];
            for (int i = 1; i < data.Length; i++)
            {
                orgGroupIds[i - 1] = int.Parse(data[i]);
            }

            // Clear All old Subscriptions
            _group.ClearOrgGroupsForUser(userId);

            // Set new Subscriptions
            _group.AddNewGroupsForUser(userId, orgGroupIds);

        }
    }
}
