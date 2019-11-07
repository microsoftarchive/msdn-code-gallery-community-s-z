//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#include "precomp.hpp"

LRESULT CMainFrame::OnCreate(UINT, WPARAM, LPARAM, BOOL&)
{
    HWND hWndToolBar = CreateSimpleToolBarCtrl(m_hWnd, IDR_MAINFRAME, FALSE, ATL_SIMPLE_TOOLBAR_PANE_STYLE | TBSTYLE_TRANSPARENT | TBSTYLE_LIST | TBSTYLE_FLAT | CCS_NORESIZE | CCS_TOP);    

    CreateSimpleReBar((ATL_SIMPLE_REBAR_NOBORDER_STYLE | CCS_TOP | RBS_DBLCLKTOGGLE) & ~RBS_AUTOSIZE);
    AddSimpleReBarBand(hWndToolBar, NULL, TRUE);

    CreateSimpleStatusBar();

    m_hWndClient = CreateClient();

    m_suppressMessageBox = FALSE;
    m_viewcontext.bIsAlphaEnable = TRUE;

    return 0;
}

HWND CMainFrame::CreateClient()
{
    HWND hWnd = NULL;

    CRect clientRect;
    GetClientRect(&clientRect);

    hWnd = m_mainSplit.Create(m_hWnd, clientRect, NULL, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN);
    ATLASSERT(NULL != hWnd);

    m_mainSplit.m_cxyMin = 35;                           // Minimum sizes
    m_mainSplit.SetSplitterExtendedStyle(0);             // Extend right pane when resizing main window
    m_mainSplit.m_bFullDrag = true;                      // Show contents during drag

    CRect leftRect;
    GetClientRect(&leftRect);

    hWnd = m_infoSplit.Create(m_mainSplit.m_hWnd, leftRect, NULL, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN);
    ATLASSERT(NULL != hWnd);

    m_infoSplit.m_cxyMin = 35;                                 // Minimum sizes
    m_infoSplit.SetSplitterExtendedStyle(SPLIT_BOTTOMALIGNED); // Extend right pane when resizing main window
    m_infoSplit.m_bFullDrag = true;                            // Show contents during drag

    m_mainSplit.SetSplitterPane(0, m_infoSplit);

    hWnd = m_viewPane.Create(m_mainSplit.m_hWnd);
    ATLASSERT(NULL != hWnd);

    m_mainSplit.SetSplitterPane(1, m_viewPane);

    m_viewPane.SetTitle(L"View");

    m_mainTreeImages.CreateFromImage(IDB_MAINTREE, 16, 0, RGB(255, 255, 255), IMAGE_BITMAP, LR_LOADTRANSPARENT | LR_CREATEDIBSECTION);

    hWnd = m_mainTree.Create(m_infoSplit.m_hWnd, rcDefault, NULL, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | TVS_HASBUTTONS | TVS_TRACKSELECT | TVS_HASLINES | TVS_LINESATROOT | TVS_SHOWSELALWAYS, WS_EX_CLIENTEDGE);
    ATLASSERT(NULL != hWnd);

    m_mainTree.SetImageList(m_mainTreeImages, TVSIL_NORMAL);

    m_infoSplit.SetSplitterPane(0, m_mainTree);

    hWnd = m_infoEdit.Create(m_infoSplit.m_hWnd, rcDefault, NULL, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | WS_VSCROLL | ES_MULTILINE | ES_AUTOVSCROLL | ES_READONLY, WS_EX_CLIENTEDGE);
    ATLASSERT(NULL != hWnd);

    m_infoEdit.SendMessage(EM_SETBKGNDCOLOR, 0, GetSysColor(COLOR_INFOBK));
    
    m_infoSplit.SetSplitterPane(1, m_infoEdit);

    hWnd = m_viewEdit.Create(m_viewPane.m_hWnd, rcDefault, NULL, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | WS_VSCROLL | WS_HSCROLL | ES_MULTILINE | ES_AUTOVSCROLL | ES_READONLY , WS_EX_CLIENTEDGE);
    ATLASSERT(NULL != hWnd);

    m_viewEdit.SendMessage(EM_SETBKGNDCOLOR, 0, GetSysColor(COLOR_INFOBK));
    m_viewEdit.SetOptions(ECOOP_OR, ECO_AUTOVSCROLL);

    m_viewPane.SetClient(m_viewEdit.m_hWnd);

    m_mainSplit.SetSplitterPos(clientRect.Width() / 4);    // Default size of left pane
    m_infoSplit.SetSplitterPos((2*leftRect.Height()) / 3); // Default size of bottom pane

    return m_mainSplit.m_hWnd;
}

