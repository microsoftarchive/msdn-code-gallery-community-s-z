// YUV_Viewer Application.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "Commdlg.h"
#include "windows.h"
#include "stdio.h"
#include "YUV_Viewer Application.h"

#define MAX_LOADSTRING 100

#define B(Col,Row) g_pRGB_Buffer[    3*((Col) + g_Width * (Row))]
#define G(Col,Row) g_pRGB_Buffer[1 + 3*((Col) + g_Width * (Row))]
#define R(Col,Row) g_pRGB_Buffer[2 + 3*((Col) + g_Width * (Row))]

#define TB(Col,Row) g_pTRGB_Buffer[    3*((Col) + g_Width * (Row))]
#define TG(Col,Row) g_pTRGB_Buffer[1 + 3*((Col) + g_Width * (Row))]
#define TR(Col,Row) g_pTRGB_Buffer[2 + 3*((Col) + g_Width * (Row))]

#define SB(Col,Row) BGR_Buffer[    3*((Col) + g_Width * (Row))]
#define SG(Col,Row) BGR_Buffer[1 + 3*((Col) + g_Width * (Row))]
#define SR(Col,Row) BGR_Buffer[2 + 3*((Col) + g_Width * (Row))]

#define Y(Col,Row) YUV444_Buffer[    3*((Col) + g_Width * (Row))]
#define U(Col,Row) YUV444_Buffer[1 + 3*((Col) + g_Width * (Row))]
#define V(Col,Row) YUV444_Buffer[2 + 3*((Col) + g_Width * (Row))]


BYTE Clamp(int n)
{
    if (n >= 255)
        n = 255;
    else if(n<=0)
        n=0;
    return n;
}
// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name
WCHAR g_SrcFileName[260];
DWORD g_BytesRead=0,g_BytesWritten=0,g_Size=0,g_CurrentFrame;
bool g_flag=0,g_Cflag=0;
UINT g_Width=0,g_Height=0,g_Frames=1,g_HSPosition=0,g_VTPosition=0;
WCHAR g_CoOrdinates[20];

BYTE *g_pRGB_Buffer;
BYTE *g_pTRGB_Buffer;

BITMAPINFO Bitmapinfo;
BITMAPINFOHEADER bmpinfo;

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	YUVViewer(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	FullScreen(HWND, UINT, WPARAM,LPARAM);
INT_PTR CALLBACK	ActualSize(HWND, UINT, WPARAM,LPARAM);

BYTE* YUV444toRGB888(BYTE *YUV444_Buffer,BYTE *g_pRGB_Buffer,UINT g_Width,UINT g_Height);
BYTE* YUV422toYUV444(BYTE *YUV422_Buffer,UINT g_Width,UINT g_Height);
BYTE* YUV420toYUV444(BYTE *YUV420_Buffer,UINT g_Width,UINT g_Height);
bool SaveBMP ( BYTE* Buffer, int width, int height, long paddedsize, LPCTSTR bmpfile );
BYTE* ConvertRGBToBMPBuffer ( BYTE* Buffer, int width, int height);
void OnPaint(HWND hDlg);
void ActualPaint(HWND hDlg);

int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_YUV_VIEWERAPPLICATION, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_YUV_VIEWERAPPLICATION));

	// Main message loop:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_YUV_VIEWERAPPLICATION));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_YUV_VIEWERAPPLICATION);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }
	
   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
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
		case ID_YUVVIEWER_OPENAPPLICATION:
			{
				DialogBox(hInst, MAKEINTRESOURCE(IDD_DIALOG), hWnd, YUVViewer);
			}break;
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;		
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}

