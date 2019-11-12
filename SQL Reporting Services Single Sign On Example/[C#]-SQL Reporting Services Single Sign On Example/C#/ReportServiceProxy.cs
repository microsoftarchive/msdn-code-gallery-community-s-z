using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Web;
using System.Net;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.Security;
using System.Xml;
using System.Globalization;

using System.Diagnostics;

using Sample.ReportingServices.Security.ReportService2010;

namespace Sample.ReportingServices.Security {
	// Because the UILogon uses the Web service to connect to the report server
	// you need to extend the server proxy to support authentication ticket
	// (cookie) management
	public class ReportServerProxy : ReportingService2010 {

		protected override WebRequest GetWebRequest(Uri uri) {
			HttpWebRequest request;
			request = (HttpWebRequest)HttpWebRequest.Create( uri );
			// Create a cookie jar to hold the request cookie
			CookieContainer cookieJar = new CookieContainer();
			request.CookieContainer = cookieJar;
			Cookie authCookie = AuthCookie;
			// if the client already has an auth cookie
			// place it in the request's cookie container
			if ( authCookie != null ) {
				request.CookieContainer.Add( authCookie );
			}
			request.Timeout = -1;
			request.Headers.Add( "Accept-Language", HttpContext.Current.Request.Headers["Accept-Language"] );
			if ( HttpContext.Current.Request.Headers["AuthToken"] != null ) {
				request.Headers.Add( "AuthToken", HttpContext.Current.Request.Headers["AuthToken"] );
			}
			if ( HttpContext.Current.Request.Headers["UserToken"] != null ) {
				request.Headers.Add( "UserToken", HttpContext.Current.Request.Headers["UserToken"] );
			}
			return request;
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes" )]
		protected override WebResponse GetWebResponse(WebRequest request) {
			WebResponse response = base.GetWebResponse( request );
			string cookieName = response.Headers["RSAuthenticationHeader"];
			// If the response contains an auth header, store the cookie
			if ( cookieName != null ) {
				
                Utilities.CustomAuthCookieName = cookieName;
				HttpWebResponse webResponse = (HttpWebResponse)response;
				Cookie authCookie = webResponse.Cookies[cookieName];
				// If the auth cookie is null, throw an exception
				if ( authCookie == null ) {
					throw new Exception( "Authorization ticket not received by LogonUser" );
				}
				// otherwise save it for this request
				AuthCookie = authCookie;
				// and send it to the client
				Utilities.RelayCookieToClient( authCookie );
			}
			return response;
		}

		private Cookie AuthCookie {
			get {
				if ( m_Authcookie == null && HttpContext.Current != null && HttpContext.Current.Request != null )
					m_Authcookie = Utilities.TranslateCookie(HttpContext.Current.Request.Cookies[Utilities.CustomAuthCookieName] );
				return m_Authcookie;
			}
			set {
				m_Authcookie = value;
			}
		}
		private Cookie m_Authcookie = null;
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses" )]
	internal sealed class Utilities {
		internal static string CustomAuthCookieName {
			get {
				lock ( m_cookieNamelockRoot ) {
					return m_cookieName;
				}
			}
			set {
				lock ( m_cookieNamelockRoot ) {
					m_cookieName = value;
				}
			}
		}
		private static string m_cookieName;
		private static object m_cookieNamelockRoot = new object();

		private static HttpCookie TranslateCookie(Cookie netCookie) {
			if ( netCookie == null )
				return null;
			HttpCookie webCookie = new HttpCookie( netCookie.Name, netCookie.Value );
			// Add domain only if it is dotted - IE doesn't send back the cookie 
			// if we set the domain otherwise
			if ( netCookie.Domain.IndexOf( '.' ) != -1 ) {
				webCookie.Domain = netCookie.Domain;
			}
			webCookie.Expires = netCookie.Expires;
			webCookie.Path = netCookie.Path;
			webCookie.Secure = netCookie.Secure;
			return webCookie;
		}

		internal static Cookie TranslateCookie(HttpCookie webCookie) {
			if ( webCookie == null )
				return null;
			Cookie netCookie = new Cookie( webCookie.Name, webCookie.Value );
			if ( webCookie.Domain == null ) {
				netCookie.Domain = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
			}
			netCookie.Expires = webCookie.Expires;
			netCookie.Path = webCookie.Path;
			netCookie.Secure = webCookie.Secure;
			return netCookie;
		}

		internal static void RelayCookieToClient(Cookie cookie) {
			// add the cookie if not already in there
			if ( HttpContext.Current.Response.Cookies[cookie.Name] == null ) {
				HttpContext.Current.Response.Cookies.Remove( cookie.Name );
			}

			HttpContext.Current.Response.SetCookie( TranslateCookie( cookie ) );
		}
	}
}
