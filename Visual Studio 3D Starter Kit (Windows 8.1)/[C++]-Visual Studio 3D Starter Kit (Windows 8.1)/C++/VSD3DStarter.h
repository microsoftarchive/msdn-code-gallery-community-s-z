// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

#include <d3d11_2.h>
#include <directxmath.h>
#include <vector>
#include <map>
#include <string>
#include <algorithm>

#include "DirectXTex\DDSTextureLoader.h"
#include "Common\DirectXHelper.h"
#include "ppltasks_extra.h"

namespace VSD3DStarter
{

	/*

	The header contains starter classes that can be used to load and render 3D assets. Assets include
	textures (png, bmp, etc.), effects (dgsl) and meshes (fbx).

	Textures should be converted into .dds files
	Effects should be converted into .cso files
	Meshes should be converted into .cmo files


	======================================================================
	Structures for Constant Buffer Data
	======================================================================

	struct MaterialConstants
	{
	DirectX::XMFLOAT4   Ambient;
	DirectX::XMFLOAT4   Diffuse;
	DirectX::XMFLOAT4   Specular;
	DirectX::XMFLOAT4   Emissive;
	float               SpecularPower;
	float               Padding0;
	float               Padding1;
	float               Padding2;
	};

	struct LightConstants
	{
	DirectX::XMFLOAT4   Ambient;
	DirectX::XMFLOAT4   LightColor[4];
	DirectX::XMFLOAT4   LightAttenuation[4];
	DirectX::XMFLOAT4   LightDirection[4];
	DirectX::XMFLOAT4   LightSpecularIntensity[4];
	UINT                IsPointLight[4];
	UINT                ActiveLights;
	float               Padding0;
	float               Padding1;
	float               Padding2;
	};

	struct ObjectConstants
	{
	DirectX::XMMATRIX   LocalToWorld4x4;
	DirectX::XMMATRIX   LocalToProjected4x4;
	DirectX::XMMATRIX   WorldToLocal4x4;
	DirectX::XMMATRIX   WorldToView4x4;
	DirectX::XMMATRIX   UvTransform4x4;
	DirectX::XMFLOAT3   EyePosition;
	float               Padding0;
	};

	struct MiscConstants
	{
	float ViewportWidth;
	float ViewportHeight;
	float Time;
	float Padding1;
	};

	struct Vertex
	{
	float x, y, z;
	float nx, ny, nz;
	float tx, ty, tz, tw;
	UINT color;
	float u, v;
	};


	======================================================================
	Graphics Class
	======================================================================

	class Graphics
	{
	// Initialization/shutdown.
	void Initialize(ID3D11Device* device, ID3D11DeviceContext* deviceContext);
	void Shutdown();

	// Accessors.
	Camera& GetCamera() const;

	ID3D11Device* GetDevice() const;
	ID3D11DeviceContext* GetDeviceContext() const;

	ID3D11Buffer* GetMaterialConstants() const;
	ID3D11Buffer* GetLightConstants() const;
	ID3D11Buffer* GetObjectConstants() const;
	ID3D11Buffer* GetMiscConstants() const;

	ID3D11SamplerState* GetSamplerState() const;
	ID3D11InputLayout* GetVertexInputLayout() const;
	ID3D11VertexShader* GetVertexShader() const;

	// Resource management for pixel shaders and textures.
	concurrency::task<ID3D11PixelShader*> GetOrCreatePixelShaderAsync(const std::wstring& shaderName);
	concurrency::task<ID3D11ShaderResourceView*> GetOrCreateTextureAsync(const std::wstring& textureName);

	// Methods to update constant buffers.
	void UpdateMaterialConstants(const MaterialConstants& data) const;
	void UpdateLightConstants(const LightConstants& data) const;
	void UpdateObjectConstants(const ObjectConstants& data) const;
	void UpdateMiscConstants(const MiscConstants& data) const;
	}


	======================================================================
	Camera Class
	======================================================================

	class Camera
	{
	public:
	Camera();

	const XMMATRIX& GetView() const;
	const XMMATRIX& GetProjection() const;

	const XMFLOAT3& GetPosition() const;
	const XMFLOAT3& GetLookAt() const;

	void SetProjection(float fovY, float aspect, float zn, float zf);
	void SetProjectionOrthographic(float viewWidth, float viewHeight, float zn, float zf);
	void SetProjectionOrthographicOffCenter(float viewLeft, float viewRight, float viewBottom, float viewTop, float zn, float zf);
	void SetPosition(const XMFLOAT3& position);
	void SetLookAt(const XMFLOAT3& lookAt);
	}


	======================================================================
	Mesh Class
	======================================================================

	class Mesh
	{
	static const UINT MaxTextures = 8;

	struct SubMesh
	{
	UINT MaterialIndex;
	UINT IndexBufferIndex;
	UINT VertexBufferIndex;
	UINT StartIndex;
	UINT PrimCount;
	};

	struct Material
	{
	std::wstring Name;
	float Ambient[4];
	float Diffuse[4];
	float Specular[4];
	float Emissive[4];
	float SpecularPower;

	Microsoft::WRL::ComPtr<ID3D11ShaderResourceView> Textures[MaxTextures];
	Microsoft::WRL::ComPtr<ID3D11VertexShader> VertexShader;
	Microsoft::WRL::ComPtr<ID3D11PixelShader> PixelShader;
	Microsoft::WRL::ComPtr<ID3D11SamplerState> SamplerState;
	};

	struct MeshExtents
	{
	float CenterX, CenterY, CenterZ;
	float Radius;

	float MinX, MinY, MinZ;
	float MaxX, MaxY, MaxZ;
	};

	// Access to mesh data.
	const std::vector<SubMesh>& SubMeshes() const;
	const std::vector<Material>& Materials() const;
	const std::vector<ID3D11Buffer*>& VertexBuffers();
	const std::vector<ID3D11Buffer*>& IndexBuffers() const;
	const MeshExtents& MeshExtents() const;

	// Render the mesh to the current render target.
	void Render(const Graphics& graphics, const DirectX::XMMATRIX& world);

	// Loads a scene from the specified file, returning a vector of mesh objects.
	static concurrency::task<void> LoadFromFileAsync(
	Graphics& graphics,
	const std::wstring& meshFilename,
	const std::wstring& shaderPathLocation,
	const std::wstring& texturePathLocation,
	std::vector<Mesh*>& loadedMeshes,
	bool clearLoadedMeshesVector = true
	);
	}

	*/

	///////////////////////////////////////////////////////////////////////////////////////////
	//
	// Simple COM helper template functions for safe AddRef() and Release() of IUnknown objects.
	//
	template <class T> inline LONG SafeAddRef(T* pUnk) { ULONG lr = 0; if (pUnk != nullptr) { lr = pUnk->AddRef(); } return lr; }
	template <class T> inline LONG SafeRelease(T*& pUnk) { ULONG lr = 0; if (pUnk != nullptr) { lr = pUnk->Release(); pUnk = nullptr; } return lr; }
	//
	//
	///////////////////////////////////////////////////////////////////////////////////////////


	///////////////////////////////////////////////////////////////////////////////////////////
	//
	// Default Vertex Shader for rendering meshes. 
	// Compiled with "fxc /nologo /T vs_4_0_level_9_1 /Fh <path to output>.h /Vn VSD3DStarter_VS <path to code below>.hlsl".
	// Full source code:
	//
	//     cbuffer MaterialVars : register (b0)
	//     {
	//         float4 MaterialAmbient;
	//         float4 MaterialDiffuse;
	//         float4 MaterialSpecular;
	//         float4 MaterialEmissive;
	//         float MaterialSpecularPower;
	//     };
	//       
	//     cbuffer ObjectVars : register(b2)
	//     {
	//         float4x4 LocalToWorld4x4;
	//         float4x4 LocalToProjected4x4;
	//         float4x4 WorldToLocal4x4;
	//         float4x4 WorldToView4x4;
	//         float4x4 UVTransform4x4;
	//         float3 EyePosition;
	//     };
	//     
	//     struct A2V
	//     {
	//         float4 pos : POSITION0;
	//         float3 normal : NORMAL0;
	//         float4 tangent : TANGENT0;
	//         float4 color : COLOR0;
	//         float2 uv : TEXCOORD0;
	//     };
	//       
	//     struct V2P
	//     {
	//         float4 pos : SV_POSITION;
	//         float4 diffuse : COLOR;
	//         float2 uv : TEXCOORD0;
	//         float3 worldNorm : TEXCOORD1;
	//         float3 worldPos : TEXCOORD2;
	//         float3 toEye : TEXCOORD3;
	//         float4 tangent : TEXCOORD4;
	//         float3 normal : TEXCOORD5;
	//     };
	//       
	//       
	//     V2P main(A2V vertex)
	//     {
	//         V2P result;
	//       
	//         float3 wp = mul(vertex.pos, LocalToWorld4x4).xyz;
	//       
	//         // Set output data.
	//         result.pos = mul(vertex.pos, LocalToProjected4x4);
	//         result.diffuse = vertex.color * MaterialDiffuse;
	//         result.uv = mul(float4(vertex.uv.x, vertex.uv.y, 0, 1), UVTransform4x4).xy;
	//         result.worldNorm = mul(vertex.normal, (float3x3)LocalToWorld4x4);
	//         result.worldPos = wp;
	//         result.toEye = EyePosition - wp;
	//         result.tangent = vertex.tangent;
	//         result.normal = vertex.normal;
	//       
	//         return result;
	//     }