INT_PTR CALLBACK ActualSize(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);

	switch (message)
	{
	case WM_INITDIALOG:
		{
			UINT Dx=5,Dy=5,DWidth=GetSystemMetrics(SM_CXSCREEN)-30,DHeight=GetSystemMetrics(SM_CYSCREEN)-95;		
			SetWindowPos(hDlg,HWND_BOTTOM,Dx,Dy,DWidth+25,DHeight+46,SWP_SHOWWINDOW);
			SCROLLINFO HS_Info,VS_Info; 
			HS_Info.cbSize = sizeof(HS_Info); 
			HS_Info.fMask  = SIF_RANGE | SIF_PAGE | SIF_POS; 
			HS_Info.nMin   = 0; 
			HS_Info.nMax   = g_Width-DWidth; 
			HS_Info.nPage  = 1; 
			HS_Info.nPos   = 0; 
			 
			VS_Info.cbSize = sizeof(VS_Info); 
			VS_Info.fMask  = SIF_RANGE | SIF_PAGE | SIF_POS; 
			VS_Info.nMin   = 0; 
			VS_Info.nMax   = g_Height-DHeight; 
			VS_Info.nPage  = 1; 
			VS_Info.nPos   = 0; 
			SetScrollInfo(hDlg, SB_HORZ, &HS_Info, TRUE); 
			SetScrollInfo(hDlg, SB_VERT, &VS_Info, TRUE);
			SetWindowText(hDlg,(LPCWSTR)g_CoOrdinates);

		}
		return (INT_PTR)TRUE;
	case WM_PAINT:
		{			
			PAINTSTRUCT ps;
			HDC hdc = BeginPaint(hDlg, &ps);
			ActualPaint(hDlg);	
			DeleteDC(hdc);

		}break;
	case WM_VSCROLL:
		{				
			g_VTPosition = GetScrollPos(hDlg, SB_VERT);
            switch (LOWORD(wParam))
            {                          
				case SB_THUMBPOSITION:
				{
					g_VTPosition = HIWORD(wParam);
					
					SetScrollPos(hDlg,SB_VERT,g_VTPosition,1);
					swprintf(g_CoOrdinates,L"%d,%d",g_HSPosition,g_VTPosition);
					SetWindowText(hDlg,(LPCWSTR)g_CoOrdinates);
					ActualPaint(hDlg);
				}break;
				case SB_THUMBTRACK:
				{
					g_VTPosition = HIWORD(wParam);					
					swprintf(g_CoOrdinates,L"%d,%d",g_HSPosition,g_VTPosition);	
					SetWindowText(hDlg,(LPCWSTR)g_CoOrdinates);
					ActualPaint(hDlg);
				}break;				
				
            }				
		}
		break;
	case WM_MOUSEWHEEL:
				{
					int zDelta = (short) HIWORD(wParam) / WHEEL_DELTA;
					int VTPosition=g_VTPosition;
					VTPosition+=((-zDelta)*4);								
					if(VTPosition>=0&&VTPosition<=g_Height-480)
					{
						g_VTPosition=VTPosition;
						SetScrollPos(hDlg,SB_VERT,g_VTPosition,1);
						swprintf(g_CoOrdinates,L"%d,%d",g_HSPosition,g_VTPosition);	
						SetWindowText(hDlg,(LPCWSTR)g_CoOrdinates);
						ActualPaint(hDlg);
					}
				}break;
	case WM_HSCROLL:
		{				
			g_HSPosition = GetScrollPos(hDlg, SB_HORZ);
            switch (LOWORD(wParam))
            {               
				case SB_THUMBPOSITION:
				{
					g_HSPosition = HIWORD(wParam);
					swprintf(g_CoOrdinates,L"%d,%d",g_HSPosition,g_VTPosition);	
					SetWindowText(hDlg,(LPCWSTR)g_CoOrdinates);
					SetScrollPos(hDlg,SB_HORZ,g_HSPosition,1);
					ActualPaint(hDlg);

				}break;
				case SB_THUMBTRACK:
				{
					g_HSPosition = HIWORD(wParam);
					swprintf(g_CoOrdinates,L"%d,%d",g_HSPosition,g_VTPosition);	
					SetWindowText(hDlg,(LPCWSTR)g_CoOrdinates);
					ActualPaint(hDlg);
				}break;
            }			
		}
		break;
	

	case WM_COMMAND:
		{
			if (LOWORD(wParam) == IDCANCEL)
			{
				EndDialog(hDlg, LOWORD(wParam));
				return (INT_PTR)TRUE;
			}			
		}
		break;
	}
	return (INT_PTR)FALSE;
}
void DisableButtons(HWND hDlg)
{
	HWND BPlay,BNext,BPrev,BStop,BPlayInf;
	BPlay=GetDlgItem(hDlg,IDC_PLAY);
	BNext=GetDlgItem(hDlg,IDC_NEXT);
	BPrev=GetDlgItem(hDlg,IDC_PREVIOUS);
	BStop=GetDlgItem(hDlg,IDC_STOP);
	
	BPlayInf=GetDlgItem(hDlg,IDC_PLAYINF);								
	

	EnableWindow(BPlay,0);
	EnableWindow(BNext,0);
	EnableWindow(BPrev,0);
	EnableWindow(BStop,0);
	EnableWindow(BPlay,0);
	
	EnableWindow(BPlayInf,0);
}
void EnableButtons(HWND hDlg)
{
	HWND BPlay,BNext,BPrev,BStop,BPlayInf;
	BPlay=GetDlgItem(hDlg,IDC_PLAY);
	BNext=GetDlgItem(hDlg,IDC_NEXT);
	BPrev=GetDlgItem(hDlg,IDC_PREVIOUS);
	BStop=GetDlgItem(hDlg,IDC_STOP);
	
	BPlayInf=GetDlgItem(hDlg,IDC_PLAYINF);								
	

	EnableWindow(BPlay,1);
	EnableWindow(BNext,1);
	EnableWindow(BPrev,1);
	EnableWindow(BStop,1);
	EnableWindow(BPlay,1);
	
	EnableWindow(BPlayInf,1);
}
void ActualPaint(HWND hDlg)
{		
		UINT Dx=4,Dy=25,DWidth=GetSystemMetrics(SM_CXSCREEN)-30,DHeight=GetSystemMetrics(SM_CYSCREEN)-95;	
		UINT offset=((g_CurrentFrame-1)*g_Width*g_Height*3);
		HDC Bhdc=GetWindowDC(hDlg);	
		SetBkMode(Bhdc,TRANSPARENT);
		if(g_Width>=DWidth)
		{			

			StretchDIBits(Bhdc,Dx,Dy+DHeight,DWidth,-DHeight,g_HSPosition,g_VTPosition,DWidth,DHeight,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);
		}
		else if((g_Width>=1024)&&(g_Width<=DWidth))
		{			
			StretchDIBits(Bhdc,Dx,Dy+g_Height,g_Width,-g_Height,g_HSPosition,g_VTPosition,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);				
		}
		else if((g_Width>=640)&&(g_Width<1024))
		{			
			StretchDIBits(Bhdc,310,g_Height+160,g_Width,-g_Height,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);				
		}
		else if((g_Width>=320)&&(g_Width<640))
		{
			StretchDIBits(Bhdc,450,g_Height+250,g_Width,-g_Height,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);								
		}
		else if((g_Width>=176)&&(g_Width<320))
		{
			StretchDIBits(Bhdc,550,g_Height+300,g_Width,-g_Height,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);								
		}
		DeleteDC(Bhdc);
}

