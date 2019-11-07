//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#pragma once

class CBitmapDataObject : IDataObject
{
public:
    static HRESULT InsertDib(HWND hWnd, IRichEditOle *pRichEditOle, HGLOBAL hGlobal);

public:
    CBitmapDataObject();
    ~CBitmapDataObject();

    // IUnknown Interface
    STDMETHOD(QueryInterface)(REFIID iid, void **ppvObject);
    STDMETHOD_(ULONG, AddRef)();
    STDMETHOD_(ULONG, Release)();

    // IDataObject Interface
    STDMETHOD(GetData)(FORMATETC *pformatetcIn, STGMEDIUM *pmedium);
    STDMETHOD(GetDataHere)(FORMATETC *pformatetc, STGMEDIUM *pmedium);
    STDMETHOD(QueryGetData)(FORMATETC *pformatetc );
    STDMETHOD(GetCanonicalFormatEtc)(FORMATETC *pformatectIn, FORMATETC* pformatetcOut);
    STDMETHOD(SetData)(FORMATETC *pformatetc, STGMEDIUM *pmedium, BOOL fRelease);
    STDMETHOD(EnumFormatEtc)(DWORD dwDirection, IEnumFORMATETC **ppenumFormatEtc);
    STDMETHOD(DAdvise)(FORMATETC *pformatetc, DWORD advf, IAdviseSink *pAdvSink, DWORD *pdwConnection);
    STDMETHOD(DUnadvise)(DWORD dwConnection);
    STDMETHOD(EnumDAdvise)(IEnumSTATDATA **ppenumAdvise);

private:
    void SetDib(HGLOBAL hGlobal);    
    HRESULT GetOleObject(IOleClientSite *oleClientSite, IStorage *storage, IOleObject *&oleObject);

    ULONG m_numReferences;

    STGMEDIUM m_stgmed;
    FORMATETC m_format;
};

