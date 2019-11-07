//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#include "precomp.hpp"

CAppModule _Module;
CSimpleMap<HRESULT, LPCWSTR> g_wicErrorCodes;

void GetHresultString(HRESULT hr, CString &out)
{
    int wicIdx = g_wicErrorCodes.FindKey(hr);

    if ((FACILITY_WINCODEC_ERR == HRESULT_FACILITY(hr)) && (wicIdx >= 0))
    {
        out = g_wicErrorCodes.GetValueAt(wicIdx);
    }
    else
    {
        const DWORD MAX_MsgLength = 256;

        WCHAR msg[MAX_MsgLength];
        DWORD len = 0;

        msg[0] = TEXT('\0');   

        if (FACILITY_WINDOWS == HRESULT_FACILITY(hr))
        {
            hr = HRESULT_CODE(hr);
        }

        // Try to have windows give a nice message, otherwise just format the HRESULT into a string.
        len = FormatMessageW(FORMAT_MESSAGE_FROM_SYSTEM|FORMAT_MESSAGE_IGNORE_INSERTS, NULL,
            hr, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), msg, MAX_MsgLength, NULL);
        if (len != 0)
        {
            // remove the trailing newline
            if (L'\r' == msg[len-2])
            {
                msg[len-2] = L'\0';
            }
            else if (L'\n' == msg[len-1])
            {
                msg[len-1] = L'\0';
            }
        }
        else
        {
            StringCchPrintf(msg, MAX_MsgLength, L"0x%.8X", static_cast<unsigned>(hr));
        }

        out = msg;
    }
}

