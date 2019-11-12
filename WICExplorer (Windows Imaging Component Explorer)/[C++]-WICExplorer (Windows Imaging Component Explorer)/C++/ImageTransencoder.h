//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#pragma once

class CImageTransencoder
{
public:
    CImageTransencoder();
    ~CImageTransencoder();

    HRESULT Begin(REFCLSID encoderClsid, LPCWSTR filename, ICodeGenerator &codeGen);
    HRESULT AddFrame(IWICBitmapSourcePtr bitmapSource);
    HRESULT SetThumbnail(IWICBitmapSourcePtr thumb);
    HRESULT SetPreview(IWICBitmapSourcePtr preview);
    HRESULT End();

    WICPixelFormatGUID     m_format;

private:
    void Clear();
    HRESULT AddBitmapSource(IWICBitmapSourcePtr bitmapSource);
    HRESULT AddBitmapFrameDecode(IWICBitmapFrameDecodePtr frame);
    HRESULT CreateFrameEncode(IWICBitmapSourcePtr bitmapSource, IWICBitmapFrameEncodePtr &frameEncode);

    ICodeGenerator       *m_codeGen;
    IWICStreamPtr         m_stream;
    IWICBitmapEncoderPtr  m_encoder;
    bool                  m_encoding;
    UINT                  m_numPalettedFrames;
};

