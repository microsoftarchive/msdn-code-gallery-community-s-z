using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TapiSample {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();

			tapi = new TAPI3Lib.TAPIClass();
			tapi.Initialize();
			foreach (TAPI3Lib.ITAddress ad in (tapi.Addresses as TAPI3Lib.ITCollection)) {
				cbLines.Items.Add(ad.AddressName);
			}

			tapi.EventFilter = (int)(TAPI3Lib.TAPI_EVENT.TE_CALLNOTIFICATION |
	TAPI3Lib.TAPI_EVENT.TE_CALLINFOCHANGE |
	TAPI3Lib.TAPI_EVENT.TE_DIGITEVENT |
	TAPI3Lib.TAPI_EVENT.TE_PHONEEVENT |
	TAPI3Lib.TAPI_EVENT.TE_CALLSTATE |
	TAPI3Lib.TAPI_EVENT.TE_GENERATEEVENT |
	TAPI3Lib.TAPI_EVENT.TE_GATHERDIGITS |
	TAPI3Lib.TAPI_EVENT.TE_REQUEST);
			tapi.ITTAPIEventNotification_Event_Event += new TAPI3Lib.ITTAPIEventNotification_EventEventHandler(tapi_ITTAPIEventNotification_Event_Event);
		}

		TAPI3Lib.TAPIClass tapi = null;
		TAPI3Lib.ITAddress line = null;
		int cn = 0;
		private void button1_Click(object sender, EventArgs e) {
			if (line != null) {
				line = null;
				if (cn != 0) tapi.UnregisterNotifications(cn);
			}
			foreach (TAPI3Lib.ITAddress ad in (tapi.Addresses as TAPI3Lib.ITCollection)) {
				if (ad.AddressName == cbLines.Text) {
					line = ad;
					break;
				}
			}
			if (line != null) {
				cn = tapi.RegisterCallNotifications(line, true, true, TAPI3Lib.TapiConstants.TAPIMEDIATYPE_AUDIO, 2);
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			if (cn != 0) tapi.UnregisterNotifications(cn);
		}

		delegate void AddLogDelegate(string text);
		private void AddLog(string text) {
			if (this.InvokeRequired) {
				this.Invoke(new AddLogDelegate(AddLog), new object[] { text });
			}
			listBox1.Items.Insert(0, text);
		}

		private void tapi_ITTAPIEventNotification_Event_Event(TAPI3Lib.TAPI_EVENT TapiEvent, object pEvent) {
			try {
				switch (TapiEvent) {
					case TAPI3Lib.TAPI_EVENT.TE_CALLNOTIFICATION:
						TAPI3Lib.ITCallNotificationEvent cn = pEvent as TAPI3Lib.ITCallNotificationEvent;
						if (cn.Call.CallState == TAPI3Lib.CALL_STATE.CS_OFFERING) {
							string c = cn.Call.get_CallInfoString(TAPI3Lib.CALLINFO_STRING.CIS_CALLERIDNUMBER);
							AddLog("Call Offering: " + c + " -> " + cn.Call.Address.DialableAddress);
						}
						break;
				}
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			if (line == null) return;
			TAPI3Lib.ITBasicCallControl bc = line.CreateCall(teNumber.Text, TAPI3Lib.TapiConstants.LINEADDRESSTYPE_PHONENUMBER, TAPI3Lib.TapiConstants.TAPIMEDIATYPE_AUDIO);
			bc.Connect(false);
		}

	}
}