	const BYTE VSD3DStarter_VS[] =
	{
		68, 88, 66, 67, 6, 246,
		181, 252, 252, 142, 75, 224,
		64, 3, 123, 57, 145, 98,
		23, 7, 1, 0, 0, 0,
		52, 10, 0, 0, 6, 0,
		0, 0, 56, 0, 0, 0,
		56, 2, 0, 0, 60, 5,
		0, 0, 184, 5, 0, 0,
		152, 8, 0, 0, 72, 9,
		0, 0, 65, 111, 110, 57,
		248, 1, 0, 0, 248, 1,
		0, 0, 0, 2, 254, 255,
		148, 1, 0, 0, 100, 0,
		0, 0, 5, 0, 36, 0,
		0, 0, 96, 0, 0, 0,
		96, 0, 0, 0, 36, 0,
		1, 0, 96, 0, 0, 0,
		1, 0, 1, 0, 1, 0,
		0, 0, 0, 0, 2, 0,
		0, 0, 3, 0, 2, 0,
		0, 0, 0, 0, 2, 0,
		4, 0, 4, 0, 5, 0,
		0, 0, 0, 0, 2, 0,
		16, 0, 2, 0, 9, 0,
		0, 0, 0, 0, 2, 0,
		20, 0, 1, 0, 11, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 2, 254, 255,
		81, 0, 0, 5, 12, 0,
		15, 160, 0, 0, 128, 63,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		31, 0, 0, 2, 5, 0,
		0, 128, 0, 0, 15, 144,
		31, 0, 0, 2, 5, 0,
		1, 128, 1, 0, 15, 144,
		31, 0, 0, 2, 5, 0,
		2, 128, 2, 0, 15, 144,
		31, 0, 0, 2, 5, 0,
		3, 128, 3, 0, 15, 144,
		31, 0, 0, 2, 5, 0,
		4, 128, 4, 0, 15, 144,
		9, 0, 0, 3, 0, 0,
		4, 192, 0, 0, 228, 144,
		7, 0, 228, 160, 5, 0,
		0, 3, 0, 0, 15, 224,
		3, 0, 228, 144, 1, 0,
		228, 160, 4, 0, 0, 4,
		0, 0, 7, 128, 4, 0,
		196, 144, 12, 0, 208, 160,
		12, 0, 197, 160, 8, 0,
		0, 3, 1, 0, 1, 224,
		0, 0, 228, 128, 9, 0,
		244, 160, 8, 0, 0, 3,
		1, 0, 2, 224, 0, 0,
		228, 128, 10, 0, 244, 160,
		8, 0, 0, 3, 2, 0,
		1, 224, 1, 0, 228, 144,
		2, 0, 228, 160, 8, 0,
		0, 3, 2, 0, 2, 224,
		1, 0, 228, 144, 3, 0,
		228, 160, 8, 0, 0, 3,
		2, 0, 4, 224, 1, 0,
		228, 144, 4, 0, 228, 160,
		9, 0, 0, 3, 0, 0,
		1, 128, 0, 0, 228, 144,
		2, 0, 228, 160, 9, 0,
		0, 3, 0, 0, 2, 128,
		0, 0, 228, 144, 3, 0,
		228, 160, 9, 0, 0, 3,
		0, 0, 4, 128, 0, 0,
		228, 144, 4, 0, 228, 160,
		2, 0, 0, 3, 4, 0,
		7, 224, 0, 0, 228, 129,
		11, 0, 228, 160, 1, 0,
		0, 2, 3, 0, 7, 224,
		0, 0, 228, 128, 9, 0,
		0, 3, 0, 0, 1, 128,
		0, 0, 228, 144, 5, 0,
		228, 160, 9, 0, 0, 3,
		0, 0, 2, 128, 0, 0,
		228, 144, 6, 0, 228, 160,
		9, 0, 0, 3, 0, 0,
		4, 128, 0, 0, 228, 144,
		8, 0, 228, 160, 4, 0,
		0, 4, 0, 0, 3, 192,
		0, 0, 170, 128, 0, 0,
		228, 160, 0, 0, 228, 128,
		1, 0, 0, 2, 0, 0,
		8, 192, 0, 0, 170, 128,
		1, 0, 0, 2, 5, 0,
		15, 224, 2, 0, 228, 144,
		1, 0, 0, 2, 6, 0,
		7, 224, 1, 0, 228, 144,
		255, 255, 0, 0, 83, 72,
		68, 82, 252, 2, 0, 0,
		64, 0, 1, 0, 191, 0,
		0, 0, 89, 0, 0, 4,
		70, 142, 32, 0, 0, 0,
		0, 0, 2, 0, 0, 0,
		89, 0, 0, 4, 70, 142,
		32, 0, 2, 0, 0, 0,
		21, 0, 0, 0, 95, 0,
		0, 3, 242, 16, 16, 0,
		0, 0, 0, 0, 95, 0,
		0, 3, 114, 16, 16, 0,
		1, 0, 0, 0, 95, 0,
		0, 3, 242, 16, 16, 0,
		2, 0, 0, 0, 95, 0,
		0, 3, 242, 16, 16, 0,
		3, 0, 0, 0, 95, 0,
		0, 3, 50, 16, 16, 0,
		4, 0, 0, 0, 103, 0,
		0, 4, 242, 32, 16, 0,
		0, 0, 0, 0, 1, 0,
		0, 0, 101, 0, 0, 3,
		242, 32, 16, 0, 1, 0,
		0, 0, 101, 0, 0, 3,
		50, 32, 16, 0, 2, 0,
		0, 0, 101, 0, 0, 3,
		114, 32, 16, 0, 3, 0,
		0, 0, 101, 0, 0, 3,
		114, 32, 16, 0, 4, 0,
		0, 0, 101, 0, 0, 3,
		114, 32, 16, 0, 5, 0,
		0, 0, 101, 0, 0, 3,
		242, 32, 16, 0, 6, 0,
		0, 0, 101, 0, 0, 3,
		114, 32, 16, 0, 7, 0,
		0, 0, 104, 0, 0, 2,
		1, 0, 0, 0, 17, 0,
		0, 8, 18, 32, 16, 0,
		0, 0, 0, 0, 70, 30,
		16, 0, 0, 0, 0, 0,
		70, 142, 32, 0, 2, 0,
		0, 0, 4, 0, 0, 0,
		17, 0, 0, 8, 34, 32,
		16, 0, 0, 0, 0, 0,
		70, 30, 16, 0, 0, 0,
		0, 0, 70, 142, 32, 0,
		2, 0, 0, 0, 5, 0,
		0, 0, 17, 0, 0, 8,
		66, 32, 16, 0, 0, 0,
		0, 0, 70, 30, 16, 0,
		0, 0, 0, 0, 70, 142,
		32, 0, 2, 0, 0, 0,
		6, 0, 0, 0, 17, 0,
		0, 8, 130, 32, 16, 0,
		0, 0, 0, 0, 70, 30,
		16, 0, 0, 0, 0, 0,
		70, 142, 32, 0, 2, 0,
		0, 0, 7, 0, 0, 0,
		56, 0, 0, 8, 242, 32,
		16, 0, 1, 0, 0, 0,
		70, 30, 16, 0, 3, 0,
		0, 0, 70, 142, 32, 0,
		0, 0, 0, 0, 1, 0,
		0, 0, 54, 0, 0, 5,
		50, 0, 16, 0, 0, 0,
		0, 0, 70, 16, 16, 0,
		4, 0, 0, 0, 54, 0,
		0, 5, 66, 0, 16, 0,
		0, 0, 0, 0, 1, 64,
		0, 0, 0, 0, 128, 63,
		16, 0, 0, 8, 18, 32,
		16, 0, 2, 0, 0, 0,
		70, 2, 16, 0, 0, 0,
		0, 0, 70, 131, 32, 0,
		2, 0, 0, 0, 16, 0,
		0, 0, 16, 0, 0, 8,
		34, 32, 16, 0, 2, 0,
		0, 0, 70, 2, 16, 0,
		0, 0, 0, 0, 70, 131,
		32, 0, 2, 0, 0, 0,
		17, 0, 0, 0, 16, 0,
		0, 8, 18, 32, 16, 0,
		3, 0, 0, 0, 70, 18,
		16, 0, 1, 0, 0, 0,
		70, 130, 32, 0, 2, 0,
		0, 0, 0, 0, 0, 0,
		16, 0, 0, 8, 34, 32,
		16, 0, 3, 0, 0, 0,
		70, 18, 16, 0, 1, 0,
		0, 0, 70, 130, 32, 0,
		2, 0, 0, 0, 1, 0,
		0, 0, 16, 0, 0, 8,
		66, 32, 16, 0, 3, 0,
		0, 0, 70, 18, 16, 0,
		1, 0, 0, 0, 70, 130,
		32, 0, 2, 0, 0, 0,
		2, 0, 0, 0, 17, 0,
		0, 8, 18, 0, 16, 0,
		0, 0, 0, 0, 70, 30,
		16, 0, 0, 0, 0, 0,
		70, 142, 32, 0, 2, 0,
		0, 0, 0, 0, 0, 0,
		17, 0, 0, 8, 34, 0,
		16, 0, 0, 0, 0, 0,
		70, 30, 16, 0, 0, 0,
		0, 0, 70, 142, 32, 0,
		2, 0, 0, 0, 1, 0,
		0, 0, 17, 0, 0, 8,
		66, 0, 16, 0, 0, 0,
		0, 0, 70, 30, 16, 0,
		0, 0, 0, 0, 70, 142,
		32, 0, 2, 0, 0, 0,
		2, 0, 0, 0, 54, 0,
		0, 5, 114, 32, 16, 0,
		4, 0, 0, 0, 70, 2,
		16, 0, 0, 0, 0, 0,
		0, 0, 0, 9, 114, 32,
		16, 0, 5, 0, 0, 0,
		70, 2, 16, 128, 65, 0,
		0, 0, 0, 0, 0, 0,
		70, 130, 32, 0, 2, 0,
		0, 0, 20, 0, 0, 0,
		54, 0, 0, 5, 242, 32,
		16, 0, 6, 0, 0, 0,
		70, 30, 16, 0, 2, 0,
		0, 0, 54, 0, 0, 5,
		114, 32, 16, 0, 7, 0,
		0, 0, 70, 18, 16, 0,
		1, 0, 0, 0, 62, 0,
		0, 1, 83, 84, 65, 84,
		116, 0, 0, 0, 20, 0,
		0, 0, 1, 0, 0, 0,
		0, 0, 0, 0, 13, 0,
		0, 0, 14, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 1, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 5, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		82, 68, 69, 70, 216, 2,
		0, 0, 2, 0, 0, 0,
		116, 0, 0, 0, 2, 0,
		0, 0, 28, 0, 0, 0,
		0, 4, 254, 255, 0, 1,
		0, 0, 164, 2, 0, 0,
		92, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		1, 0, 0, 0, 1, 0,
		0, 0, 105, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 2, 0,
		0, 0, 1, 0, 0, 0,
		1, 0, 0, 0, 77, 97,
		116, 101, 114, 105, 97, 108,
		86, 97, 114, 115, 0, 79,
		98, 106, 101, 99, 116, 86,
		97, 114, 115, 0, 92, 0,
		0, 0, 5, 0, 0, 0,
		164, 0, 0, 0, 80, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 105, 0,
		0, 0, 6, 0, 0, 0,
		148, 1, 0, 0, 80, 1,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 28, 1,
		0, 0, 0, 0, 0, 0,
		16, 0, 0, 0, 0, 0,
		0, 0, 44, 1, 0, 0,
		0, 0, 0, 0, 60, 1,
		0, 0, 16, 0, 0, 0,
		16, 0, 0, 0, 2, 0,
		0, 0, 44, 1, 0, 0,
		0, 0, 0, 0, 76, 1,
		0, 0, 32, 0, 0, 0,
		16, 0, 0, 0, 0, 0,
		0, 0, 44, 1, 0, 0,
		0, 0, 0, 0, 93, 1,
		0, 0, 48, 0, 0, 0,
		16, 0, 0, 0, 0, 0,
		0, 0, 44, 1, 0, 0,
		0, 0, 0, 0, 110, 1,
		0, 0, 64, 0, 0, 0,
		4, 0, 0, 0, 0, 0,
		0, 0, 132, 1, 0, 0,
		0, 0, 0, 0, 77, 97,
		116, 101, 114, 105, 97, 108,
		65, 109, 98, 105, 101, 110,
		116, 0, 1, 0, 3, 0,
		1, 0, 4, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		77, 97, 116, 101, 114, 105,
		97, 108, 68, 105, 102, 102,
		117, 115, 101, 0, 77, 97,
		116, 101, 114, 105, 97, 108,
		83, 112, 101, 99, 117, 108,
		97, 114, 0, 77, 97, 116,
		101, 114, 105, 97, 108, 69,
		109, 105, 115, 115, 105, 118,
		101, 0, 77, 97, 116, 101,
		114, 105, 97, 108, 83, 112,
		101, 99, 117, 108, 97, 114,
		80, 111, 119, 101, 114, 0,
		0, 0, 3, 0, 1, 0,
		1, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 36, 2,
		0, 0, 0, 0, 0, 0,
		64, 0, 0, 0, 2, 0,
		0, 0, 52, 2, 0, 0,
		0, 0, 0, 0, 68, 2,
		0, 0, 64, 0, 0, 0,
		64, 0, 0, 0, 2, 0,
		0, 0, 52, 2, 0, 0,
		0, 0, 0, 0, 88, 2,
		0, 0, 128, 0, 0, 0,
		64, 0, 0, 0, 0, 0,
		0, 0, 52, 2, 0, 0,
		0, 0, 0, 0, 104, 2,
		0, 0, 192, 0, 0, 0,
		64, 0, 0, 0, 0, 0,
		0, 0, 52, 2, 0, 0,
		0, 0, 0, 0, 119, 2,
		0, 0, 0, 1, 0, 0,
		64, 0, 0, 0, 2, 0,
		0, 0, 52, 2, 0, 0,
		0, 0, 0, 0, 134, 2,
		0, 0, 64, 1, 0, 0,
		12, 0, 0, 0, 2, 0,
		0, 0, 148, 2, 0, 0,
		0, 0, 0, 0, 76, 111,
		99, 97, 108, 84, 111, 87,
		111, 114, 108, 100, 52, 120,
		52, 0, 3, 0, 3, 0,
		4, 0, 4, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		76, 111, 99, 97, 108, 84,
		111, 80, 114, 111, 106, 101,
		99, 116, 101, 100, 52, 120,
		52, 0, 87, 111, 114, 108,
		100, 84, 111, 76, 111, 99,
		97, 108, 52, 120, 52, 0,
		87, 111, 114, 108, 100, 84,
		111, 86, 105, 101, 119, 52,
		120, 52, 0, 85, 86, 84,
		114, 97, 110, 115, 102, 111,
		114, 109, 52, 120, 52, 0,
		69, 121, 101, 80, 111, 115,
		105, 116, 105, 111, 110, 0,
		171, 171, 1, 0, 3, 0,
		1, 0, 3, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		77, 105, 99, 114, 111, 115,
		111, 102, 116, 32, 40, 82,
		41, 32, 72, 76, 83, 76,
		32, 83, 104, 97, 100, 101,
		114, 32, 67, 111, 109, 112,
		105, 108, 101, 114, 32, 54,
		46, 51, 46, 57, 54, 48,
		48, 46, 49, 54, 51, 56,
		52, 0, 171, 171, 73, 83,
		71, 78, 168, 0, 0, 0,
		5, 0, 0, 0, 8, 0,
		0, 0, 128, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 3, 0, 0, 0,
		0, 0, 0, 0, 15, 15,
		0, 0, 137, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 3, 0, 0, 0,
		1, 0, 0, 0, 7, 7,
		0, 0, 144, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 3, 0, 0, 0,
		2, 0, 0, 0, 15, 15,
		0, 0, 152, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 3, 0, 0, 0,
		3, 0, 0, 0, 15, 15,
		0, 0, 158, 0, 0, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 3, 0, 0, 0,
		4, 0, 0, 0, 3, 3,
		0, 0, 80, 79, 83, 73,
		84, 73, 79, 78, 0, 78,
		79, 82, 77, 65, 76, 0,
		84, 65, 78, 71, 69, 78,
		84, 0, 67, 79, 76, 79,
		82, 0, 84, 69, 88, 67,
		79, 79, 82, 68, 0, 171,
		79, 83, 71, 78, 228, 0,
		0, 0, 8, 0, 0, 0,
		8, 0, 0, 0, 200, 0,
		0, 0, 0, 0, 0, 0,
		1, 0, 0, 0, 3, 0,
		0, 0, 0, 0, 0, 0,
		15, 0, 0, 0, 212, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 3, 0,
		0, 0, 1, 0, 0, 0,
		15, 0, 0, 0, 218, 0,
		0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 3, 0,
		0, 0, 2, 0, 0, 0,
		3, 12, 0, 0, 218, 0,
		0, 0, 1, 0, 0, 0,
		0, 0, 0, 0, 3, 0,
		0, 0, 3, 0, 0, 0,
		7, 8, 0, 0, 218, 0,
		0, 0, 2, 0, 0, 0,
		0, 0, 0, 0, 3, 0,
		0, 0, 4, 0, 0, 0,
		7, 8, 0, 0, 218, 0,
		0, 0, 3, 0, 0, 0,
		0, 0, 0, 0, 3, 0,
		0, 0, 5, 0, 0, 0,
		7, 8, 0, 0, 218, 0,
		0, 0, 4, 0, 0, 0,
		0, 0, 0, 0, 3, 0,
		0, 0, 6, 0, 0, 0,
		15, 0, 0, 0, 218, 0,
		0, 0, 5, 0, 0, 0,
		0, 0, 0, 0, 3, 0,
		0, 0, 7, 0, 0, 0,
		7, 8, 0, 0, 83, 86,
		95, 80, 79, 83, 73, 84,
		73, 79, 78, 0, 67, 79,
		76, 79, 82, 0, 84, 69,
		88, 67, 79, 79, 82, 68,
		0, 171
	};

