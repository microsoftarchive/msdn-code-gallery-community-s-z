#region Copyright © 2005 Noogen Technologies Inc.
// Author:
//	Tommy Noogen (tom@noogen.net)
//
// (C) 2005 Noogen Technologies Inc. (http://www.noogen.net)
// 
// MIT X.11 LICENSE
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
#endregion

using System;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

namespace Noogen.Validation
{
	/// <summary>
	/// Provide comparison of string data.  This class currently
	/// implement System.Web.UI.WebControls validation so that
	/// we don't have to write more codes.  Eventually, we may want
	/// to implement out own code.
	/// </summary>
	internal class ValidationUtil : BaseCompareValidator
	{
		/// <summary>
		/// Disable default ctor.
		/// </summary>
		private ValidationUtil(){}

		/// <summary>
		/// Compare two values using provided operator and data type.
		/// </summary>
		/// <param name="leftText"></param>
		/// <param name="rightText"></param>
		/// <param name="op"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public static bool CompareValues(string leftText, string rightText, ValidationCompareOperator op, ValidationDataType type)
		{
			System.Web.UI.WebControls.ValidationCompareOperator vco = 
				(System.Web.UI.WebControls.ValidationCompareOperator)Enum.Parse(
					typeof(System.Web.UI.WebControls.ValidationCompareOperator), 
					op.ToString());

			System.Web.UI.WebControls.ValidationDataType vdt = 
				(System.Web.UI.WebControls.ValidationDataType)Enum.Parse(
				typeof(System.Web.UI.WebControls.ValidationDataType), 
				type.ToString());

			return ValidationUtil.Compare(leftText, rightText, vco, vdt);
		}

		/// <summary>
		/// Utility method validation regular expression.
		/// </summary>
		/// <param name="valueText"></param>
		/// <param name="patternText"></param>
		/// <returns></returns>
		public static bool ValidateRegEx(string valueText, string patternText)
		{
			Match m = Regex.Match(valueText, patternText);
			return m.Success;
		}
		/// <summary>
		/// Here because base class required it.
		/// </summary>
		/// <returns></returns>
		protected override bool EvaluateIsValid()
		{
			return false;
		}

		#region "public static Xml Serializations"

		/// <summary>
		/// Get object from an xml string.
		/// </summary>
		/// <param name="xmlString"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public static object XmlStringToObject(string xmlString, System.Type type)
		{
			System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(type);
			TextReader r = null;
			object retObj = null;
			try 
			{
				r = new StringReader( xmlString );
				retObj = x.Deserialize(r);
			}
			finally
			{
				if (r != null)
					r.Close();
			}
			return retObj;
		}

		/// <summary>
		/// Write object to xml string.
		/// </summary>
		/// <param name="obj"></param>
		public static string ObjectToXmlString(object obj)
		{
			System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(obj.GetType());
			TextWriter w = null;
			string sReturn = string.Empty;

			try 
			{
				w = new StringWriter(); 
				x.Serialize(w, obj);
				sReturn = w.ToString();
			} 
			finally
			{
				if (w != null)
					w.Close();
			}

			return sReturn;
		}
		#endregion

		#region "public static FileToString"

		/// <summary>
		/// Load the entire text file into a string.
		/// </summary>
		/// <param name="sFile">Full pathname of file to read.</param>
		/// <returns>String content of the text file.</returns>
		public static string FileToString(string sFile)
		{
			string sText = string.Empty;
			using (StreamReader sr = new StreamReader(sFile))
			{
				sText = sr.ReadToEnd();
			}
			return sText;
		}

		/// <summary>
		/// Load the text file with specified size as return text.
		/// </summary>
		/// <param name="sFile">File to read from.</param>
		/// <param name="size">Number of char to read.</param>
		/// <returns></returns>
		public static string FileToString(string sFile, int size)
		{
			char[]  cToRead = new char[size];
			string sText = string.Empty;
			using(StreamReader sr = new StreamReader(sFile))
			{
				sr.Read(cToRead, 0, size);
				sText = new string(cToRead);
			}
			return sText;
		}
		#endregion

		#region "public static StringToFile"

		/// <summary>
		/// Save a string to file.
		/// </summary>
		/// <param name="strValue">String value to save.</param>
		/// <param name="strFileName">File name to save to.</param>
		/// <param name="bAppendToFile">True - to append string to file.  Default false - overwrite file.</param>
		public static void StringToFile(string strValue, string strFileName, bool bAppendToFile)
		{
			using(StreamWriter sw = new StreamWriter(strFileName, bAppendToFile))
			{
				sw.Write(strValue);
			}
		}

		/// <summary>
		/// Save a string to file.
		/// </summary>
		public static void StringToFile(string strValue, string strFileName)
		{
			StringToFile(strValue, strFileName, false);
		}
		#endregion

	}
}
