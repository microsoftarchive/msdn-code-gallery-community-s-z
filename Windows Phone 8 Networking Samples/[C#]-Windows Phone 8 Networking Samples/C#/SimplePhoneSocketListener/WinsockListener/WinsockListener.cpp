// WinsockListener.cpp
#include "pch.h"
#include "WinsockListener.h"

using namespace WinsockListener;

CWinsockListener::CWinsockListener()
{
}

void CWinsockListener::SetClientCallBack(IClientConnectedCallback^ callbackObject)
{
	_callbackObject = callbackObject;
}

void CWinsockListener::StartSocketServer(String^* UsingIpAddress, String^* errMessage)
{
    int listenSocket;  // listen on sock_fd, clients that are connected talk on clientConnectedSocket
    struct addrinfo hints, *servinfo;
    int yes=1;
	const char* c = NULL;
	c = (char*)&yes;    
    int rv;
	//used to callback to the managed layer when connections are received
	IClientConnectedCallback^ callbackObject = _callbackObject;

	//init winsock
	WSADATA wsaData; 
	if ((rv = WSAStartup(MAKEWORD(2,2), &wsaData)) != 0) {
		*errMessage = "WSAStartup error:";
		*errMessage += WSAGetLastError();
        return;
    }

    memset(&hints, 0, sizeof hints);
	//using ipv4
    hints.ai_family = AF_INET;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_flags = AI_PASSIVE; // use my IP

	//get our device servinfo for the ipv4 socket
    if ((rv = getaddrinfo(NULL, PORT, &hints, &servinfo)) != 0) {
		*errMessage = "getaddrinfo error:";
		*errMessage += WSAGetLastError();
        return;
    }

	//get the listener socket
	listenSocket = socket(servinfo->ai_family, servinfo->ai_socktype, servinfo->ai_protocol);
    if (listenSocket == INVALID_SOCKET) {
		*errMessage = "socket failed with error:";
		*errMessage += WSAGetLastError();
        freeaddrinfo(servinfo);
        WSACleanup();
        return;
    }

    // bind
    int iResult = bind( listenSocket, servinfo->ai_addr, (int)servinfo->ai_addrlen);
    if (iResult == SOCKET_ERROR) {
		*errMessage = "Bind failed with error:";
		*errMessage += WSAGetLastError();
        freeaddrinfo(servinfo);
        closesocket(listenSocket);
        WSACleanup();
        return;
    }
	
	//get ip of the device so we can show it in the UI 
	hostent* localHost;
	char* localIP;
	localHost = gethostbyname("");
	localIP = inet_ntoa (*(struct in_addr *)*localHost->h_addr_list);
	wchar_t serverIP[255];
	MultiByteToWideChar(CP_UTF8, 0, localIP, -1, serverIP, 255);
	*UsingIpAddress = ref new String(serverIP);

	//free servinfo; don't need it anymore
    freeaddrinfo(servinfo); 

    if (listen(listenSocket, BACKLOG) == -1) {
		*errMessage = "Listen error:";
		*errMessage += WSAGetLastError();
        return;
    }
	
	//this handler executes in the background forever listening for 
	//incoming connections and calling back to the UI thread when it has one come through.
	using namespace Windows::System::Threading;
	ThreadPool::RunAsync( ref new WorkItemHandler( [listenSocket,callbackObject](Windows::Foundation::IAsyncAction^ operation)
	   {  
			while(1) {  
				
				struct sockaddr_storage their_addr; 
				int clientConnectedSocket;
				socklen_t sin_size = sizeof their_addr;

				//accept connections from clients
				clientConnectedSocket = accept(listenSocket, (struct sockaddr *)&their_addr, &sin_size);
				if (clientConnectedSocket == -1) {
					perror("accept");
					continue;
				}

				//if you receive a connection from a client you'd likely spin it off on another 
				//thread we're doing very little here so we just execute on this one
				struct sockaddr_in* inaddr = (struct sockaddr_in*) &their_addr;
				char* s = inet_ntoa(inaddr->sin_addr); 

				wchar_t ws[255];
				MultiByteToWideChar(CP_UTF8, 0, s, -1, ws, 255);
				String^ clientIpAddress = ref new String(ws);//

				//tell the UI thread we got a connection
				callbackObject->ClientConnectedServer(clientIpAddress);

				//send the client some data
				if (send(clientConnectedSocket, "Server says hi!", 15, 0) == -1)
					perror("send");
				closesocket(clientConnectedSocket);
				clientConnectedSocket = NULL;
			}
				
			closesocket(listenSocket); 
			WSACleanup(); 

	   }));

    return;
}