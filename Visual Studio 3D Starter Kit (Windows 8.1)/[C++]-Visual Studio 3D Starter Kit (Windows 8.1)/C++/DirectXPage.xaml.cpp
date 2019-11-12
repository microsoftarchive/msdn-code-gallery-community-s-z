//
// DirectXPage.xaml.cpp
// Implementation of the DirectXPage class.
//

#include "pch.h"
#include "DirectXPage.xaml.h"
#include "StarterKitMain.h"

using namespace StarterKit;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::Graphics::Display;
using namespace Windows::System::Threading;
using namespace Windows::UI;
using namespace Windows::UI::Core;
using namespace Windows::UI::Input;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace concurrency;

DirectXPage::DirectXPage():
	m_windowVisible(true),
	m_hitCountCube(0),
	m_hitCountCylinder(0),
	m_hitCountCone(0),
	m_hitCountSphere(0),
	m_hitCountTeapot(0),
	m_colorIndex(0)
{
	InitializeComponent();

	// Initialize Starter Kit state.
	m_colors.push_back(Colors::Red);
	m_colors.push_back(Colors::Violet);
	m_colors.push_back(Colors::Indigo);
	m_colors.push_back(Colors::Blue);
	m_colors.push_back(Colors::Green);
	m_colors.push_back(Colors::Yellow);
	m_colors.push_back(Colors::Orange);
	
	// Register event handlers for page lifecycle.
	CoreWindow^ window = Window::Current->CoreWindow;

	window->VisibilityChanged +=
		ref new TypedEventHandler<CoreWindow^, VisibilityChangedEventArgs^>(this, &DirectXPage::OnVisibilityChanged);

	DisplayInformation^ currentDisplayInformation = DisplayInformation::GetForCurrentView();

	currentDisplayInformation->DpiChanged +=
		ref new TypedEventHandler<DisplayInformation^, Object^>(this, &DirectXPage::OnDpiChanged);

	currentDisplayInformation->OrientationChanged +=
		ref new TypedEventHandler<DisplayInformation^, Object^>(this, &DirectXPage::OnOrientationChanged);

	DisplayInformation::DisplayContentsInvalidated +=
		ref new TypedEventHandler<DisplayInformation^, Object^>(this, &DirectXPage::OnDisplayContentsInvalidated);

	swapChainPanel->CompositionScaleChanged += 
		ref new TypedEventHandler<SwapChainPanel^, Object^>(this, &DirectXPage::OnCompositionScaleChanged);

	swapChainPanel->SizeChanged +=
		ref new SizeChangedEventHandler(this, &DirectXPage::OnSwapChainPanelSizeChanged);

	// Disable all pointer visual feedback for better performance when touching.
	auto pointerVisualizationSettings = PointerVisualizationSettings::GetForCurrentView();
	pointerVisualizationSettings->IsContactFeedbackEnabled = false; 
	pointerVisualizationSettings->IsBarrelButtonFeedbackEnabled = false;

	// At this point we have access to the device. 
	// We can create the device-dependent resources.
	m_deviceResources = std::make_shared<DX::DeviceResources>();
	m_deviceResources->SetSwapChainPanel(swapChainPanel);

	m_main = std::unique_ptr<StarterKitMain>(new StarterKitMain(m_deviceResources));
	m_main->StartRenderLoop();
}

DirectXPage::~DirectXPage()
{
	// Stop rendering and processing events on destruction.
	m_main->StopRenderLoop();
}

// Called when the Previous Color app bar button is pressed.
void DirectXPage::OnPreviousColorPressed(Object^ sender, RoutedEventArgs^ e)
{
	m_colorIndex--;
	if (m_colorIndex <= 0)
	{
		m_colorIndex = m_colors.size() - 1;
	}
	ChangeObjectColor(L"Teapot_Node", m_colorIndex);
}

// Called when the Next Color app bar button is pressed.
void DirectXPage::OnNextColorPressed(Object^ sender, RoutedEventArgs^ e)
{
	m_colorIndex++;
	if (m_colorIndex >= m_colors.size())
		m_colorIndex = 0;

	ChangeObjectColor(L"Teapot_Node", m_colorIndex);
}