INT_PTR CALLBACK FullScreen(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_PAINT:
		{
			UINT Dx=550,Dy=300,DWidth=GetSystemMetrics(SM_CXSCREEN)-342,DHeight=GetSystemMetrics(SM_CYSCREEN);			
			UINT offset=((g_CurrentFrame-1)*g_Width*g_Height*3);
			PAINTSTRUCT ps;
			HDC hdc = BeginPaint(hDlg, &ps);
			HDC Bhdc=GetWindowDC(hDlg);				
			BitBlt(Bhdc,0,0,GetSystemMetrics(SM_CXSCREEN),GetSystemMetrics(SM_CYSCREEN),NULL,0,0,BLACKNESS);
			if(g_Width>=DWidth)
			{
				SetStretchBltMode(Bhdc,HALFTONE );				
				StretchDIBits(Bhdc,155,768,1024,-768,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);
			}
			else if((g_Width>=640)&&(g_Width<=DWidth))
			{			
				StretchDIBits(Bhdc,310,g_Height+160,g_Width,-g_Height,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);				
			}
			else if((g_Width>=320)&&(g_Width<=640))
			{
				StretchDIBits(Bhdc,450,g_Height+250,g_Width,-g_Height,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);								
			}
			else if((g_Width>=176)&&(g_Width<=320))
			{
				StretchDIBits(Bhdc,550,g_Height+300,g_Width,-g_Height,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);								
			}
			EndPaint(hDlg, &ps);
			DeleteDC(hdc);
			
			DeleteDC(Bhdc);
		}
		break;
	case WM_INITDIALOG:
		{
			SetWindowPos(hDlg,HWND_BOTTOM,0,0,GetSystemMetrics(SM_CXSCREEN),GetSystemMetrics(SM_CYSCREEN),SWP_SHOWWINDOW);		
		
			return (INT_PTR)TRUE;
		}
		break;
	case WM_RBUTTONDOWN:
			{
				EndDialog(hDlg, LOWORD(wParam));
				return (INT_PTR)TRUE;
			}break;
	case WM_COMMAND:
		{
			if (LOWORD(wParam) == IDCANCEL)
			{
				EndDialog(hDlg, LOWORD(wParam));
				return (INT_PTR)TRUE;
			}
			
		}
		break;
	}
	return (INT_PTR)FALSE;
}