LRESULT CMainFrame::OnPaneClose(WORD, WORD, HWND hWndCtl, BOOL&)
{
    // hide the container whose Close button was clicked. Use 
    // DestroyWindow(hWndCtl) instead if you want to totally 
    // remove the container instead of just hiding it
    ::ShowWindow(hWndCtl, SW_HIDE);


    // find the container's parent splitter
    HWND hWnd = ::GetParent(hWndCtl);
    CSplitterWindow* pWnd;

#pragma warning( disable : 4312 )
    pWnd = reinterpret_cast<CSplitterWindow*>(::GetWindowLong(hWnd, GWL_ID));
#pragma warning( default : 4312 )

    // take the container that was Closed out of the splitter.
    // Use SetSplitterPane(nPane, NULL) if you want to stay in
    // multipane mode instead of changing to single pane mode
    int nCount = pWnd->m_nPanesCount;
    for(int nPane = 0; nPane < nCount; nPane++)
    {
        if (hWndCtl == pWnd->m_hWndPane[nPane])
        {
            pWnd->SetSinglePaneMode(nCount - nPane - 1);
            break;
        }
    }

    if(hWndCtl == m_viewPane.m_hWnd)
    {
        HMENU menu = GetMenu();
        // Clear the "Show View Pane" check mark in the menu
        CheckMenuItem(menu, ID_SHOW_VIEWPANE, MF_UNCHECKED | MF_BYCOMMAND);
    }

    return 0;
}

CInfoElement *CMainFrame::GetElementFromTreeItem(HTREEITEM hItem)
{
    return reinterpret_cast<CInfoElement*>(m_mainTree.GetItemData(hItem));
}

HTREEITEM CMainFrame::GetTreeItemFromElement(CInfoElement *element)
{
    return FindTreeItem(m_mainTree.GetRootItem(),element);
}

HTREEITEM CMainFrame::FindTreeItem(HTREEITEM start, CInfoElement *element)
{
    if(!start)
    {
        return 0;
    }
    if(GetElementFromTreeItem(start) == element)
    {
        return start;
    }
    HTREEITEM result;
    if((result = FindTreeItem(m_mainTree.GetChildItem(start), element)) != 0)
    {
        return result;
    }
    return FindTreeItem(m_mainTree.GetNextSiblingItem(start), element);
}

int CMainFrame::GetElementTreeImage(CInfoElement *elem)
{
    if (dynamic_cast<CBitmapDecoderElement*>(elem))
    {
        return 151;
    }
    else if (dynamic_cast<CBitmapFrameDecodeElement*>(elem))
    {
        return 160;
    }
    else if (dynamic_cast<CMetadataReaderElement*>(elem))
    {
        return 7;
    }
    else
    {
        return 85;
    }
}

HTREEITEM CMainFrame::BuildTree(CInfoElement *elem, HTREEITEM hParent)
{
    ATLASSERT(elem);

    if (elem)
    {
        int image = GetElementTreeImage(elem);
        UINT state = (NULL == hParent) ? TVIS_BOLD : 0;

        HTREEITEM hItem = m_mainTree.InsertItem(TVIF_TEXT | TVIF_STATE | TVIF_IMAGE | TVIF_SELECTEDIMAGE,
            elem->Name(), image, image, state, state, 0, hParent, NULL);

        // Set a pointer to the element in the tree
        m_mainTree.SetItemData(hItem, reinterpret_cast<DWORD_PTR>(elem));

        // Add children
        if (elem->FirstChild())
        {
            BuildTree(elem->FirstChild(), hItem);
        }

        // Add the siblings
        if (elem->NextSibling())
        {
            BuildTree(elem->NextSibling(), hParent);
        }

        // Expand this branch
        m_mainTree.Expand(hItem);

        return hItem;
    }

    return NULL;
}

void CMainFrame::UpdateTreeView(bool selectLastRoot)
{
    // This method simply destroys the entire tree, then re-creates it from scratch.
    m_mainTree.DeleteAllItems();

    CInfoElement *root = CElementManager::GetRootElement();
    HTREEITEM rootItem = NULL;
    if(root->FirstChild())
    {
        // BuildTree traverses by the first child and next sibling.
        // Therefore, all of the elements will be added except for root.
        rootItem = BuildTree(root->FirstChild(), NULL);
    }

    if (selectLastRoot)
    {
        m_mainTree.SelectItem(rootItem);
        m_mainTree.SetFocus();
    }
}

HRESULT CMainFrame::OpenFile(LPCWSTR filename, bool &updateElements)
{
    updateElements = false;

    CInfoElement *newRoot = NULL;
    ICodeGenerator *codeGen = new CSimpleCodeGenerator();

    HRESULT result = CElementManager::OpenFile(filename, *codeGen, newRoot);

    if (SUCCEEDED(result))
    {
        updateElements = true;
    }
    else
    {
        CString msg;
        CString err;
        GetHresultString(result, err);

        if (result == E_FAIL)
        {
            msg.Format(L"File \"%s\" loaded but contained 0 frames.\n\n", filename);
        }
        else
        {
            msg.Format(L"Unable to load the file \"%s\". The error is: %s.\n\n", filename, (LPCWSTR)err);
        }

        if (NULL != newRoot)
        {
            updateElements = true;
            msg.Format(L"Unable to completely load the file \"%s\". The error is: %s. Some parts of the file may still be viewed.\n\n", filename, (LPCWSTR)err);
        }

        CString code;
        codeGen->GenerateCode(code);
        msg += code;

        if(m_suppressMessageBox == FALSE)
        {
            CWindow::MessageBoxW(msg, L"Error Opening File", MB_OK | MB_ICONWARNING);
        }
    }

    delete codeGen;

    return result;
}

