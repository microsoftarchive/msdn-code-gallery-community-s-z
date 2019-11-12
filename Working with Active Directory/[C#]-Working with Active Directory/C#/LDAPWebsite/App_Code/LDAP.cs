using System;
using System.Collections.Generic;
using System.Configuration;
using LDAPLibrary;

public class LDAP
{
    public static Boolean IsAuthenticated(String username, String password)
    {
        LDAPManager manager = new LDAPManager();
        bool isAuthenticated = manager.IsAuthenticated(username, password, ConfigurationManager.AppSettings["DomainName"],
            ConfigurationManager.AppSettings["ActiveDirectoryPath"]);

        return isAuthenticated;
    }

    public static HashSet<User> GetActiveDirectoryUsers()
    {
        HashSet<User> adUsers = new HashSet<User>();
        LDAPManager manager = new LDAPManager();
        adUsers = manager.GetActiveDirectoryUsers(ConfigurationManager.AppSettings["ActiveDirectoryGroups"],
            ConfigurationManager.AppSettings["ActiveDirectoryPath"]);

        return adUsers;
    }
}