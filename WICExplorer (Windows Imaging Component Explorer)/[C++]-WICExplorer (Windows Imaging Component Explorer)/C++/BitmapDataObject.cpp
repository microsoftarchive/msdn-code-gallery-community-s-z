//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#include "precomp.hpp"


HRESULT CBitmapDataObject::InsertDib(HWND /*hWnd*/, IRichEditOle *pRichEditOle, HGLOBAL hGlobal)
{
    HRESULT result = S_OK;

    IOleClientSite *oleClientSite = NULL;
    IDataObject *dataObject = NULL;
    IStorage *storage = NULL;
    ILockBytes *lockBytes = NULL;
    IOleObject *oleObject = NULL;

    // Get the bitmap's DataObject
    CBitmapDataObject *bitmapDataObject = new CBitmapDataObject;        
    bitmapDataObject->QueryInterface(IID_IDataObject, (void **)&dataObject);
    bitmapDataObject->SetDib(hGlobal);

    // Get the RichEdit container site
    if (SUCCEEDED(result))
    {
        result = pRichEditOle->GetClientSite(&oleClientSite);
    }

    // Initialize a Storage Object
    if (SUCCEEDED(result))
    {            
        result = ::CreateILockBytesOnHGlobal(NULL, TRUE, &lockBytes);
        ATLASSERT(NULL != lockBytes);
    }

    if (SUCCEEDED(result))
    {
        result = ::StgCreateDocfileOnILockBytes(lockBytes,
            STGM_SHARE_EXCLUSIVE|STGM_CREATE|STGM_READWRITE, 0, &storage);
        ATLASSERT(NULL != storage);
    }

    // Get the ole object which will be inserted in the richedit control
    if (SUCCEEDED(result))
    {
        result = bitmapDataObject->GetOleObject(oleClientSite, storage, oleObject);
        ::OleSetContainedObject(oleObject, TRUE);
    }

    // Add the object to the RichEdit
    if (SUCCEEDED(result))
    {
        CLSID clsid;
        oleObject->GetUserClassID(&clsid);

        REOBJECT reobject = { 0 };
        reobject.cbStruct = sizeof(REOBJECT);

        reobject.clsid = clsid;
        reobject.cp = REO_CP_SELECTION;
        reobject.dvaspect = DVASPECT_CONTENT;
        reobject.dwFlags = REO_BELOWBASELINE;
        reobject.poleobj = oleObject;
        reobject.polesite = oleClientSite;
        reobject.pstg = storage;

        result = pRichEditOle->InsertObject(&reobject);
    }

    // Cleanup
    if (oleObject)
    {
        oleObject->Release();
    }
    if (oleClientSite)
    {
        oleClientSite->Release();
    }
    if (storage)
    {
        storage->Release();
    }
    if (lockBytes)
    {
        lockBytes->Release();
    }
    if (dataObject)
    {
        dataObject->Release();
    }

    return result;
}

CBitmapDataObject::CBitmapDataObject()
: m_numReferences(0)
{
}

CBitmapDataObject::~CBitmapDataObject()
{
    ::ReleaseStgMedium(&m_stgmed);
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::QueryInterface(REFIID iid, void **ppvObject)
{
    HRESULT result = E_INVALIDARG;

    if (ppvObject)
    {
        if (IID_IUnknown == iid)
        {
            *ppvObject = static_cast<IUnknown*>(this);
            AddRef();
            result = S_OK;
        }
        else if (IID_IDataObject == iid)
        {
            *ppvObject = static_cast<IDataObject*>(this);
            AddRef();
            result = S_OK;
        }
        else
        {
            *ppvObject = NULL;
            result = E_NOINTERFACE;
        }
    }

    return result;
}

ULONG STDMETHODCALLTYPE CBitmapDataObject::AddRef()
{
    m_numReferences++;
    return m_numReferences;
}

ULONG STDMETHODCALLTYPE CBitmapDataObject::Release()
{
    ULONG result = 0;

    if (m_numReferences > 0)
    {
        result = --m_numReferences;

        if (0 == m_numReferences)
        {
            delete this;
        }
    }

    return result;
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::GetData(FORMATETC * /*pformatetcIn*/, STGMEDIUM *pmedium)
{
    pmedium->tymed = TYMED_HGLOBAL;
    pmedium->hGlobal = ::OleDuplicateData(m_stgmed.hGlobal, CF_DIB, GMEM_MOVEABLE | GMEM_SHARE);
    pmedium->pUnkForRelease = NULL;

    return S_OK;
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::GetDataHere(FORMATETC * /*pformatetc*/, STGMEDIUM * /*pmedium*/)
{
    return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::QueryGetData(FORMATETC *pformatetc )
{
    HRESULT result = DV_E_FORMATETC;
    if (pformatetc)
    {
        if (CF_DIB == pformatetc->cfFormat)
        {
            result = S_OK;
        }
    }
    return result;
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::GetCanonicalFormatEtc(FORMATETC * /*pformatectIn*/, FORMATETC* /*pformatetcOut*/)
{
    return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::SetData(FORMATETC *pformatetc, STGMEDIUM *pmedium, BOOL /*fRelease*/)
{
    m_format = *pformatetc;
    m_stgmed = *pmedium;

    return S_OK;
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::EnumFormatEtc(DWORD /*dwDirection*/, IEnumFORMATETC **ppenumFormatEtc)
{
    *ppenumFormatEtc = nullptr;
    return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::DAdvise(FORMATETC * /*pformatetc*/, DWORD /*advf*/, IAdviseSink * /*pAdvSink*/, DWORD * /*pdwConnection*/)
{
    return OLE_E_ADVISENOTSUPPORTED;
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::DUnadvise(DWORD /*dwConnection*/)
{
    return OLE_E_ADVISENOTSUPPORTED;
}

HRESULT STDMETHODCALLTYPE CBitmapDataObject::EnumDAdvise(IEnumSTATDATA **ppenumAdvise)
{
    *ppenumAdvise = nullptr;
    return OLE_E_ADVISENOTSUPPORTED;
}

void CBitmapDataObject::SetDib(HGLOBAL hGlobal)
{
    ATLASSERT(hGlobal);

    if (hGlobal)
    {
        STGMEDIUM stgm = { 0 };
        stgm.tymed = TYMED_HGLOBAL;
        stgm.hGlobal = hGlobal;
        stgm.pUnkForRelease = NULL;

        FORMATETC fm = { 0 };
        fm.cfFormat = 0; 
        fm.ptd = NULL; 
        fm.dwAspect = DVASPECT_CONTENT; 
        fm.lindex = -1; 
        fm.tymed = TYMED_NULL;

        SetData(&fm, &stgm, TRUE);
    }
}

HRESULT CBitmapDataObject::GetOleObject(IOleClientSite *oleClientSite, IStorage *storage, IOleObject *&oleObject)
{
    HRESULT result = E_UNEXPECTED;

    oleObject = NULL;

    ATLASSERT(m_stgmed.hGlobal);

    if (m_stgmed.hGlobal)
    {
        result = ::OleCreateStaticFromData(this, IID_IOleObject, OLERENDER_DRAW,
            &m_format, oleClientSite, storage, (void **)&oleObject);

        if (FAILED(result))
        {
            oleObject = NULL;
        }
    }

    return result;
}