// Saves the current state of the app for suspend and terminate events.
void DirectXPage::SaveInternalState(IPropertySet^ state)
{
	critical_section::scoped_lock lock(m_main->GetCriticalSection());
	m_deviceResources->Trim();

	// Stop rendering when the app is suspended.
	m_main->StopRenderLoop();

	// Put code to save app state here.
}

// Loads the current state of the app for resume events.
void DirectXPage::LoadInternalState(IPropertySet^ state)
{
	// Put code to load app state here.

	// Start rendering when the app is resumed.
	m_main->StartRenderLoop();
}

// Called when the SwapChainPanel is tapped.
void DirectXPage::OnTapped(Object^ sender, TappedRoutedEventArgs^ e)
{
	auto currentPoint = e->GetPosition(nullptr);
	String^ objName = m_main->OnHitObject((int)currentPoint.X, (int)currentPoint.Y);
	if (objName != nullptr)
	{
		m_main->ToggleHitEffect(objName);

		if (objName->Equals(L"Cylinder_Node"))
		{
			this->HitCountCylinder->Text = (++m_hitCountCylinder).ToString();
		}
		else if (objName->Equals(L"Cube_Node"))
		{
			this->HitCountCube->Text = (++m_hitCountCube).ToString();
		}
		else if (objName->Equals(L"Sphere_Node"))
		{
			this->HitCountSphere->Text = (++m_hitCountSphere).ToString();
		}
		else if (objName->Equals(L"Cone_Node"))
		{
			this->HitCountCone->Text = (++m_hitCountCone).ToString();
		}
		else if (objName->Equals(L"Teapot_Node"))
		{
			this->HitCountTeapot->Text = (++m_hitCountTeapot).ToString();
		}
	}
}

// Helper method to change an object's color.
void DirectXPage::ChangeObjectColor(String^ objectName, int colorIndex)
{
	auto color = m_colors[colorIndex];
	m_main->ChangeMaterialColor(objectName, color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
}

// Window event handlers.

void DirectXPage::OnVisibilityChanged(CoreWindow^ sender, VisibilityChangedEventArgs^ args)
{
	m_windowVisible = args->Visible;
	if (m_windowVisible)
	{
		m_main->StartRenderLoop();
	}
	else
	{
		m_main->StopRenderLoop();
	}
}

// DisplayInformation event handlers.

void DirectXPage::OnDpiChanged(DisplayInformation^ sender, Object^ args)
{
	critical_section::scoped_lock lock(m_main->GetCriticalSection());
	m_deviceResources->SetDpi(sender->LogicalDpi);
	m_main->CreateWindowSizeDependentResources();
}

void DirectXPage::OnOrientationChanged(DisplayInformation^ sender, Object^ args)
{
	critical_section::scoped_lock lock(m_main->GetCriticalSection());
	m_deviceResources->SetCurrentOrientation(sender->CurrentOrientation);
	m_main->CreateWindowSizeDependentResources();
}

void DirectXPage::OnDisplayContentsInvalidated(DisplayInformation^ sender, Object^ args)
{
	critical_section::scoped_lock lock(m_main->GetCriticalSection());
	m_deviceResources->ValidateDevice();
}

void DirectXPage::OnCompositionScaleChanged(SwapChainPanel^ sender, Object^ args)
{
	critical_section::scoped_lock lock(m_main->GetCriticalSection());
	m_deviceResources->SetCompositionScale(sender->CompositionScaleX, sender->CompositionScaleY);
	m_main->CreateWindowSizeDependentResources();
}

void DirectXPage::OnSwapChainPanelSizeChanged(Object^ sender, SizeChangedEventArgs^ e)
{
	critical_section::scoped_lock lock(m_main->GetCriticalSection());
	m_deviceResources->SetLogicalSize(e->NewSize);
	m_main->CreateWindowSizeDependentResources();
}