static void PopulateWicErrorCodes()
{
    g_wicErrorCodes.Add(WINCODEC_ERR_GENERIC_ERROR, L"WINCODEC_ERR_GENERIC_ERROR");
    g_wicErrorCodes.Add(WINCODEC_ERR_INVALIDPARAMETER, L"WINCODEC_ERR_INVALIDPARAMETER");
    g_wicErrorCodes.Add(WINCODEC_ERR_OUTOFMEMORY, L"WINCODEC_ERR_OUTOFMEMORY");
    g_wicErrorCodes.Add(WINCODEC_ERR_NOTIMPLEMENTED, L"WINCODEC_ERR_NOTIMPLEMENTED");
    g_wicErrorCodes.Add(WINCODEC_ERR_ABORTED, L"WINCODEC_ERR_ABORTED");
    g_wicErrorCodes.Add(WINCODEC_ERR_ACCESSDENIED, L"WINCODEC_ERR_ACCESSDENIED");
    g_wicErrorCodes.Add(WINCODEC_ERR_VALUEOVERFLOW, L"WINCODEC_ERR_VALUEOVERFLOW");
    g_wicErrorCodes.Add(WINCODEC_ERR_WRONGSTATE, L"WINCODEC_ERR_WRONGSTATE");
    g_wicErrorCodes.Add(WINCODEC_ERR_VALUEOUTOFRANGE, L"WINCODEC_ERR_VALUEOUTOFRANGE");
    g_wicErrorCodes.Add(WINCODEC_ERR_UNKNOWNIMAGEFORMAT, L"WINCODEC_ERR_UNKNOWNIMAGEFORMAT");
    g_wicErrorCodes.Add(WINCODEC_ERR_UNSUPPORTEDVERSION, L"WINCODEC_ERR_UNSUPPORTEDVERSION");
    g_wicErrorCodes.Add(WINCODEC_ERR_NOTINITIALIZED, L"WINCODEC_ERR_NOTINITIALIZED");
    g_wicErrorCodes.Add(WINCODEC_ERR_ALREADYLOCKED, L"WINCODEC_ERR_ALREADYLOCKED");
    g_wicErrorCodes.Add(WINCODEC_ERR_PROPERTYNOTFOUND, L"WINCODEC_ERR_PROPERTYNOTFOUND");
    g_wicErrorCodes.Add(WINCODEC_ERR_PROPERTYNOTSUPPORTED, L"WINCODEC_ERR_PROPERTYNOTSUPPORTED");
    g_wicErrorCodes.Add(WINCODEC_ERR_PROPERTYSIZE, L"WINCODEC_ERR_PROPERTYSIZE");
    g_wicErrorCodes.Add(WINCODEC_ERR_CODECPRESENT, L"WINCODEC_ERR_CODECPRESENT");
    g_wicErrorCodes.Add(WINCODEC_ERR_CODECNOTHUMBNAIL, L"WINCODEC_ERR_CODECNOTHUMBNAIL");
    g_wicErrorCodes.Add(WINCODEC_ERR_PALETTEUNAVAILABLE, L"WINCODEC_ERR_PALETTEUNAVAILABLE");
    g_wicErrorCodes.Add(WINCODEC_ERR_CODECTOOMANYSCANLINES, L"WINCODEC_ERR_CODECTOOMANYSCANLINES");
    g_wicErrorCodes.Add(WINCODEC_ERR_INTERNALERROR, L"WINCODEC_ERR_INTERNALERROR");
    g_wicErrorCodes.Add(WINCODEC_ERR_SOURCERECTDOESNOTMATCHDIMENSIONS, L"WINCODEC_ERR_SOURCERECTDOESNOTMATCHDIMENSIONS");
    g_wicErrorCodes.Add(WINCODEC_ERR_COMPONENTNOTFOUND, L"WINCODEC_ERR_COMPONENTNOTFOUND");
    g_wicErrorCodes.Add(WINCODEC_ERR_IMAGESIZEOUTOFRANGE, L"WINCODEC_ERR_IMAGESIZEOUTOFRANGE");
    g_wicErrorCodes.Add(WINCODEC_ERR_TOOMUCHMETADATA, L"WINCODEC_ERR_TOOMUCHMETADATA");
    g_wicErrorCodes.Add(WINCODEC_ERR_BADIMAGE, L"WINCODEC_ERR_BADIMAGE");
    g_wicErrorCodes.Add(WINCODEC_ERR_BADHEADER, L"WINCODEC_ERR_BADHEADER");
    g_wicErrorCodes.Add(WINCODEC_ERR_FRAMEMISSING, L"WINCODEC_ERR_FRAMEMISSING");
    g_wicErrorCodes.Add(WINCODEC_ERR_BADMETADATAHEADER, L"WINCODEC_ERR_BADMETADATAHEADER");
    g_wicErrorCodes.Add(WINCODEC_ERR_BADSTREAMDATA, L"WINCODEC_ERR_BADSTREAMDATA");
    g_wicErrorCodes.Add(WINCODEC_ERR_STREAMWRITE, L"WINCODEC_ERR_STREAMWRITE");
    g_wicErrorCodes.Add(WINCODEC_ERR_STREAMREAD, L"WINCODEC_ERR_STREAMREAD");
    g_wicErrorCodes.Add(WINCODEC_ERR_STREAMNOTAVAILABLE, L"WINCODEC_ERR_STREAMNOTAVAILABLE");
    g_wicErrorCodes.Add(WINCODEC_ERR_UNSUPPORTEDPIXELFORMAT, L"WINCODEC_ERR_UNSUPPORTEDPIXELFORMAT");
    g_wicErrorCodes.Add(WINCODEC_ERR_UNSUPPORTEDOPERATION, L"WINCODEC_ERR_UNSUPPORTEDOPERATION");    
    g_wicErrorCodes.Add(WINCODEC_ERR_INVALIDREGISTRATION, L"WINCODEC_ERR_INVALIDREGISTRATION");
    g_wicErrorCodes.Add(WINCODEC_ERR_COMPONENTINITIALIZEFAILURE, L"WINCODEC_ERR_COMPONENTINITIALIZEFAILURE");
    g_wicErrorCodes.Add(WINCODEC_ERR_INSUFFICIENTBUFFER, L"WINCODEC_ERR_INSUFFICIENTBUFFER");
    g_wicErrorCodes.Add(WINCODEC_ERR_DUPLICATEMETADATAPRESENT, L"WINCODEC_ERR_DUPLICATEMETADATAPRESENT");
    g_wicErrorCodes.Add(WINCODEC_ERR_PROPERTYUNEXPECTEDTYPE, L"WINCODEC_ERR_PROPERTYUNEXPECTEDTYPE");
    g_wicErrorCodes.Add(WINCODEC_ERR_UNEXPECTEDSIZE, L"WINCODEC_ERR_UNEXPECTEDSIZE");
    g_wicErrorCodes.Add(WINCODEC_ERR_INVALIDQUERYREQUEST, L"WINCODEC_ERR_INVALIDQUERYREQUEST");
    g_wicErrorCodes.Add(WINCODEC_ERR_UNEXPECTEDMETADATATYPE, L"WINCODEC_ERR_UNEXPECTEDMETADATATYPE");
    g_wicErrorCodes.Add(WINCODEC_ERR_REQUESTONLYVALIDATMETADATAROOT, L"WINCODEC_ERR_REQUESTONLYVALIDATMETADATAROOT");
    g_wicErrorCodes.Add(WINCODEC_ERR_INVALIDQUERYCHARACTER, L"WINCODEC_ERR_INVALIDQUERYCHARACTER");
}

