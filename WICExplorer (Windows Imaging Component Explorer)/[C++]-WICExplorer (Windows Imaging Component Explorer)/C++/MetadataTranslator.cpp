//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#include "precomp.hpp"

CMetadataTranslator::Key::Key(LPWSTR guidStr, LPCWSTR idStr)
{
    CLSIDFromString(guidStr, &m_format);
    m_id = _wtoi(idStr);
}

CMetadataTranslator::Key::Key()
{
    // No initialization
}

HRESULT CMetadataTranslator::ReadPropVariantInteger(PROPVARIANT *pv, int &out)
{
    HRESULT result = E_INVALIDARG;

    ATLASSERT(NULL != pv);
    if (NULL != pv)
    {
        switch (pv->vt)
        {
        case VT_I1:
            out = pv->cVal;
            result = S_OK;
            break;
        case VT_UI1:
            out = pv->bVal;
            result = S_OK;
            break;
        case VT_I2:
            out = pv->iVal;
            result = S_OK;
            break;
        case VT_UI2:
            out = pv->uiVal;
            result = S_OK;
            break;
        case VT_I4:
            out = pv->lVal;
            result = S_OK;
            break;
        case VT_UI4:
            out = pv->ulVal;
            result = S_OK;
            break;
        case VT_INT:
            out = pv->intVal;
            result = S_OK;
            break;
        case VT_UINT:
            out = pv->uintVal;
            result = S_OK;
            break;
        }
    }

    return result;
}

HRESULT CMetadataTranslator::Translate(const GUID &format, PROPVARIANT *pv, CString &out)
{
    HRESULT result = S_OK;

    int id = 0;

    // For now, pv must be one of the integers
    IFC(ReadPropVariantInteger(pv, id));

    // Lookup the string
    Key k;
    k.m_format = format;
    k.m_id = id;
    int idx = m_dictionary.FindKey(k);

    if (idx >= 0)
    {
        // Found one!
        out = m_dictionary.GetValueAt(idx);
    }
    else
    {
        // No translation found
        result = E_FAIL;
    }

    return result;
}

HRESULT CMetadataTranslator::LoadFormat(MSXML2::IXMLDOMNodePtr formatNode)
{
    HRESULT result = S_OK;

    // Get the format
    _bstr_t formatGuidStr;
    MSXML2::IXMLDOMNodePtr formatGuidNode = formatNode->attributes->getNamedItem(TEXT("guid"));
    if (NULL != formatGuidNode)
    {
        formatGuidStr = formatGuidNode->nodeValue;
    }

    // Verify that the GUID has some text
    if (formatGuidStr.length() < 1)
    {
        return E_UNEXPECTED;
    }

    // Load each entry
    MSXML2::IXMLDOMNodeListPtr entryNodes = formatNode->childNodes;
    for (int ei = 0; ei < entryNodes->length; ei++)
    {
        if (_wcsicmp(entryNodes->item[ei]->nodeName, TEXT("entry")) == 0)
        {
            MSXML2::IXMLDOMNodePtr entryIdNode = entryNodes->item[ei]->attributes->getNamedItem(TEXT("id"));
            MSXML2::IXMLDOMNodePtr entryValueNode = entryNodes->item[ei]->attributes->getNamedItem(TEXT("value"));

            if ((NULL != entryIdNode) && (NULL != entryValueNode))
            {
                _bstr_t idStr = entryIdNode->nodeValue;
                _bstr_t valueStr = entryValueNode->nodeValue;

                // Finally, we can add this entry
                m_dictionary.Add(Key(formatGuidStr, idStr), CString((LPCWSTR)valueStr));
            }
        }
    }

    return result;
}

HRESULT CMetadataTranslator::LoadTranslations()
{
    HRESULT result = S_OK;

    // Create the XML document object
    MSXML2::IXMLDOMDocumentPtr xmlDoc;
    IFC(xmlDoc.CreateInstance(__uuidof(MSXML2::DOMDocument)));

    // Do not allow asynchronous download
    xmlDoc->async = VARIANT_FALSE;
      
    // Load the translations file
    _variant_t dictFilename(L"MetadataDictionary.xml");
    _variant_t br(true);
    br = xmlDoc->load(dictFilename);
    if (!(bool)br)
    {
        return E_FAIL;
    }

    // Locate each of the Metadata formats, and process them.
    // <dictionary> -> <format /> <format /> ... </dictionary>
    MSXML2::IXMLDOMNodeListPtr dictNodes = xmlDoc->childNodes;
    for (int di = 0; di < dictNodes->length; di++)
    {
        if (_wcsicmp(dictNodes->item[di]->nodeName, TEXT("dictionary")) == 0)
        {
            MSXML2::IXMLDOMNodeListPtr formatNodes = dictNodes->item[di]->childNodes;
            for (int fi = 0; fi < formatNodes->length; fi++)
            {
                if (_wcsicmp(formatNodes->item[fi]->nodeName, TEXT("format")) == 0)
                {
                    LoadFormat(formatNodes->item[fi]);
                }
            }
        }
    }

    return result;
}