	//
	//
	///////////////////////////////////////////////////////////////////////////////////////////

	///////////////////////////////////////////////////////////////////////////////////////////
	//
	// Constant buffer structures
	//
	// These structs use padding and different data types in places to adhere
	// to the shader constant's alignment.
	//
	struct MaterialConstants
	{
		MaterialConstants()
		{
			static_assert((sizeof(MaterialConstants) % 16) == 0, "CB must be 16-byte aligned");
			Ambient = DirectX::XMFLOAT4(0.0f, 0.0f, 0.0f, 1.0f);
			Diffuse = DirectX::XMFLOAT4(1.0f, 1.0f, 1.0f, 1.0f);
			Specular = DirectX::XMFLOAT4(0.0f, 0.0f, 0.0f, 0.0f);
			Emissive = DirectX::XMFLOAT4(0.0f, 0.0f, 0.0f, 0.0f);
			SpecularPower = 1.0f;
			Padding0 = 0.0f;
			Padding1 = 0.0f;
			Padding2 = 0.0f;
		}

		DirectX::XMFLOAT4   Ambient;
		DirectX::XMFLOAT4   Diffuse;
		DirectX::XMFLOAT4   Specular;
		DirectX::XMFLOAT4   Emissive;
		float               SpecularPower;
		float               Padding0;
		float               Padding1;
		float               Padding2;
	};

