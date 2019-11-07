using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading; 
using System.IO;
namespace winforCongitiveTexttoSpeech
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// This method is called once the audio returned from the service.
		/// It will then attempt to play that audio file.
		/// Note that the playback will fail if the output audio format is not pcm encoded.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="args">The <see cref="GenericEventArgs{Stream}"/> instance containing the event data.</param>
		/// 
		// readStream is the stream you need to read
		// writeStream is the stream you want to write to
 
		private  void PlayAudio(object sender, GenericEventArgs<Stream> args)
		{ 
			Stream readStream = args.EventData;
			 
			try
			{
				string saveTo = Path.GetDirectoryName(Application.ExecutablePath) + @"\SaveMP3File";  //Folder to Save
				if (!Directory.Exists(saveTo))
				{
					Directory.CreateDirectory(saveTo);
				}
				string filename = saveTo + @"\Shanu" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp3"; //Save the speech as mp3 file in root folder

				FileStream writeStream = File.Create(filename);

				int Length = 256;
				Byte[] buffer = new Byte[Length];
				int bytestoRead = readStream.Read(buffer, 0, Length);
				// write the required bytes
				while (bytestoRead > 0)
				{
					writeStream.Write(buffer, 0, bytestoRead);
					bytestoRead = readStream.Read(buffer, 0, Length);
				}

				readStream.Close();
				writeStream.Close();
				SoundPlayer player = new System.Media.SoundPlayer(filename);
				player.PlaySync();
				 
			}
			catch (Exception EX)
			{
				txtstatus.Text = EX.Message;
			}
			args.EventData.Dispose();

			
		}

		/// <summary>
		/// Handler an error when a TTS request failed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="GenericEventArgs{Exception}"/> instance containing the event data.</param>
		private  void ErrorHandler(object sender, GenericEventArgs<Exception> e)
		{
			txtstatus.Text= "Unable to complete the TTS request: [{0}]" + e.ToString();
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			cboLocale.SelectedIndex = 0;
			cboServiceName.SelectedIndex = 0;

			 

		}

		private void btnSpeak_Click(object sender, EventArgs e)
		{
			txtstatus.Text = "Starting Authtentication";
			string accessToken;

			// Note: The way to get api key:
			// Free: https://www.microsoft.com/cognitive-services/en-us/subscriptions?productId=/products/Bing.Speech.Preview
			// Paid: https://portal.azure.com/#create/Microsoft.CognitiveServices/apitype/Bing.Speech/pricingtier/S0
			Authentication auth = new Authentication("AddYourAPIKEYHere");

			try
			{
				accessToken = auth.GetAccessToken();
				txtstatus.Text = "Token: {0} " + accessToken;
			}
			catch (Exception ex)
			{
				txtstatus.Text = "Failed authentication.";
				
				txtstatus.Text = ex.Message;
				return;
			}

			txtstatus.Text = "Starting TTSSample request code execution.";

			string requestUri = "https://speech.platform.bing.com/synthesize";

			var cortana = new Synthesize();

			cortana.OnAudioAvailable += PlayAudio;
			cortana.OnError += ErrorHandler;

			// Reuse Synthesize object to minimize latency
			cortana.Speak(CancellationToken.None, new Synthesize.InputOptions()
			{
				RequestUri = new Uri(requestUri),
				// Text to be spoken.
				Text = txtSpeak.Text,
				VoiceType = Gender.Female,
				// Refer to the documentation for complete list of supported locales.
				Locale = cboLocale.SelectedItem.ToString(), //"en-US",

				// You can also customize the output voice. Refer to the documentation to view the different
				// voices that the TTS service can output.
				VoiceName = cboServiceName.SelectedItem.ToString(), //"Microsoft Server Speech Text to Speech Voice (en-US, ZiraRUS)",
															   // Service can return audio in different output format.
				OutputFormat = AudioOutputFormat.Riff16Khz16BitMonoPcm,
				AuthorizationToken = "Bearer " + accessToken,
			}).Wait();
		}

		private void cboLocale_SelectedIndexChanged(object sender, EventArgs e)
		{
			cboServiceName.SelectedIndex = cboLocale.SelectedIndex;
		}

		private void cboServiceName_SelectedIndexChanged(object sender, EventArgs e)
		{
			cboLocale.SelectedIndex = cboServiceName.SelectedIndex;
		}
	}
}
