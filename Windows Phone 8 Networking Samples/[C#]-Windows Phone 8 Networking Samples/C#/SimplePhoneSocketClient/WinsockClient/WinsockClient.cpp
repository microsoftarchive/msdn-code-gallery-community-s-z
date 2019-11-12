// WinsockClient.cpp
#include "pch.h"
#include "WinsockClient.h"
#include "windows.h"

using namespace WinsockClient;
using namespace Platform;

CWinsockClient::CWinsockClient()
{
}

int CWinsockClient::ConnectThroughSocket(String^ hostForConn, String^* errMsg)
{
    int sockfd;  // socket to connect with
    char buf[MAXDATASIZE]; //receive buffer (unused for now)
    struct addrinfo hints, *servinfo, *p;  //socket setup
    int rv; //return value
	
	WSADATA wsaData; 
	
	//init Winsock
	if ((rv = WSAStartup(MAKEWORD(2,2), &wsaData)) != 0) {
		*errMsg = "WSAStartup error: %s", gai_strerror(rv);
        return 1;
    }

	//configure the host we're going to connect to
	auto host = hostForConn->Data();
	int size = hostForConn->Length() + 1;
	char* hostToConnect = new char[size];
	WideCharToMultiByte(CP_UTF8, 0, host, -1, hostToConnect, size, NULL, NULL);
    memset(&hints, 0, sizeof hints);
    hints.ai_family = AF_UNSPEC;
    hints.ai_socktype = SOCK_STREAM;

	//get adapters
    if ((rv = getaddrinfo((PCSTR)hostToConnect, PORT, &hints, &servinfo)) != 0) {
		*errMsg = "getaddrinfo: %s\n", gai_strerror(rv);
		delete[] hostToConnect;
        return 1;
    }

    // loop through all our adapters and connect to our target through the first we can
    for(p = servinfo; p != NULL; p = p->ai_next) {
        if ((sockfd = socket(p->ai_family, p->ai_socktype,
                p->ai_protocol)) == -1) {
            *errMsg = "client: socket";
            continue;
        }

		//Connect
        if ((rv = connect(sockfd, p->ai_addr, p->ai_addrlen)) == -1) {
			int err = WSAGetLastError();
            closesocket(sockfd);
            *errMsg = "client: connect";
            continue;
        } 
		break;
    }

    if (p == NULL) {
		*errMsg = "client: failed to connect";
		delete[] hostToConnect;
        return 2;
    }

	//free servinfo struct
    freeaddrinfo(servinfo); 

  //Send or Receive data from the opened socket...
  //  if ((numbytes = recv(sockfd, buf, MAXDATASIZE-1, 0)) == -1) {
		//*errMsg = "recv error";
		//delete[] hostToConnect;
  //      return -1; //exit(1);
  //  }
  //...

    closesocket(sockfd);

	//delete the character array holding our target listener
	delete[] hostToConnect;
    return 0;
}