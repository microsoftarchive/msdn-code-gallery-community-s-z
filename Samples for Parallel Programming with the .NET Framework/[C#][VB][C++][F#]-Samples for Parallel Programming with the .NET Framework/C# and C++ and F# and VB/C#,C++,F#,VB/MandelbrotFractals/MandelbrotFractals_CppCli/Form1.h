//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Form1.h
//
//--------------------------------------------------------------------------

#pragma once

#include "MandelbrotPosition.h"
#include "MandelbrotGenerator.h"

namespace MandelbrotFractals {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Drawing;
	using namespace System::Diagnostics;
	using namespace System::Threading;
	using namespace System::Threading::Tasks;

	public ref class Form1 : public System::Windows::Forms::Form
	{
	private: 
		MandelbrotPosition _mandelbrotWindow;
		System::Drawing::Size _lastWindowSize;
		Point _lastMousePosition;
		DateTime _lastUpdateTime;
		bool _leftMouseDown;
		String^ _formTitle;
		TaskScheduler^ _uiScheduler;
		CancellationTokenSource^ _lastCancellation;
	private: System::Windows::Forms::StatusStrip^  statusStrip1;
	private: System::Windows::Forms::ToolStripStatusLabel^  toolStripStatusLabel1;
			 bool _parallelRendering;

	public:
		Form1(void)
		{
			InitializeComponent();

			_mandelbrotWindow = MandelbrotPosition::Default;
			_lastWindowSize = System::Drawing::Size::Empty;
			_lastUpdateTime = _lastUpdateTime = DateTime::MinValue;
			_leftMouseDown = false;
			_formTitle = "Mandelbrot Fractal ({0}x) - Time: {1}";
			_parallelRendering = false;
			_uiScheduler = TaskScheduler::FromCurrentSynchronizationContext();
		}

	protected:
		~Form1()
		{
			if (components) delete components;
		}

	private: 
		System::Windows::Forms::PictureBox^  mandelbrotPb;

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
			this->mandelbrotPb = (gcnew System::Windows::Forms::PictureBox());
			this->statusStrip1 = (gcnew System::Windows::Forms::StatusStrip());
			this->toolStripStatusLabel1 = (gcnew System::Windows::Forms::ToolStripStatusLabel());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->mandelbrotPb))->BeginInit();
			this->statusStrip1->SuspendLayout();
			this->SuspendLayout();
			// 
			// mandelbrotPb
			// 
			this->mandelbrotPb->BackColor = System::Drawing::Color::Black;
			this->mandelbrotPb->Dock = System::Windows::Forms::DockStyle::Fill;
			this->mandelbrotPb->Location = System::Drawing::Point(0, 0);
			this->mandelbrotPb->Name = L"mandelbrotPb";
			this->mandelbrotPb->Size = System::Drawing::Size(400, 384);
			this->mandelbrotPb->SizeMode = System::Windows::Forms::PictureBoxSizeMode::CenterImage;
			this->mandelbrotPb->TabIndex = 0;
			this->mandelbrotPb->TabStop = false;
			this->mandelbrotPb->VisibleChanged += gcnew System::EventHandler(this, &Form1::mandelbrotPb_VisibleChanged);
			this->mandelbrotPb->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::mandelbrotPb_MouseMove);
			this->mandelbrotPb->MouseDoubleClick += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::mandelbrotPb_MouseDoubleClick);
			this->mandelbrotPb->Resize += gcnew System::EventHandler(this, &Form1::mandelbrotPb_Resize);
			this->mandelbrotPb->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::mandelbrotPb_MouseDown);
			this->mandelbrotPb->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::mandelbrotPb_MouseUp);
			// 
			// statusStrip1
			// 
			this->statusStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) {this->toolStripStatusLabel1});
			this->statusStrip1->Location = System::Drawing::Point(0, 362);
			this->statusStrip1->Name = L"statusStrip1";
			this->statusStrip1->Size = System::Drawing::Size(400, 22);
			this->statusStrip1->TabIndex = 1;
			this->statusStrip1->Text = L"statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this->toolStripStatusLabel1->Name = L"toolStripStatusLabel1";
			this->toolStripStatusLabel1->Size = System::Drawing::Size(307, 17);
			this->toolStripStatusLabel1->Text = L"P: parallel mode, S: sequential mode, Double-click: zoom";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(400, 384);
			this->Controls->Add(this->statusStrip1);
			this->Controls->Add(this->mandelbrotPb);
			this->KeyPreview = true;
			this->Name = L"Form1";
			this->Text = L"Mandelbrot Fractals";
			this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &Form1::Form1_KeyDown);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->mandelbrotPb))->EndInit();
			this->statusStrip1->ResumeLayout(false);
			this->statusStrip1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	private:

		System::Void Form1_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) 
		{
			// Switch to sequential or parallel based on the key pressed
			if (e->KeyCode == Keys::S)
            {
                _parallelRendering = false;
                UpdateImageAsync();
            }
			else if (e->KeyCode == Keys::P)
            {
                _parallelRendering = true;
                UpdateImageAsync();
            }
		}

		System::Void mandelbrotPb_MouseDoubleClick(System::Object^  sender, MouseEventArgs^  e)
		{
			// Center the image on the selected location
			_mandelbrotWindow.CenterX += ((e->X - (mandelbrotPb->Width / 2.0)) / mandelbrotPb->Width) * _mandelbrotWindow.Width;
			_mandelbrotWindow.CenterY += ((e->Y - (mandelbrotPb->Height / 2.0)) / mandelbrotPb->Height) * _mandelbrotWindow.Height;

			// If the left mouse button was used, zoom in by a factor of 2; if the right mouse button, zoom
			// out by a factor of 2
			double factor = e->Button == System::Windows::Forms::MouseButtons::Left ? .5 : 2;
			_mandelbrotWindow.Width *= factor;
			_mandelbrotWindow.Height *= factor;

			// Update the image
			UpdateImageAsync();
		}

		System::Void mandelbrotPb_VisibleChanged(System::Object^  sender, System::EventArgs^  e) 
		{
			// When the picture box becomes visible, render it
			if (mandelbrotPb->Visible)
			{
				_lastWindowSize = Size;
				UpdateImageAsync();
			}
		}

		System::Void mandelbrotPb_Resize(System::Object^  sender, System::EventArgs^  e) 
		{
			// If the window has been resized
			System::Drawing::Size currentSize = this->Size;
			if (currentSize != _lastWindowSize)
			{
				// Scale the mandelbrot image by the same factor so that its visual size doesn't change
				double xFactor = currentSize.Width / (double)_lastWindowSize.Width, yFactor = currentSize.Height / (double)_lastWindowSize.Height;
				_mandelbrotWindow.Width *= xFactor;
				_mandelbrotWindow.Height *= yFactor;

				// Record the new window size
				_lastWindowSize = currentSize;

				// Update the image
				UpdateImageAsync();
			}
		}

		System::Void mandelbrotPb_MouseMove(System::Object^  sender, MouseEventArgs^  e) 
		{
			// Determine how far the mouse has moved.  If it moved at all...
			Point delta(e->X - _lastMousePosition.X, e->Y - _lastMousePosition.Y);
			if (delta != Point::Empty)
			{
				// And if the left mouse button is down...
				if (_leftMouseDown)
				{
					// Determine how much the mouse moved in fractal coordinates
					double fractalMoveX = delta.X * _mandelbrotWindow.Width / mandelbrotPb->Width;
					double fractalMoveY = delta.Y * _mandelbrotWindow.Height / mandelbrotPb->Height;

					// Shift the fractal window accordingly
					_mandelbrotWindow.CenterX -= fractalMoveX;
					_mandelbrotWindow.CenterY -= fractalMoveY;

					// And update the image
					UpdateImageAsync();
				}
				// Record the new mouse position
				_lastMousePosition = e->Location;
			}
		}

		System::Void mandelbrotPb_MouseDown(System::Object^  sender, MouseEventArgs^  e) 
		{
			// Record that mouse button is being pressed
			if (e->Button == System::Windows::Forms::MouseButtons::Left)
			{
				_lastMousePosition = e->Location;
				_leftMouseDown = true;
			}
		}

		System::Void mandelbrotPb_MouseUp(System::Object^  sender, MouseEventArgs^  e) 
		{
			// Record that the mouse button is being released
			if (e->Button == System::Windows::Forms::MouseButtons::Left)
			{
				_lastMousePosition = e->Location;
				_leftMouseDown = false;
			}
		}

		ref class UpdateImageData
		{
		public:
			System::Drawing::Size RenderSize;
			DateTime TimeOfRequest;
			MandelbrotPosition MandelbrotWindow;
			bool Parallel;
			Bitmap^ Result;
			TimeSpan ElapsedTime;
			CancellationToken CancellationToken;
		};

		void Render(Object^ state)
		{
			UpdateImageData^ uid = (UpdateImageData^)state;
			Stopwatch^ sw = Stopwatch::StartNew();
			Bitmap^ bmp = MandelbrotGenerator::Create(
				uid->MandelbrotWindow, uid->RenderSize.Width, uid->RenderSize.Height, uid->CancellationToken, uid->Parallel);
			if (bmp != nullptr)
			{
				uid->Result = bmp;
				uid->ElapsedTime = sw->Elapsed;
				Task::Factory->StartNew(
					gcnew Action<Object^>(this, &Form1::CompleteRenderOnUIThread), uid,
					CancellationToken::None,
					TaskCreationOptions::None, _uiScheduler);
			}
		}

		void CompleteRenderOnUIThread(Object^ state)
		{
			UpdateImageData^ uid = (UpdateImageData^)state;
			if (uid->TimeOfRequest > _lastUpdateTime)
			{
				Image^ old = mandelbrotPb->Image;
				mandelbrotPb->Image = uid->Result;
				if (old != nullptr) delete old;

				_lastUpdateTime = uid->TimeOfRequest;
				this->Text = String::Format(_formTitle, 
					(Object^)(uid->Parallel ? Environment::ProcessorCount : 1), 
					(Object^)(uid->ElapsedTime.ToString()));
			}
			else delete uid->Result;
		}

		void UpdateImageAsync()
		{
			if (_lastCancellation != nullptr) _lastCancellation->Cancel();
			_lastCancellation = gcnew CancellationTokenSource();

			UpdateImageData^ uid = gcnew UpdateImageData();
			uid->Parallel = _parallelRendering;
			uid->MandelbrotWindow = _mandelbrotWindow;
			uid->TimeOfRequest = DateTime::UtcNow;
			uid->RenderSize = mandelbrotPb->Size;
			uid->CancellationToken = _lastCancellation->Token;

			Task::Factory->StartNew(gcnew Action<Object^>(this, &Form1::Render), uid, uid->CancellationToken);
		}
	};
}