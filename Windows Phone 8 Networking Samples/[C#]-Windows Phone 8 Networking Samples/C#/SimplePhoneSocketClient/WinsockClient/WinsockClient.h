#pragma once
#include "pch.h"
#include <ws2tcpip.h>
#include <stdio.h>
#include <tchar.h>

#define PORT "4533" // the port client will be connecting to 
#define MAXDATASIZE 100 // max number of bytes we can get at once 

using namespace Platform;


namespace WinsockClient
{
    public ref class CWinsockClient sealed
    {
    public:
        CWinsockClient();
		int ConnectThroughSocket(String^ hostToConnect, String^* error);
    };
}