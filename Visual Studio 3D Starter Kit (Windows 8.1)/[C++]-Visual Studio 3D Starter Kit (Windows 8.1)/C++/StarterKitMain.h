// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

#include "Common\StepTimer.h"
#include "Common\DeviceResources.h"
#include "Content\SampleFpsTextRenderer.h"
#include "Game.h"

// Renders Direct2D and 3D content on the screen.
namespace StarterKit
{
	class StarterKitMain : public DX::IDeviceNotify
	{
	public:
		StarterKitMain(const std::shared_ptr<DX::DeviceResources>& deviceResources);
		~StarterKitMain();

		// Public methods passed straight to the Game renderer.
		Platform::String^ OnHitObject(int x, int y) { return m_sceneRenderer->OnHitObject(x, y); }
		void ToggleHitEffect(Platform::String^ object) { m_sceneRenderer->ToggleHitEffect(object); }
		void ChangeMaterialColor(Platform::String^ object, float r, float g, float b) { m_sceneRenderer->ChangeMaterialColor(object, r, g, b); }

		void CreateWindowSizeDependentResources();
		void StartRenderLoop();
		void StopRenderLoop();
		Concurrency::critical_section& GetCriticalSection() { return m_criticalSection; }

		// IDeviceNotify
		virtual void OnDeviceLost();
		virtual void OnDeviceRestored();

	private:
		void Update();
		bool Render();

		// Cached pointer to device resources.
		std::shared_ptr<DX::DeviceResources> m_deviceResources;

		// TODO: Replace with your own content renderers.
		std::unique_ptr<Game> m_sceneRenderer;
		std::unique_ptr<SampleFpsTextRenderer> m_fpsTextRenderer;

		Windows::Foundation::IAsyncAction^ m_renderLoopWorker;
		Concurrency::critical_section m_criticalSection;

		// Rendering loop timer.
		DX::StepTimer m_timer;
	};
}