//
// DirectXPage.xaml.h
// Declaration of the DirectXPage class.
//

#pragma once

#include "DirectXPage.g.h"

#include "Common\DeviceResources.h"

namespace StarterKit
{
	// Forward declaration
	class StarterKitMain;

	/// <summary>
	/// A page that hosts a DirectX SwapChainPanel.
	/// </summary>
	public ref class DirectXPage sealed
	{
	public:
		DirectXPage();
		virtual ~DirectXPage();

		// Event handlers for the app bar buttons.
		void OnPreviousColorPressed(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
		void OnNextColorPressed(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);

		void SaveInternalState(Windows::Foundation::Collections::IPropertySet^ state);
		void LoadInternalState(Windows::Foundation::Collections::IPropertySet^ state);

	private:
		// Called when the SwapChainPanel is tapped.
		void OnTapped(Platform::Object^ sender, Windows::UI::Xaml::Input::TappedRoutedEventArgs^ e);

		// Helper method to change an object's color.
		void ChangeObjectColor(Platform::String^ objectName, int colorIndex);

		// Used to keep count of clicks in the various objects in our scene.
		int m_hitCountCube;
		int m_hitCountSphere;
		int m_hitCountCone;
		int m_hitCountCylinder;
		int m_hitCountTeapot;

		// Used to keep track of the teapot color (change with the app bar button).
		std::vector<Windows::UI::Color>::size_type m_colorIndex;
		std::vector<Windows::UI::Color> m_colors;

		// ----- Members below come with the default DirectX (XAML) template. ----------------------------------------------

		// XAML low-level rendering event handler.
		void OnRendering(Platform::Object^ sender, Platform::Object^ args);

		// Window event handlers.
		void OnVisibilityChanged(Windows::UI::Core::CoreWindow^ sender, Windows::UI::Core::VisibilityChangedEventArgs^ args);

		// DisplayInformation event handlers.
		void OnDpiChanged(Windows::Graphics::Display::DisplayInformation^ sender, Platform::Object^ args);
		void OnOrientationChanged(Windows::Graphics::Display::DisplayInformation^ sender, Platform::Object^ args);
		void OnDisplayContentsInvalidated(Windows::Graphics::Display::DisplayInformation^ sender, Platform::Object^ args);

		// Other event handlers.
		void OnCompositionScaleChanged(Windows::UI::Xaml::Controls::SwapChainPanel^ sender, Object^ args);
		void OnSwapChainPanelSizeChanged(Platform::Object^ sender, Windows::UI::Xaml::SizeChangedEventArgs^ e);

		// Resources used to render the DirectX content in the XAML page background.
		std::shared_ptr<DX::DeviceResources> m_deviceResources;
		std::unique_ptr<StarterKitMain> m_main; 
		bool m_windowVisible;
	};
}

