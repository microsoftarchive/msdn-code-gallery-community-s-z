#pragma once

#include <ws2tcpip.h>

#include <stdio.h>
#include <tchar.h>

using namespace Platform;

#define PORT "4533"  // the port users will be connecting to
#define BACKLOG 10     // how many pending connections queue will hold


namespace WinsockListener
{
	public interface class IClientConnectedCallback
	{
	public:
		void ClientConnectedServer(String^ ipAddressOfClient);

	};

    public ref class CWinsockListener sealed
    {
    public:
        CWinsockListener();
		void SetClientCallBack(IClientConnectedCallback^ callbackObject);
		void StartSocketServer(String^* UsingIpAddress, String^* errMessage);

	private:
		IClientConnectedCallback^ _callbackObject;

    };


}