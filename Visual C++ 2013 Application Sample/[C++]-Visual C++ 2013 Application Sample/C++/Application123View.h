// Application123View.h : interface of the CApplication123View class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_APPLICATION123VIEW_H__229A0FDB_318D_499D_9DF3_2C4956873089__INCLUDED_)
#define AFX_APPLICATION123VIEW_H__229A0FDB_318D_499D_9DF3_2C4956873089__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CApplication123View : public CView
{
protected: // create from serialization only
	CApplication123View();
	DECLARE_DYNCREATE(CApplication123View)

// Attributes
public:
	CApplication123Doc* GetDocument();

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CApplication123View)
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CApplication123View();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CApplication123View)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in Application123View.cpp
inline CApplication123Doc* CApplication123View::GetDocument()
   { return (CApplication123Doc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_APPLICATION123VIEW_H__229A0FDB_318D_499D_9DF3_2C4956873089__INCLUDED_)