HRESULT CMainFrame::OpenWildcard(LPCWSTR search, DWORD &attempted, DWORD &opened, bool &updateElements)
{
    updateElements = false;
    HRESULT hr = S_OK;
    WIN32_FIND_DATA fdata;
    HANDLE hf = FindFirstFile(search, &fdata);

    // fdata.cFileName does not store the directory, nor is the directory
    // stored anywhere else inside of fdata. The directory needs to be copied
    // from the search string, and then cFileName has to be concatonated to the
    // directory.
    WCHAR directoryPrefix[MAX_PATH*2] = {0};
    WCHAR *lastSlash = (WCHAR *)wcsrchr(search, L'\\');
    WCHAR *lastSlash2 = (WCHAR *)wcsrchr(search, L'/');

    if(lastSlash2 > lastSlash)
    {
        lastSlash = lastSlash2;
    }

    size_t directorySize = 0;

    if(lastSlash != NULL)
    {
        // The +1 is to include the slash.
        directorySize = (lastSlash + 1) - search;

        if(directorySize > MAX_PATH)
        {
            return E_INVALIDARG;
        }

        wcsncpy_s(directoryPrefix, ARRAYSIZE(directoryPrefix), search, directorySize);
    }

    if(hf == INVALID_HANDLE_VALUE)
    {
        if(m_suppressMessageBox == FALSE)
        {
            MessageBox(L"Could not open " + CString(search), L"Error opening expression", MB_OK);
        }
        return 0;
    }
    do
    {
        HRESULT temp;
        bool updateThis = 0;

        // Concat the filename onto the directory.
        wcscpy_s(directoryPrefix + directorySize,
            ARRAYSIZE(directoryPrefix) - directorySize,
            fdata.cFileName);

        if(SUCCEEDED(temp = OpenFile(directoryPrefix, updateThis)))
        {
            opened++;
        }
        else
        {
            hr = temp;
        }

        attempted++;
        updateElements = updateElements || updateThis;
    } while(FindNextFile(hf, &fdata));

    FindClose(hf);

    return hr;
}

HRESULT CMainFrame::Load(const LPCWSTR *argv, int argc)
{
    HRESULT result = S_OK;
    bool needsUpdate = false;
    CString quiet = "/quiet";

    DWORD attempted = 0, opened = 0;
    for(int i = 0; i < argc; i++)
    {
        if(quiet.CompareNoCase(argv[i]) == 0)
        {
            m_suppressMessageBox = TRUE;
        }
        else
        {
            bool thisNeedsUpdate = false;
            result = OpenWildcard(argv[i], attempted, opened, thisNeedsUpdate);
            needsUpdate = needsUpdate || thisNeedsUpdate;
        }
    }

    if(needsUpdate)
    {
        UpdateTreeView(true);
    }

    if(attempted > 1)
    {
        WCHAR buffer[60];
        swprintf_s(buffer, 60, L"Successfully opened %d out of %d image files", opened, attempted);

        if(m_suppressMessageBox == FALSE)
        {
            MessageBox(buffer, L"Done", MB_OK);
        }
    }

    return result;
}

CString GetFullPath(CString directory, CString file)
{
    WCHAR buffer[MAX_PATH*2];
    WCHAR oldDirectory[MAX_PATH];

    // Ideally we'd like to use GetFullPathName to give us an absolute path,
    // since it's more reliable. Unfortunately, it only works off of the current
    // directory. That means we'll have to backup the current directory and then
    // switch it to what's passed.

    GetCurrentDirectory(MAX_PATH, oldDirectory);

    if(!SetCurrentDirectory(directory))
    {
        // We can't switch to that directory for some reason.
        // This is a backup algorithm, but it might fail in very unusual cases.
        if(file.Left(2).Right(1) == L':' ||
            file.Left(2) == L"\\\\")
        {
            // It's an absolute path.
            return file;
        }
        // It's a relative path, so it needs the directory too.
        if(directory.Right(1) == L'\\')
            return directory + file;
        else
            return directory + L"\\" + file;
    }
    LPWSTR filePart;

    GetFullPathName(file, MAX_PATH*2, buffer, &filePart);

    SetCurrentDirectory(oldDirectory);

    return buffer;
}

