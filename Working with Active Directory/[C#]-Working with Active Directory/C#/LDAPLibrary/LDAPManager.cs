using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;

namespace LDAPLibrary
{
    public class LDAPManager
    {
        #region Public Methods

        public bool IsAuthenticated(String username, String password, String domain, String path)
        {
            String domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(path, domainAndUsername, password);
            String filterAttribute;
            User user = new User();
            bool isAuthenticated = false;
            try
            {
                //Bind to the native AdsObject to force authentication.			
                if (entry.NativeObject != null)
                {
                    DirectorySearcher search = new DirectorySearcher(entry);

                    search.Filter = "(SAMAccountName=" + username + ")";
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();

                    if (null == result)
                    {
                        isAuthenticated = false;
                    }
                    else
                    {
                        filterAttribute = (String)result.Properties["cn"][0];

                        user.UserLoginName = username;
                        user.UserName = filterAttribute;
                        user.Password = password;

                        isAuthenticated = true;
                    }
                }
                else
                    isAuthenticated = false;
            }
            catch (Exception)
            {
                isAuthenticated = false;
            }
            return isAuthenticated;
        }

        public HashSet<User> GetActiveDirectoryUsers(String activeDirectoryGroups, String path)
        {
            HashSet<User> users = new HashSet<User>();
            HashSet<User> adUsers = new HashSet<User>();

            string[] groups = activeDirectoryGroups.Split('|');
            if (groups.Length > 0)
            {
                foreach (string group in groups)
                    adUsers.UnionWith(GetUsersFromADGroup(group, path));
                users = adUsers;
            }

            return users;
        }

        #endregion

        #region Private Methods

        private IEnumerable<User> GetUsersFromADGroup(string activeDirectoryGroup, String path)
        {
            DirectoryEntry entry = new DirectoryEntry(path);
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = String.Format("(&(objectCategory=group)(cn={0}))", activeDirectoryGroup);
            search.PropertiesToLoad.Add("distinguishedName");
            SearchResult searchResult = search.FindOne();
            if (searchResult == null)
                return new HashSet<User>();
            DirectoryEntry group = searchResult.GetDirectoryEntry();
            Hashtable searchedGroups = new Hashtable();
            return GetUsersInGroup(group.Properties["distinguishedName"].Value.ToString(), searchedGroups, path);
        }

        private IEnumerable<User> GetUsersInGroup(string activeDirectoryGroup, Hashtable searchedGroups, String path)
        {
            HashSet<User> groupMembers = new HashSet<User>();
            searchedGroups.Add(activeDirectoryGroup, activeDirectoryGroup);
            // find all users in this group
            DirectorySearcher ds = new DirectorySearcher(path);
            ds.Filter = String.Format("(&(memberOf={0})(objectClass=user))", activeDirectoryGroup);
            ds.PropertiesToLoad.Add("sAMAccountName");
            ds.PropertiesToLoad.Add("mail");
            ds.PropertiesToLoad.Add("displayName");
            //Add user to the list
            foreach (SearchResult sr in ds.FindAll())
            {
                string name = sr.Properties["sAMAccountName"][0].ToString();
                string email = string.Empty;
                if (sr.Properties.Contains("mail"))
                    email = sr.Properties["mail"][0].ToString();
                User user = new User();
                user.UserLoginName = name;
                user.Email = email;
                if (groupMembers.Contains(user) == false)
                    groupMembers.Add(user);
            }

            IList<string> nestedGroups = GetNestedGroups(activeDirectoryGroup, path);
            foreach (string directoryGroup in nestedGroups)
            {
                if (searchedGroups.ContainsKey(directoryGroup) == false)
                {
                    IEnumerable<User> users = GetUsersInGroup(directoryGroup, searchedGroups, path);
                    foreach (User user in users)
                    {
                        if (groupMembers.Contains(user) == false)
                        {
                            groupMembers.Add(user);
                        }
                    }
                }
            }
            return groupMembers;
        }

        private IList<string> GetNestedGroups(string activeDirectoryGroup, String path)
        {
            IList<string> groupMembers = new List<string>();
            DirectorySearcher ds = new DirectorySearcher(path);
            ds.Filter = String.Format("(&(memberOf={0})(objectClass=group))", activeDirectoryGroup);
            ds.PropertiesToLoad.Add("distinguishedName");
            foreach (SearchResult sr in ds.FindAll())
                groupMembers.Add(sr.Properties["distinguishedName"][0].ToString());

            return groupMembers;
        }

        #endregion
    }
}
