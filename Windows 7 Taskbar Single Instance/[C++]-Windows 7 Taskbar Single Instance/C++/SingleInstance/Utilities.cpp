#include "StdAfx.h"
#include "Utilities.h"

BOOL IsUserAdmin()
{
	BOOL b;
	SID_IDENTIFIER_AUTHORITY NtAuthority = SECURITY_NT_AUTHORITY;
	PSID AdministratorsGroup; 
	b = AllocateAndInitializeSid(
	    &NtAuthority,
	    2,
	    SECURITY_BUILTIN_DOMAIN_RID,
	    DOMAIN_ALIAS_RID_ADMINS,
		0, 0, 0, 0, 0, 0,
		&AdministratorsGroup); 
	if(b) 
	{
		if (!CheckTokenMembership( NULL, AdministratorsGroup, &b)) 
		{
			b = FALSE;
	    }	
	    FreeSid(AdministratorsGroup); 
	}

	return(b);
}
