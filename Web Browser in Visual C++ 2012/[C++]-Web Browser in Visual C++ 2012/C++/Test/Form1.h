#pragma once


namespace Test {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	void fail();

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
		
	
	public:
		Form1()
		{
			
			InitializeComponent();
			//
			//TODO: Add the constructor code here
//
			// textBox1->Text= "c:/"; 
		//		webBrowser1->Navigate("www.msn.com"); 
			//else	
			
textBox1->Text="english.cntv.cn/live";
textBox1->Update() ;

webBrowser1->Navigate(textBox1->Text);

textBox1->Text="";
//textBox1->SelectedText ="";

		//textBox1
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  button1;
	protected: 

	protected: 

	


	protected: 
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::WebBrowser^  webBrowser1;
	private: System::Windows::Forms::WebBrowser^  webBrowser2;



	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->webBrowser1 = (gcnew System::Windows::Forms::WebBrowser());
			this->webBrowser2 = (gcnew System::Windows::Forms::WebBrowser());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(480, 45);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(93, 20);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Clear";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(48, 46);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(399, 20);
			this->textBox1->TabIndex = 1;
			this->textBox1->TextChanged += gcnew System::EventHandler(this, &Form1::textBox1_TextChanged);
			// 
			// webBrowser1
			// 
			this->webBrowser1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->webBrowser1->Location = System::Drawing::Point(0, 0);
			this->webBrowser1->MinimumSize = System::Drawing::Size(20, 20);
			this->webBrowser1->Name = L"webBrowser1";
			this->webBrowser1->ScriptErrorsSuppressed = true;
			this->webBrowser1->Size = System::Drawing::Size(848, 407);
			this->webBrowser1->TabIndex = 2;
			this->webBrowser1->DocumentCompleted += gcnew System::Windows::Forms::WebBrowserDocumentCompletedEventHandler(this, &Form1::webBrowser1_DocumentCompleted_1);
			// 
			// webBrowser2
			// 
			this->webBrowser2->Location = System::Drawing::Point(655, 45);
			this->webBrowser2->MinimumSize = System::Drawing::Size(20, 20);
			this->webBrowser2->Name = L"webBrowser2";
			this->webBrowser2->ScriptErrorsSuppressed = true;
			this->webBrowser2->Size = System::Drawing::Size(20, 20);
			this->webBrowser2->TabIndex = 3;
			this->webBrowser2->Visible = false;
			this->webBrowser2->DocumentCompleted += gcnew System::Windows::Forms::WebBrowserDocumentCompletedEventHandler(this, &Form1::webBrowser2_DocumentCompleted);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(848, 407);
			this->Controls->Add(this->webBrowser2);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->webBrowser1);
			this->Name = L"Form1";
			this->Text = L"Web Browser";
			this->WindowState = System::Windows::Forms::FormWindowState::Maximized;
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				// On error goto errorhandler
				//private:
	//	button1(void)


	//__try	{
				 
				 webBrowser1->Navigate(textBox1->Text);

				 
			//	 webBrowser1->ActiveXInstance(textBox1->Text);
			//	 webBrowser1->OnDoubleClick->Navigating(textBox1->Refresh);   
				
				webBrowser1->Refresh ();
				textBox1->Text="";
			// textBox1->Text;

   
		//		fail(); }
   

   // __except will only catch an exception here
  // __except(EXCEPTION_EXECUTE_HANDLER)
	{   
   // if the exception was not caught by the catch(...) inside fail()
  //    cout << "An exception was caught in __except." << endl;
   }




//	private:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
//		~button1()
///		{
//			if (webBrowser1)
//			{
//				delete webBrowser1;
//			}
//		}
			 }
	private: System::Void textBox1_TextChanged(System::Object^  sender, System::EventArgs^  e) {
			  
				 webBrowser1->Navigate(textBox1->Text );
			   //	webBrowser1->Navigate(textBox1->Text)=webBrowser2->Navigate(textBox1->Text)  ; 
			 }
	private: System::Void webBrowser1_DocumentCompleted(System::Object^  sender, System::Windows::Forms::WebBrowserDocumentCompletedEventArgs^  e) {
		//ebBrowser1->Navigate (textBox1->Text);
			 }
	private: System::Void webBrowser1_DocumentCompleted_1(System::Object^  sender, System::Windows::Forms::WebBrowserDocumentCompletedEventArgs^  e) {
			//textBox1->Text="";
				// webBrowser1->Navigate(textBox1->Text)  ;
				 textBox1->Update(); 
			 }


private: System::Void webBrowser2_DocumentCompleted(System::Object^  sender, System::Windows::Forms::WebBrowserDocumentCompletedEventArgs^  e) {
		 }
};
	 
}

