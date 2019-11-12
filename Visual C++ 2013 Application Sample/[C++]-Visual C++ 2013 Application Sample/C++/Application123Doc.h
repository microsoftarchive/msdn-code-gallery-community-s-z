// Application123Doc.h : interface of the CApplication123Doc class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_APPLICATION123DOC_H__44629B0C_4133_4500_BD12_E73B6DFF6827__INCLUDED_)
#define AFX_APPLICATION123DOC_H__44629B0C_4133_4500_BD12_E73B6DFF6827__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CApplication123Doc : public CDocument
{
protected: // create from serialization only
	CApplication123Doc();
	DECLARE_DYNCREATE(CApplication123Doc)

// Attributes
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CApplication123Doc)
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CApplication123Doc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CApplication123Doc)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_APPLICATION123DOC_H__44629B0C_4133_4500_BD12_E73B6DFF6827__INCLUDED_)
