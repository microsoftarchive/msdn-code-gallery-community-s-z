//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#include "precomp.hpp"


CImageTransencoder::CImageTransencoder()
: m_codeGen(NULL)
, m_encoding(false)
, m_numPalettedFrames(0)
{
    m_format = GUID_WICPixelFormatDontCare;
}

CImageTransencoder::~CImageTransencoder()
{
    End();
}

void CImageTransencoder::Clear()
{
    m_codeGen           = NULL;
    m_stream            = NULL;
    m_encoder           = NULL;
    m_encoding          = false;
    m_numPalettedFrames = 0;
}

HRESULT CImageTransencoder::Begin(REFGUID containerFormat, LPCWSTR filename, ICodeGenerator &codeGen)
{
    HRESULT result = S_OK;

    Clear();

    m_codeGen = &codeGen;

    // Get a writable stream
    m_codeGen->BeginVariableScope(L"IWICStream*", L"stream", L"NULL");

    m_codeGen->CallFunction(L"imagingFactory->CreateStream(&stream)");
    IFC(g_imagingFactory->CreateStream(&m_stream));

    m_codeGen->CallFunction(L"stream->InitializeFromFilename(\"%s\", GENERIC_WRITE)", filename);
    IFC(m_stream->InitializeFromFilename(filename, GENERIC_WRITE));

    // Create the encoder
    m_codeGen->BeginVariableScope(L"IWICBitmapEncoder*", L"encoder", L"NULL");

    m_codeGen->CallFunction(L"imagingFactory->CreateEncoder(containerFormat, NULL, &encoder)");
    IFC(g_imagingFactory->CreateEncoder(containerFormat, NULL, &m_encoder));

    if (NULL != m_encoder)
    {
        // Initialize it
        m_codeGen->CallFunction(L"encoder->Initialize(stream, WICBitmapEncoderCacheInMemory)");
        IFC(m_encoder->Initialize(m_stream, WICBitmapEncoderNoCache));

        // This transencoder is now ready to encode
        m_encoding = true;
    }

    return result;
}

HRESULT CImageTransencoder::AddFrame(IWICBitmapSourcePtr bitmapSource)
{
    HRESULT result = S_OK;

    // Check the params
    ATLASSERT(NULL != bitmapSource);
    if (NULL == bitmapSource)
    {
        return E_INVALIDARG;
    }

    // Check the state of the object
    ATLASSERT(m_encoding);
    if (!m_encoding)
    {
        return E_UNEXPECTED;
    }

    // Perform different operations if this is a frame vs. just a boring BitmapSource
    IWICBitmapFrameDecodePtr frame = bitmapSource;
    if (NULL != frame)
    {
        m_codeGen->BeginVariableScope(L"IWICBitmapFrameDecode*", L"source", L"...");
        IFC(AddBitmapFrameDecode(frame));
        m_codeGen->EndVariableScope();
    }
    else
    {
        m_codeGen->BeginVariableScope(L"IWICBitmapSource*", L"source", L"...");
        IFC(AddBitmapSource(bitmapSource));
        m_codeGen->EndVariableScope();
    }

    return result;
}

HRESULT CImageTransencoder::SetThumbnail(IWICBitmapSourcePtr thumb)
{
    HRESULT result = S_OK;

    // Check the state of the object
    ATLASSERT(m_encoding);
    if (!m_encoding)
    {
        return E_UNEXPECTED;
    }

    // Set the Thumbnail
    m_codeGen->CallFunction(L"encoder->SetThumbnail(thumb)");

    // Allow failure
    m_encoder->SetThumbnail(thumb);

    return result;
}

HRESULT CImageTransencoder::SetPreview(IWICBitmapSourcePtr preview)
{
    HRESULT result = S_OK;

    // Check the state of the object
    ATLASSERT(m_encoding);
    if (!m_encoding)
    {
        return E_UNEXPECTED;
    }

    // Set the Preview
    m_codeGen->CallFunction(L"encoder->SetPreview(preview)");

    // Allow failure
    m_encoder->SetPreview(preview);

    return result;
}

