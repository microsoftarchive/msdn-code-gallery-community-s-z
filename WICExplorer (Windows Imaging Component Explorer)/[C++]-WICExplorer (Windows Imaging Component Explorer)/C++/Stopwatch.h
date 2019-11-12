//----------------------------------------------------------------------------------------
// THIS CODE AND INFORMATION IS PROVIDED "AS-IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------------------
#pragma once

class CStopwatch
{
public:
    CStopwatch()
    {
        QueryPerformanceFrequency(&m_frequency);
        m_startTime.QuadPart = 0;        
    }

    void Start()
    {
        QueryPerformanceCounter(&m_startTime);
    }

    DWORD GetTimeMS()
    {
        LARGE_INTEGER now;
        QueryPerformanceCounter(&now);

        LONGLONG timeMS = ((now.QuadPart - m_startTime.QuadPart) * LONGLONG(1000)) / m_frequency.QuadPart;

        return DWORD(timeMS);
    }

private:
    LARGE_INTEGER m_frequency;
    LARGE_INTEGER m_startTime;
};

