// Application123.h : main header file for the APPLICATION123 application
//

#if !defined(AFX_APPLICATION123_H__344AF6CF_14C4_481A_9457_381185E56828__INCLUDED_)
#define AFX_APPLICATION123_H__344AF6CF_14C4_481A_9457_381185E56828__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CApplication123App:
// See Application123.cpp for the implementation of this class
//

class CApplication123App : public CWinApp
{
public:
	CApplication123App();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CApplication123App)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation
	//{{AFX_MSG(CApplication123App)
	afx_msg void OnAppAbout();
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_APPLICATION123_H__344AF6CF_14C4_481A_9457_381185E56828__INCLUDED_)