INT_PTR CALLBACK YUVViewer(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{	
	PAINTSTRUCT ps;
	HDC hdc;
	UNREFERENCED_PARAMETER(lParam);	
	g_Frames=GetDlgItemInt(hDlg,IDC_FRAMES,0,0);	  

	switch (message)
	{
	case WM_INITDIALOG:
		{						
			SetDlgItemText(hDlg,IDC_COMBO1,L"Select YUV Type");
			SetDlgItemText(hDlg,IDC_FRAMES,L"1");
			SetWindowPos(hDlg,HWND_DESKTOP,200,5,900,675,0);
			SendDlgItemMessage(hDlg,IDC_COMBO1,CB_ADDSTRING,0,(LPARAM)L"YUV444");
			SendDlgItemMessage(hDlg,IDC_COMBO1,CB_ADDSTRING,0,(LPARAM)L"YUV422");
			SendDlgItemMessage(hDlg,IDC_COMBO1,CB_ADDSTRING,0,(LPARAM)L"YUV420");
			DisableButtons(hDlg);
			return (INT_PTR)TRUE;
		}
	case WM_PAINT:
		{		
			hdc = BeginPaint(hDlg, &ps);
			OnPaint(hDlg);			
		// TODO: Add any drawing code here...
			EndPaint(hDlg, &ps);					
		}
		break;
	case WM_TIMER:
			{ 
				switch (wParam) 
				{ 
					case IDT_300MILLISECONDS: 
					{
						/*MessageBox(hDlg,L"5 Seconds Up",L"Timer Function",0);*/
						UINT CurrentSelection=1;
						CurrentSelection=GetDlgItemInt(hDlg,IDC_CURFRAM,0,0);
						if(CurrentSelection==g_Frames)
						{							
							SetDlgItemInt(hDlg,IDC_CURFRAM,1,0);
						}
						else
						{
							SetDlgItemInt(hDlg,IDC_CURFRAM,CurrentSelection+1,0);
							g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,0,0);							
							OnPaint(hDlg);
						}						
					}
					break;
					return 0; 			 
				} 
			}
			break;
		
		
	case WM_COMMAND:
		switch (wParam)
		{
		case IDC_ACTUALSIZE:
			{
				DialogBox(hInst, MAKEINTRESOURCE(IDD_ACTUAL), hDlg, ActualSize);		

			}break;
		case IDC_FULLSCREEN:
			{
				DialogBox(hInst, MAKEINTRESOURCE(IDD_FULLSCREEN), hDlg, FullScreen);				
			}break;
		case IDC_NEXT:
			{
				UINT CurrentSelection=1;
				CurrentSelection=GetDlgItemInt(hDlg,IDC_CURFRAM,0,0);
				if(CurrentSelection==g_Frames)
					SetDlgItemInt(hDlg,IDC_CURFRAM,1,0);
				else
					SetDlgItemInt(hDlg,IDC_CURFRAM,CurrentSelection+1,0);
				g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,0,0);			
				OnPaint(hDlg);
			}break;
		case IDC_PLAYINF:
			{
			if(IsDlgButtonChecked(hDlg,IDC_PLAYINF)== BST_CHECKED)
			{
				/*MessageBox(hDlg,L"Button Checked",L"Check Button",0);*/
				SetTimer(hDlg,IDT_300MILLISECONDS,200,(TIMERPROC) NULL); 				
				SetDlgItemInt(hDlg,IDC_CURFRAM,1,0);
				g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,0,0);					

			}
			if(IsDlgButtonChecked(hDlg,IDC_PLAYINF)== BST_UNCHECKED)
			{
				KillTimer(hDlg,IDT_300MILLISECONDS);
				/*MessageBox(hDlg,L"Check Button Un-Checked",L"Check Button",0);*/

			}
			}break;
		case IDC_PREVIOUS:
			{
				
					UINT CurrentSelection=1;
				CurrentSelection=GetDlgItemInt(hDlg,IDC_CURFRAM,0,0);
				if(CurrentSelection==1)
					SetDlgItemInt(hDlg,IDC_CURFRAM,g_Frames,0);
				else
					SetDlgItemInt(hDlg,IDC_CURFRAM,CurrentSelection-1,0);
				g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,0,0);			
				OnPaint(hDlg);
				
			}break;
		
		case IDC_PLAY:
			{
				
				SetTimer(hDlg,IDT_300MILLISECONDS,300,(TIMERPROC) NULL); 				
				SetDlgItemInt(hDlg,IDC_CURFRAM,1,0);
				g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,0,0);				

			}break;
		case IDC_STOP:
			{
				 
				KillTimer(hDlg,IDT_300MILLISECONDS);
			}break;

		case IDC_SAVEAS:
			{
				OPENFILENAME ofn;       // common dialog box structure								
							
				ZeroMemory(&ofn, sizeof(ofn));
				ofn.lStructSize = sizeof(ofn);
				ofn.hwndOwner = hDlg;
				ofn.lpstrFile = g_SrcFileName;				
				ofn.lpstrFile[0] = '\0';
				ofn.nMaxFile = sizeof(g_SrcFileName);
				ofn.lpstrFilter = L"Bitmap\0*.BMP\0";
				ofn.nFilterIndex = 1;
				ofn.lpstrFileTitle = NULL;
				ofn.nMaxFileTitle = 0;
				ofn.lpstrInitialDir = NULL;
				ofn.lpstrDefExt = L"BMP";
				ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
				g_Size= g_Width*g_Height*3;
				
				if (GetSaveFileName(&ofn)==TRUE) // Display the Open dialog box. 
				{	/*For any Operation on File Handle Use here.*/			
					/*BYTE *BMP_Buffer=ConvertRGBToBMPBuffer(g_pTRGB_Buffer,g_Width,g_Height);*/
					/*SaveBMP(BMP_Buffer,g_Width,g_Height,g_Size,ofn.lpstrFile);*/
					SaveBMP(g_pTRGB_Buffer,g_Width,g_Height,g_Size,ofn.lpstrFile);
					/*delete[]BMP_Buffer;*/					
				}	
				/*SetDlgItemText(hDlg,IDC_EDIT1,L"");
				SetDlgItemInt(hDlg,IDC_WIDTH,0,0);
				SetDlgItemInt(hDlg,IDC_HEIGHT,0,0);
				SetDlgItemText(hDlg,IDC_COMBO1,L"Select YUV Type");*/
			}
			break;
		
		case IDC_DISPLAY:
			{	
				InvalidateRect(hDlg,0,1);
				DisableButtons(hDlg);
				g_Width=GetDlgItemInt(hDlg,IDC_WIDTH,0,0);
				g_Height=GetDlgItemInt(hDlg,IDC_HEIGHT,0,0);
				SetDlgItemText(hDlg,IDC_CURFRAM,L"1");
				g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,0,0);
				if(g_Width==0||g_Height==0)
				{
					MessageBox(hDlg,L"Please Enter the Width & Height of Image",L"Select Width & Height",0);
					return NULL;
					break;
				}				
				HWND Combo=GetDlgItem(hDlg,IDC_COMBO1);
				int index=SendMessage(Combo,CB_GETCURSEL,0,0);
				switch(index)
				{
				case 2:
					{
						/*MessageBox(hDlg,L"You have selected 3rd Item - YUV444",L"Item Selected",0);						*/
						ZeroMemory(&Bitmapinfo,sizeof(Bitmapinfo));
						ZeroMemory(&bmpinfo,sizeof(bmpinfo));

						bmpinfo.biSize = sizeof(BITMAPINFOHEADER);
						bmpinfo.biWidth = g_Width;
						bmpinfo.biHeight = g_Height;
						bmpinfo.biPlanes = 1;			// we only have one bitplane
						bmpinfo.biBitCount = 24;		// RGB mode is 24 bits
						bmpinfo.biCompression = BI_RGB;	
						bmpinfo.biSizeImage = 0;		// can be 0 for 24 bit images
						bmpinfo.biXPelsPerMeter = 0;     // paint and PSP use this values
						bmpinfo.biYPelsPerMeter = 0;     
						bmpinfo.biClrUsed = 0;			// we are in RGB mode and have no palette
						bmpinfo.biClrImportant = 0;    // all colors are important
						HANDLE File_Handle;              // file handle						

						Bitmapinfo.bmiHeader=bmpinfo;									
					
						File_Handle=CreateFile(g_SrcFileName,GENERIC_READ,0,
											(LPSECURITY_ATTRIBUTES) NULL,OPEN_EXISTING,
											FILE_ATTRIBUTE_NORMAL,(HANDLE) NULL);
							/*MessageBox(hDlg,L"File Opened Successfully",L"Item Selected",0);*/
						
						DWORD FileSize=GetFileSize(File_Handle,NULL);
						g_Frames=((UINT)FileSize/(g_Width*g_Height*3));
						
						SetDlgItemInt(hDlg,IDC_FRAMES,g_Frames,0);
						if(g_Frames>1)
							EnableButtons(hDlg);
						UINT g_Size;
						g_Size=g_Width*g_Height*g_Frames*3;

						if(g_Size<FileSize)
						{
							/*MessageBox(hDlg,L"Check the Width & Height of File & File Size ",0,0);*/
							CloseHandle ( File_Handle );
							return NULL;
						}	
						
						BYTE *YUV444_Buffer;
						YUV444_Buffer=(BYTE*)GlobalAlloc(0,g_Size);	
						if ( YUV444_Buffer==NULL)
						{
							MessageBox(hDlg,L"Cannot Create Buffer to Hold Data",0,0);
							return NULL;
						}

						if ( ReadFile ( File_Handle, YUV444_Buffer, g_Size, &g_BytesRead, NULL ) == false )
						{
							MessageBox(hDlg,L"File Cannot be Opened",0,0);
							CloseHandle ( File_Handle );
							return NULL;
						}
				
						CloseHandle ( File_Handle );
						
						g_pTRGB_Buffer=YUV444toRGB888(YUV444_Buffer,g_pTRGB_Buffer,g_Width,g_Height);
						if ( g_pTRGB_Buffer==NULL)
						{
							MessageBox(hDlg,L"Cannot Create g_pTRGB_Buffer Buffer to Hold Data",0,0);
							return NULL;
						}					
						
						g_flag=1;
						OnPaint(hDlg);
						GlobalFree(YUV444_Buffer);						
					}
					break;
				case 1:
					/*MessageBox(hDlg,L"You have selected 2nd Item - YUV422",L"Item Selected",0);*/
					{						
						ZeroMemory(&Bitmapinfo,sizeof(Bitmapinfo));
						ZeroMemory(&bmpinfo,sizeof(bmpinfo));

						bmpinfo.biSize = sizeof(BITMAPINFOHEADER);
						bmpinfo.biWidth = g_Width;
						bmpinfo.biHeight = g_Height;
						bmpinfo.biPlanes = 1;			// we only have one bitplane
						bmpinfo.biBitCount = 24;		// RGB mode is 24 bits
						bmpinfo.biCompression = BI_RGB;	
						bmpinfo.biSizeImage = 0;		// can be 0 for 24 bit images
						bmpinfo.biXPelsPerMeter = 0;     // paint and PSP use this values
						bmpinfo.biYPelsPerMeter = 0;     
						bmpinfo.biClrUsed = 0;			// we are in RGB mode and have no palette
						bmpinfo.biClrImportant = 0;    // all colors are important
						HANDLE File_Handle;              // file handle							

						Bitmapinfo.bmiHeader=bmpinfo;		
						
					
						File_Handle=CreateFile(g_SrcFileName,GENERIC_READ,0,
											(LPSECURITY_ATTRIBUTES) NULL,OPEN_EXISTING,
											FILE_ATTRIBUTE_NORMAL,(HANDLE) NULL);
							/*MessageBox(hDlg,L"File Opened Successfully",L"Item Selected",0);*/
						DWORD FileSize=GetFileSize(File_Handle,NULL);
						g_Frames=((UINT)FileSize/(g_Width*g_Height*2));
						
						SetDlgItemInt(hDlg,IDC_FRAMES,g_Frames,0);
						if(g_Frames>1)
							EnableButtons(hDlg);
						g_Size=g_Width*g_Height*g_Frames;	
						if((g_Size*2)<FileSize)
						{
							MessageBox(hDlg,L"Check the Width & Height of File & File Size ",0,0);
							CloseHandle ( File_Handle );
							return NULL;
						}								
												
						BYTE* YUV422_Buffer= (BYTE*)GlobalAlloc(0,g_Size*2);
						if ( YUV422_Buffer==NULL)
						{
							MessageBox(hDlg,L"Cannot Create YUV422_Buffer Buffer to Hold Data",0,0);
							return NULL;
						}
						
						if ( ReadFile ( File_Handle, YUV422_Buffer, g_Size*2, &g_BytesRead, NULL ) == false )
						{
							MessageBox(hDlg,L"File Cannot be Opened",0,0);
							CloseHandle ( File_Handle );
							return NULL;
						}	
						CloseHandle ( File_Handle );
						BYTE* YUV444_Buffer=YUV422toYUV444(YUV422_Buffer,g_Width,g_Height);						
						if ( YUV444_Buffer==NULL)
						{
							MessageBox(hDlg,L"Cannot Create YUV444_Buffer Buffer to Hold Data",0,0);
							return NULL;
						}						
						g_pTRGB_Buffer=YUV444toRGB888(YUV444_Buffer,g_pTRGB_Buffer,g_Width,g_Height);	
						if ( g_pTRGB_Buffer==NULL)
						{
							MessageBox(hDlg,L"422:Cannot Create g_pTRGB_Buffer Buffer to Hold Data",0,MB_OK);
							return NULL;
						}
						
						g_flag=1;
						OnPaint(hDlg);
						GlobalFree(YUV444_Buffer);
						GlobalFree(YUV422_Buffer);
					}
					break;
				case 0:
					{
						/*MessageBox(hDlg,L"You have selected 1 st Item - YUV420",L"Item Selected",0);*/
						ZeroMemory(&Bitmapinfo,sizeof(Bitmapinfo));
						ZeroMemory(&bmpinfo,sizeof(bmpinfo));

						bmpinfo.biSize = sizeof(BITMAPINFOHEADER);
						bmpinfo.biWidth = g_Width;
						bmpinfo.biHeight = g_Height;
						bmpinfo.biPlanes = 1;			// we only have one bitplane
						bmpinfo.biBitCount = 24;		// RGB mode is 24 bits
						bmpinfo.biCompression = BI_RGB;	
						bmpinfo.biSizeImage = 0;		// can be 0 for 24 bit images
						bmpinfo.biXPelsPerMeter = 0;     // paint and PSP use this values
						bmpinfo.biYPelsPerMeter = 0;     
						bmpinfo.biClrUsed = 0;			// we are in RGB mode and have no palette
						bmpinfo.biClrImportant = 0;    // all colors are important
						HANDLE File_Handle;              // file handle	
						

						Bitmapinfo.bmiHeader=bmpinfo;		

					
						File_Handle=CreateFile(g_SrcFileName,GENERIC_READ,0,
											(LPSECURITY_ATTRIBUTES) NULL,OPEN_EXISTING,
											FILE_ATTRIBUTE_NORMAL,(HANDLE) NULL);
							/*MessageBox(hDlg,L"File Opened Successfully",L"Item Selected",0);*/
						
						DWORD FileSize=GetFileSize(File_Handle,NULL);
						g_Frames=((UINT)FileSize/(g_Width*g_Height+((g_Width*g_Height)/2)));
						
						SetDlgItemInt(hDlg,IDC_FRAMES,g_Frames,0);
						if(g_Frames>1)
							EnableButtons(hDlg);
						g_Size=g_Width*g_Height*g_Frames;							
						
						UINT ISize;
						ISize=g_Frames*((g_Width*g_Height)+((g_Width*g_Height)/2));							
						
						BYTE* YUV420_Buffer= (BYTE*)GlobalAlloc(GPTR,ISize);
						if ( YUV420_Buffer==NULL)
						{
							MessageBox(hDlg,L"Cannot Create YUV420_Buffer Buffer to Hold Data",0,0);
							return NULL;
						}		

						if ( ReadFile ( File_Handle, YUV420_Buffer, ISize, &g_BytesRead, NULL ) == false )
						{
							MessageBox(hDlg,L"File Cannot be Opened",0,0);
							CloseHandle ( File_Handle );
							return NULL;
						}	
						CloseHandle ( File_Handle );
						
						BYTE* YUV444_Buffer=YUV420toYUV444(YUV420_Buffer,g_Width,g_Height);
						GlobalFree(YUV420_Buffer);
						if ( YUV444_Buffer==NULL)
						{
							MessageBox(hDlg,L"Cannot Create YUV444_Buffer Buffer to Hold Data",0,0);
							return NULL;
						}
						
						g_pTRGB_Buffer=YUV444toRGB888(YUV444_Buffer,g_pTRGB_Buffer,g_Width,g_Height);
						GlobalFree(YUV444_Buffer);

						if ( g_pTRGB_Buffer==NULL)
						{
							MessageBox(hDlg,L"Cannot Create g_pTRGB_Buffer Buffer to Hold Data",0,0);
							return NULL;
						}																
						g_flag=1;
						OnPaint(hDlg);	
					}
					break;
				default:
					MessageBox(hDlg,L"Please Select any YUV Type",L"Item Not-Selected",0);
					break;
				}			  
			}
			break;
		case IDC_BROWSE:
			{				
				OPENFILENAME ofn;       // common dialog box structure								
							
				ZeroMemory(&ofn, sizeof(ofn));
				ofn.lStructSize = sizeof(ofn);
				ofn.hwndOwner = hDlg;
				ofn.lpstrFile = g_SrcFileName;				
				ofn.lpstrFile[0] = '\0';
				ofn.nMaxFile = sizeof(g_SrcFileName);
				ofn.lpstrFilter = L"YUV File\0*.YUV\0All Files\0*.*\0";
				ofn.nFilterIndex = 1;
				ofn.lpstrFileTitle = NULL;
				ofn.nMaxFileTitle = 0;
				ofn.lpstrInitialDir = NULL;
				ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;		

				
				if (GetOpenFileName(&ofn)==TRUE) // Display the Open dialog box. 
				{	/*For any Operation on File Handle Use here.*/			
					wcscpy(g_SrcFileName,ofn.lpstrFile);	
					SetDlgItemText(hDlg,IDC_EDIT1,ofn.lpstrFile);
				}	
				if(g_flag==0)
				{
					SetDlgItemText(hDlg,IDC_WIDTH,L"0");
					SetDlgItemText(hDlg,IDC_HEIGHT,L"0");												
					InvalidateRect(hDlg,0,1);	
				}
				
			}
			break;
		case IDCANCEL:
		case IDC_EXIT:
			{
				 
				KillTimer(hDlg,IDT_300MILLISECONDS);
				EndDialog(hDlg, LOWORD(wParam));							
				GlobalFree(g_pTRGB_Buffer);				
				return (INT_PTR)TRUE;
			break;
			}
		}
		break;

	}
	return (INT_PTR)FALSE;
}

