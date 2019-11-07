//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#pragma once

#include "Element.h"

class CMainFrame : public CFrameWindowImpl<CMainFrame>
{
public:
    DECLARE_FRAME_WND_CLASS(NULL, IDR_MAINFRAME)

    BEGIN_MSG_MAP(CMainFrame)
        MESSAGE_HANDLER(WM_CREATE, OnCreate)
        
        COMMAND_ID_HANDLER(ID_PANE_CLOSE, OnPaneClose)
        COMMAND_ID_HANDLER(ID_FILE_OPEN, OnFileOpen)
        COMMAND_ID_HANDLER(ID_FILE_OPEN_DIR, OnFileOpenDir)
        COMMAND_ID_HANDLER(ID_FILE_SAVE, OnFileSave)
        COMMAND_ID_HANDLER(ID_APP_EXIT, OnAppExit)
        COMMAND_ID_HANDLER(ID_APP_ABOUT, OnAppAbout)
        COMMAND_ID_HANDLER(ID_SHOW_VIEWPANE, OnShowViewPane)
        COMMAND_ID_HANDLER(ID_SHOW_ALPHA, OnShowAlpha)
        COMMAND_ID_HANDLER(ID_FILE_LOAD, OnContextClick)
        COMMAND_ID_HANDLER(ID_FILE_UNLOAD, OnContextClick)
        COMMAND_ID_HANDLER(ID_FILE_CLOSE, OnContextClick)
        COMMAND_ID_HANDLER(ID_FIND_METADATA, OnContextClick)
        
        NOTIFY_CODE_HANDLER(TVN_SELCHANGED, OnTreeViewSelChanged)
        NOTIFY_CODE_HANDLER(NM_RCLICK, OnNMRClick)
        
        CHAIN_MSG_MAP(CFrameWindowImpl<CMainFrame>)
    END_MSG_MAP()

    HRESULT Load(const LPCWSTR *filenames, int count);

private:
    InfoElementViewContext m_viewcontext;
        
    HWND CreateClient();
    int GetElementTreeImage(CInfoElement *elem);
    // Opens a single file
    HRESULT OpenFile(LPCWSTR filename, bool &updateElements);
    // Opens files based on a wildcard expression (not recursive)
    HRESULT OpenWildcard(LPCWSTR search, DWORD &attempted, DWORD &opened, bool &updateElements);
    // Opens images recursively in a directory
    HRESULT OpenDirectory(LPCWSTR directory, DWORD &attempted, DWORD &opened);
    void UpdateTreeView(bool selectLastRoot);
    HTREEITEM BuildTree(CInfoElement *elem, HTREEITEM hParent);
    BOOL DoElementContextMenu(HWND hWnd, CInfoElement &element, POINT point);
    HMENU CreateElementContextMenu(CInfoElement &element);
    CInfoElement *GetElementFromTreeItem(HTREEITEM hItem);
    HTREEITEM GetTreeItemFromElement(CInfoElement *element);
    HTREEITEM FindTreeItem(HTREEITEM start, CInfoElement *element);
    bool ElementCanBeSavedAsImage(CInfoElement &element);
    HRESULT SaveElementAsImage(CInfoElement &element);
    void DrawElement(CInfoElement &element);
    
    LRESULT OnCreate(UINT, WPARAM, LPARAM, BOOL&);
    LRESULT OnNMRClick(int , LPNMHDR pnmh, BOOL&);
    LRESULT OnTreeViewSelChanged(WPARAM wParam, LPNMHDR lpNmHdr, BOOL &bHandled);
    LRESULT OnPaneClose(WORD, WORD, HWND hWndCtl, BOOL&);
    LRESULT OnFileOpen(WORD, WORD, HWND, BOOL&);
    LRESULT OnFileOpenDir(WORD code, WORD item, HWND hSender, BOOL& handled);
    LRESULT OnFileSave(WORD, WORD, HWND, BOOL&);
    LRESULT OnAppExit(WORD, WORD, HWND, BOOL&);
    LRESULT OnAppAbout(WORD, WORD, HWND, BOOL&);
    LRESULT OnShowViewPane(WORD code, WORD item, HWND hSender, BOOL& handled);
    LRESULT OnShowAlpha(WORD code, WORD item, HWND hSender, BOOL& handled);
    LRESULT OnContextClick(WORD code, WORD item, HWND hSender, BOOL& handled);

    CSplitterWindow m_mainSplit;
    CHorSplitterWindow m_infoSplit;

    CPaneContainer m_viewPane;

    CImageList    m_mainTreeImages;
    CTreeViewCtrl m_mainTree;
    CRichEditCtrl m_infoEdit;
    CRichEditCtrl m_viewEdit;

    BOOL m_suppressMessageBox;
private:
    HRESULT QueryMetadata(CInfoElement *elem);
};