HRESULT CImageTransencoder::End()
{
    HRESULT result = S_OK;

    if (NULL != m_encoder)
    {
        m_encoder->Commit();

        m_codeGen->EndVariableScope();
    }

    if (NULL != m_stream)
    {
        m_codeGen->EndVariableScope();
    }

    Clear();

    return result;
}

UINT NumPaletteColorsRequiredByFormat(REFGUID pf)
{
    if (GUID_WICPixelFormat1bppIndexed == pf)
    {
        return (1 << 1);
    }
    else if (GUID_WICPixelFormat2bppIndexed == pf)
    {
        return (1 << 2);
    }
    else if (GUID_WICPixelFormat4bppIndexed == pf)
    {
        return (1 << 4);
    }
    else if (GUID_WICPixelFormat8bppIndexed == pf)
    {
        return (1 << 8);
    }

    return 0;
}

HRESULT CImageTransencoder::CreateFrameEncode(IWICBitmapSourcePtr bitmapSource, IWICBitmapFrameEncodePtr &frameEncode)
{
    HRESULT result = S_OK;

    // Try to add a frame encode to the encoder
    m_codeGen->BeginVariableScope(L"IWICBitmapFrameEncode*", L"frame", L"NULL");
    m_codeGen->CallFunction(L"encoder->CreateNewFrame(&frame, NULL)");
    IFC(m_encoder->CreateNewFrame(&frameEncode, NULL));

    // Initialize it
    m_codeGen->CallFunction(L"frame->Initialize(NULL)");
    IFC(frameEncode->Initialize(NULL));

    // Set the Size
    UINT width = 0, height = 0;

    m_codeGen->CallFunction(L"source->GetSize(&width, &height)");
    IFC(bitmapSource->GetSize(&width, &height));

    m_codeGen->CallFunction(L"frame->SetSize(%u, %u)", width, height);
    IFC(frameEncode->SetSize(width, height));

    // Set the Resolution
    double dpiX = 0, dpiY = 0;

    m_codeGen->CallFunction(L"source->GetResolution(&dpiX, &dpiY)");
    IFC(bitmapSource->GetResolution(&dpiX, &dpiY));

    m_codeGen->CallFunction(L"frame->SetResolution(%g, %g)", dpiX, dpiY);
    IFC(frameEncode->SetResolution(dpiX, dpiY));

    // Attempt to set the PixelFormat
    // This call is allowed to fail because the encoder may not support the desired format
    WICPixelFormatGUID desiredPixelFormat = { 0 };
    WICPixelFormatGUID supportedPixelFormat = { 0 };

    m_codeGen->CallFunction(L"source->GetPixelFormat(&desiredPixelFormat)");
    IFC(bitmapSource->GetPixelFormat(&desiredPixelFormat));

    m_codeGen->CallFunction(L"supportedPixelFormat = desiredPixelFormat");
    if(m_format == GUID_WICPixelFormatDontCare)
    {
        supportedPixelFormat = desiredPixelFormat;
    }
    else
    {
        supportedPixelFormat = m_format;
    }

    m_codeGen->CallFunction(L"frame->SetPixelFormat(&supportedPixelFormat)");
    frameEncode->SetPixelFormat(&supportedPixelFormat);
    m_format = supportedPixelFormat;

    // If the format that we will encode to requires a palette, then we need to
    // retrieve one. First we will try the palette of the BitmapSource itself.
    // If that fails, we will generate a palette from the BitmapSource.
    UINT numPaletteColors = NumPaletteColorsRequiredByFormat(supportedPixelFormat);
    if (numPaletteColors > 0)
    {
        // Create the palette
        m_codeGen->BeginVariableScope(L"IWICPalette*", L"palette", L"NULL");
        IWICPalettePtr palette;

        m_codeGen->CallFunction(L"imagingFactory->CreatePalette(&palette)");
        IFC(g_imagingFactory->CreatePalette(&palette));

        // Attempt to get the palette from the source
        m_codeGen->CallFunction(L"source->CopyPalette(palette)");
        result = bitmapSource->CopyPalette(palette);

        if (FAILED(result))
        {
            // We weren't able to get the palette directly from the source,
            // so let's try to generate one from the source's data
            result = S_OK;

            m_codeGen->CallFunction(L"palette->InitializeFromBitmap(source, %u, FALSE)", numPaletteColors);
            IFC(palette->InitializeFromBitmap(bitmapSource, numPaletteColors, FALSE));
        }

        // Set the palette
        m_codeGen->CallFunction(L"frame->SetPalette(palette)");
        IFC(frameEncode->SetPalette(palette));

        // If this is the first frame to require a palette, use this palette as the
        // global palette
        m_numPalettedFrames++;
        if (1 == m_numPalettedFrames)
        {
            m_codeGen->CallFunction(L"encoder->SetPalette(palette)");
            m_encoder->SetPalette(palette);
        }

        m_codeGen->EndVariableScope();
    }    

    // Copy the color profile, if there is one.
    IWICBitmapFrameDecodePtr frame = bitmapSource;
    UINT colorContextCount = 0;
    if ( frame != NULL &&
        SUCCEEDED(frame->GetColorContexts(0, 0, &colorContextCount)) &&
        colorContextCount > 0)
    {
        IWICColorContext **contexts = new IWICColorContext*[colorContextCount];
        for (UINT i = 0; i < colorContextCount; i++)
        {
            IFC(g_imagingFactory->CreateColorContext(&contexts[i]));
        }
        IFC(frame->GetColorContexts(colorContextCount, contexts, &colorContextCount));

        if(FAILED(frameEncode->SetColorContexts(colorContextCount, contexts)))
        {
            ::MessageBox(0, L"Unable to copy color contexts", L"Warning", MB_OK);
        }
        for(UINT i = 0; i < colorContextCount; i++)
        {
            if(contexts[i] != NULL)
            {
                contexts[i]->Release();
            }
        }
        delete[] contexts;
    }

    // Finally, write the actual BitmapSource
    WICRect rct;
    rct.X = 0;
    rct.Y = 0;
    rct.Width = width;
    rct.Height = height;

    m_codeGen->CallFunction(L"frame->WriteSource(source, &rct)");
    IFC(frameEncode->WriteSource(bitmapSource, &rct));

    return result;
}