LRESULT CMainFrame::OnFileOpen(WORD, WORD, HWND hParentWnd, BOOL&)
{
    CFileDialog fileDlg(TRUE, NULL, NULL, OFN_HIDEREADONLY | OFN_FILEMUSTEXIST | OFN_ALLOWMULTISELECT,
        L"All Files (*.*)\0*.*\0\0", hParentWnd);

    // Create a large buffer to hold the result of the filenames.
    const int BUFFER_SIZE = 16 * 1024;
    WCHAR *filenameBuffer = new WCHAR[BUFFER_SIZE];
    if (NULL != filenameBuffer)
    {
        filenameBuffer[0] = L'\0';
        fileDlg.m_ofn.lpstrFile = filenameBuffer;
        fileDlg.m_ofn.nMaxFile = BUFFER_SIZE;
    }

    // Bring up the dialog
    INT_PTR res = fileDlg.DoModal();

    if (IDOK == res)
    {
        bool updateElements = false;

        // Get the path to the files
        CString path = fileDlg.m_ofn.lpstrFile;

        // If m_ofn.lpstrFileTitle is empty, then there are multiple files. Otherwise, there is
        // just one file. We need to handle both cases.
        if (L'\0' != *fileDlg.m_ofn.lpstrFileTitle)
        {
            // Just one file
            OpenFile(path, updateElements);
        }
        else
        {
            // Get each of the files
            WCHAR *filenamePtr = fileDlg.m_ofn.lpstrFile + path.GetLength() + 1;
            while (L'\0' != *filenamePtr)
            {
                CString filename = filenamePtr;

                // Try opening the file
                bool fileWantsUpdate = false;

                OpenFile(GetFullPath(path, filename), fileWantsUpdate);

                updateElements = updateElements || fileWantsUpdate;

                // Go for the next file
                filenamePtr = filenamePtr + filename.GetLength() + 1;
            }
        }

        // Update the tree if necessary
        if (updateElements)
        {
            UpdateTreeView(true);
        }
    }

    delete filenameBuffer;

    return 0;
}

HRESULT CMainFrame::OpenDirectory(LPCWSTR directory, DWORD &attempted, DWORD &opened)
{
    HRESULT hr = S_OK;
    WIN32_FIND_DATA fdata;
    HANDLE hf = FindFirstFile(CString(directory) + "\\*", &fdata);

    if(hf == INVALID_HANDLE_VALUE)
    {
        if(m_suppressMessageBox == FALSE)
        {
            MessageBox(L"Could not open " + CString(directory), L"Error opening directory", MB_OK);
        }
        return 0;
    }
    do
    {
        CString path = CString(directory) + L"\\" + fdata.cFileName;
        CString extension = CString(fdata.cFileName).Right(4);
        HRESULT temp;

        if((fdata.dwFileAttributes&FILE_ATTRIBUTE_DIRECTORY) == FILE_ATTRIBUTE_DIRECTORY &&
            wcscmp(fdata.cFileName, L".") &&
            wcscmp(fdata.cFileName, L".."))
        {
            if(FAILED(temp = OpenDirectory(path, attempted, opened)))
            {
                hr = temp;
            }
        }
        else if(!extension.CompareNoCase(L".jpg") ||
            !extension.CompareNoCase(L".jpeg") ||
            !extension.CompareNoCase(L".png") ||
            !extension.CompareNoCase(L".gif") ||
            !extension.CompareNoCase(L".bmp") ||
            !extension.CompareNoCase(L".tif") ||
            !extension.CompareNoCase(L".tiff") ||
            !extension.CompareNoCase(L".ico") ||
            !extension.CompareNoCase(L".icon") ||
            !extension.CompareNoCase(L".dds"))
        {
            bool updateThis = 0;
            if(SUCCEEDED(temp = OpenFile(path, updateThis)))
            {
                opened++;
            }
            else
            {
                hr = temp;
            }
            attempted++;
        }
    } while(FindNextFile(hf, &fdata));

    FindClose(hf);

    return hr;
}

LRESULT CMainFrame::OnFileOpenDir(WORD /*code*/, WORD /*item*/, HWND hSender, BOOL& handled)
{
    CFolderDialog fileDlg(hSender,
        L"Select directory with *.jpg, *.png, *.gif, *.bmp, *.tif, *.ico, or *.dds", 
        BIF_VALIDATE | BIF_EDITBOX);

    handled = 1;

    // Bring up the dialog
    if(fileDlg.DoModal() != IDOK)
    {
        return 0;
    }

    DWORD attempted = 0, opened = 0;
    OpenDirectory(fileDlg.GetFolderPath(), attempted, opened);

    UpdateTreeView(true);

    WCHAR buffer[60];
    swprintf_s(buffer, 60, L"Successfully opened %d out of %d image files", opened, attempted);

    if(m_suppressMessageBox == FALSE)
    {
        MessageBox(buffer, L"Done", MB_OK);
    }

    return 0;
}

