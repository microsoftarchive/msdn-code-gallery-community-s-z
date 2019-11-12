// Application123Doc.cpp : implementation of the CApplication123Doc class
//

#include "stdafx.h"
#include "Application123.h"

#include "Application123Doc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CApplication123Doc

IMPLEMENT_DYNCREATE(CApplication123Doc, CDocument)

BEGIN_MESSAGE_MAP(CApplication123Doc, CDocument)
	//{{AFX_MSG_MAP(CApplication123Doc)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CApplication123Doc construction/destruction

CApplication123Doc::CApplication123Doc()
{
	// TODO: add one-time construction code here

}

CApplication123Doc::~CApplication123Doc()
{
}

BOOL CApplication123Doc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CApplication123Doc serialization

void CApplication123Doc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

/////////////////////////////////////////////////////////////////////////////
// CApplication123Doc diagnostics

#ifdef _DEBUG
void CApplication123Doc::AssertValid() const
{
	CDocument::AssertValid();
}

void CApplication123Doc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CApplication123Doc commands