	struct LightConstants
	{
		LightConstants()
		{
			static_assert((sizeof(LightConstants) % 16) == 0, "CB must be 16-byte aligned");
			ZeroMemory(this, sizeof(LightConstants));
			Ambient = DirectX::XMFLOAT4(1.0f, 1.0f, 1.0f, 1.0f);
		}

		DirectX::XMFLOAT4   Ambient;
		DirectX::XMFLOAT4   LightColor[4];
		DirectX::XMFLOAT4   LightAttenuation[4];
		DirectX::XMFLOAT4   LightDirection[4];
		DirectX::XMFLOAT4   LightSpecularIntensity[4];
		UINT                IsPointLight[4];
		UINT                ActiveLights;
		float               Padding0;
		float               Padding1;
		float               Padding2;
	};

	struct ObjectConstants
	{
		ObjectConstants()
		{
			static_assert((sizeof(ObjectConstants) % 16) == 0, "CB must be 16-byte aligned");
			ZeroMemory(this, sizeof(ObjectConstants));
		}

		DirectX::XMMATRIX   LocalToWorld4x4;
		DirectX::XMMATRIX   LocalToProjected4x4;
		DirectX::XMMATRIX   WorldToLocal4x4;
		DirectX::XMMATRIX   WorldToView4x4;
		DirectX::XMMATRIX   UvTransform4x4;
		DirectX::XMFLOAT3   EyePosition;
		float               Padding0;
	};

	struct MiscConstants
	{
		MiscConstants()
		{
			static_assert((sizeof(MiscConstants) % 16) == 0, "CB must be 16-byte aligned");
			ViewportWidth = 1.0f;
			ViewportHeight = 1.0f;
			Time = 0.0f;
			Padding1 = 0.0f;
		}

		float ViewportWidth;
		float ViewportHeight;
		float Time;
		float Padding1;
	};

	struct Vertex
	{
		float x, y, z;
		float nx, ny, nz;
		float tx, ty, tz, tw;
		UINT color;
		float u, v;
	};

#define NUM_BONE_INFLUENCES 4
	struct SkinningVertex
	{
		UINT boneIndex[NUM_BONE_INFLUENCES];
		float boneWeight[NUM_BONE_INFLUENCES];
	};
	struct SkinningVertexInput
	{
		byte boneIndex[NUM_BONE_INFLUENCES];
		float boneWeight[NUM_BONE_INFLUENCES];
	};


	//
	//
	///////////////////////////////////////////////////////////////////////////////////////////