void CMainFrame::DrawElement(CInfoElement &element)
{
    // Clear the RichEdits
    m_viewEdit.SetSelAll();
    m_viewEdit.ReplaceSel(L"");
    m_infoEdit.SetSelAll();
    m_infoEdit.ReplaceSel(L"");

    // Display the view -- prepend it with a path to the selected element
    CString path = element.Name();
    CInfoElement *parent = &element;

    while (NULL != parent->Parent())
    {
        path = parent->Parent()->Name() + L"\\" + path;
        parent = parent->Parent();
    }

    CRichEditDevice view(m_viewEdit);
    view.BeginSection(path);
    element.OutputView(view,m_viewcontext);
    view.EndSection();

    m_viewEdit.SetSel(0, 0);

    // Display the info
    CRichEditDevice info(m_infoEdit);
    element.OutputInfo(info);

    m_infoEdit.SetSel(0, 0);
}

LRESULT CMainFrame::OnTreeViewSelChanged(WPARAM /*wParam*/, LPNMHDR lpNmHdr, BOOL &bHandled)
{
    bHandled = TRUE;

    LPNMTREEVIEW lpNmTreeView = reinterpret_cast<LPNMTREEVIEW>(lpNmHdr);

    CInfoElement *elem = GetElementFromTreeItem(lpNmTreeView->itemNew.hItem);

    if (elem)
    {
        DrawElement(*elem);
    }

    return 0;
}

LRESULT CMainFrame::OnNMRClick(int, LPNMHDR pnmh, BOOL&)
{
    // Get the location of the click point in the window
    POINT pt = { 0 };
    ::GetCursorPos(&pt);

    POINT ptClient = pt;
    if (NULL != pnmh->hwndFrom)
    {
        ::ScreenToClient(pnmh->hwndFrom, &ptClient);
    }

    // If it was a right-click in the tree view, then bring up the context menu.
    if (pnmh->hwndFrom == m_mainTree.m_hWnd)
    {
        TVHITTESTINFO tvhti = { 0 };
        tvhti.pt = ptClient;
        m_mainTree.HitTest(&tvhti);

        if (0 != (tvhti.flags & TVHT_ONITEMLABEL))
        {
            CInfoElement *elem = GetElementFromTreeItem(tvhti.hItem);
            if (NULL != elem)
            {
                m_mainTree.SelectItem(tvhti.hItem);
                DoElementContextMenu(::GetParent(m_mainTree.m_hWnd), *elem, pt);
            }
        }
    }

    return 0;
}

HMENU CMainFrame::CreateElementContextMenu(CInfoElement &element)
{
    HMENU result = ::CreatePopupMenu();

    MENUITEMINFO itemInfo = { 0 };
    itemInfo.cbSize = sizeof(MENUITEMINFO);
    itemInfo.fMask = MIIM_FTYPE | MIIM_ID | MIIM_STATE | MIIM_STRING;
    itemInfo.fType = MFT_STRING;
    
    element.FillContextMenu(result);

    return result;
}

BOOL CMainFrame::DoElementContextMenu(HWND hWnd, CInfoElement &element, POINT point)
{
    HMENU hMenu = CreateElementContextMenu(element);
    if (NULL == hMenu)
    {
        return FALSE;
    }

    ::TrackPopupMenu(hMenu, TPM_LEFTALIGN | TPM_RIGHTBUTTON, point.x, point.y, 0, hWnd, NULL);
    ::DestroyMenu(hMenu);

    return TRUE;
}

LRESULT CMainFrame::OnFileSave(WORD, WORD, HWND, BOOL&)
{
    // Get the currently selected tree node.
    HTREEITEM hItem = m_mainTree.GetSelectedItem();

    if (NULL != hItem)
    {
        CInfoElement *elem = GetElementFromTreeItem(hItem);
        if (NULL != elem)
        {
            SaveElementAsImage(*elem);
        }
    }
    
    return 0;
}

bool CMainFrame::ElementCanBeSavedAsImage(CInfoElement &element)
{
    return ((NULL != dynamic_cast<CBitmapDecoderElement*>(&element)) ||
            (NULL != dynamic_cast<CBitmapSourceElement*>(&element)));
}

HRESULT GetPixelFormatName(WCHAR *dest, UINT chars, WICPixelFormatGUID guid);