BYTE* ConvertRGBToBMPBuffer ( BYTE* g_pRGB_Buffer, int width, int height)
{
	long newsize; 

	// first make sure the parameters are valid
	if ( ( NULL == g_pRGB_Buffer ) || ( width == 0 ) || ( height == 0 ) )
		return NULL;

	// now we have to find with how many bytes
	// we have to pad for the next DWORD boundary

	int padding = 0;
	int scanlinebytes = width * 3;
	while ( ( scanlinebytes + padding ) % 4 != 0 )     // DWORD = 4 bytes
		padding++;
	// get the padded scanline width
	int psw = scanlinebytes + padding;

	// we can already store the size of the new padded buffer
	newsize = height * psw;

	// and create new buffer
	BYTE* newbuf = new BYTE[newsize];

	// fill the buffer with zero bytes then we dont have to add
	// extra padding zero bytes later on
	memset ( newbuf, 0, newsize );

	// now we loop trough all bytes of the original buffer,
	// swap the R and B bytes and the scanlines
	long bufpos = 0;
	long newpos = 0;
	for ( int y = 0; y < height; y++ )
		for ( int x = 0; x < 3 * width; x+=3 )
		{
			bufpos = y * 3 * width + x;     // position in original buffer
			newpos = ( height - y - 1 ) * psw + x;           // position in padded buffer

			newbuf[newpos+ 2] = g_pRGB_Buffer[bufpos+2];       // swap r and b
			newbuf[newpos + 1] = g_pRGB_Buffer[bufpos + 1]; // g stays
			newbuf[newpos ] = g_pRGB_Buffer[bufpos];     // swap b and r
		}

	return newbuf;
}

