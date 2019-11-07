//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#pragma once

// Change these values to use different versions
#define _RICHEDIT_VER    0x0300

#include <windows.h>
#include <tchar.h>
#include <shellapi.h>
#include <comip.h>

#include <wincodec.h>
#include <wincodecsdk.h>
#include <icm.h>

#import "msxml2.tlb" named_guids

#define STRSAFE_NO_DEPRECATE 1
#include <strsafe.h>

#include <atlbase.h>
#include <atlstr.h>
#include <atlwin.h>

// ***** The Windows Template Library (WTL) is required for this project *****
// ***** and must be downloaded separately. See instructions in readme.md. *****
#define _WTL_NO_CSTRING

#include "wtl90\atlapp.h"

extern CAppModule _Module;

#include "wtl90\atlframe.h"
#include "wtl90\atlctrls.h"
#include "wtl90\atldlgs.h"
#include "wtl90\atlmisc.h"
#include "wtl90\atlsplit.h"
#include "wtl90\atlctrlx.h"

#define MP(i) typedef _com_ptr_t<_com_IIID<i, &IID_##i> > i##Ptr;
#include "Interfaces.h"
#undef MP

extern IWICImagingFactoryPtr g_imagingFactory;
extern CSimpleMap<HRESULT, LPCWSTR> g_wicErrorCodes;

#define IFC(c) do { result = (c); if (FAILED(result)) return result; } while(0);

#define READ_WIC_STRING(f, out) do {                                    \
    UINT strLen = 0;                                                    \
    result = f(0, 0, &strLen);                                          \
    if (SUCCEEDED(result) && (strLen > 0)) {                            \
        result = f(strLen, out.GetBufferSetLength(strLen), &strLen);    \
        out.ReleaseBuffer(strLen - 1);                                  \
    } else { out = L""; } } while(0);

void GetHresultString(HRESULT hr, CString &out);

#include "resource.h"

#include "AboutDlg.h"
#include "BitmapDataObject.h"
#include "CodeGenerator.h"
#include "Element.h"
#include "EncoderSelectionDlg.h"
#include "ImageTransencoder.h"
#include "MainFrame.h"
#include "MetadataTranslator.h"
#include "OutputDevice.h"
#include "PropVariant.h"
#include "Stopwatch.h"