HRESULT CImageTransencoder::AddBitmapSource(IWICBitmapSourcePtr bitmapSource)
{
    HRESULT result = S_OK;

    // Create the frame
    IWICBitmapFrameEncodePtr frameEncode;
    IFC(CreateFrameEncode(bitmapSource, frameEncode));

    // Nothing more to do with it
    m_codeGen->CallFunction(L"frame->Commit()");
    IFC(frameEncode->Commit());

    return result;
}

HRESULT CImageTransencoder::AddBitmapFrameDecode(IWICBitmapFrameDecodePtr frame)
{
    HRESULT result = S_OK;

    // Create the frame
    IWICBitmapFrameEncodePtr frameEncode;
    IFC(CreateFrameEncode(frame, frameEncode));

    // Output Thumbnail
    m_codeGen->BeginVariableScope(L"IWICBitmapSource*", L"thumb", L"NULL");
    IWICBitmapSourcePtr thumb = NULL;

    m_codeGen->CallFunction(L"source->GetThumbnail(&thumb)");
    frame->GetThumbnail(&thumb);

    if (NULL != thumb)
    {
        m_codeGen->CallFunction(L"frame->SetThumbnail(thumb)");

        // This is allowed to fail
        frameEncode->SetThumbnail(thumb);
    }

    // TODO: Output Metadata

    // All done
    m_codeGen->CallFunction(L"frame->Commit()");
    IFC(frameEncode->Commit());

    return result;
}