	///////////////////////////////////////////////////////////////////////////////////////////
	//
	// Camera class provides simple camera functionality.
	//
	class Camera
	{
	public:
		Camera()
		{
			DirectX::XMMATRIX identity = DirectX::XMMatrixIdentity();
			DirectX::XMStoreFloat4x4(&m_view, identity);
			DirectX::XMStoreFloat4x4(&m_proj, identity);

			m_viewWidth = 1;
			m_viewHeight = 1;

			m_position = DirectX::XMFLOAT3(0.0f, 0.0f, 0.0f);
			m_lookAt = DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f);
			m_up = DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f);
		}

		const DirectX::XMFLOAT4X4& GetView() const { return m_view; }
		const DirectX::XMFLOAT4X4& GetProjection() const { return m_proj; }
		const DirectX::XMFLOAT4X4& GetOrientationMatrix() const { return m_orientationMatrix; }

		const DirectX::XMFLOAT3& GetPosition() const { return m_position; }
		const DirectX::XMFLOAT3& GetLookAt() const { return m_lookAt; }
		const DirectX::XMFLOAT3& GetUpVector() const { return m_up; }

		void SetViewport(UINT w, UINT h)
		{
			m_viewWidth = w;
			m_viewHeight = h;
		}

		void SetProjection(float fovY, float aspect, float zn, float zf)
		{
			DirectX::XMMATRIX p = DirectX::XMMatrixPerspectiveFovRH(fovY, aspect, zn, zf);
			XMStoreFloat4x4(&m_proj, p);
		}

		void SetProjectionOrthographic(float viewWidth, float viewHeight, float zn, float zf)
		{
			DirectX::XMMATRIX p = DirectX::XMMatrixOrthographicRH(viewWidth, viewHeight, zn, zf);
			XMStoreFloat4x4(&m_proj, p);
		}

		void SetProjectionOrthographicOffCenter(float viewLeft, float viewRight, float viewBottom, float viewTop, float zn, float zf)
		{
			DirectX::XMMATRIX p = DirectX::XMMatrixOrthographicOffCenterRH(viewLeft, viewRight, viewBottom, viewTop, zn, zf);
			XMStoreFloat4x4(&m_proj, p);
		}

		void SetPosition(const DirectX::XMFLOAT3& position)
		{
			m_position = position;
			this->UpdateView();
		}

		void SetLookAt(const DirectX::XMFLOAT3& lookAt)
		{
			m_lookAt = lookAt;
			this->UpdateView();
		}

		void SetUpVector(const DirectX::XMFLOAT3& up)
		{
			m_up = up;
			this->UpdateView();
		}

		void SetOrientationMatrix(const DirectX::XMFLOAT4X4& orientationMatrix)
		{
			m_orientationMatrix = orientationMatrix;
		}

		void GetWorldLine(UINT pixelX, UINT pixelY, DirectX::XMFLOAT3* outPoint, DirectX::XMFLOAT3* outDir)
		{
			DirectX::XMFLOAT4 p0 = DirectX::XMFLOAT4((float)pixelX, (float)pixelY, 0, 1);
			DirectX::XMFLOAT4 p1 = DirectX::XMFLOAT4((float)pixelX, (float)pixelY, 1, 1);

			DirectX::XMVECTOR screen0 = DirectX::XMLoadFloat4(&p0);
			DirectX::XMVECTOR screen1 = DirectX::XMLoadFloat4(&p1);

			DirectX::XMMATRIX projMat = XMLoadFloat4x4(&m_proj);
			DirectX::XMMATRIX viewMat = XMLoadFloat4x4(&m_view);

			DirectX::XMVECTOR pp0 = DirectX::XMVector3Unproject(screen0, 0, 0, (float)m_viewWidth, (float)m_viewHeight, 0, 1, projMat, viewMat, DirectX::XMMatrixIdentity());
			DirectX::XMVECTOR pp1 = DirectX::XMVector3Unproject(screen1, 0, 0, (float)m_viewWidth, (float)m_viewHeight, 0, 1, projMat, viewMat, DirectX::XMMatrixIdentity());

			DirectX::XMStoreFloat3(outPoint, pp0);
			DirectX::XMStoreFloat3(outDir, pp1);

			outDir->x -= outPoint->x;
			outDir->y -= outPoint->y;
			outDir->z -= outPoint->z;
		}

	private:
		void UpdateView()
		{
			DirectX::XMVECTOR vPosition = DirectX::XMLoadFloat3(&m_position);
			DirectX::XMVECTOR vLook = DirectX::XMLoadFloat3(&m_lookAt);
			DirectX::XMVECTOR vUp = DirectX::XMLoadFloat3(&m_up);

			DirectX::XMMATRIX v = DirectX::XMMatrixLookAtRH(vPosition, vLook, vUp);
			DirectX::XMStoreFloat4x4(&m_view, v);
		}

		DirectX::XMFLOAT4X4 m_view;
		DirectX::XMFLOAT4X4 m_proj;
		DirectX::XMFLOAT4X4 m_orientationMatrix;
		DirectX::XMFLOAT3 m_position;
		DirectX::XMFLOAT3 m_lookAt;
		DirectX::XMFLOAT3 m_up;
		UINT m_viewWidth;
		UINT m_viewHeight;
	};
	//
	//
	///////////////////////////////////////////////////////////////////////////////////////////


	///////////////////////////////////////////////////////////////////////////////////////////
	//
	// Graphics wraps D3D engine and related constant buffers
	//
	class Graphics
	{
	public:
		// Construction / destruction.
		Graphics()
		{
		}

		~Graphics()
		{
			this->Shutdown();
		}

		// Initializes the Graphics object.
		void Initialize(ID3D11Device* device, ID3D11DeviceContext* deviceContext, D3D_FEATURE_LEVEL deviceFeatureLevel)
		{
			// Make sure this is shutdown before initializing.
			this->Shutdown();

			// Store the device interfaces and feature level.
			m_device = device;
			m_deviceContext = deviceContext;
			m_deviceFeatureLevel = deviceFeatureLevel;

			// Create the constant buffers.
			D3D11_BUFFER_DESC bufferDesc;
			bufferDesc.Usage = D3D11_USAGE_DEFAULT;
			bufferDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
			bufferDesc.CPUAccessFlags = 0;
			bufferDesc.MiscFlags = 0;
			bufferDesc.StructureByteStride = 0;

			bufferDesc.ByteWidth = sizeof(MaterialConstants);
			m_device->CreateBuffer(&bufferDesc, nullptr, &m_materialConstants);

			bufferDesc.ByteWidth = sizeof(LightConstants);
			m_device->CreateBuffer(&bufferDesc, nullptr, &m_lightConstants);

			bufferDesc.ByteWidth = sizeof(ObjectConstants);
			m_device->CreateBuffer(&bufferDesc, nullptr, &m_objectConstants);

			bufferDesc.ByteWidth = sizeof(MiscConstants);
			m_device->CreateBuffer(&bufferDesc, nullptr, &m_miscConstants);

			// Create the sampler state.
			D3D11_SAMPLER_DESC samplerDesc;
			samplerDesc.Filter = D3D11_FILTER_ANISOTROPIC;
			samplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_WRAP;
			samplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_WRAP;
			samplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_WRAP;
			samplerDesc.MipLODBias = 0.0f;
			samplerDesc.MaxAnisotropy = m_deviceFeatureLevel <= D3D_FEATURE_LEVEL_9_1 ? 2 : 4;
			samplerDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;
			samplerDesc.BorderColor[0] = 0.0f;
			samplerDesc.BorderColor[1] = 0.0f;
			samplerDesc.BorderColor[2] = 0.0f;
			samplerDesc.BorderColor[3] = 0.0f;
			samplerDesc.MinLOD = 0;
			samplerDesc.MaxLOD = D3D11_FLOAT32_MAX;
			m_device->CreateSamplerState(&samplerDesc, &m_sampler);

			// Create the vertex layout.
			D3D11_INPUT_ELEMENT_DESC layout[] =
			{
				{ "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "NORMAL", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "TANGENT", 0, DXGI_FORMAT_R32G32B32A32_FLOAT, 0, 24, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "COLOR", 0, DXGI_FORMAT_R8G8B8A8_UNORM, 0, 40, D3D11_INPUT_PER_VERTEX_DATA, 0 },
				{ "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 44, D3D11_INPUT_PER_VERTEX_DATA, 0 },
			};
			m_device->CreateInputLayout(layout, _countof(layout), VSD3DStarter_VS, _countof(VSD3DStarter_VS), &m_vertexLayout);

			// Create the vertex shader.
			m_device->CreateVertexShader(VSD3DStarter_VS, _countof(VSD3DStarter_VS), nullptr, &m_vertexShader);

			// Create the null texture (a 1x1 white texture so shaders work when textures are not set on meshes correctly).
			D3D11_TEXTURE2D_DESC desc;
			desc.Width = 1;
			desc.Height = 1;
			desc.MipLevels = 1;
			desc.ArraySize = 1;
			desc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;
			desc.SampleDesc.Count = 1;
			desc.SampleDesc.Quality = 0;
			desc.Usage = D3D11_USAGE_DEFAULT;
			desc.BindFlags = D3D11_BIND_SHADER_RESOURCE;
			desc.CPUAccessFlags = 0;
			desc.MiscFlags = 0;
			m_device->CreateTexture2D(&desc, nullptr, &m_nullTexture);

			INT32 white = 0xffffffff;
			m_deviceContext->UpdateSubresource(m_nullTexture.Get(), 0, nullptr, &white, sizeof(white), sizeof(white));

			Microsoft::WRL::ComPtr<ID3D11ShaderResourceView> nullTextureView;
			m_device->CreateShaderResourceView(m_nullTexture.Get(), nullptr, &nullTextureView);
			m_textureResources[L""] = nullTextureView;
		}

		// Shuts down the Graphics object.
		void Shutdown()
		{
			m_pixelShaderResources.clear();
			m_textureResources.clear();
		}

		// Accessors.
		Camera& GetCamera() const { return m_camera; }

		ID3D11Device* GetDevice() const { return m_device.Get(); }
		ID3D11DeviceContext* GetDeviceContext() const { return m_deviceContext.Get(); }
		D3D_FEATURE_LEVEL GetDeviceFeatureLevel() const { return m_deviceFeatureLevel; }

		ID3D11Buffer* GetMaterialConstants() const { return m_materialConstants.Get(); }
		ID3D11Buffer* GetLightConstants() const { return m_lightConstants.Get(); }
		ID3D11Buffer* GetObjectConstants() const { return m_objectConstants.Get(); }
		ID3D11Buffer* GetMiscConstants() const { return m_miscConstants.Get(); }

		ID3D11SamplerState* GetSamplerState() const { return m_sampler.Get(); }
		ID3D11InputLayout* GetVertexInputLayout() const { return m_vertexLayout.Get(); }
		ID3D11VertexShader* GetVertexShader() const { return m_vertexShader.Get(); }

		concurrency::task<ID3D11PixelShader*> GetOrCreatePixelShaderAsync(const std::wstring& shaderName)
		{
			auto iter = m_pixelShaderResources.find(shaderName);
			if (iter != m_pixelShaderResources.end())
			{
				return concurrency::extras::create_value_task(iter->second.Get());
			}
			else
			{
				std::vector<BYTE> psBuffer;
				return DX::ReadDataAsync(shaderName).then([this, shaderName](const std::vector<byte>& psBuffer) -> ID3D11PixelShader*
				{
					Microsoft::WRL::ComPtr<ID3D11PixelShader> result = nullptr;

					if (psBuffer.size() > 0)
					{
						this->GetDevice()->CreatePixelShader(&psBuffer[0], psBuffer.size(), nullptr, result.GetAddressOf());
						if (result == nullptr)
						{
							throw std::exception("Pixel Shader could not be created");
						}

						m_pixelShaderResources[shaderName] = result;

						return result.Get();
					}
					else
					{
						return nullptr;
					}
				});
			}
		}

		concurrency::task<ID3D11ShaderResourceView*> GetOrCreateTextureAsync(const std::wstring& textureName)
		{
			auto iter = m_textureResources.find(textureName);
			if (iter != m_textureResources.end())
			{
				return concurrency::extras::create_value_task(iter->second.Get());
			}
			else
			{
				std::vector<BYTE> ddsBuffer;
				return DX::ReadDataAsync(textureName).then([this, textureName](const std::vector<byte>& ddsBuffer) -> ID3D11ShaderResourceView*
				{
					if (ddsBuffer.size() > 0)
					{
						Microsoft::WRL::ComPtr<ID3D11ShaderResourceView> result(this->CreateTextureFromDDSInMemory(&ddsBuffer[0], ddsBuffer.size()));
						if (result == nullptr)
						{
							throw std::exception("Texture could not be created");
						}
						m_textureResources[textureName] = result;

						return result.Get();
					}
					else
					{
						return nullptr;
					}
				});
			}
		}

		// Methods to update constant buffers.
		void UpdateMaterialConstants(const MaterialConstants& data) const
		{
			m_deviceContext->UpdateSubresource(m_materialConstants.Get(), 0, nullptr, &data, 0, 0);
		}
		void UpdateLightConstants(const LightConstants& data) const
		{
			m_deviceContext->UpdateSubresource(m_lightConstants.Get(), 0, nullptr, &data, 0, 0);
		}
		void UpdateObjectConstants(const ObjectConstants& data) const
		{
			m_deviceContext->UpdateSubresource(m_objectConstants.Get(), 0, nullptr, &data, 0, 0);
		}
		void UpdateMiscConstants(const MiscConstants& data) const
		{
			m_deviceContext->UpdateSubresource(m_miscConstants.Get(), 0, nullptr, &data, 0, 0);
		}

	private:
		ID3D11ShaderResourceView* CreateTextureFromDDSInMemory(const BYTE* ddsData, size_t ddsDataSize)
		{
			ID3D11ShaderResourceView* textureView = nullptr;

			if (ddsData != nullptr && ddsDataSize > 0)
			{
				HRESULT hr = DirectX::CreateDDSTextureFromMemory(m_device.Get(), ddsData, ddsDataSize, nullptr, &textureView);

				if (FAILED(hr))
				{
					SafeRelease(textureView);
				}
				else
				{
					return textureView;
				}
			}

			return nullptr;
		}

		std::map<std::wstring, Microsoft::WRL::ComPtr<ID3D11PixelShader>> m_pixelShaderResources;
		std::map<std::wstring, Microsoft::WRL::ComPtr<ID3D11ShaderResourceView>> m_textureResources;

		mutable Camera m_camera;

		Microsoft::WRL::ComPtr<ID3D11Device> m_device;
		Microsoft::WRL::ComPtr<ID3D11DeviceContext> m_deviceContext;
		D3D_FEATURE_LEVEL m_deviceFeatureLevel;

		Microsoft::WRL::ComPtr<ID3D11Buffer> m_materialConstants;
		Microsoft::WRL::ComPtr<ID3D11Buffer> m_lightConstants;
		Microsoft::WRL::ComPtr<ID3D11Buffer> m_objectConstants;
		Microsoft::WRL::ComPtr<ID3D11Buffer> m_miscConstants;

		Microsoft::WRL::ComPtr<ID3D11SamplerState> m_sampler;
		Microsoft::WRL::ComPtr<ID3D11InputLayout> m_vertexLayout;
		Microsoft::WRL::ComPtr<ID3D11VertexShader> m_vertexShader;
		Microsoft::WRL::ComPtr<ID3D11Texture2D> m_nullTexture;
	};
	//
	//
	///////////////////////////////////////////////////////////////////////////////////////////


	///////////////////////////////////////////////////////////////////////////////////////////
	//
	// Mesh is a class used to display meshes in 3d which are converted
	// during build-time from fbx and dgsl files.
	//
	class Mesh
	{
	public:
		static const UINT MaxTextures = 8;  // 8 unique textures are supported.

		struct SubMesh
		{
			SubMesh() : MaterialIndex(0), IndexBufferIndex(0), VertexBufferIndex(0), StartIndex(0), PrimCount(0) {}

			UINT MaterialIndex;
			UINT IndexBufferIndex;
			UINT VertexBufferIndex;
			UINT StartIndex;
			UINT PrimCount;
		};

		struct Material
		{
			Material() { ZeroMemory(this, sizeof(Material)); }
			~Material() {}

			std::wstring Name;

			DirectX::XMFLOAT4X4 UVTransform;

			float Ambient[4];
			float Diffuse[4];
			float Specular[4];
			float Emissive[4];
			float SpecularPower;

			Microsoft::WRL::ComPtr<ID3D11ShaderResourceView> Textures[MaxTextures];
			Microsoft::WRL::ComPtr<ID3D11VertexShader> VertexShader;
			Microsoft::WRL::ComPtr<ID3D11PixelShader> PixelShader;
			Microsoft::WRL::ComPtr<ID3D11SamplerState> SamplerState;
		};

		struct MeshExtents
		{
			float CenterX, CenterY, CenterZ;
			float Radius;

			float MinX, MinY, MinZ;
			float MaxX, MaxY, MaxZ;
		};

		struct Triangle
		{
			DirectX::XMFLOAT3 points[3];
		};

		typedef std::vector<Triangle> TriangleCollection;

		struct BoneInfo
		{
			std::wstring Name;
			INT ParentIndex;
			DirectX::XMFLOAT4X4 InvBindPos;
			DirectX::XMFLOAT4X4 BindPose;
			DirectX::XMFLOAT4X4 BoneLocalTransform;
		};

		struct Keyframe
		{
			Keyframe() : BoneIndex(0), Time(0.0f) {}

			UINT BoneIndex;
			float Time;
			DirectX::XMFLOAT4X4 Transform;
		};

		typedef std::vector<Keyframe> KeyframeArray;

		struct AnimClip
		{
			float StartTime;
			float EndTime;
			KeyframeArray Keyframes;
		};

		typedef std::map<const std::wstring, AnimClip> AnimationClipMap;

		// Access to mesh data.
		std::vector<SubMesh>& SubMeshes() { return m_submeshes; }
		std::vector<Material>& Materials() { return m_materials; }
		std::vector<ID3D11Buffer*>& VertexBuffers() { return m_vertexBuffers; }
		std::vector<ID3D11Buffer*>& SkinningVertexBuffers() { return m_skinningVertexBuffers; }
		std::vector<ID3D11Buffer*>& IndexBuffers() { return m_indexBuffers; }
		MeshExtents& Extents() { return m_meshExtents; }
		AnimationClipMap& AnimationClips() { return m_animationClips; }
		std::vector<BoneInfo>& BoneInfoCollection() { return m_boneInfo; }
		TriangleCollection& Triangles() { return m_triangles; }
		const wchar_t* Name() const { return m_name.c_str(); }

		void* Tag;

		// Destructor.
		~Mesh()
		{
			for (ID3D11Buffer *ib : m_indexBuffers)
			{
				SafeRelease(ib);
			}

			for (ID3D11Buffer *vb : m_vertexBuffers)
			{
				SafeRelease(vb);
			}

			for (ID3D11Buffer *svb : m_skinningVertexBuffers)
			{
				SafeRelease(svb);
			}

			m_submeshes.clear();
			m_materials.clear();
			m_indexBuffers.clear();
			m_vertexBuffers.clear();
			m_skinningVertexBuffers.clear();
		}

		// Render the mesh to the current render target.
		void Render(const Graphics& graphics, const DirectX::XMMATRIX& world)
		{
			ID3D11DeviceContext* deviceContext = graphics.GetDeviceContext();

			BOOL supportsShaderResources = graphics.GetDeviceFeatureLevel() >= D3D_FEATURE_LEVEL_10_0;

			const DirectX::XMMATRIX& view = DirectX::XMLoadFloat4x4(&graphics.GetCamera().GetView());
			const DirectX::XMMATRIX& projection = DirectX::XMLoadFloat4x4(&graphics.GetCamera().GetProjection()) * DirectX::XMLoadFloat4x4(&graphics.GetCamera().GetOrientationMatrix());

			// Compute the object matrices.
			DirectX::XMMATRIX localToView = world * view;
			DirectX::XMMATRIX localToProj = world * view * projection;

			// Initialize object constants and update the constant buffer.
			ObjectConstants objConstants;
			objConstants.LocalToWorld4x4 = DirectX::XMMatrixTranspose(world);
			objConstants.LocalToProjected4x4 = DirectX::XMMatrixTranspose(localToProj);
			objConstants.WorldToLocal4x4 = DirectX::XMMatrixTranspose(DirectX::XMMatrixInverse(nullptr, world));
			objConstants.WorldToView4x4 = DirectX::XMMatrixTranspose(view);
			objConstants.UvTransform4x4 = DirectX::XMMatrixIdentity();
			objConstants.EyePosition = graphics.GetCamera().GetPosition();
			graphics.UpdateObjectConstants(objConstants);

			// Assign the constant buffers to correct slots.
			ID3D11Buffer* constantBuffer = graphics.GetLightConstants();
			deviceContext->VSSetConstantBuffers(1, 1, &constantBuffer);
			deviceContext->PSSetConstantBuffers(1, 1, &constantBuffer);

			constantBuffer = graphics.GetMiscConstants();
			deviceContext->VSSetConstantBuffers(3, 1, &constantBuffer);
			deviceContext->PSSetConstantBuffers(3, 1, &constantBuffer);

			// Prepare to draw.
			deviceContext->IASetInputLayout(graphics.GetVertexInputLayout());
			deviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

			// Loop over each submesh.
			for (SubMesh& submesh : m_submeshes)
			{
				// Only draw submeshes that have valid materials.
				MaterialConstants materialConstants;

				if (submesh.IndexBufferIndex < m_indexBuffers.size() &&
					submesh.VertexBufferIndex < m_vertexBuffers.size())
				{
					UINT stride = sizeof(Vertex);
					UINT offset = 0;
					deviceContext->IASetVertexBuffers(0, 1, &m_vertexBuffers[submesh.VertexBufferIndex], &stride, &offset);
					deviceContext->IASetIndexBuffer(m_indexBuffers[submesh.IndexBufferIndex], DXGI_FORMAT_R16_UINT, 0);
				}

				if (submesh.MaterialIndex < m_materials.size())
				{
					Material& material = m_materials[submesh.MaterialIndex];

					// Update the material constant buffer.
					memcpy(&materialConstants.Ambient, material.Ambient, sizeof(material.Ambient));
					memcpy(&materialConstants.Diffuse, material.Diffuse, sizeof(material.Diffuse));
					memcpy(&materialConstants.Specular, material.Specular, sizeof(material.Specular));
					memcpy(&materialConstants.Emissive, material.Emissive, sizeof(material.Emissive));
					materialConstants.SpecularPower = material.SpecularPower;

					graphics.UpdateMaterialConstants(materialConstants);

					// Assign the material buffer to correct slots.
					constantBuffer = graphics.GetMaterialConstants();
					deviceContext->VSSetConstantBuffers(0, 1, &constantBuffer);
					deviceContext->PSSetConstantBuffers(0, 1, &constantBuffer);

					// Update the UV transform.
					memcpy(&objConstants.UvTransform4x4, &material.UVTransform, sizeof(objConstants.UvTransform4x4));
					graphics.UpdateObjectConstants(objConstants);

					constantBuffer = graphics.GetObjectConstants();
					deviceContext->VSSetConstantBuffers(2, 1, &constantBuffer);
					deviceContext->PSSetConstantBuffers(2, 1, &constantBuffer);

					// Assign the shaders, samplers and texture resources.
					ID3D11SamplerState* sampler = material.SamplerState.Get();

					deviceContext->VSSetShader(material.VertexShader.Get(), nullptr, 0);
					if (supportsShaderResources)
					{
						deviceContext->VSSetSamplers(0, 1, &sampler);
					}

					deviceContext->PSSetShader(material.PixelShader.Get(), nullptr, 0);
					deviceContext->PSSetSamplers(0, 1, &sampler);

					for (UINT tex = 0; tex < MaxTextures; tex++)
					{
						ID3D11ShaderResourceView* texture = material.Textures[tex].Get();

						if (supportsShaderResources)
						{
							deviceContext->VSSetShaderResources(0 + tex, 1, &texture);
							deviceContext->VSSetShaderResources(MaxTextures + tex, 1, &texture);
						}

						deviceContext->PSSetShaderResources(0 + tex, 1, &texture);
						deviceContext->PSSetShaderResources(MaxTextures + tex, 1, &texture);
					}

					// Draw the submesh.
					deviceContext->DrawIndexed(submesh.PrimCount * 3, submesh.StartIndex, 0);
				}
			}
		}

		// Loads a scene from the specified file, returning a vector of mesh objects.
		static concurrency::task<void> LoadFromFileAsync(
			Graphics& graphics,
			const std::wstring& meshFilename,
			const std::wstring& shaderPathLocation,
			const std::wstring& texturePathLocation,
			std::vector<Mesh*>& loadedMeshes,
			bool clearLoadedMeshesVector = true
			)
		{
			// Clear the output vector.
			if (clearLoadedMeshesVector)
			{
				loadedMeshes.clear();
			}

			auto folder = Windows::ApplicationModel::Package::Current->InstalledLocation;

			// Start by loading the file.
			return concurrency::create_task(folder->GetFileAsync(Platform::StringReference(meshFilename.c_str())))
				// Then open the file.
				.then([](Windows::Storage::StorageFile^ file)
			{
				return Windows::Storage::FileIO::ReadBufferAsync(file);
			})
				// Then read the meshes.
				.then([&graphics, shaderPathLocation, texturePathLocation, &loadedMeshes](Windows::Storage::Streams::IBuffer^ buffer)
			{
				auto reader = Windows::Storage::Streams::DataReader::FromBuffer(buffer);
				reader->ByteOrder = Windows::Storage::Streams::ByteOrder::LittleEndian;
				reader->UnicodeEncoding = Windows::Storage::Streams::UnicodeEncoding::Utf8;

				// Read how many meshes are part of the scene.
				std::shared_ptr<UINT> remainingMeshesToRead = std::make_shared<UINT>(reader->ReadUInt32());

				if (*remainingMeshesToRead == 0)
				{
					return concurrency::create_task([](){});
				}

				// For each mesh in the scene, load it from the file.

				return concurrency::extras::create_iterative_task([reader, &graphics, shaderPathLocation, texturePathLocation, &loadedMeshes, remainingMeshesToRead]()
				{
					return Mesh::ReadAsync(reader, graphics, shaderPathLocation, texturePathLocation)
						.then([&loadedMeshes, remainingMeshesToRead](Mesh* mesh) -> bool
					{
						if (mesh != nullptr)
						{
							loadedMeshes.push_back(mesh);
						}

						// Return true to continue iterating, false to stop.

						*remainingMeshesToRead = *remainingMeshesToRead - 1;

						return *remainingMeshesToRead > 0;
					});
				});
			});
		}

	private:
		Mesh()
		{
			Tag = nullptr;
		}

		static void StripPath(std::wstring& path)
		{
			size_t p = path.rfind(L"\\");
			if (p != std::wstring::npos)
			{
				path = path.substr(p + 1);
			}
		}

		template <typename T>
		static void ReadStruct(Windows::Storage::Streams::DataReader^ reader, T* output, size_t size = sizeof(T))
		{
			reader->ReadBytes(Platform::ArrayReference<BYTE>((BYTE*)output, size));
		}

		// Reads a string converted from an array of wchar_t of given size using a DataReader.
		static void ReadString(Windows::Storage::Streams::DataReader^ reader, std::wstring* output, unsigned int count)
		{
			if (count == 0)
			{
				return;
			}

			std::vector<wchar_t> characters(count);
			ReadStruct(reader, &characters[0], count * sizeof(wchar_t));
			*output = &characters[0];
		}

		// Reads a string converted from an array of wchar_t using a DataReader.
		static void ReadString(Windows::Storage::Streams::DataReader^ reader, std::wstring* output)
		{
			UINT count = reader->ReadUInt32();
			ReadString(reader, output, count);
		}

		static concurrency::task<Mesh*> ReadAsync(Windows::Storage::Streams::DataReader^ reader, Graphics& graphics, const std::wstring& shaderPathLocation, const std::wstring& texturePathLocation)
		{
			std::vector<concurrency::task<void>> innerTasks;

			// Initialize output mesh.
			if (reader == nullptr)
			{
				return concurrency::extras::create_value_task<Mesh*>(nullptr);
			}

			Mesh* mesh = new Mesh();

			ReadString(reader, &mesh->m_name);

			// Read material count.
			UINT numMaterials = reader->ReadUInt32();
			mesh->m_materials.resize(numMaterials);

			// Load each material.
			for (UINT i = 0; i < numMaterials; i++)
			{
				Material& material = mesh->m_materials[i];

				// Read the material name.
				ReadString(reader, &material.Name);

				// Read the ambient and diffuse properties of material.

				ReadStruct(reader, &material.Ambient, sizeof(material.Ambient));
				ReadStruct(reader, &material.Diffuse, sizeof(material.Diffuse));
				ReadStruct(reader, &material.Specular, sizeof(material.Specular));
				ReadStruct(reader, &material.SpecularPower);
				ReadStruct(reader, &material.Emissive, sizeof(material.Emissive));
				ReadStruct(reader, &material.UVTransform);

				// Assign the vertex shader and sampler state.
				material.VertexShader = graphics.GetVertexShader();

				material.SamplerState = graphics.GetSamplerState();

				// Read the size of the name of the pixel shader.
				UINT stringLen = reader->ReadUInt32();
				if (stringLen > 0)
				{
					// Read the pixel shader name.
					std::wstring sourceFile;
					ReadString(reader, &sourceFile, stringLen);

					// Continue loading pixel shader if name is not empty.
					if (!sourceFile.empty())
					{
						// Create well-formed file name for the pixel shader.
						Mesh::StripPath(sourceFile);

						// Use fallback shader if Pixel Shader Model 4.0 is not supported.
						if (graphics.GetDeviceFeatureLevel() < D3D_FEATURE_LEVEL_10_0)
						{
							// This device is not compatible with Pixel Shader Model 4.0.
							// Try to fall back to a shader with the same name but compiled from HLSL.
							size_t lastUnderline = sourceFile.find_last_of('_');
							size_t firstDotAfterLastUnderline = sourceFile.find_first_of('.', lastUnderline);
							sourceFile = sourceFile.substr(lastUnderline + 1, firstDotAfterLastUnderline - lastUnderline) + L"cso";
						}

						// Append the base path.
						sourceFile = shaderPathLocation + sourceFile;

						// Get or create the pixel shader.
						innerTasks.push_back(graphics.GetOrCreatePixelShaderAsync(sourceFile).then([&material](ID3D11PixelShader* materialPixelShader)
						{
							material.PixelShader = materialPixelShader;
						}));
					}
				}

				// Load the textures.
				for (int t = 0; t < MaxTextures; t++)
				{
					// Read the size of the name of the texture.
					stringLen = reader->ReadUInt32();
					if (stringLen > 0)
					{
						// Read the texture name.
						std::wstring sourceFile;
						ReadString(reader, &sourceFile, stringLen);

						// Append the base path.
						sourceFile = texturePathLocation + sourceFile;

						// Get or create the texture.
						innerTasks.push_back(graphics.GetOrCreateTextureAsync(sourceFile).then([&material, t](ID3D11ShaderResourceView* textureResource)
						{
							material.Textures[t] = textureResource;
						}));
					}
				}
			}

			// Does this object contain skeletal animation?
			BYTE isSkeletalDataPresent = reader->ReadByte();

			// Read the submesh information.
			UINT numSubmeshes = reader->ReadUInt32();
			mesh->m_submeshes.resize(numSubmeshes);
			for (UINT i = 0; i < numSubmeshes; i++)
			{
				SubMesh& submesh = mesh->m_submeshes[i];
				submesh.MaterialIndex = reader->ReadUInt32();
				submesh.IndexBufferIndex = reader->ReadUInt32();
				submesh.VertexBufferIndex = reader->ReadUInt32();
				submesh.StartIndex = reader->ReadUInt32();
				submesh.PrimCount = reader->ReadUInt32();
			}

			// Read the index buffers.
			UINT numIndexBuffers = reader->ReadUInt32();
			mesh->m_indexBuffers.resize(numIndexBuffers);

			std::vector<std::vector<USHORT>> indexBuffers(numIndexBuffers);

			for (UINT i = 0; i < numIndexBuffers; i++)
			{
				UINT ibCount = reader->ReadUInt32();
				if (ibCount > 0)
				{
					indexBuffers[i].resize(ibCount);

					// Read in the index data.
					for (USHORT& component : indexBuffers[i])
					{
						component = reader->ReadUInt16();
					}

					// Create an index buffer for this data.
					D3D11_BUFFER_DESC bd = { 0 };
					bd.Usage = D3D11_USAGE_DEFAULT;
					bd.ByteWidth = sizeof(USHORT)* ibCount;
					bd.BindFlags = D3D11_BIND_INDEX_BUFFER;
					bd.CPUAccessFlags = 0;

					D3D11_SUBRESOURCE_DATA initData = { 0 };
					initData.pSysMem = &indexBuffers[i][0];

					graphics.GetDevice()->CreateBuffer(&bd, &initData, &mesh->m_indexBuffers[i]);
				}
			}

			// Read the vertex buffers.
			UINT numVertexBuffers = reader->ReadUInt32();
			mesh->m_vertexBuffers.resize(numVertexBuffers);

			std::vector<std::vector<Vertex>> vertexBuffers(numVertexBuffers);

			for (UINT i = 0; i < numVertexBuffers; i++)
			{
				UINT vbCount = reader->ReadUInt32();
				if (vbCount > 0)
				{
					vertexBuffers[i].resize(vbCount);

					// Read in the vertex data.
					ReadStruct(reader, &vertexBuffers[i][0], vbCount * sizeof(Vertex));

					// Create a vertex buffer for this data.
					D3D11_BUFFER_DESC bd = { 0 };
					bd.Usage = D3D11_USAGE_DEFAULT;
					bd.ByteWidth = sizeof(Vertex)* vbCount;
					bd.BindFlags = D3D11_BIND_VERTEX_BUFFER;
					bd.CPUAccessFlags = 0;

					D3D11_SUBRESOURCE_DATA initData = { 0 };
					initData.pSysMem = &vertexBuffers[i][0];

					graphics.GetDevice()->CreateBuffer(&bd, &initData, &mesh->m_vertexBuffers[i]);
				}
			}

			// Create the triangle array for each submesh.
			for (SubMesh& subMesh : mesh->m_submeshes)
			{
				std::vector<USHORT>& ib = indexBuffers[subMesh.IndexBufferIndex];
				std::vector<Vertex>& vb = vertexBuffers[subMesh.VertexBufferIndex];

				for (UINT j = 0; j < ib.size(); j += 3)
				{
					Vertex& v0 = vb[ib[j]];
					Vertex& v1 = vb[ib[j + 1]];
					Vertex& v2 = vb[ib[j + 2]];

					Triangle tri;
					tri.points[0].x = v0.x;
					tri.points[0].y = v0.y;
					tri.points[0].z = v0.z;

					tri.points[1].x = v1.x;
					tri.points[1].y = v1.y;
					tri.points[1].z = v1.z;

					tri.points[2].x = v2.x;
					tri.points[2].y = v2.y;
					tri.points[2].z = v2.z;

					mesh->m_triangles.push_back(tri);
				}
			}

			// Clear the temporary buffers.
			vertexBuffers.clear();
			indexBuffers.clear();

			// Read the skinning vertex buffers.
			UINT numSkinningVertexBuffers = reader->ReadUInt32();
			mesh->m_skinningVertexBuffers.resize(numSkinningVertexBuffers);
			for (UINT i = 0; i < numSkinningVertexBuffers; i++)
			{
				UINT vbCount = reader->ReadUInt32();
				if (vbCount > 0)
				{
					std::vector<SkinningVertexInput> verts(vbCount);

					// Read in the vertex data.
					for (SkinningVertexInput& vertex : verts)
					{
						for (size_t j = 0; j < NUM_BONE_INFLUENCES; j++)
						{
							// Convert indices to byte (to support D3D Feature Level 9).
							vertex.boneIndex[j] = (byte)reader->ReadUInt32();
						}
						for (size_t j = 0; j < NUM_BONE_INFLUENCES; j++)
						{
							vertex.boneWeight[j] = reader->ReadSingle();
						}
					}

					// Create a vertex buffer for this data.
					D3D11_BUFFER_DESC bd = { 0 };
					bd.Usage = D3D11_USAGE_DEFAULT;
					bd.ByteWidth = sizeof(SkinningVertexInput)* vbCount;
					bd.BindFlags = D3D11_BIND_VERTEX_BUFFER;
					bd.CPUAccessFlags = 0;

					D3D11_SUBRESOURCE_DATA initData = { 0 };
					initData.pSysMem = &verts[0];

					graphics.GetDevice()->CreateBuffer(&bd, &initData, &mesh->m_skinningVertexBuffers[i]);
				}
			}

			// Read the mesh extents.
			ReadStruct(reader, &mesh->m_meshExtents);

			// Read bones and animation information if needed.
			if (isSkeletalDataPresent)
			{
				// Read bone information.
				UINT boneCount = reader->ReadUInt32();

				mesh->m_boneInfo.resize(boneCount);

				for (BoneInfo& bone : mesh->m_boneInfo)
				{
					// Read the bone name.
					ReadString(reader, &bone.Name);

					// Read the transforms.
					bone.ParentIndex = reader->ReadInt32();
					ReadStruct(reader, &bone.InvBindPos);
					ReadStruct(reader, &bone.BindPose);
					ReadStruct(reader, &bone.BoneLocalTransform);
				}

				// Read animation clips.
				UINT clipCount = reader->ReadUInt32();

				for (UINT j = 0; j < clipCount; j++)
				{
					// Read clip name.
					std::wstring clipName;
					ReadString(reader, &clipName);

					mesh->m_animationClips[clipName].StartTime = reader->ReadSingle();
					mesh->m_animationClips[clipName].EndTime = reader->ReadSingle();

					KeyframeArray& keyframes = mesh->m_animationClips[clipName].Keyframes;

					// Read keyframe count.
					UINT kfCount = reader->ReadUInt32();

					// Preallocate the memory.
					keyframes.reserve(kfCount);

					// Read each keyframe.
					for (UINT k = 0; k < kfCount; k++)
					{
						Keyframe kf;

						// Read the bone.
						kf.BoneIndex = reader->ReadUInt32();

						// Read the time.
						kf.Time = reader->ReadSingle();

						// Read the transform.
						ReadStruct(reader, &kf.Transform);

						// Add to the keyframe collection.
						keyframes.push_back(kf);
					}
				}
			}

			return concurrency::when_all(innerTasks.begin(), innerTasks.end()).then([mesh]()
			{
				return mesh;
			});
		}

		std::vector<SubMesh> m_submeshes;
		std::vector<Material> m_materials;
		std::vector<ID3D11Buffer*> m_vertexBuffers;
		std::vector<ID3D11Buffer*> m_skinningVertexBuffers;
		std::vector<ID3D11Buffer*> m_indexBuffers;
		TriangleCollection m_triangles;

		MeshExtents m_meshExtents;

		AnimationClipMap m_animationClips;
		std::vector<BoneInfo> m_boneInfo;

		std::wstring m_name;
	};
	//
	//
	///////////////////////////////////////////////////////////////////////////////////////////

}