// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

#include <memory>
#include <vector>

#include "VSD3DStarter.h"
#include "Animation\Animation.h"

#include "..\Common\DeviceResources.h"
#include "..\Common\StepTimer.h"

namespace StarterKit
{
	class Game
	{
	public:
		Game(const std::shared_ptr<DX::DeviceResources>& deviceResources);
		void CreateDeviceDependentResources();
		void CreateWindowSizeDependentResources();
		void ReleaseDeviceDependentResources();
		void Update(DX::StepTimer const& timer);
		void Render();

		// Methods used to manipulate the objects in the scene.
		Platform::String^ OnHitObject(int x, int y);
		void ToggleHitEffect(Platform::String^ object);
		void ChangeMaterialColor(Platform::String^ object, float r, float g, float b);

	private:
		// Members used to keep track of the scene state.
		SkinnedMeshRenderer m_skinnedMeshRenderer;
		std::vector<VSD3DStarter::Mesh*> m_meshModels;
		DirectX::XMFLOAT4X4 m_teapotTransform;
		std::vector<float> m_time;
		float m_rotation;

		// Members used to keep track of the graphics state.
		VSD3DStarter::Graphics m_graphics;
		VSD3DStarter::LightConstants m_lightConstants;
		VSD3DStarter::MiscConstants m_miscConstants;

		// Cached pointer to device resources.
		std::shared_ptr<DX::DeviceResources> m_deviceResources;

		// Variables used with the rendering loop.
		bool m_loadingComplete;
	};
}