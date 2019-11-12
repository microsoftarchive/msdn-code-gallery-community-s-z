// Application123View.cpp : implementation of the CApplication123View class
//

#include "stdafx.h"
#include "Application123.h"

#include "Application123Doc.h"
#include "Application123View.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CApplication123View

IMPLEMENT_DYNCREATE(CApplication123View, CView)

BEGIN_MESSAGE_MAP(CApplication123View, CView)
	//{{AFX_MSG_MAP(CApplication123View)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, CView::OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CApplication123View construction/destruction

CApplication123View::CApplication123View()
{
	// TODO: add construction code here

}

CApplication123View::~CApplication123View()
{
}

BOOL CApplication123View::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CApplication123View drawing

void CApplication123View::OnDraw(CDC* pDC)
{
	CApplication123Doc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	// TODO: add draw code for native data here
}

/////////////////////////////////////////////////////////////////////////////
// CApplication123View printing

BOOL CApplication123View::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CApplication123View::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CApplication123View::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

/////////////////////////////////////////////////////////////////////////////
// CApplication123View diagnostics

#ifdef _DEBUG
void CApplication123View::AssertValid() const
{
	CView::AssertValid();
}

void CApplication123View::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CApplication123Doc* CApplication123View::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CApplication123Doc)));
	return (CApplication123Doc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CApplication123View message handlers