BYTE* YUV444toRGB888(BYTE *YUV444_Buffer,BYTE *g_pTRGB_Buffer,UINT g_Width,UINT g_Height)
{
	if ( ( NULL == YUV444_Buffer ) || ( g_Width == 0 ) || ( g_Height == 0 ) )
		return 0;
	UINT g_Size=g_Width*g_Height*g_Frames*3;
	g_pTRGB_Buffer= (BYTE*)GlobalAlloc(0,g_Size);
	
	UINT Row=0,Col=0;
	for (Row =0 ; Row < g_Height*g_Frames; Row ++)
	{
		for (Col = 0; Col < g_Width; Col ++)
		{			
			TB(Col,Row) = Clamp(( 298 * (Y(Col,Row)-16) + 516 * (U(Col,Row)-128) + 128) >> 8);			
			TG(Col,Row) = Clamp(( 298 * (Y(Col,Row)-16) - 100 * (U(Col,Row)-128) - 208 * (V(Col,Row)-128) + 128) >> 8);			
			TR(Col,Row) = Clamp(( 298 * (Y(Col,Row)-16) + 409 * (V(Col,Row)-128) + 128) >> 8);
		}		
	}	
	return g_pTRGB_Buffer;
}

BYTE* YUV420toYUV444(BYTE *YUV420_Buffer,UINT g_Width,UINT g_Height)
{	
	if ( ( NULL == YUV420_Buffer ) || ( g_Width == 0 ) || ( g_Height == 0 ) )
	{
		MessageBox(0,L"YUV420_Buffer or Width or Height Value Not Received",0,0);
		return 0;	
	}
	g_Size=g_Width*g_Height*g_Frames;	
	UINT FrameSize=g_Width*g_Height;

	BYTE *YUV444_Buffer= new BYTE[g_Size*3];
	if ( NULL == YUV444_Buffer)
	{
		MessageBox(0,L"YUV444_Buffer  Not Created",0,0);
		return 0;	
	}
	ZeroMemory(YUV444_Buffer,sizeof(YUV444_Buffer));	
		
	UINT i=0,SYpos=0,SUpos=0,SVpos=0,Row, Col;		

	for (i = 0; i <g_Frames; i++)
	{	
		SYpos=i*(FrameSize+FrameSize/2);
		for (Row = i*g_Height; Row <g_Height*(i+1);Row++)
		{
			for (Col = 0; Col < g_Width; Col ++)
			{			
				Y(Col,Row)=YUV420_Buffer[SYpos];	SYpos++;			
			}		
		}			
	}	
	SUpos=FrameSize;
	SVpos=FrameSize+(FrameSize/4);
	for (i = 0; i <g_Frames; i++)
	{		
		for (Row = i*g_Height; Row <g_Height*(i+1); Row +=2)
		{
			for (Col = 0; Col < g_Width; Col +=2)
			{			
				V(Col,Row)=YUV420_Buffer[SUpos];
				V(Col+1,Row)=YUV420_Buffer[SUpos];
				V(Col,Row+1)=YUV420_Buffer[SUpos];
				V(Col+1,Row+1)=YUV420_Buffer[SUpos];SUpos++;

				U(Col,Row)=YUV420_Buffer[SVpos];
				U(Col+1,Row)=YUV420_Buffer[SVpos];
				U(Col,Row+1)=YUV420_Buffer[SVpos];
				U(Col+1,Row+1)=YUV420_Buffer[SVpos];SVpos++;
			}		
		}
		SUpos+=((FrameSize+FrameSize/4));
		SVpos+=((FrameSize+FrameSize/4));
	}
	return YUV444_Buffer;
}

