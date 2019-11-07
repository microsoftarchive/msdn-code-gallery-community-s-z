// YUV Image Viewer.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "YUV Image Viewer.h"
#include <olectl.h>
#include <Windows.h>
#include <Commdlg.h>
#include <Shlwapi.h>
#include <stdio.h>
#include <Gdiplus.h>
#include<math.h>
#include<string.h>
#include <atlstr.h>
#pragma comment(lib, "gdiplus.lib")
#define MAX_LOADSTRING 100

HINSTANCE hInst;								
TCHAR szTitle[MAX_LOADSTRING];				
TCHAR szWindowClass[MAX_LOADSTRING];			

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	Browse(HWND, UINT, WPARAM, LPARAM);
int                 Savefile(HWND);
int                 Browsefile(HWND);
int                 YUV444(HWND);
int                 YUV422(HWND);
int                 YUV420(HWND);
int                 YUV422_Packed(HWND);
int                 YUV420_Packed(HWND);
int                 YUVgrayscale(HWND);
int                 Display(HWND);
int                 saveBMP(HWND);
OPENFILENAMEA       ofn1,ofn2;
HANDLE              hf;
RECT                rClt1,rClt2;
BITMAP              bm;
HBITMAP             hBitmap=NULL,memBM;
HDC                 hCompDc=NULL,hDc=NULL,hMemDC = NULL,hDc2=NULL,hMemDc =NULL;
BOOL                Sreturn=0;
char                szFile1[200];
char                szFile2[200];
wchar_t             szFile[200],szFile3[200],buffer1[100],buffer2[100],buffer3[100];
_locale_t           locale;
size_t              count ;
errno_t             err=0;
int                 Fileflag=0,Zoomflag=0,Centralzoom=0,flag=0,Packed=0,Planar=0;
double              Zoom,Xoffset,Yoffset,X1,X2,Y1,Y2,Zx,Zy,X,Y,Height=0,Width=0;
int                 grayscale=0,saveflag=0;
int	y[144][176],u[144][176],v[144][176];
int	Red[144][176],Blue[144][176],Green[144][176],bitmapdata[432][528];
int Loop,Frame_Count,No_OF_FRAMES,sel,index1=-1,index2=-1,index3=-1;


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
	LoadString(hInstance, IDC_YUVIMAGEVIEWER, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_YUVIMAGEVIEWER));

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
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_YUVIMAGEVIEWER));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_YUVIMAGEVIEWER);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}


BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable


    hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW|WS_MAXIMIZE,
       0, 0, 1000, 720, NULL, NULL, hInstance, NULL);

  
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
	HWND hCbo;

	switch (message)
	{

    
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		switch (wmId)
		{
		 
		case ID_FILE_OPENYUVIMAGE:

		             DialogBox(hInst, MAKEINTRESOURCE(IDD_DIALOG1), hWnd, Browse);
					 
					 if((index1==0)&&((index2==0)||(index2==1)))
					 {
					     YUV420(hWnd);
						 return 1;
					 }
					 
					
					 if((index1==1)&&(index2==0))
					 {
					     YUV422_Packed(hWnd);
						 return 1;
					 }
                      
					 if((index1==1)&&(index2==1))
					 {
						 YUV422(hWnd);
						 return 1;
					 }
					 
					 if((index1==2)&&(index2==0))
				      {
					     Packed=1;
				         YUV444(hWnd);
						 return 1;
				      }
                     if((index1==2)&&(index2==1))
				      {
                         Packed=0;
					     YUV444(hWnd);
						 return 1;
				      }
        break;

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
		if(flag==1)
		Display(hWnd);
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

INT_PTR CALLBACK Browse(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	//UNREFERENCED_PARAMETER(lParam);
	
	HWND hCbo;
	switch (message)
	{
	case WM_INITDIALOG:

		
	
		SendDlgItemMessageA(hDlg, IDC_COMBO1, CB_ADDSTRING, 0, (LPARAM)"YUV444");
	    SendDlgItemMessageA(hDlg, IDC_COMBO1, CB_ADDSTRING, 0, (LPARAM)"YUV422");
		SendDlgItemMessageA(hDlg, IDC_COMBO1, CB_ADDSTRING, 0, (LPARAM)"YUV420");
        SendDlgItemMessageA(hDlg, IDC_COMBO2, CB_ADDSTRING, 0, (LPARAM)"Packed");
		SendDlgItemMessageA(hDlg, IDC_COMBO2, CB_ADDSTRING, 0, (LPARAM)"Planar");
        SendDlgItemMessageA(hDlg, IDC_COMBO3, CB_ADDSTRING, 0, (LPARAM)"172x144");
   return (INT_PTR)TRUE;
   break;

   case WM_COMMAND:
           switch(LOWORD(wParam)) 
          {
         case IDC_BUTTON1:
                         Browsefile(hDlg);
                         if(!GetOpenFileNameA(&ofn1))
						   {
						    MessageBox(NULL, L"GetpoenfileName Failed", L"Error", MB_OK);
						    
						   }
						 else
							 SetDlgItemTextA(hDlg,IDC_EDIT1,(LPCSTR)szFile1);

		 break;
         case IDC_COMBO1: 
                switch(HIWORD(wParam))
                      {
                       case CBN_SELCHANGE:
                       hCbo= GetDlgItem(hDlg,IDC_COMBO1);
		               index1= (int)SendMessageA(hCbo,CB_GETCURSEL ,0,0);
	                   break;
			          }
	    break;
	    case IDC_COMBO2: 
				switch(HIWORD(wParam))
                {
                  case CBN_SELCHANGE:
                  hCbo= GetDlgItem(hDlg,IDC_COMBO2);
		          index2= (int)SendMessageA(hCbo,CB_GETCURSEL ,0,0);
			      break;
			   }
		break;
		case IDC_COMBO3: 
				switch(HIWORD(wParam))
            {
                  case CBN_SELCHANGE:
                  hCbo= GetDlgItem(hDlg,IDC_COMBO3);
		          index3= (int)SendMessageA(hCbo,CB_GETCURSEL ,0,0);
				  break;
			}
	    break;
	   }
        
			 if(LOWORD(wParam)== IDOK)
		      {
					   
	               if((index1==-1)||(index2==-1)||(index3==-1))
				    {
					MessageBoxA(hDlg,(LPCSTR)"Select the property of YUV Image ",(LPCSTR)"Error", MB_OK);
					return (INT_PTR)TRUE;
				     }
				    grayscale=0;
                    EndDialog(hDlg, LOWORD(wParam));
			        return (INT_PTR)TRUE;
		      }


			 if(LOWORD(wParam)==IDC_BUTTON2)
			 {
              if((index1==-1)||(index2==-1)||(index3==-1))
				   {
					MessageBoxA(hDlg,(LPCSTR)"Select the property of YUV Image ",(LPCSTR)"Error", MB_OK);
					return (INT_PTR)TRUE;
				    }
			     grayscale=1;
			     EndDialog(hDlg, LOWORD(wParam));
			     return (INT_PTR)TRUE;
			  }
			
			   if(LOWORD(wParam)==IDC_BUTTON3)
			 {
              if((index1==-1)||(index2==-1)||(index3==-1))
				   {
					MessageBoxA(hDlg,(LPCSTR)"Select the property of YUV Image ",(LPCSTR)"Error", MB_OK);
					return (INT_PTR)TRUE;
				    }


			             Savefile(hDlg);
                         if(!GetSaveFileNameA(&ofn2))
						   {
						    MessageBox(NULL, L"GetpoenfileName Failed", L"Error", MB_OK);
						    
						   }
			     saveflag=1;
			     EndDialog(hDlg, LOWORD(wParam));
			     return (INT_PTR)TRUE;
			  }
        

		
              if (LOWORD(wParam) == IDCANCEL)
		          {
			        EndDialog(hDlg, LOWORD(wParam));
			        return (INT_PTR)TRUE;
		          }

		    
		break;
  }
	return (INT_PTR)FALSE;

}
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

int Browsefile(HWND hwnd)

  {
           ZeroMemory(&ofn1, sizeof(ofn1));
           ofn1.lStructSize = sizeof(ofn1);
           ofn1.hwndOwner = hwnd;
		   ofn1.lpstrFile = szFile1;
		   ofn1.lpstrFile[0] = '\0';
           ofn1.nMaxFile = sizeof(szFile1);
		   ofn1.lpstrFilter = "YUV444(Planar)\0*.yuv\0YUV422(Planar)\0*.yuv\0YUV420(Planar)\0*.yuv\0YUV444(Packed)\0*.yuv\0YUV422(Packed)\0*.yuv\0";
           ofn1.nFilterIndex = 1;
           ofn1.lpstrFileTitle = NULL;
           ofn1.nMaxFileTitle = 0;
           ofn1.lpstrInitialDir = NULL;
           ofn1.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
		   return 1;
			  
}
int Savefile(HWND hwnd)

  {
           ZeroMemory(&ofn2, sizeof(ofn2));
           ofn2.lStructSize = sizeof(ofn2);
           ofn2.hwndOwner = hwnd;
		   ofn2.lpstrFile = szFile2;
		   ofn2.lpstrFile[0] = '\0';
           ofn2.nMaxFile = sizeof(szFile2);
		   ofn2.lpstrFilter = "All File\0*.*\0JPEG(.jpg)\0*.jpg\0 24 bit Bitmap(.bmp)\0*.bmp\0 16 bit Bitmap(.bmp)\0*.bmp\0 8 bit Bitmap(.bmp)\0*.bmp\0";
                             
		   ofn2.nFilterIndex = 2;
           ofn2.lpstrFileTitle = NULL;
           ofn2.nMaxFileTitle = 0;
           ofn2.lpstrInitialDir = NULL;
           ofn2.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
		   ofn2.lpstrDefExt = (LPCSTR)L"bmp";
		   return 1;
			  
}
int YUV444(HWND hDlg)

{
FILE *yuvfile;
long int Len_Y = 176 * 144 , Len_U = 176 * 144, Len_V = 176 * 144;
int m,n;

err=fopen_s(&yuvfile ,szFile1,"rb");
	 if(err)
       {
	     MessageBox(NULL, L"fopen Failed", L"Error", MB_OK);
		 return 0;
       }
	 

	fseek(yuvfile,0L,SEEK_END);
    No_OF_FRAMES = ftell(yuvfile) / (Len_Y + Len_U + Len_V);
    rewind(yuvfile);
	

  {
	  
//TO READ PACKED YUV444 IMAGE
if(Packed==1)
{
  for ( m = 0; m < 144; m++)
  for ( n = 0; n < 176; n++)
  {
  y[m][n] = fgetc(yuvfile);
  u[m][n] = fgetc(yuvfile);
  v[m][n] = fgetc(yuvfile);
  }
}
else
  {

   //TO READ PLANAR YUV444 IMAGE

  for ( m = 0; m < 144; m++)
  for ( n = 0; n < 176; n++)
  y[m][n] = fgetc(yuvfile);


  for ( m = 0; m < 144; m++)
  for ( n = 0; n < 176; n++)
  u[m][n] = fgetc(yuvfile);


  for ( m = 0; m < 144; m++)
  for ( n = 0; n < 176; n++)
  v[m][n] = fgetc(yuvfile);
 } 
}


flag=1;
Display(hDlg);
fclose(yuvfile);
return 0;
} 
int YUV420(HWND hDlg)
{
FILE *yuvfile;
int Array_72x88[72][88];
int	Array_144x88[144][88];
int	Array_144x176[144][176];
int cb[144][88],cr[144][88];

long int Len_Y = 176 * 144 , Len_U = 88 * 72, Len_V = 88 * 72,Size;
int a,b,c,d,i,j,m,n;
int Height = 144, Width = 176;
err=fopen_s(&yuvfile ,szFile1,"rb");
	 if(err)
       {
	     MessageBox(NULL, L"fopen Failed", L"Error", MB_OK);
		 return 0;
       }
	 
fseek(yuvfile,0L,SEEK_END);
No_OF_FRAMES = ftell(yuvfile) / (Len_Y + Len_U + Len_V);
rewind(yuvfile);
//Converting 4:2:0 YUV to 4:2:2 YUV

for ( Frame_Count = 0 ; Frame_Count < No_OF_FRAMES ; Frame_Count++ )
{


for ( m = 0; m < 144; m++)
for ( n = 0; n < 176; n++)
y[m][n] = fgetc(yuvfile);                      //Y values



   for ( Loop = 1 ; Loop <= 2; Loop++)
    {
    m = n = 0 ;

     Size = Loop == 1 ? Len_U : Len_V;
     for ( i = 0; i < Size; i++ ) 
     {
       Array_72x88[m][n++] = fgetc(yuvfile);     //U and V value from YUV420
           if ( n > 87 ) 
           {
            n = 0;
            m++;
            }
      } 
 

 for ( j = 0; j < 88 ; j++ )
 for ( i = 0; i < 144 ; i++)

    if ( ! ( i % 2 ) )
    {
     a = (i>>1)-2;
     b = (i>>1)-1;
     c = (i>>1);
     d = (i>>1)+1;

     a = a < 0 ? 0 : a;
     b = b < 0 ? 0 : b;
     c = c < 0 ? 0 : c;
     d = d < 0 ? 0 : d;

    a = a >= (Height>>1) ? (Height>>1)-1 : a ;
    b = b >= (Height>>1) ? (Height>>1)-1 : b;
    c = c >= (Height>>1) ? (Height>>1)-1 : c;
    d = d >= (Height>>1) ? (Height>>1)-1 : d;


    Array_144x88[i][j] = ( - 3 * Array_72x88[a][j] + 29 * Array_72x88[b][j] \
    + 111 * Array_72x88[c][j] - 9 * Array_72x88[d][j] + 64 ) >> 7;
    }

   else
   {
    a = (i-3) >> 1;
    b = (i-1) >> 1;
    c = (i+1) >> 1;
    d = (i+3) >> 1;

    a = a < 0 ? 0 : a;
    b = b < 0 ? 0 : b;
    c = c < 0 ? 0 : c;
    d = d < 0 ? 0 : d;

   a = a >= (Height>>1) ? (Height>>1)-1 : a ;
   b = b >= (Height>>1) ? (Height>>1)-1 : b;
   c = c >= (Height>>1) ? (Height>>1)-1 : c;
   d = d >= (Height>>1) ? (Height>>1)-1 : d;

   Array_144x88[i][j] = ( - 3 * Array_72x88[a][j] + 29 * Array_72x88[b][j] \
   + 111 * Array_72x88[c][j] - 9 * Array_72x88[d][j] + 64 ) >> 7;

   }
    for ( i = 0; i < 144 ; i++)
    for ( j = 0; j < 88 ; j++ ) 
       {
        if(Loop==1)
        cb[i][j]=Array_144x88[i][j];
        else
        cr[i][j]=Array_144x88[i][j];
        }


} // END OF FOR ( Loop ) 

} // END OF FOR ( Frame_Count)


/*Converting 4:2:2 YUV to 4:4:4 YUV*/



for ( Loop = 1 ; Loop <= 2; Loop++)
{
m = n = 0 ;

Size = Loop == 1 ? Len_U : Len_V;

for ( i = 0; i < Size; i++ ) 
{
if(Loop==1)
Array_144x88[m][n++] = cb[m][n++];
else
Array_144x88[m][n++] = cr[m][n++];

if ( n > 87 ) 
{
n = 0;
m++;
}
} 
for ( i = 0; i < 144 ; i++)
for ( j = 0; j < 176 ; j++ ) 
if ( ! ( j % 2 ) )
{
a = (j>>1)-2;
b = (j>>1)-1;
c = (j>>1);
d = (j>>1)+1;

a = a < 0 ? 0 : a;
b = b < 0 ? 0 : b;
c = c < 0 ? 0 : c;
d = d < 0 ? 0 : d;

a = a >= (Width>>1) ? (Width>>1)-1 : a ;
b = b >= (Width>>1) ? (Width>>1)-1 : b;
c = c >= (Width>>1) ? (Width>>1)-1 : c;
d = d >= (Width>>1) ? (Width>>1)-1 : d;



Array_144x176[i][j] = ( - 3 * Array_144x88[i][a] + 29 * Array_144x88[i][b] \
+ 111 * Array_144x88[i][c] - 9 * Array_144x88[i][d] + 64 ) >> 7;
}
else
{
a = (j-3) >> 1;
b = (j-1) >> 1;
c = (j+1) >> 1;
d = (j+3) >> 1;

a = a < 0 ? 0 : a;
b = b < 0 ? 0 : b;
c = c < 0 ? 0 : c;
d = d < 0 ? 0 : d;

a = a >= (Width>>1) ? (Width>>1)-1 : a ;
b = b >= (Width>>1) ? (Width>>1)-1 : b;
c = c >= (Width>>1) ? (Width>>1)-1 : c;
d = d >= (Width>>1) ? (Width>>1)-1 : d;

Array_144x176[i][j] = ( - 3 * Array_144x88[i][a] + 29 * Array_144x88[i][b] \
+ 111 * Array_144x88[i][c] - 9 * Array_144x88[i][d] + 64 ) >> 7;

}


for ( i = 0; i < 144 ; i++)
for ( j = 0; j < 176 ; j++ ) 
if(Loop==1)
u[i][j]=Array_144x176[i][j];
else
v[i][j]=Array_144x176[i][j];

} // END OF FOR ( Loop ) 
flag=1;
Display(hDlg);
fclose(yuvfile);
return 1;
}

int YUV422(HWND hDlg)
{
FILE *yuvfile;
int	Array_144x88[144][88];
int	Array_144x176[144][176];


long int Len_Y = 176 * 144 , Len_U=144 * 88 ,Len_V = 144 * 88 , Size;
int a,b,c,d,i,j,m,n;
int Height = 144, Width = 176;



err=fopen_s(&yuvfile ,szFile1,"rb");
	 if(err)
       {
	     MessageBox(NULL, L"fopen Failed", L"Error", MB_OK);
		 return 0;
       }
	  
fseek(yuvfile,0L,SEEK_END);
No_OF_FRAMES = ftell(yuvfile) / (Len_Y + Len_U + Len_V);
rewind(yuvfile);

//READ ALL THE Y VALUES
for ( m = 0; m < 144; m++)
for ( n = 0; n < 176; n++)
y[m][n] = fgetc(yuvfile);


//READ ALL THE U/V VALUES INTO 176 x 72

for ( Loop = 1 ; Loop <= 2; Loop++)
{
m = n = 0 ;

Size = Loop == 1 ? Len_U : Len_V;

for ( i = 0; i < Size; i++ ) 
{
Array_144x88[m][n++] = fgetc(yuvfile); 

if ( n > 87 ) 
{
n = 0;
m++;
}
} 


//STORE THE RESULT IN ANOTHER 2D ARRAY OF SIZE ( 176 x 144 )

for ( i = 0; i < 144 ; i++)
for ( j = 0; j < 176 ; j++) 
if ( ! ( j % 2 ) )
{
a = (j>>1)-2;
b = (j>>1)-1;
c = (j>>1);
d = (j>>1)+1;

a = a < 0 ? 0 : a;
b = b < 0 ? 0 : b;
c = c < 0 ? 0 : c;
d = d < 0 ? 0 : d;

a = a >= (Width>>1) ? (Width>>1)-1 : a;
b = b >= (Width>>1) ? (Width>>1)-1 : b;
c = c >= (Width>>1) ? (Width>>1)-1 : c;
d = d >= (Width>>1) ? (Width>>1)-1 : d;



Array_144x176[i][j] = ( - 3 * Array_144x88[i][a] + 29 * Array_144x88[i][b] \
+ 111 * Array_144x88[i][c] - 9 * Array_144x88[i][d] + 64 ) >> 7;
}
else
{
a = (j-3) >> 1;
b = (j-1) >> 1;
c = (j+1) >> 1;
d = (j+3) >> 1;

a = a < 0 ? 0 : a;
b = b < 0 ? 0 : b;
c = c < 0 ? 0 : c;
d = d < 0 ? 0 : d;

a = a >= (Width>>1) ? (Width>>1)-1 : a;
b = b >= (Width>>1) ? (Width>>1)-1 : b;
c = c >= (Width>>1) ? (Width>>1)-1 : c;
d = d >= (Width>>1) ? (Width>>1)-1 : d;

Array_144x176[i][j] = ( - 3 * Array_144x88[i][a] + 29 * Array_144x88[i][b] \
+ 111 * Array_144x88[i][c] - 9 * Array_144x88[i][d] + 64 ) >> 7;

}


for ( i = 0; i < 144 ; i++)
for ( j = 0; j < 176 ; j++ ) 
if(Loop==1)
u[i][j]=Array_144x176[i][j];
else
v[i][j]=Array_144x176[i][j];


   } // END OF FOR Loop 

flag=1;
Display(hDlg);
fclose(yuvfile);

}

int YUV422_Packed(HWND hDlg)
{
FILE *yuvfile;
int	Array_144x88[144][88],Array_144x88_u[144][88],Array_144x88_v[144][88];

int	Array_144x176[144][176],Array_144x176_u[144][176],Array_144x176_v[144][176];

long int Len_Y = 176 * 144 , Len_U=144 * 88 ,Len_V = 144 * 88 , Size;

int a,b,c,d,i,j,m,n,u_m=0,u_n=0,v_m=0,v_n=0;

int Height = 144, Width = 176;




err=fopen_s(&yuvfile ,szFile1,"rb");
	 if(err)
       {
	     MessageBox(NULL, L"fopen Failed", L"Error", MB_OK);
		 return 0;
       }
	  
fseek(yuvfile,0L,SEEK_END);
No_OF_FRAMES = ftell(yuvfile) / (Len_Y + Len_U + Len_V);
rewind(yuvfile);

//READ ALL THE Y VALUES

for ( m = 0; m < 144; m++)
for ( n = 0; n < 176; n++)
{
y[m][n] = fgetc(yuvfile);
if(!(n%2))
  {
  Array_144x88_u[u_m][u_n++]=fgetc(yuvfile);
  if (u_n > 87 ) 
  {
   u_n = 0;
   u_m++;
   }
  }
 else
  {
  Array_144x88_v[v_m][v_n++]=fgetc(yuvfile);
  if ( v_n > 87 ) 
   {
   v_n = 0;
   v_m++;
   }
   }
  }


//READ ALL THE U/V VALUES INTO 176 x 72

for ( Loop = 1 ; Loop <= 2; Loop++)
{



//STORE THE RESULT IN ANOTHER 2D ARRAY OF SIZE ( 176 x 144 )

for ( i = 0; i < 144 ; i++)
for ( j = 0; j < 176 ; j++) 
if ( ! ( j % 2 ) )
{
a = (j>>1)-2;
b = (j>>1)-1;
c = (j>>1);
d = (j>>1)+1;

a = a < 0 ? 0 : a;
b = b < 0 ? 0 : b;
c = c < 0 ? 0 : c;
d = d < 0 ? 0 : d;

a = a >= (Width>>1) ? (Width>>1)-1 : a;
b = b >= (Width>>1) ? (Width>>1)-1 : b;
c = c >= (Width>>1) ? (Width>>1)-1 : c;
d = d >= (Width>>1) ? (Width>>1)-1 : d;


if(Loop==1)
Array_144x176_u[i][j] = ( - 3 * Array_144x88_u[i][a] + 29 * Array_144x88_u[i][b] \
+ 111 * Array_144x88_u[i][c] - 9 * Array_144x88_u[i][d] + 64 ) >> 7;
if(Loop==2)
Array_144x176_v[i][j] = ( - 3 * Array_144x88_v[i][a] + 29 * Array_144x88_v[i][b] \
+ 111 * Array_144x88_v[i][c] - 9 * Array_144x88_v[i][d] + 64 ) >> 7;
}
else
{
a = (j-3) >> 1;
b = (j-1) >> 1;
c = (j+1) >> 1;
d = (j+3) >> 1;

a = a < 0 ? 0 : a;
b = b < 0 ? 0 : b;
c = c < 0 ? 0 : c;
d = d < 0 ? 0 : d;

a = a >= (Width>>1) ? (Width>>1)-1 : a;
b = b >= (Width>>1) ? (Width>>1)-1 : b;
c = c >= (Width>>1) ? (Width>>1)-1 : c;
d = d >= (Width>>1) ? (Width>>1)-1 : d;
if(Loop==1)
Array_144x176_u[i][j] = ( - 3 * Array_144x88_u[i][a] + 29 * Array_144x88_u[i][b] \
+ 111 * Array_144x88_u[i][c] - 9 * Array_144x88_u[i][d] + 64 ) >> 7;
if(Loop==2)
Array_144x176_v[i][j] = ( - 3 * Array_144x88_v[i][a] + 29 * Array_144x88_v[i][b] \
+ 111 * Array_144x88_v[i][c] - 9 * Array_144x88_v[i][d] + 64 ) >> 7;


}


for ( i = 0; i < 144 ; i++)
for ( j = 0; j < 176 ; j++ ) 
if(Loop==1)
u[i][j]=Array_144x176_u[i][j];
else
v[i][j]=Array_144x176_v[i][j];


   } // END OF FOR Loop 


flag=1;
Display(hDlg);
fclose(yuvfile);

}


int Display(HWND hDlg)
{
int C,D,E;

GetClientRect(hDlg, &rClt2);
Xoffset=(rClt2.right-176)/2;
Yoffset=(rClt2.bottom-144)/2;
     
	for ( Frame_Count = 0 ; Frame_Count < No_OF_FRAMES ; Frame_Count++ )
{
for ( int m = 0; m < 144; m++)
for (int  n = 0; n < 176; n++)
{
C = y[m][n] - 16;
D = u[m][n] - 128;
E = v[m][n] - 128;


Red[m][n] = ( 298 * C + 409 * E + 128) >> 8;
Green[m][n] = ( 298 * C - 100 * D - 208 * E + 128) >> 8;
Blue[m][n] = ( 298 * C + 516 * D + 128) >> 8;


if (Red[m][n] > 255) Red[m][n] = 255;

if (Green[m][n] > 255) Green[m][n] = 255;

if (Blue[m][n] > 255) Blue[m][n] = 255;

if (Red[m][n] < 0) Red[m][n] = 0;

if (Green[m][n] < 0) Green[m][n] = 0;

if (Blue[m][n] < 0) Blue[m][n] = 0;

}
}
	
	
if(saveflag==1)
	{
	 if(saveBMP(hDlg))
		MessageBoxA(NULL, "BMP file saved", "Success", MB_OK);
     saveflag=0;
	 return 1;
	}


 hDc     = GetDC(hDlg);


if(grayscale==1)
{
    for( int m=0; m<144; ++m)
    for( int n=0; n<176; ++n)
      {
	   if(!(SetPixel(hDc, Xoffset+n, Yoffset+m, RGB(y[m][n],y[m][n],y[m][n]))))
	      MessageBoxA(NULL, "SetPixel Failed", "Error", MB_OK);
	  }
}
else 
{

      for( int m=0; m<144; ++m)
      for( int n=0; n<176; ++n)
      {
       if(!(SetPixel(hDc, Xoffset+n, Yoffset+m, RGB(Red[m][n],Green[m][n], Blue[m][n]))))
	   MessageBoxA(NULL, "SetPixel Failed", "Error", MB_OK);
	  }
}
grayscale=0;
return 1;
}
int saveBMP(HWND hDlg)
{
FILE *bmpfile;
BITMAPFILEHEADER fileheader;
BITMAPINFOHEADER infoheader;
int m,n;
err=fopen_s(&bmpfile ,szFile2,"wb");
	 if(err)
       {
	     MessageBox(NULL, L"fopen Failed", L"Error", MB_OK);
		 return 0;
       }



infoheader.biBitCount=24;
infoheader.biHeight=144;
infoheader.biWidth=176;
infoheader.biClrUsed=0;
infoheader.biXPelsPerMeter=3780;
infoheader.biYPelsPerMeter=3780;
infoheader.biSize=40;
infoheader.biSizeImage=(infoheader.biWidth*infoheader.biHeight*infoheader.biBitCount)/8;
infoheader.biClrImportant=0;
infoheader.biCompression=0;
infoheader.biPlanes=1;

fileheader.bfReserved1=fileheader.bfReserved2=0;
fileheader.bfType=19778;
fileheader.bfOffBits=54;
fileheader.bfSize=fileheader.bfOffBits+infoheader.biSizeImage;




//Write file header and info header to destination

fwrite (&fileheader, 1  ,sizeof(BITMAPFILEHEADER),bmpfile);
fwrite (&infoheader , 1 ,sizeof(BITMAPINFOHEADER),bmpfile);

//Write RGB data to destination  
	 for( int m=144; m>0; --m)
     for( int n=0; n<176; ++n)
       {
         fwrite(&Red[m][n],   1, sizeof(BYTE), bmpfile);
		 fwrite(&Green[m][n], 1, sizeof(BYTE), bmpfile);
		 fwrite(&Blue[m][n],  1, sizeof(BYTE), bmpfile);
	   }
	 fclose( bmpfile);
	 return 1;


}
