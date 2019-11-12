#pragma once

namespace timer2 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Media;

	//global counters to count destroyed ships and number of shots
	int ShipsDestroyed = 0;
	int Shots = 0;
	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:

		Form1(void)
		{
			InitializeComponent();

			//
			//TODO: Add the constructor code here
			//
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

	
	private: System::Windows::Forms::Label^  label1;
	protected: 
	private: System::Windows::Forms::Timer^  timer1;
	private: System::Windows::Forms::PictureBox^  canonBall;
	private: System::Windows::Forms::PictureBox^  canon;
	private: System::Windows::Forms::PictureBox^  explosion;



	private: System::ComponentModel::BackgroundWorker^  backgroundWorker1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::PictureBox^  pictureBox4;
	private: System::Windows::Forms::PictureBox^  ship;

	private: System::Windows::Forms::Timer^  timer2;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Label^  label5;



	private: System::ComponentModel::IContainer^  components;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->canonBall = (gcnew System::Windows::Forms::PictureBox());
			this->canon = (gcnew System::Windows::Forms::PictureBox());
			this->explosion = (gcnew System::Windows::Forms::PictureBox());
			this->backgroundWorker1 = (gcnew System::ComponentModel::BackgroundWorker());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->pictureBox4 = (gcnew System::Windows::Forms::PictureBox());
			this->ship = (gcnew System::Windows::Forms::PictureBox());
			this->timer2 = (gcnew System::Windows::Forms::Timer(this->components));
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->canonBall))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->canon))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->explosion))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox4))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->ship))->BeginInit();
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(59, 50);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(0, 13);
			this->label1->TabIndex = 0;
			// 
			// timer1
			// 
			this->timer1->Tick += gcnew System::EventHandler(this, &Form1::Timer_Tik);
			// 
			// canonBall
			// 
			this->canonBall->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"canonBall.Image")));
			this->canonBall->Location = System::Drawing::Point(140, 102);
			this->canonBall->Name = L"canonBall";
			this->canonBall->Size = System::Drawing::Size(100, 20);
			this->canonBall->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->canonBall->TabIndex = 1;
			this->canonBall->TabStop = false;
			this->canonBall->LocationChanged += gcnew System::EventHandler(this, &Form1::canonBall_LocationChanged);
			// 
			// canon
			// 
			this->canon->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"canon.Image")));
			this->canon->Location = System::Drawing::Point(31, 90);
			this->canon->Name = L"canon";
			this->canon->Size = System::Drawing::Size(209, 139);
			this->canon->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->canon->TabIndex = 2;
			this->canon->TabStop = false;
			// 
			// explosion
			// 
			this->explosion->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"explosion.Image")));
			this->explosion->Location = System::Drawing::Point(700, 42);
			this->explosion->Name = L"explosion";
			this->explosion->Size = System::Drawing::Size(217, 208);
			this->explosion->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->explosion->TabIndex = 3;
			this->explosion->TabStop = false;
			this->explosion->Visible = false;
			// 
			// backgroundWorker1
			// 
			this->backgroundWorker1->DoWork += gcnew System::ComponentModel::DoWorkEventHandler(this, &Form1::backgroundWorker1_DoWork_1);
			// 
			// button1
			// 
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 14.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->button1->Location = System::Drawing::Point(450, 270);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 41);
			this->button1->TabIndex = 4;
			this->button1->Text = L"Fire!!!";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// pictureBox4
			// 
			this->pictureBox4->Dock = System::Windows::Forms::DockStyle::Fill;
			this->pictureBox4->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox4.Image")));
			this->pictureBox4->Location = System::Drawing::Point(0, 0);
			this->pictureBox4->Name = L"pictureBox4";
			this->pictureBox4->Size = System::Drawing::Size(958, 333);
			this->pictureBox4->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->pictureBox4->TabIndex = 5;
			this->pictureBox4->TabStop = false;
			// 
			// ship
			// 
			this->ship->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"ship.Image")));
			this->ship->Location = System::Drawing::Point(720, 42);
			this->ship->Name = L"ship";
			this->ship->Size = System::Drawing::Size(214, 155);
			this->ship->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->ship->TabIndex = 6;
			this->ship->TabStop = false;
			// 
			// timer2
			// 
			this->timer2->Enabled = true;
			this->timer2->Tick += gcnew System::EventHandler(this, &Form1::timer2_Tick);
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->BackColor = System::Drawing::Color::White;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label2->Location = System::Drawing::Point(41, 50);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(130, 20);
			this->label2->TabIndex = 7;
			this->label2->Text = L"Ships Destroyed:";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->BackColor = System::Drawing::Color::White;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 18, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label3->Location = System::Drawing::Point(177, 50);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(0, 29);
			this->label3->TabIndex = 8;
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->BackColor = System::Drawing::Color::White;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label4->Location = System::Drawing::Point(103, 9);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(68, 20);
			this->label4->TabIndex = 9;
			this->label4->Text = L"Shots #:";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->BackColor = System::Drawing::Color::White;
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 18, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label5->Location = System::Drawing::Point(177, 9);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(0, 29);
			this->label5->TabIndex = 10;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(958, 333);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->ship);
			this->Controls->Add(this->explosion);
			this->Controls->Add(this->canon);
			this->Controls->Add(this->canonBall);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->pictureBox4);
			this->Name = L"Form1";
			this->Text = L"Ship Destroyer by Yegor Isakov LTD";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->canonBall))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->canon))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->explosion))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox4))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->ship))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion


	// cycle of ship cruises  controlled by Timer2	 
	private: System::Void timer2_Tick(System::Object^  sender, System::EventArgs^  e) {
				 
				 explosion->Left -=5;
				 ship->Left -=5;

				 // as ship come too close ship movement reset 
				 if (explosion->Location == Point(320, 42))
				 {timer2->Enabled = false;
				 explosion->Location = Point(720, 42); 
				 explosion->Visible = false;
				 ship->Visible = true; 
				 ship->Location = Point(700, 42); 
				 timer2->Enabled = true;}
		 }	 

	
			 // canon set up  
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 ship->Visible = true;
				 explosion->Visible = false;
				 canonBall->Location = Point(220, 102);
				 timer1->Enabled = true;
				 Shots = Shots +1;
				 label5->Text =System::Convert::ToString(Shots);
		 }
			 // canon fire controled by Timer 1
	private: System::Void Timer_Tik(System::Object^  sender, System::EventArgs^  e) {
				 
				 canonBall->Left +=50;
				
			}
			 
	private: System::Void canonBall_LocationChanged(System::Object^  sender, System::EventArgs^  e) {
				
				 if ((canonBall->Location == Point(320, 102)||
					 canonBall->Location == Point(420, 102)||
					 canonBall->Location == Point(520, 102)) && 
					 (explosion->Location == Point(320, 42)||
					 explosion->Location == Point(325, 42)|| 
					 explosion->Location == Point(330, 42)||
					 explosion->Location == Point(420, 42)||
					 explosion->Location == Point(425, 42)|| 
					 explosion->Location == Point(520, 42)||
					 explosion->Location == Point(525, 42)||
					 explosion->Location == Point(530, 42)||
					 explosion->Location == Point(650, 42)))
				 {
					 backgroundWorker1->RunWorkerAsync();
				 timer1->Enabled = false; 
				 timer2->Enabled = false;
				 explosion->Visible = true;
				 ship->Visible = false;
				 timer2->Enabled = true;
				 ShipsDestroyed =  ShipsDestroyed +1;
				 label3->Text =System::Convert::ToString(ShipsDestroyed);
				 }

				 
			 }


			 	
//background worker to play sound		 

private: System::Void backgroundWorker1_DoWork_1(System::Object^  sender, System::ComponentModel::DoWorkEventArgs^  e) {
		SoundPlayer^ player = gcnew SoundPlayer();
		player->SoundLocation = "c:\\windows\\media\\tada.wav";
			//"c:\\Users\\yegoris\\Desktop\\bomb.waw";
		player->Load();
		player->PlaySync();
		} 

};
}


