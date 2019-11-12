
// MFCTesterApplicationDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "afxcmn.h"

#define WM_ARGS_RECEIVED (WM_USER + 100)


// CMFCTesterApplicationDlg dialog
class CMFCTesterApplicationDlg : public CDialog
{
// Construction
public:
	CMFCTesterApplicationDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_MFCTESTERAPPLICATION_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

	static void ArgsHandlerStatic(LPCWSTR* pArguments, DWORD dwLength, LPVOID pContext);

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	
	LRESULT OnArgsReceivedMsg(WPARAM wParam, LPARAM lParam);

	DECLARE_MESSAGE_MAP()
public:
	CListCtrl m_lstCtrlArgs;
	CRichEditCtrl m_editStatus;
};
