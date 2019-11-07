// SIDCloner.h

#pragma once
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Security;

namespace WinTools {

	public ref class SidCloner
	{
	public:
		static void CloneSid(String^ sourceIdentity, String^ sourceDomain, String^ targetIdentity, String^ targetDomain);
		static void CloneSid(String^ sourceIdentity, String^ sourceDomain, String^ sourceDC, String^ targetIdentity, String^ targetDomain, String^ targetDC);
		static void CloneSid(String^ sourceIdentity, String^ sourceDomain, String^ sourceDC, String^ sourceUserName, SecureString^ sourcePassword, String^ targetIdentity, String^ targetDomain);
		static void CloneSid(String^ sourceIdentity, String^ sourceDomain, String^ sourceDC, String^ sourceUserName, SecureString^ sourcePassword, String^ targetIdentity, String^ targetDomain, String^ targetDC, String^ targetUserName, SecureString^ targetPassword);
	private:
		static void GetRpcCredentials(const wchar_t* pUserName, const wchar_t* pDomain, const wchar_t* pPassword, RPC_AUTH_IDENTITY_HANDLE* pHandle);
		static void GetDSHandle(const wchar_t* pDomain, const wchar_t* pDC, RPC_AUTH_IDENTITY_HANDLE *pIdentityHandle, HANDLE* pDSHandle);
		static void CloneSid(String^ sourceIdentity, String^ sourceDomain, String^ sourceDC, String^ sourceUserName, String^ sourceUserDomain, const wchar_t* pSourcePassword, String^ targetIdentity, String^ targetDomain, String^ targetDC, String^ targetUserName, String^ targetUserDomain, const wchar_t* pTargetPassword);
		static void CrackName(String^ userName, String^ *userPart, String^ *domainPart, String ^defaultDomain);
	};
}