static int Run(LPWSTR lpCmdLine, int nCmdShow)
{
    int result = 0;

    CMessageLoop msgLoop;
    _Module.AddMessageLoop(&msgLoop);

    CMainFrame mainWnd;

    // Create the main window
    if (NULL == mainWnd.CreateEx(NULL))
    {
        ATLTRACE(L"Main window creation failed");
        return 0;
    }

    // Center it
    mainWnd.CenterWindow();

    // Load the files
    int argc;
    LPWSTR *argv = CommandLineToArgvW(lpCmdLine, &argc);

    // If argc == 0, then lpCmdLine is the name of the executable (WICExplorer)
    if(*lpCmdLine != 0)
    {
        mainWnd.Load(argv, argc);
    }
    LocalFree(argv);

    // Show the window
    mainWnd.ShowWindow(nCmdShow);

    result = msgLoop.Run();

    _Module.RemoveMessageLoop();

    return result;
}

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE /*hPrevInstance*/, LPWSTR lpCmdLine, int nCmdShow)
{
    int result = 0;
    HRESULT hr = S_OK;

    PopulateWicErrorCodes();
    
    // Initialize COM
    hr = ::CoInitialize(NULL);
    ATLASSERT(SUCCEEDED(hr));
    if (FAILED(hr))
    {
        return 0;
    }

    // Initialize the Common Controls
    INITCOMMONCONTROLSEX iccx;
    iccx.dwSize = sizeof(iccx);
    iccx.dwICC = ICC_COOL_CLASSES | ICC_BAR_CLASSES | ICC_WIN95_CLASSES; 
    BOOL initCCRes = ::InitCommonControlsEx(&iccx);
    ATLASSERT(initCCRes);
    if (!initCCRes)
    {
        CoUninitialize();
        return 0;
    }

    // Initialize WindowsCodecs
    hr = CoCreateInstance(CLSID_WICImagingFactory, NULL, CLSCTX_INPROC_SERVER, IID_IWICImagingFactory, (LPVOID*) &g_imagingFactory);
    ATLASSERT(SUCCEEDED(hr));
    if (FAILED(hr))
    {
        CString msg;
        CString err;
        GetHresultString(hr, err);

        msg.Format(L"Unable to create ImagingFactory. The error is: %s.", (LPCTSTR)err);
        ::MessageBoxW(NULL, msg, L"Error Creating ImagingFactory", MB_ICONERROR);
    }

    // Initialize the RichEdit library
    HINSTANCE hInstRich = ::LoadLibrary(CRichEditCtrl::GetLibraryName());
    ATLASSERT(NULL != hInstRich);

    // Start running
    if (SUCCEEDED(hr) && (NULL != hInstRich))
    {
        ::DefWindowProc(NULL, 0, 0, 0L);

        hr = _Module.Init(NULL, hInstance);
        ATLASSERT(SUCCEEDED(hr));

        result = Run(lpCmdLine, nCmdShow);

        _Module.Term();

        // Release the factory
        IWICImagingFactory* imagingFactory = NULL;
        imagingFactory = g_imagingFactory.Detach();
        imagingFactory->Release();

        CElementManager::ClearAllElements();
        ::FreeLibrary(hInstRich);
        ::CoUninitialize();
    }    

    return SUCCEEDED(hr) ? 0 : result;
}
