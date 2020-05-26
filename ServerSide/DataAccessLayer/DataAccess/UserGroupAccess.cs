using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class UserGroupAccess
    {
        NotificationContext _context = new NotificationContext();

        public int[] GetGroups(int userId)
        {
            return _context.UserGroups.Where(u => u.UserId == userId).Select(u => u.OrgGroupId).ToArray();
        }
        public int[] GetUserList(string receiver)
        {
            if(receiver == "All")
            {
                return _context.Users.Select(u => u.UserId).ToArray();
            }
            else if (receiver == "Gurgoan")
            {
                return _context.UserGroups.Where(u => u.OrgGroupId == 2).Select(u => u.UserId).ToArray();
            }
            else if (receiver == "Jaipur")
            {
                return _context.UserGroups.Where(u => u.OrgGroupId == 3).Select(u => u.UserId).ToArray();
            }
            else if (receiver == "Noida")
            {
                return _context.UserGroups.Where(u => u.OrgGroupId == 4).Select(u => u.UserId).ToArray();
            }
            else if (receiver == "Banglore")
            {
                return _context.UserGroups.Where(u => u.OrgGroupId == 5).Select(u => u.UserId).ToArray();
            }
            else if (receiver == "Engineer")
            {
                return _context.UserGroups.Where(u => u.OrgGroupId == 6).Select(u => u.UserId).ToArray();
            }
            else if (receiver == "HR")
            {
                return _context.UserGroups.Where(u => u.OrgGroupId == 7).Select(u => u.UserId).ToArray();
            } else
            {
                // Sending notifications to individuals
                var emails = receiver.Split(',');
                for (int i = 0; i < emails.Length; i++)
                {
                    emails[i] = emails[i].Trim();
                }

                List<int> userIds = new List<int>();
                foreach (var email in emails)
                {
                    var userId = _context.Users.Where(u => u.Email == email).Select(u => u.UserId).FirstOrDefault();
                    if (userId == 0)
                    {
                        return null;
                    }
                    userIds.Add(userId);
                }

                return userIds.ToArray();
            }
        }

        public void AddNewGroupsForUser(int userId, int[] orgGroupIds)
        {
            for (int i = 0; i < orgGroupIds.Length; i++)
            {
                UserGroup group = new UserGroup();
                group.OrgGroupId = orgGroupIds[i];
                group.UserId = userId;
                group.TypeId = 1;
                group.CommModes = 0;

                _context.UserGroups.Add(group);
                _context.SaveChanges();
            }
        }

        public void ClearOrgGroupsForUser(int userId)
        {
            var groups = _context.UserGroups.Where(g => g.UserId == userId).ToList();
            foreach (var group in groups)
            {
                _context.UserGroups.Remove(group);
                _context.SaveChanges();
            }
        }
    }
}
