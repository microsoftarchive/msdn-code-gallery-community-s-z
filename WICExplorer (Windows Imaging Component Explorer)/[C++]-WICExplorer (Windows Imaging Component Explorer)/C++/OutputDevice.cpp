//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#include "precomp.hpp"

static const CString NormalFontName = L"Verdana";
static const CString VerbatimFontName = L"Lucida Console";

CRichEditDevice::CRichEditDevice(CRichEditCtrl &richEditCtrl)
: m_richEditCtrl(richEditCtrl)
{
    SetFontName(NormalFontName);
    SetFontSize(TEXT_SIZE);
    SetBackgroundColor(GetSysColor(COLOR_INFOBK));
    SetTextColor(GetSysColor(COLOR_INFOTEXT));
}

CRichEditDevice::~CRichEditDevice()
{
}

void CRichEditDevice::SetBackgroundColor(COLORREF color)
{
    m_richEditCtrl.SendMessage(EM_SETBKGNDCOLOR, 0, color);
    ::InvalidateRect(m_richEditCtrl.GetParent(), 0, TRUE);
}

COLORREF CRichEditDevice::SetTextColor(COLORREF color)
{
    CHARFORMAT2 cf;
    cf.cbSize = sizeof(CHARFORMAT2);
    m_richEditCtrl.GetSelectionCharFormat(cf);
    cf.dwEffects = 0;
    
    COLORREF result = cf.crTextColor;

    cf.wWeight = FW_NORMAL;
    cf.dwMask = CFM_COLOR | CFM_WEIGHT;
    cf.crTextColor = color;
    
    m_richEditCtrl.SendMessage(EM_SETCHARFORMAT, SCF_SELECTION | SCF_WORD, (LPARAM)&cf);

    return result;
}

void CRichEditDevice::SetHighlightColor(COLORREF color)
{
    CHARFORMAT2 cf;
    cf.cbSize = sizeof(CHARFORMAT2);
    cf.dwEffects = 0;

    cf.dwMask = CFM_BACKCOLOR;
    cf.crBackColor = color;
    
    m_richEditCtrl.SendMessage(EM_SETCHARFORMAT, SCF_SELECTION | SCF_WORD, (LPARAM)&cf);
}

void CRichEditDevice::SetFontName(LPCWSTR name)
{
    CHARFORMAT2 cf;
    cf.cbSize = sizeof(CHARFORMAT2);
    cf.dwEffects = 0;

    cf.wWeight = FW_NORMAL;
    int len = (int)wcslen(name);
    for (int i = 0; i < len; i++)
    {
        cf.szFaceName[i] = name[i];
    }
    cf.szFaceName[len] = L'\0';
    cf.dwMask = CFM_FACE | CFM_WEIGHT;

    m_richEditCtrl.SendMessage(EM_SETCHARFORMAT, SCF_SELECTION | SCF_WORD, (LPARAM)&cf);
}

int CRichEditDevice::SetFontSize(int pointSize)
{
    CHARFORMAT2 cf;
    cf.cbSize = sizeof(CHARFORMAT2);
    m_richEditCtrl.GetSelectionCharFormat(cf);
    cf.dwEffects = 0;
    
    int result = cf.yHeight / 20;

    cf.wWeight = FW_NORMAL;
    cf.yHeight = 20 * pointSize; // Convert to twips
    cf.dwMask  = CFM_SIZE | CFM_WEIGHT;

    m_richEditCtrl.SetSelectionCharFormat(cf);

    return result;
}

void CRichEditDevice::BeginSection(LPCWSTR name)
{
    // Add this new level to the output stack
    m_sections.Add(CString(name));

    // Actually write the section heading
    if ((NULL != name) && (L'\0' != *name))
    {
        AddText(L"\n");

        int headingSize = TEXT_SIZE + ((m_sections.GetSize() <= 4) ? (4 - m_sections.GetSize())*TEXT_SIZE/4 : 0);
        int oldSize = SetFontSize(headingSize);
        COLORREF oldColor = SetTextColor(RGB(192, 0, 0));

        AddText(name);
        
        SetTextColor(oldColor);
        SetFontSize(oldSize);

        AddText(L"\n\n");
    }
}

void CRichEditDevice::AddText(LPCWSTR name)
{
    m_richEditCtrl.AppendText(name);
}

void CRichEditDevice::AddVerbatimText(LPCWSTR name)
{
    SetFontName(VerbatimFontName);
    m_richEditCtrl.AppendText(name);
    SetFontName(NormalFontName);
}

void CRichEditDevice::AddDib(HGLOBAL hBitmap)
{
    IRichEditOle *oleInterface = m_richEditCtrl.GetOleInterface();

    if (NULL != oleInterface)
    {
        HRESULT res = CBitmapDataObject::InsertDib(m_richEditCtrl.m_hWnd, oleInterface, hBitmap);

        if (FAILED(res))
        {
            CString msg;
            CString err;

            GetHresultString(res, err);

            msg.Format(L"Failed to render bitmap: %s\n", (LPCWSTR)err);
            COLORREF oldColor = SetTextColor(RGB(255, 0, 0));
            AddText(msg);
            SetTextColor(oldColor);
        }
        else
        {
            AddText(L"\n");
        }

        oleInterface->Release();
    }
}

void CRichEditDevice::BeginKeyValues(LPCWSTR name)
{
    // Write the heading if one was specified
    if ((NULL != name) && (L'\0' != *name))
    {
        COLORREF oldColor = SetTextColor(RGB(0, 0, 128));

        AddText(name);
        
        SetTextColor(oldColor);

        AddText(L"\n");
    }
}

void CRichEditDevice::AddKeyValue(LPCWSTR key, LPCWSTR value)
{
    COLORREF oldColor = SetTextColor(RGB(0, 128, 0));

    AddText(key);
        
    SetTextColor(oldColor);

    AddText(L"\t\t");
    AddText(value);
    AddText(L"\n");
}

void CRichEditDevice::EndKeyValues()
{
    AddText(L"\n");
}

void CRichEditDevice::EndSection()
{
    if (m_sections.GetSize() > 0)
    {
        m_sections.RemoveAt(m_sections.GetSize() - 1);
    }
}
