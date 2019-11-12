// ddddd.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "ddddd.h"
#include "Resource.h"
#include <stdio.h>
#include <CommDlg.h>
#include <windows.h>

OPENFILENAME ofn;
TCHAR szFile[260];
HANDLE hf;
BOOL  bBitmap=0;
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{

	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;

switch (message)
    {
    case WM_COMMAND:
        wmId    = LOWORD(wParam);
        wmEvent = HIWORD(wParam);
        // Parse the menu selections:
        switch (wmId)
        {
		case ID_OPTION_DISPLAY:
            bBitmap=!bBitmap;
            InvalidateRect(hWnd,0,TRUE);
            break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }

case WM_PAINT:
        hdc = BeginPaint(hWnd, &ps);
        // TODO: Add any drawing code here...
if(bBitmap)
        {
        ZeroMemory(&ofn, sizeof(ofn));
        ofn.lStructSize = sizeof(ofn);
        ofn.hwndOwner = hWnd;
        ofn.lpstrFile = szFile;
        //
        // Set lpstrFile[0] to '\0' so that GetOpenFileName does not 
        // use the contents of szFile to initialize itself.
        //
        ofn.lpstrFile[0] = '\0';
        ofn.nMaxFile = sizeof(szFile);
        ofn.nFilterIndex = 1;
        ofn.lpstrFileTitle = NULL;
        ofn.nMaxFileTitle = 0;
        ofn.lpstrInitialDir = NULL;
        ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;

        // Display the Open dialog box. 

        if (GetOpenFileName(&ofn)==TRUE) 
            hf = CreateFile(ofn.lpstrFile, GENERIC_READ,
                0, (LPSECURITY_ATTRIBUTES) NULL,
                OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL,
                (HANDLE) NULL);

    LoadBitmap((HINSTANCE)("F-35C.bmp"),(LPCWSTR)hdc);

        EndPaint(hWnd, &ps);
        break;
        }

}
}
bool LoadBitmap(LPCWSTR szFileName, HDC hWinDC)
{
    // Load the bitmap image file
    HBITMAP hBitmap;
    hBitmap = (HBITMAP)::LoadImage(NULL, szFileName, IMAGE_BITMAP, 0, 0,
        LR_LOADFROMFILE);
    // Verify that the image was loaded
    if (hBitmap == NULL) {
        ::MessageBox(NULL, __T("LoadImage Failed"), __T("Error"), MB_OK);
        return false;
    }

    // Create a device context that is compatible with the window
    HDC hLocalDC;
    hLocalDC = ::CreateCompatibleDC(hWinDC);
    // Verify that the device context was created
    if (hLocalDC == NULL) {
        ::MessageBox(NULL, __T("CreateCompatibleDC Failed"), __T("Error"), MB_OK);
        return false;
    }

    // Get the bitmap's parameters and verify the get
    BITMAP qBitmap;
    int iReturn = GetObject(reinterpret_cast<HGDIOBJ>(hBitmap), sizeof(BITMAP),
        reinterpret_cast<LPVOID>(&qBitmap));
    if (!iReturn) {
        ::MessageBox(NULL, __T("GetObject Failed"), __T("Error"), MB_OK);
        return false;
    }

    // Select the loaded bitmap into the device context
    HBITMAP hOldBmp = (HBITMAP)::SelectObject(hLocalDC, hBitmap);
    if (hOldBmp == NULL) {
        ::MessageBox(NULL, __T("SelectObject Failed"), __T("Error"), MB_OK);
        return false;
    }

    // Blit the dc which holds the bitmap onto the window's dc
    BOOL qRetBlit = ::BitBlt(hWinDC, 0, 0, qBitmap.bmWidth, qBitmap.bmHeight,
        hLocalDC, 0, 0, SRCCOPY);
    if (!qRetBlit) {
        ::MessageBox(NULL, __T("Blit Failed"), __T("Error"), MB_OK);
        return false;
    }

    // Unitialize and deallocate resources
    ::SelectObject(hLocalDC, hOldBmp);
    ::DeleteDC(hLocalDC);
    ::DeleteObject(hBitmap);
    return true;
}
	