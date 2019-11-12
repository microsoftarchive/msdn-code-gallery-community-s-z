// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

// This header shows you how to render animated meshes.
// If you don't need animations, remove this file and fix any build errors
// by removing all references to the SkinnedMeshedRenderer class.

#pragma once

#include "../VSD3DStarter.h"

#define MAX_BONES 59
struct BoneConstants
{
	BoneConstants()
	{
		static_assert((sizeof(BoneConstants) % 16) == 0, "CB must be 16-byte aligned");
	}

	DirectX::XMFLOAT4X4 Bones[MAX_BONES];
};

struct AnimationState
{
	AnimationState()
	{
		m_animTime = 0;
	}

	std::vector<DirectX::XMFLOAT4X4> m_boneWorldTransforms;
	float m_animTime;
};

class SkinnedMeshRenderer
{
public:
	SkinnedMeshRenderer() {}

	~SkinnedMeshRenderer() {}

	// Initializes the skinned mesh renderer, loading the vertex shader asynchronously.
	concurrency::task<void> InitializeAsync(ID3D11Device* device, ID3D11DeviceContext* deviceContext)
	{
		UNREFERENCED_PARAMETER(deviceContext);

		m_skinningShader = nullptr;
		m_boneConstantBuffer = nullptr;
		m_skinningVertexLayout = nullptr;

		// Create constant buffers.
		D3D11_BUFFER_DESC bufferDesc;
		bufferDesc.Usage = D3D11_USAGE_DEFAULT;
		bufferDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
		bufferDesc.CPUAccessFlags = 0;
		bufferDesc.MiscFlags = 0;
		bufferDesc.StructureByteStride = 0;

		bufferDesc.ByteWidth = sizeof(BoneConstants);
		device->CreateBuffer(&bufferDesc, nullptr, &m_boneConstantBuffer);

		// Load skinning assets.
		return DX::ReadDataAsync(L"SkinningVertexShader.cso").then([this, device](const std::vector<byte>& vsBuffer)
		{
			if (vsBuffer.size() > 0)
			{
				device->CreateVertexShader(&vsBuffer[0], vsBuffer.size(), nullptr, &m_skinningShader);
				if (m_skinningShader == nullptr)
				{
					throw std::exception("Pixel Shader could not be created");
				}
			}

			// Create the vertex layout.
			D3D11_INPUT_ELEMENT_DESC layout[] =
			{
				{ "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "NORMAL", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "TANGENT", 0, DXGI_FORMAT_R32G32B32A32_FLOAT, 0, 24, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "COLOR", 0, DXGI_FORMAT_R8G8B8A8_UNORM, 0, 40, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 44, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "BLENDINDICES", 0, DXGI_FORMAT_R8G8B8A8_UINT, 1, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "BLENDWEIGHT", 0, DXGI_FORMAT_R32G32B32A32_FLOAT, 1, 4, D3D11_INPUT_PER_VERTEX_DATA, 0 },
			};
			device->CreateInputLayout(layout, ARRAYSIZE(layout), &vsBuffer[0], vsBuffer.size(), &m_skinningVertexLayout);
		});
	}

	// Combines the transforms by taking into account all parent bone transforms recursively
	void CombineTransforms(uint32 currentBoneIndex, std::vector<VSD3DStarter::Mesh::BoneInfo> const& skinningInfo, std::vector<DirectX::XMFLOAT4X4>& boneWorldTransforms)
	{
		auto bone = skinningInfo[currentBoneIndex];
		if (m_isTransformCombined[currentBoneIndex] || bone.ParentIndex < 0 || bone.ParentIndex == static_cast<int>(currentBoneIndex))
		{
			m_isTransformCombined[currentBoneIndex] = true;
			return;
		}

		CombineTransforms(bone.ParentIndex, skinningInfo, boneWorldTransforms);

		DirectX::XMMATRIX leftMat = XMLoadFloat4x4(&boneWorldTransforms[currentBoneIndex]);
		DirectX::XMMATRIX rightMat = XMLoadFloat4x4(&boneWorldTransforms[bone.ParentIndex]);

		DirectX::XMMATRIX ret = leftMat * rightMat;

		XMStoreFloat4x4(&boneWorldTransforms[currentBoneIndex], ret);

		m_isTransformCombined[currentBoneIndex] = true;
	}

	// Updates the animation state for a given time.
	void UpdateAnimation(float timeDelta, std::vector<VSD3DStarter::Mesh*>& meshes, std::wstring clipName = L"Take 001")
	{
		for (VSD3DStarter::Mesh* mesh : meshes)
		{
			AnimationState* animState = (AnimationState*)mesh->Tag;
			if (animState == nullptr)
			{
				continue;
			}

			animState->m_animTime += timeDelta;

			// Update the bones.
			const std::vector<VSD3DStarter::Mesh::BoneInfo>& skinningInfo = mesh->BoneInfoCollection();
			for (UINT b = 0; b < skinningInfo.size(); b++)
			{
				animState->m_boneWorldTransforms[b] = skinningInfo[b].BoneLocalTransform;
			}

			// Get the keyframes.
			auto& animClips = mesh->AnimationClips();
			auto found = animClips.find(clipName);
			if (found != animClips.end())
			{
				const auto& kf = found->second.Keyframes;
				for (const auto& frame : kf)
				{
					if (frame.Time > animState->m_animTime)
					{
						break;
					}

					animState->m_boneWorldTransforms[frame.BoneIndex] = frame.Transform;
				}
				// Transform to world.
				m_isTransformCombined.assign(skinningInfo.size(), false);

				for (UINT b = 0; b < skinningInfo.size(); b++)
				{
					CombineTransforms(b, skinningInfo, animState->m_boneWorldTransforms);
				}
				for (UINT b = 0; b < skinningInfo.size(); b++)
				{
					DirectX::XMMATRIX leftMat = XMLoadFloat4x4(&skinningInfo[b].InvBindPos);
					DirectX::XMMATRIX rightMat = XMLoadFloat4x4(&animState->m_boneWorldTransforms[b]);

					DirectX::XMMATRIX ret = leftMat * rightMat;

					XMStoreFloat4x4(&animState->m_boneWorldTransforms[b], ret);
				}

				if (animState->m_animTime > found->second.EndTime)
				{
					animState->m_animTime = found->second.StartTime + (animState->m_animTime - found->second.EndTime);
				}
			}
		}
	}

	// Renders the mesh using the skinned mesh renderer.
	void RenderSkinnedMesh(VSD3DStarter::Mesh* mesh, const VSD3DStarter::Graphics& graphics, const DirectX::XMMATRIX& world)
	{
		ID3D11DeviceContext* deviceContext = graphics.GetDeviceContext();

		BOOL supportsShaderResources = graphics.GetDeviceFeatureLevel() >= D3D_FEATURE_LEVEL_10_0;

		const DirectX::XMMATRIX& view = DirectX::XMLoadFloat4x4(&graphics.GetCamera().GetView());
		const DirectX::XMMATRIX& projection = DirectX::XMLoadFloat4x4(&graphics.GetCamera().GetProjection()) * DirectX::XMLoadFloat4x4(&graphics.GetCamera().GetOrientationMatrix());

		// Compute the object matrices.
		DirectX::XMMATRIX localToView = world * view;
		DirectX::XMMATRIX localToProj = world * view * projection;

		// Initialize object constants and update the constant buffer.
		VSD3DStarter::ObjectConstants objConstants;
		objConstants.LocalToWorld4x4 = DirectX::XMMatrixTranspose(world);
		objConstants.LocalToProjected4x4 = DirectX::XMMatrixTranspose(localToProj);
		objConstants.WorldToLocal4x4 = DirectX::XMMatrixTranspose(DirectX::XMMatrixInverse(nullptr, world));
		objConstants.WorldToView4x4 = DirectX::XMMatrixTranspose(view);
		objConstants.UvTransform4x4 = DirectX::XMMatrixIdentity();
		objConstants.EyePosition = graphics.GetCamera().GetPosition();
		graphics.UpdateObjectConstants(objConstants);

		// Assign constant buffers to correct slots.
		ID3D11Buffer* constantBuffer = graphics.GetLightConstants();
		deviceContext->VSSetConstantBuffers(1, 1, &constantBuffer);
		deviceContext->PSSetConstantBuffers(1, 1, &constantBuffer);

		constantBuffer = graphics.GetMiscConstants();
		deviceContext->VSSetConstantBuffers(3, 1, &constantBuffer);
		deviceContext->PSSetConstantBuffers(3, 1, &constantBuffer);

		ID3D11Buffer* boneConsts = m_boneConstantBuffer.Get();
		deviceContext->VSSetConstantBuffers(4, 1, &boneConsts);

		// Prepare to draw.

		// NOTE: Set the skinning vertex layout.
		deviceContext->IASetInputLayout(m_skinningVertexLayout.Get());
		deviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

		BoneConstants boneConstants;

		// Update the bones.
		AnimationState* animState = (AnimationState*)mesh->Tag;
		if (animState != nullptr)
		{
			// Copy to constants.
			for (UINT b = 0; b < animState->m_boneWorldTransforms.size(); b++)
			{
				DirectX::XMMATRIX bones = DirectX::XMMatrixTranspose((XMLoadFloat4x4(&animState->m_boneWorldTransforms[b])));
				XMStoreFloat4x4(&boneConstants.Bones[b], bones);
			}
		}

		// Update the constants.
		deviceContext->UpdateSubresource(m_boneConstantBuffer.Get(), 0, nullptr, &boneConstants, 0, 0);

		// Loop over each submesh.
		for (const VSD3DStarter::Mesh::SubMesh& submesh : mesh->SubMeshes())
		{
			// Only draw submeshes that have valid materials.
			VSD3DStarter::MaterialConstants materialConstants;

			if (submesh.IndexBufferIndex < mesh->IndexBuffers().size() &&
				submesh.VertexBufferIndex < mesh->VertexBuffers().size())
			{
				ID3D11Buffer* vbs[2] =
				{
					mesh->VertexBuffers()[submesh.VertexBufferIndex],
					mesh->SkinningVertexBuffers()[submesh.VertexBufferIndex]
				};

				UINT stride[2] = { sizeof(VSD3DStarter::Vertex), sizeof(VSD3DStarter::SkinningVertexInput) };
				UINT offset[2] = { 0, 0 };
				deviceContext->IASetVertexBuffers(0, 2, vbs, stride, offset);
				deviceContext->IASetIndexBuffer(mesh->IndexBuffers()[submesh.IndexBufferIndex], DXGI_FORMAT_R16_UINT, 0);
			}

			if (submesh.MaterialIndex < mesh->Materials().size())
			{
				const VSD3DStarter::Mesh::Material& material = mesh->Materials()[submesh.MaterialIndex];

				// Update the material constant buffer.
				memcpy(&materialConstants.Ambient, material.Ambient, sizeof(material.Ambient));
				memcpy(&materialConstants.Diffuse, material.Diffuse, sizeof(material.Diffuse));
				memcpy(&materialConstants.Specular, material.Specular, sizeof(material.Specular));
				memcpy(&materialConstants.Emissive, material.Emissive, sizeof(material.Emissive));
				materialConstants.SpecularPower = material.SpecularPower;

				graphics.UpdateMaterialConstants(materialConstants);

				// Assign the material buffer to the correct slots.
				constantBuffer = graphics.GetMaterialConstants();
				deviceContext->VSSetConstantBuffers(0, 1, &constantBuffer);
				deviceContext->PSSetConstantBuffers(0, 1, &constantBuffer);

				// Update the UV transform.
				memcpy(&objConstants.UvTransform4x4, &material.UVTransform, sizeof(objConstants.UvTransform4x4));
				graphics.UpdateObjectConstants(objConstants);

				constantBuffer = graphics.GetObjectConstants();
				deviceContext->VSSetConstantBuffers(2, 1, &constantBuffer);
				deviceContext->PSSetConstantBuffers(2, 1, &constantBuffer);

				// Assign shaders, samplers and texture resources.


				// NOTE: Set the skinning shader here.
				deviceContext->VSSetShader(m_skinningShader.Get(), nullptr, 0);

				ID3D11SamplerState* samplerState = material.SamplerState.Get();
				if (supportsShaderResources)
				{
					deviceContext->VSSetSamplers(0, 1, &samplerState);
				}

				deviceContext->PSSetShader(material.PixelShader.Get(), nullptr, 0);
				deviceContext->PSSetSamplers(0, 1, &samplerState);

				for (UINT tex = 0; tex < VSD3DStarter::Mesh::MaxTextures; tex++)
				{
					ID3D11ShaderResourceView* shaderResourceView = material.Textures[tex].Get();
					if (supportsShaderResources)
					{
						deviceContext->VSSetShaderResources(0 + tex, 1, &shaderResourceView);
						deviceContext->VSSetShaderResources(VSD3DStarter::Mesh::MaxTextures + tex, 1, &shaderResourceView);
					}

					deviceContext->PSSetShaderResources(0 + tex, 1, &shaderResourceView);
					deviceContext->PSSetShaderResources(VSD3DStarter::Mesh::MaxTextures + tex, 1, &shaderResourceView);
				}

				// Draw the submesh.
				deviceContext->DrawIndexed(submesh.PrimCount * 3, submesh.StartIndex, 0);
			}
		}

		// Clear the extra vertex buffer.
		ID3D11Buffer* vbs[1] = { nullptr };
		UINT stride = 0;
		UINT offset = 0;
		deviceContext->IASetVertexBuffers(1, 1, vbs, &stride, &offset);
	}

private:
	Microsoft::WRL::ComPtr<ID3D11VertexShader> m_skinningShader;
	Microsoft::WRL::ComPtr<ID3D11InputLayout> m_skinningVertexLayout;
	Microsoft::WRL::ComPtr<ID3D11Buffer> m_boneConstantBuffer;
	std::vector<bool> m_isTransformCombined;
};