BYTE* YUV422toYUV444(BYTE *YUV422_Buffer,UINT g_Width,UINT g_Height)
{
	
	if ( ( NULL == YUV422_Buffer ) || ( g_Width == 0 ) || ( g_Height == 0 ) )
	{
		MessageBox(0,L"YUV422_Buffer or g_Width or g_Height Value Not Received",0,0);
		return 0;	
	}	
	g_Size=g_Width*g_Height*g_Frames;	

	BYTE *YUV444_Buffer= new BYTE[g_Size*3];	
	if ( ( NULL == YUV444_Buffer ) || ( g_Width == 0 ) || ( g_Height == 0 ) )
	{
		MessageBox(0,L"YUV444_Buffer or g_Width or g_Height Value Not Received",0,0);
		return 0;	
	}
	ZeroMemory(YUV444_Buffer,sizeof(YUV444_Buffer));	

	UINT i=0,SYpos=1,SUpos=0,SVpos=2,Row, Col;		
	UINT FrameSize=g_Width*g_Height;
	for (i = 0; i <g_Frames; i++)
	{			
		for (Row = i*g_Height; Row <g_Height*(i+1);Row++)
		{
			for (Col = 0; Col < g_Width; Col +=2)
			{			
				Y(Col,Row)=YUV422_Buffer[SYpos];	SYpos+=2;	
				U(Col,Row)=YUV422_Buffer[SUpos];	
				V(Col,Row)=YUV422_Buffer[SVpos];	

				Y(Col+1,Row)=YUV422_Buffer[SYpos];	SYpos+=2;	
				U(Col+1,Row)=YUV422_Buffer[SUpos];	SUpos+=4;	
				V(Col+1,Row)=YUV422_Buffer[SVpos];	SVpos+=4;	
			}		
		}
		
	}	
	return YUV444_Buffer;
}

BYTE* ConvertBMPToRGBBuffer ( BYTE* Buffer, int width, int height )
{
	// first make sure the parameters are valid
	if ( ( NULL == Buffer ) || ( width == 0 ) || ( height == 0 ) )
		return NULL;

	// find the number of padding bytes

	int padding = 0;
	int scanlinebytes = width * 3;
	while ( ( scanlinebytes + padding ) % 4 != 0 )     // DWORD = 4 bytes
		padding++;
	// get the padded scanline width
	int psw = scanlinebytes + padding;

	// create new buffer
	BYTE* newbuf = new BYTE[width*height*3];

	// now we loop trough all bytes of the original buffer,
	// swap the R and B bytes and the scanlines
	long bufpos = 0;
	long newpos = 0;
	for ( int y = 0; y < height; y++ )
		for ( int x = 0; x < 3 * width; x+=3 )
		{
			newpos = y * 3 * width + x;
			bufpos = ( height - y - 1 ) * psw + x;

			newbuf[newpos] = Buffer[bufpos + 2];
			newbuf[newpos + 1] = Buffer[bufpos+1];
			newbuf[newpos + 2] = Buffer[bufpos];
		}

	return newbuf;
}

