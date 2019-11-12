//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#pragma once

class IOutputDevice
{
public:
    virtual ~IOutputDevice()
    {
    }

    virtual void SetBackgroundColor(COLORREF color) = 0;
    virtual COLORREF SetTextColor(COLORREF color) = 0;
    virtual void SetHighlightColor(COLORREF color) = 0;

    virtual void SetFontName(LPCWSTR name) = 0;
    virtual int SetFontSize(int pointSize) = 0;

    virtual void BeginSection(LPCWSTR name) = 0;
    virtual void AddText(LPCWSTR text) = 0;
    virtual void AddVerbatimText(LPCWSTR text) = 0;
    virtual void AddDib(HGLOBAL hGlobal) = 0;
    virtual void BeginKeyValues(LPCWSTR name) = 0;
    virtual void AddKeyValue(LPCWSTR key, LPCWSTR value) = 0;
    virtual void EndKeyValues() = 0;
    virtual void EndSection() = 0;
};

class CRichEditDevice : public IOutputDevice
{
public:
    CRichEditDevice(CRichEditCtrl &richEditCtrl);
    ~CRichEditDevice();

    void SetBackgroundColor(COLORREF color);
    COLORREF SetTextColor(COLORREF color);
    void SetHighlightColor(COLORREF color);

    void SetFontName(LPCWSTR name);
    int SetFontSize(int pointSize);

    void BeginSection(LPCWSTR name);
    void AddText(LPCWSTR name);
    void AddVerbatimText(LPCWSTR text);
    void AddDib(HGLOBAL hGlobal);
    void BeginKeyValues(LPCWSTR name);
    void AddKeyValue(LPCWSTR key, LPCWSTR value);
    void EndKeyValues();
    void EndSection();

private:
    enum { TEXT_SIZE = 10 };

    CSimpleArray<CString> m_sections;
    CRichEditCtrl &m_richEditCtrl;
};