HRESULT CMainFrame::SaveElementAsImage(CInfoElement &element)
{
    HRESULT result = E_UNEXPECTED;

    if (ElementCanBeSavedAsImage(element))
    {
        // Let the user choose the type of encoder to use
        CEncoderSelectionDlg dlg;
        INT_PTR id = dlg.DoModal();

        if (IDOK == id)
        {
            // Now that we know what kind of encoder they want to use, let's get a filename from them
            CFileDialog fileDlg(FALSE, NULL, NULL, OFN_HIDEREADONLY,
                L"All Files (*.*)\0*.*\0\0", m_hWnd);
            id = fileDlg.DoModal();

            if (IDOK == id)
            {
                // Now we have a filename and an encoder, let's go
                ICodeGenerator *codeGen = new CSimpleCodeGenerator();

                WICPixelFormatGUID format = dlg.GetPixelFormat();
                result = CElementManager::SaveElementAsImage(element, dlg.GetContainerFormat(), format, fileDlg.m_szFileName, *codeGen);

                if (FAILED(result))
                {
                    CString err;
                    GetHresultString(result, err);

                    CString msg;
                    msg.Format(L"Unable to encode '%s' as '%s'. The error is: %s.\n\n",
                        (LPCWSTR)element.Name(), fileDlg.m_szFileName, (LPCWSTR)err);

                    CString code;
                    codeGen->GenerateCode(code);
                    msg += code;

                    if(m_suppressMessageBox == FALSE)
                    {
                        CWindow::MessageBoxW(msg, L"Error Encoding Image", MB_OK | MB_ICONERROR);
                    }
                }
                else if( dlg.GetPixelFormat() != GUID_WICPixelFormatDontCare &&
                    dlg.GetPixelFormat() != format)
                {
                    // The user cares about the pixel format, and WIC actually used
                    // a different one than what the user picked.
                    CString msg;
                    WCHAR picked[30], actual[30];
                    if(FAILED(GetPixelFormatName(picked, ARRAYSIZE(picked), dlg.GetPixelFormat())))
                    {
                        wcscpy_s(picked, ARRAYSIZE(picked), L"Unknown");
                    }
                    if(FAILED(GetPixelFormatName(actual, ARRAYSIZE(actual), format)))
                    {
                        wcscpy_s(actual, ARRAYSIZE(actual), L"Unknown");
                    }
                    msg.Format(L"You specified '%s' as the pixel format and WIC used '%s'", picked, actual);

                    if(m_suppressMessageBox == FALSE)
                    {
                        CWindow::MessageBoxW(msg, L"Different format picked", MB_OK);
                    }
                }

                delete codeGen;
            }
        }
        else
        {
            result = S_OK;
        }
    }
    else
    {
        CString msg;
        msg.Format(L"The selected element '%s' cannot be saved as an Image.", (LPCWSTR)element.Name());

        if(m_suppressMessageBox == FALSE)
        {
            ::MessageBox(0, msg, L"Cannot Save Element", MB_OK | MB_ICONERROR);
        }
    }

    return result;
}

LRESULT CMainFrame::OnAppExit(WORD, WORD, HWND, BOOL&)
{
    PostMessage(WM_CLOSE);

    return 0;
}

LRESULT CMainFrame::OnAppAbout(WORD, WORD, HWND, BOOL&)
{
    CAboutDlg dlg;
    dlg.DoModal();

    return 0;
}

#define ERROR_BLOCK_READER MAKE_HRESULT(1, 0x899, 1)

HRESULT GetReaderFromQueryReader(IWICMetadataQueryReader *queryReader, IWICMetadataReader **reader)
{
    HRESULT result = S_OK;

    // This will take the query reader and copy it into a CDummyBlockWriter. 
    // Internally, AddWriter will be called with the unabstracted metadata reader.
    class CDummyBlockWriter : 
        public IWICMetadataBlockWriter
    {
    public:
        IWICMetadataWriterPtr writer;
        IWICMetadataBlockReaderPtr blockReader;
        CDummyBlockWriter()
        {
        }

        ~CDummyBlockWriter()
        {
        }

        ULONG STDMETHODCALLTYPE AddRef()
        {
            return 0;
        }

        ULONG STDMETHODCALLTYPE Release()
        {
            return 0;
        }

        HRESULT STDMETHODCALLTYPE QueryInterface(const IID &id, void **dest)
        {
            if(id==IID_IWICMetadataBlockWriter)
                *dest=(IWICMetadataBlockWriter *)this;
            else if(id==IID_IWICMetadataBlockReader)
                *dest=(IWICMetadataBlockReader *)this;
            else if(id==IID_IUnknown)
                *dest=(IUnknown *)this;
            else
                return E_NOINTERFACE;
            return S_OK;
        }

        STDMETHOD(InitializeFromBlockReader)(
            IWICMetadataBlockReader *pIMDBlockReader
            )
        {
            blockReader = pIMDBlockReader;
            return S_OK;
        }

        STDMETHOD(GetWriterByIndex)(
            UINT /*nIndex*/,
            IWICMetadataWriter **ppIMetadataWriter
            )
        {
            *ppIMetadataWriter = nullptr;
            return CO_E_NOT_SUPPORTED;
        }

        STDMETHOD(AddWriter)(
            IWICMetadataWriter *pIMetadataWriter
            )
        {
            if(writer)
            {
                return CO_E_NOT_SUPPORTED;
            }
            writer=pIMetadataWriter;
            return S_OK;
        }

        STDMETHOD(SetWriterByIndex)(
            UINT /*nIndex*/,
            IWICMetadataWriter * /*pIMetadataWriter*/
            )
        {
            return CO_E_NOT_SUPPORTED;
        }

        STDMETHOD(RemoveWriterByIndex)(
            UINT /*nIndex*/)
        {
            return CO_E_NOT_SUPPORTED;
        }

        STDMETHOD(GetContainerFormat)(
            GUID * /*pguidContainerFormat*/
            )
        {
            return CO_E_NOT_SUPPORTED;
        }

        STDMETHOD(GetCount)(
            UINT *pcCount
            )
        {
            *pcCount = 0;
            return CO_E_NOT_SUPPORTED;
        }

        STDMETHOD(GetReaderByIndex)(
            UINT /*nIndex*/,
            IWICMetadataReader **ppIMetadataReader
            )
        {
            *ppIMetadataReader = nullptr;
            return CO_E_NOT_SUPPORTED;
        }

        STDMETHOD(GetEnumerator)(
            IEnumUnknown **ppIEnumMetadata
            )
        {
            *ppIEnumMetadata = nullptr;
            return CO_E_NOT_SUPPORTED;
        }
    } dummyWriter;

    // These lower level metadata data functions will require the component factory.
    IWICComponentFactoryPtr componentFactory;
    IFC(g_imagingFactory->QueryInterface(IID_IWICComponentFactory, (void **)&componentFactory));

    // This takes the IWICMetadataBlockWriter and wraps it as a IWICMetadataQueryWriter.
    // This is necessary because only query writer to query writer copying is supported.
    IWICMetadataQueryWriterPtr writerWrapper;
    IFC(componentFactory->CreateQueryWriterFromBlockWriter(&dummyWriter,&writerWrapper));

    // Prepare the propvariant for copying the query reader.
    PROPVARIANT propValue;
    PropVariantInit(&propValue);
    propValue.vt=VT_UNKNOWN;
    propValue.punkVal=queryReader;
    propValue.punkVal->AddRef();

    // Writing to "/" performs the special operation of copying from another query writer.
    IFC(writerWrapper->SetMetadataByName(L"/",&propValue));
    PropVariantClear(&propValue);

    // At this point, dummyWriter.writer should be set to the unabstracted query reader.
    if(dummyWriter.writer == 0)
    {
        if(dummyWriter.blockReader)
        {
            return ERROR_BLOCK_READER;
        }
        return E_FAIL;
    }

    IFC(dummyWriter.writer->QueryInterface(IID_IWICMetadataReader, (void **)reader));

    return result;
}