bool SaveBMP ( BYTE* Buffer, int width, int height, long paddedsize, LPCTSTR bmpfile )
{
	// declare bmp structures
	BITMAPFILEHEADER bmfh;
	BITMAPINFOHEADER info;

	// andinitialize them to zero
	memset ( &bmfh, 0, sizeof (BITMAPFILEHEADER ) );
	memset ( &info, 0, sizeof (BITMAPINFOHEADER ) );

	// fill the fileheader with data
	bmfh.bfType = 0x4d42;       // 0x4d42 = 'BM'
	bmfh.bfReserved1 = 0;
	bmfh.bfReserved2 = 0;
	bmfh.bfSize = sizeof(BITMAPFILEHEADER) + sizeof(BITMAPINFOHEADER) + paddedsize;
	bmfh.bfOffBits = 0x36;		// number of bytes to start of bitmap bits

	// fill the infoheader

	info.biSize = sizeof(BITMAPINFOHEADER);
	info.biWidth = width;
	info.biHeight = -height;
	info.biPlanes = 1;			// we only have one bitplane
	info.biBitCount = 24;		// RGB mode is 24 bits
	info.biCompression = BI_RGB;
	info.biSizeImage = 0;		// can be 0 for 24 bit images
	info.biXPelsPerMeter = 0x0ec4;     // paint and PSP use this values
	info.biYPelsPerMeter = 0x0ec4;
	info.biClrUsed = 0;			// we are in RGB mode and have no palette
	info.biClrImportant = 0;    // all colors are important

	// now we open the file to write to
	HANDLE file = CreateFile ( bmpfile , GENERIC_WRITE, FILE_SHARE_READ,
		 NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL );
	if ( file == NULL )
	{
		CloseHandle ( file );
		return false;
	}

	// write file header
	unsigned long bwritten;
	if ( WriteFile ( file, &bmfh, sizeof ( BITMAPFILEHEADER ), &bwritten, NULL ) == false )
	{
		CloseHandle ( file );
		return false;
	}
	// write infoheader
	if ( WriteFile ( file, &info, sizeof ( BITMAPINFOHEADER ), &bwritten, NULL ) == false )
	{
		CloseHandle ( file );
		return false;
	}
	// write image data
	if ( WriteFile ( file, Buffer, paddedsize, &bwritten, NULL ) == false )
	{
		CloseHandle ( file );
		return false;
	}
	// and close file
	CloseHandle ( file );
	return true;
}

BYTE* LoadBMP ( int* width, int* height, long* size, LPCTSTR bmpfile )
{
	// declare bitmap structures
	BITMAPFILEHEADER bmpheader;
	BITMAPINFOHEADER bmpinfo;
	// value to be used in ReadFile funcs
	DWORD bytesread;
	// open file to read from
	HANDLE file = CreateFile ( bmpfile , GENERIC_READ, FILE_SHARE_READ,
		 NULL, OPEN_EXISTING, FILE_FLAG_SEQUENTIAL_SCAN, NULL );
	if ( NULL == file )
		return NULL; // coudn't open file


	// read file header
	if ( ReadFile ( file, &bmpheader, sizeof ( BITMAPFILEHEADER ), &bytesread, NULL ) == false )
	{
		CloseHandle ( file );
		return NULL;
	}

	//read bitmap info

	if ( ReadFile ( file, &bmpinfo, sizeof ( BITMAPINFOHEADER ), &bytesread, NULL ) == false )
	{
		CloseHandle ( file );
		return NULL;
	}

	// check if file is actually a bmp
	if ( bmpheader.bfType != 'MB' )
	{
		CloseHandle ( file );
		return NULL;
	}

	// get image measurements
	*width   = bmpinfo.biWidth;
	*height  = abs ( bmpinfo.biHeight );

	// check if bmp is uncompressed
	if ( bmpinfo.biCompression != BI_RGB )
	{
		CloseHandle ( file );
		return NULL;
	}

	// check if we have 24 bit bmp
	if ( bmpinfo.biBitCount != 24 )
	{
		CloseHandle ( file );
		return NULL;
	}


	// create buffer to hold the data
	*size = bmpheader.bfSize - bmpheader.bfOffBits;
	BYTE* Buffer = new BYTE[ *size ];
	// move file pointer to start of bitmap data
	SetFilePointer ( file, bmpheader.bfOffBits, NULL, FILE_BEGIN );
	// read bmp data
	if ( ReadFile ( file, Buffer, *size, &bytesread, NULL ) == false )
	{
		delete [] Buffer;
		CloseHandle ( file );
		return NULL;
	}

	// everything successful here: close file and return buffer

	CloseHandle ( file );

	return Buffer;
}
void OnPaint(HWND hDlg)
{
	if(g_flag==1)
	{
		if(g_pTRGB_Buffer==NULL)
			MessageBox(hDlg,L"RGB_Buffer Value Not Received",0,0);

		
		UINT Dx=10,Dy=65,DWidth=800,DHeight=600,Framecnt=1;
		UINT offset=((g_CurrentFrame-1)*g_Width*g_Height*3);
		HDC Bhdc=GetWindowDC(hDlg);				
		if(g_Width>=DWidth)
		{
			SetStretchBltMode(Bhdc,HALFTONE );
			StretchDIBits(Bhdc,10,65+DHeight,DWidth,-DHeight,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);
		}
		else if((g_Width>=800)&&(g_Width<=DWidth))
		{			
			StretchDIBits(Bhdc,10,65+DHeight,DWidth,-DHeight,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);				
		}
		else if((g_Width>=736)&&(g_Width<800))
		{		
			SetStretchBltMode(Bhdc,HALFTONE );
			StretchDIBits(Bhdc,10,65+DHeight,DWidth,-DHeight,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);				
		}
		else if((g_Width>=640)&&(g_Width<736))
		{			
			StretchDIBits(Bhdc,110,g_Height+110,g_Width,-g_Height,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);				
		}
		else if((g_Width>=320)&&(g_Width<640))
		{
			StretchDIBits(Bhdc,250,g_Height+250,g_Width,-g_Height,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);								
		}
		else if((g_Width>=176)&&(g_Width<320))
		{
			StretchDIBits(Bhdc,350,g_Height+300,g_Width,-g_Height,0,0,g_Width,g_Height,g_pTRGB_Buffer+offset,&Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);								
		}
		DeleteDC(Bhdc);			
	}
}