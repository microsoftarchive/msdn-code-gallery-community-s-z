// COM Port.cpp : Defines the entry point for the application.
#include "stdafx.h"
#include "COM Port.h"
#include <commctrl.h>
#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								
TCHAR szTitle[MAX_LOADSTRING];					
TCHAR szWindowClass[MAX_LOADSTRING];

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	Port(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	Terminal_1(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	Terminal_2(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);



int                SetupUart();
int                SetupUart2();
int                WriteUart(unsigned char *buf1, int len,HANDLE);
int                ReadUart(int len,HANDLE);
int                configure(),configuretimeout(),CloseUart(),CloseUart2();
BOOL IsAppRunning (HWND);


HANDLE         LPort;
DCB            PortDCB; 
COMMTIMEOUTS   CommTimeouts; 
HANDLE         hPort1,hPort2,hPort;
char           lastError[1024],buf1[100],buf2[100];
int            index1=-1,index2=-1,index3=-1,index4=-1,index5=-1,index6=-1,index7=-1;
char           buff;

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
	LoadString(hInstance, IDC_COMPORT, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_COMPORT));

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


//  FUNCTION: MyRegisterClass()
//  PURPOSE: Registers the window class.

ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_COMPORT));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_COMPORT);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}


//   FUNCTION: InitInstance(HINSTANCE, int)
//   PURPOSE: Saves instance handle and creates main window

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
     28,25,980 , 680, NULL, NULL, hInstance, NULL);
   
   if ( IsAppRunning (hWnd) ) 
   {
	   return FALSE;
   }

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}