LRESULT CMainFrame::OnShowViewPane(WORD /*code*/, WORD item, HWND /*hSender*/, BOOL& handled)
{
    MENUITEMINFO currentState;
    memset(&currentState, 0, sizeof(currentState));
    currentState.cbSize = sizeof(MENUITEMINFO);
    currentState.fMask = MIIM_STATE;
    HMENU menu = GetMenu();

    GetMenuItemInfo(menu, item, FALSE, &currentState);

    if((currentState.fState & MFS_CHECKED) == MFS_CHECKED)
    {
        // Hide it
        OnPaneClose(0, 0, m_viewPane.m_hWnd, handled);
    }
    else
    {
        // Show it
        m_mainSplit.SetSinglePaneMode(SPLIT_PANE_NONE);

        // Set the check mark
        CheckMenuItem(menu, item, MF_CHECKED | MF_BYCOMMAND);
        handled = 1;
    }

    return 0;
}

LRESULT CMainFrame::OnShowAlpha(WORD /*code*/, WORD item, HWND /*hSender*/, BOOL& handled)
{
    MENUITEMINFO currentState;
    memset(&currentState, 0, sizeof(currentState));
    currentState.cbSize = sizeof(MENUITEMINFO);
    currentState.fMask = MIIM_STATE;
    HMENU menu = GetMenu();

    GetMenuItemInfo(menu, item, FALSE, &currentState);
    if((currentState.fState & MFS_CHECKED) == MFS_CHECKED)
    {
        m_viewcontext.bIsAlphaEnable = FALSE;
        CheckMenuItem(menu, item, MF_UNCHECKED | MF_BYCOMMAND);
    }
    else
    {
        m_viewcontext.bIsAlphaEnable = TRUE;
        CheckMenuItem(menu, item, MF_CHECKED | MF_BYCOMMAND);
        handled = 1;
    }

    HTREEITEM hItem = m_mainTree.GetSelectedItem();
    CInfoElement *elem = GetElementFromTreeItem(hItem);
    if (elem)
    {
        DrawElement(*elem);
    }

    return 0;
}