//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//  PURPOSE:  Processes messages for the main window.

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
		switch (wmId)
		{
        case ID_FILE_OPENPORT:
			 
			
			 DialogBox(hInst, MAKEINTRESOURCE(IDD_DIALOG1), hWnd, Port);
		     CloseUart();
			 CloseUart2();
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
INT_PTR CALLBACK Port(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
HINSTANCE hInstance=0;
	HWND hWnd;
	hInst = hInstance;

	//UNREFERENCED_PARAMETER(lParam);
	
	HWND hCbo;
	switch (message)
	{
	case WM_INITDIALOG:

		
	
		SendDlgItemMessageA(hDlg, IDC_COMBO1, CB_ADDSTRING, 0, (LPARAM)"9600");
	    SendDlgItemMessageA(hDlg, IDC_COMBO1, CB_ADDSTRING, 0, (LPARAM)"19200");
		SendDlgItemMessageA(hDlg, IDC_COMBO1, CB_ADDSTRING, 0, (LPARAM)"38400");
        SendDlgItemMessageA(hDlg, IDC_COMBO1, CB_ADDSTRING, 0, (LPARAM)"57600");
		SendDlgItemMessageA(hDlg, IDC_COMBO1, CB_ADDSTRING, 0, (LPARAM)"115200");
        SendDlgItemMessageA(hDlg, IDC_COMBO2, CB_ADDSTRING, 0, (LPARAM)"5");
		SendDlgItemMessageA(hDlg, IDC_COMBO2, CB_ADDSTRING, 0, (LPARAM)"6");
		SendDlgItemMessageA(hDlg, IDC_COMBO2, CB_ADDSTRING, 0, (LPARAM)"7");
		SendDlgItemMessageA(hDlg, IDC_COMBO2, CB_ADDSTRING, 0, (LPARAM)"8");
		SendDlgItemMessageA(hDlg, IDC_COMBO3, CB_ADDSTRING, 0, (LPARAM)"Even");
		SendDlgItemMessageA(hDlg, IDC_COMBO3, CB_ADDSTRING, 0, (LPARAM)"Odd");
		SendDlgItemMessageA(hDlg, IDC_COMBO3, CB_ADDSTRING, 0, (LPARAM)"None");
		SendDlgItemMessageA(hDlg, IDC_COMBO3, CB_ADDSTRING, 0, (LPARAM)"Mark");
		SendDlgItemMessageA(hDlg, IDC_COMBO3, CB_ADDSTRING, 0, (LPARAM)"Space");
		SendDlgItemMessageA(hDlg, IDC_COMBO4, CB_ADDSTRING, 0, (LPARAM)"1");
		SendDlgItemMessageA(hDlg, IDC_COMBO4, CB_ADDSTRING, 0, (LPARAM)"2");
		SendDlgItemMessageA(hDlg, IDC_COMBO5, CB_ADDSTRING, 0, (LPARAM)"Xon/Xoff");
		SendDlgItemMessageA(hDlg, IDC_COMBO5, CB_ADDSTRING, 0, (LPARAM)"Hardware");
		SendDlgItemMessageA(hDlg, IDC_COMBO5, CB_ADDSTRING, 0, (LPARAM)"None");
		SendDlgItemMessageA(hDlg, IDC_COMBO6, CB_ADDSTRING, 0, (LPARAM)"COM1");
		SendDlgItemMessageA(hDlg, IDC_COMBO6, CB_ADDSTRING, 0, (LPARAM)"COM5");
		SendDlgItemMessageA(hDlg, IDC_COMBO7, CB_ADDSTRING, 0, (LPARAM)"COM1");
		SendDlgItemMessageA(hDlg, IDC_COMBO7, CB_ADDSTRING, 0, (LPARAM)"COM5");
		
   return (INT_PTR)TRUE;
   break;

   case WM_COMMAND:
          switch(LOWORD(wParam)) 
          {
        
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
	   
		     case IDC_COMBO4: 
				switch(HIWORD(wParam))
                {
                  case CBN_SELCHANGE:
                     hCbo= GetDlgItem(hDlg,IDC_COMBO4);
		             index4= (int)SendMessageA(hCbo,CB_GETCURSEL ,0,0);
				  break;
			    }
	         break;
	   
	         case IDC_COMBO5: 
				switch(HIWORD(wParam))
                 {
                  case CBN_SELCHANGE:
                  hCbo= GetDlgItem(hDlg,IDC_COMBO5);
		          index5= (int)SendMessageA(hCbo,CB_GETCURSEL ,0,0);
				  break;
			     }
            break;
	        case IDC_COMBO6: 
				 switch(HIWORD(wParam))
                   {
                    case CBN_SELCHANGE:
                    hCbo= GetDlgItem(hDlg,IDC_COMBO6);
		            index6= (int)SendMessageA(hCbo,CB_GETCURSEL ,0,0);
				    break;
			       }
	        break;
			case IDC_COMBO7: 
				 switch(HIWORD(wParam))
                   {
                    case CBN_SELCHANGE:
                    hCbo= GetDlgItem(hDlg,IDC_COMBO7);
		            index7= (int)SendMessageA(hCbo,CB_GETCURSEL ,0,0);
				    break;
			       }
	        break;
           
	       break;
		  }
 
		  if(LOWORD(wParam)== IDOK)
		      {
					   
	               if((index1==-1)||(index2==-1)||(index3==-1)||(index4==-1)||(index5==-1)||(index6==-1)||(index6==-1))
				    {
					MessageBoxA(hDlg,(LPCSTR)"Select the property of COM Port",(LPCSTR)"Error", MB_OK);
				   
				    }
				   else
				   {

			       if(index6==index7)
				   {
					MessageBoxA(hDlg,(LPCSTR)"cannot open same Port twice",(LPCSTR)"Error", MB_OK);
				    return (INT_PTR)FALSE;
				   }
					SetupUart();
				    SetupUart2();
					EndDialog(hDlg, LOWORD(wParam));
					DialogBox(hInst, MAKEINTRESOURCE(IDD_DIALOG2), hDlg, Terminal_1);
					 return (INT_PTR)TRUE;
					}
				  
		      }
		   if (LOWORD(wParam) == IDCANCEL)
		          {
			        EndDialog(hDlg, LOWORD(wParam));
			        return (INT_PTR)TRUE;
		          }
		   
	
      
   
	
     }
	return (INT_PTR)FALSE;
}



INT_PTR CALLBACK Terminal_1(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	HWND hEb;
	switch (message)
	{
	 case WM_INITDIALOG:
		 return (INT_PTR)TRUE;
	 break;

	 case WM_COMMAND:
		switch(LOWORD(wParam)) 
          {
        
         case IDC_EDIT1:
		 
			 switch(HIWORD(wParam))
			    {
			
	              case EN_CHANGE: 
				     int ret=GetDlgItemTextA(hDlg,IDC_EDIT1,(LPSTR)buf1,sizeof(buf1));			 
				     WriteUart((unsigned char *)buf1,sizeof(buf1),hPort1);
		             ReadUart(sizeof(buf1),hPort2);
				     ret= SetDlgItemTextA(hDlg,IDC_EDIT2,(LPCSTR)buf2);
				     ret=0;
				  break;
                }
		 break;

		 case IDC_EDIT2:
		  
			 switch(HIWORD(wParam))
			    {
			
	              case EN_CHANGE: 
				     int ret=GetDlgItemTextA(hDlg,IDC_EDIT2,(LPSTR)buf1,sizeof(buf1));			 
				     WriteUart((unsigned char *)buf1,sizeof(buf1),hPort1);
		             ReadUart(sizeof(buf1),hPort2);
				     ret= SetDlgItemTextA(hDlg,IDC_EDIT1,(LPCSTR)buf2);
				     ret=0;
				   break;
                   
			     }
		    break;

		}
		  
		      if (LOWORD(wParam) == IDC_BUTTON1)
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

int SetupUart()
{
	int STOPBITS;
   
	hPort1 = CreateFile (TEXT("COM5"),			            // Name of the port 
						GENERIC_READ | GENERIC_WRITE,     // Access (read-write) mode 
						0,                                  
						NULL,                             
						OPEN_EXISTING,
						FILE_ATTRIBUTE_NORMAL,                     
			            NULL);                             
             
	
	if ( hPort1 == INVALID_HANDLE_VALUE )
	{ 
		
		MessageBox (NULL, L"Port Open Failed" ,L"Error", MB_OK);
		return 0;
	}   

	  //Initialize the DCBlength member. 
      PortDCB.DCBlength = sizeof (DCB); 
      
      // Get the default port setting information.
      GetCommState (hPort1, &PortDCB);
	  configure();

	  // Retrieve the time-out parameters for all read and write operations  
	  GetCommTimeouts (hPort1, &CommTimeouts); 
	  configuretimeout();
	
   

	//Re-configure the port with the new DCB structure. 
	if (!SetCommState (hPort1, &PortDCB)) 
	{ 
        MessageBox (NULL, L"1.Could not create the read thread.(SetCommState Failed)" ,L"Error", MB_OK);
		CloseHandle(hPort1);   
		return 0; 
	 } 

	// Set the time-out parameters for all read and write operations on the port. 
	if (!SetCommTimeouts (hPort1, &CommTimeouts)) 
	{ 
        MessageBox (NULL, L"Could not create the read thread.(SetCommTimeouts Failed)" ,L"Error", MB_OK);
		CloseHandle(hPort1);  
		return 0; 
	} 

	// Clear the port of any existing data. 
	if(PurgeComm(hPort1, PURGE_TXCLEAR | PURGE_RXCLEAR)==0) 
	{   MessageBox (NULL, L"Clearing The Port Failed" ,L"Message", MB_OK);
		CloseHandle(hPort1); 
		return 0; 
	} 
    
	    MessageBox (NULL, L"COM5 SERIAL SETUP OK." ,L"Message", MB_OK);
	    return 1;
}

int SetupUart2()
{
	int STOPBITS;

	

	hPort2 = CreateFile (TEXT("COM1"),				       // Name of the port 
						GENERIC_READ | GENERIC_WRITE,     // Access (read-write) mode 
						0,                                  
						NULL,                             
						OPEN_EXISTING,
						FILE_ATTRIBUTE_NORMAL,                     
			            NULL);                             
             
	
	if ( hPort2 == INVALID_HANDLE_VALUE ) 
	{ 
		
		MessageBox (NULL, L"Port Open Failed" ,L"Error", MB_OK);
		return 0;
	}
	
	 // Initialize the DCBlength member. 
     PortDCB.DCBlength = sizeof (DCB); 
      
      // Get the default port setting information.
      GetCommState (hPort2, &PortDCB);
	  configure();

	
	
	
	// Retrieve the time-out parameters for all read and write operations  
	GetCommTimeouts (hPort2, &CommTimeouts);
	configuretimeout();
	

	
	
	

	
    
	//Re-configure the port with the new DCB structure. 
	if (!SetCommState (hPort2, &PortDCB)) 
	{ 
        MessageBox (NULL, L"1.Could not create the read thread.(SetCommState Failed)" ,L"Error", MB_OK);
		CloseHandle(hPort2);   
		return 0; 
	 } 
	
	// Set the time-out parameters for all read and write operations on the port. 
	if (!SetCommTimeouts (hPort2, &CommTimeouts)) 
	{ 
        MessageBox (NULL, L"Could not create the read thread.(SetCommTimeouts Failed)" ,L"Error", MB_OK);
		CloseHandle(hPort2);  
		return 0; 
	} 

	// Clear the port of any existing data. 
	if(PurgeComm(hPort2, PURGE_TXCLEAR | PURGE_RXCLEAR)==0) 
	{   MessageBox (NULL, L"Clearing The Port Failed" ,L"Message", MB_OK);
		CloseHandle(hPort2); 
		return 0; 
	} 
    
	MessageBox (NULL, L"COM1 SERIAL SETUP OK." ,L"Message", MB_OK);
	return 1;
}



int configure()
{
	

// Change the DCB structure settings
PortDCB.fBinary = TRUE;                         // Binary mode; no EOF check
PortDCB.fParity = TRUE;                         // Enable parity checking 
PortDCB.fDsrSensitivity = FALSE;                // DSR sensitivity 
PortDCB.fErrorChar = FALSE;                     // Disable error replacement 
PortDCB.fOutxDsrFlow = FALSE;                   // No DSR output flow control 
PortDCB.fAbortOnError = FALSE;                  // Do not abort reads/writes on error
PortDCB.fNull = FALSE;                          // Disable null stripping 
PortDCB.fTXContinueOnXoff = TRUE;                // XOFF continues Tx 

switch(index1)                                  // BAUD Rate
	{
	case 0:
		PortDCB.BaudRate= 115200;            
	break;
	case 1:
		PortDCB.BaudRate = 19200;            
	break;
	case 2:
		PortDCB.BaudRate= 38400;            
	break;
	case 3:
	     PortDCB.BaudRate = 57600;            
	break;
	case 4:
	     PortDCB.BaudRate = 9600;            
	break;
	default:
		break;
	}
	switch(index2)                                     // Number of bits/byte, 5-8 
	{
	case 0:
        PortDCB.ByteSize = 5;            
	break;
	case 1:
		PortDCB.ByteSize = 6;            
	break;
	case 2:
		PortDCB.ByteSize= 7;            
	break;
	case 3:
		PortDCB.ByteSize=8;            
	break;
	default:
		break;
	}
	switch(index3)                                     // 0-4=no,odd,even,mark,space 
	{
	case 0:
		PortDCB.Parity= EVENPARITY;                
	break;
	case 1:
	     PortDCB.Parity = MARKPARITY;               
	break;
	case 2:
	      PortDCB.Parity = NOPARITY;                   
	break;
	case 3:
		 PortDCB.Parity = ODDPARITY;           
	break;
	case 4:
		 PortDCB.Parity = SPACEPARITY;           
	break;
	default:
		break;
	}
	switch(index4)                       
	{
	case 0:
		PortDCB.StopBits =  ONESTOPBIT;          
	break;
	case 1:
		PortDCB.StopBits =  TWOSTOPBITS;        
	break;
	
	default:
		break;
	}
	switch(index5)                       
	{
	case 0:
		PortDCB.fOutxCtsFlow = TRUE;                        // CTS output flow control 
        PortDCB.fDtrControl = DTR_CONTROL_ENABLE;           // DTR flow control type 
        PortDCB.fOutX = FALSE;                              // No XON/XOFF out flow control 
        PortDCB.fInX = FALSE;                               // No XON/XOFF in flow control 
        PortDCB.fRtsControl = RTS_CONTROL_ENABLE;           // RTS flow control 
		 
	    
	break;
	case 1:
		PortDCB.fOutxCtsFlow = FALSE;                      // No CTS output flow control 
        PortDCB.fDtrControl = DTR_CONTROL_ENABLE;          // DTR flow control type 
        PortDCB.fOutX = FALSE;                             // No XON/XOFF out flow control 
        PortDCB.fInX = FALSE;                              // No XON/XOFF in flow control 
        PortDCB.fRtsControl = RTS_CONTROL_ENABLE;          // RTS flow control 
    break;
	case 2:
		PortDCB.fOutxCtsFlow = FALSE;                      // No CTS output flow control 
        PortDCB.fDtrControl = DTR_CONTROL_ENABLE;          // DTR flow control type 
        PortDCB.fOutX = TRUE;                              // Enable XON/XOFF out flow control 
        PortDCB.fInX = TRUE;                               // Enable XON/XOFF in flow control 
        PortDCB.fRtsControl = RTS_CONTROL_ENABLE;          // RTS flow control 
		 
	   
    break;
	
	default:
		break;
	}





return 1;
}
int configuretimeout()
{
	//memset(&CommTimeouts, 0x00, sizeof(CommTimeouts)); 
	CommTimeouts.ReadIntervalTimeout = 50; 
	CommTimeouts.ReadTotalTimeoutConstant = 50; 
	CommTimeouts.ReadTotalTimeoutMultiplier=10;
	CommTimeouts.WriteTotalTimeoutMultiplier=10;
	CommTimeouts.WriteTotalTimeoutConstant = 50; 
   return 1;
}
int WriteUart(unsigned char *buf1, int len,HANDLE hPort)
{
	DWORD dwNumBytesWritten;

	WriteFile (hPort,buf1, len,&dwNumBytesWritten,NULL);			

	if(dwNumBytesWritten > 0)
	{
		//MessageBox (NULL, L"Transmission Success" ,L"Success", MB_OK);
		return 1;
	}
	
	else 
	   {
		MessageBox (NULL, L"Transmission Failed" ,L"Error", MB_OK);
		return 0;	
	   }
}


int ReadUart(int len,HANDLE hPort)
{
	BOOL ret;
	DWORD dwRead;
    BOOL fWaitingOnRead = FALSE;
    OVERLAPPED osReader = {0};
    unsigned long retlen=0;

   // Create the overlapped event. Must be closed before exiting to avoid a handle leak.

   osReader.hEvent = CreateEvent(NULL, TRUE, FALSE, NULL);
   if (osReader.hEvent == NULL)
       MessageBox (NULL, L"Error in creating Overlapped event" ,L"Error", MB_OK);
   if (!fWaitingOnRead)
   {
          if (!ReadFile(hPort, buf2, len, &dwRead,  &osReader)) 

          {
			
          FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
                        NULL,
                        GetLastError(),
                        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
                        (LPWSTR)lastError,
                        1024,
                        NULL);
		   MessageBox (NULL, (LPWSTR)lastError ,L"MESSAGE", MB_OK);
            
           }
           else
		   {
             
	         // MessageBox (NULL, L"ReadFile Suceess" ,L"Success", MB_OK);
           }
        
    }



 
	
	if(dwRead > 0)	
	{
		//MessageBox (NULL, L"Read DATA Success" ,L"Success", MB_OK);//If we have data
		return (int) retlen;
	}
	     //return the length
    
	else return 0;     //else no data has been read
 }


int CloseUart()
{
	CloseHandle(hPort1); 
	return 1;
}
int CloseUart2()
{
	CloseHandle(hPort2);
	return 1;
}
BOOL IsAppRunning (HWND hDlg )
{
    HANDLE hMutex = NULL;
	
    hMutex = CreateMutex ( NULL, TRUE, _T("MySpecialMutexNameHERE") );
    if ( GetLastError() == ERROR_ALREADY_EXISTS )
    {   MessageBoxA(hDlg,"Application Running Already!","Error",MB_OK);
        CloseHandle ( hMutex );
        return TRUE;
    }
    return FALSE;
}