LRESULT CMainFrame::OnContextClick(WORD /*code*/, WORD item, HWND /*hSender*/, BOOL& handled)
{
    handled = 1;
    HTREEITEM hItem = m_mainTree.GetSelectedItem();
    CInfoElement *elem = GetElementFromTreeItem(hItem);

    switch(item)
    {
    case ID_FILE_LOAD:
        {
            CSimpleCodeGenerator temp;
            ((CBitmapDecoderElement *)elem)->Load(temp);
            UpdateTreeView(0);
            DrawElement(*elem);
        }
        break;
    case ID_FILE_UNLOAD:
        ((CBitmapDecoderElement *)elem)->Unload();
        UpdateTreeView(0);
        DrawElement(*elem);
        break;
    case ID_FILE_CLOSE:
        CElementManager::GetRootElement()->RemoveChild((CBitmapDecoderElement *)elem);
        UpdateTreeView(0);
        break;
    case ID_FIND_METADATA:
        {
            HRESULT result = QueryMetadata(elem);
            if(FAILED(result))
            {
                CString msg;
                CString err;
                GetHresultString(result, err);
                msg.Format(L"Unable find metadata. The error is: %s.", (LPCWSTR)err);
                
                if(m_suppressMessageBox == FALSE)
                {
                    CWindow::MessageBoxW(msg, L"Error Finding Metadata", MB_OK | MB_ICONWARNING);
                }
            }
        }
        break;
    }

    return 0;
}

HRESULT CMainFrame::QueryMetadata(CInfoElement *elem)
{
    HRESULT result = S_OK;

    class CQLPath : public CDialogImpl<CQLPath>
    {
    public:
        CAtlString m_path;
        enum { IDD = IDD_QLPATH };

        BEGIN_MSG_MAP(CAboutDlg)
            COMMAND_ID_HANDLER(IDOK, OnCloseCmd)
            COMMAND_ID_HANDLER(IDCANCEL, OnCloseCmd)
        END_MSG_MAP()

        LRESULT OnCloseCmd(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
        {
            GetDlgItemText(IDC_QLPATH, m_path);
            EndDialog(wID);
            return 0;
        }
    } qlpath;

    if (IDOK != qlpath.DoModal())
    {
        return S_OK;
    }

    IWICMetadataQueryReaderPtr rootQueryReader;
    IFC(elem->GetQueryReader(&rootQueryReader));

    bool inbraces = 0;
    int lastSlash = -1;
    for(int pos = 0; pos < qlpath.m_path.GetLength(); pos++)
    {
        switch(qlpath.m_path[pos])
        {
        case L'\\':
            // skip the next character
            pos++;
            break;
        case L'{':
            inbraces = 1;
            break;
        case L'}':
            inbraces = 0;
            break;
        case L'/':
            // braces escape forward slashes, e.g. /ifd/xmp/{wstr=string with /s}
            if(!inbraces)
            {
                lastSlash = pos;
            }
            break;
        }
    }

    // Now let's get the query reader for everything upto the last slash
    CString parentPath, childPath;
    if(lastSlash == -1 || lastSlash == 0)
    {
        if(dynamic_cast<CBitmapFrameDecodeElement*>(elem))
        {
            // A frame decode element doesn't normally display metadata. We should punt this.
            parentPath = qlpath.m_path;
        }
        else
        {
            // Display it inside the current element
            childPath = qlpath.m_path;
        }
    }
    else
    {
        parentPath = qlpath.m_path.Mid(0, lastSlash);
        childPath = qlpath.m_path.Mid(lastSlash);
    }

    IWICMetadataQueryReaderPtr parentQueryReader;
    PROPVARIANT value;

    PropVariantInit(&value);

    if(parentPath != L"")
    {
        if(FAILED(rootQueryReader->GetMetadataByName(parentPath, &value)))
        {
            parentPath = qlpath.m_path;
            IFC(rootQueryReader->GetMetadataByName(parentPath, &value));
        }
        if(value.vt == VT_UNKNOWN)
        {
            IFC(value.punkVal->QueryInterface(IID_IWICMetadataQueryReader,
                (void **)&parentQueryReader));
        }
        else
        {
            // This wasn't really a path to a metadata query reader. This means
            // the parsing failed. The best we can do is display this result in
            // the frame decoder.
            parentQueryReader = rootQueryReader;
            childPath = parentPath;
        }

        PropVariantClear(&value);
    }
    else
    {
        parentQueryReader = rootQueryReader;
    }

    IWICMetadataReaderPtr parentReader;
    CInfoElement *parentElem;
    if(FAILED(GetReaderFromQueryReader(parentQueryReader, &parentReader)))
    {    
        parentElem = elem;
    }
    else
    {
        parentElem = elem->FindElementByReader(parentReader);
    }

    if(parentElem)
    {
        parentElem->m_queryKey = qlpath.m_path;
        CString v;
        // If there's a child element (might not be true if this is a branch), then
        // read its value. Otherwise, use the parent's path
        if(childPath != L"")
        {
            parentQueryReader->GetMetadataByName(childPath, &value);
        }
        else
        {
            rootQueryReader->GetMetadataByName(parentPath, &value);
        }
        result = PropVariantToString(&value, PVTSOPTION_IncludeType, v);
        PropVariantClear(&value);
        IFC(result);

        parentElem->m_queryValue = v;
        if(elem == parentElem)
        {
            // Redraw the output view with the new query string
            DrawElement(*parentElem);
        }
        else
        {
            // When the tree selection changes, the output view will be redrawn
            m_mainTree.SelectItem(GetTreeItemFromElement(parentElem));
        }
    }
    return result;
}
