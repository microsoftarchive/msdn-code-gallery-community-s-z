// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

#include "VSD3DStarter.h"

#include <DirectXCollision.h>

namespace VSD3DStarter
{
	// Helper methods used for hit testing meshes
	class HitTestingHelpers
	{
	public:
		// Returns true if the given ray (p0, dir) intersects the bounding sphere of the given mesh. 
		// The outT parameter contains the length of the ray at the point of intersection.
		static bool LineSphereHitTest(Mesh& mesh, const DirectX::XMFLOAT3* p0, const DirectX::XMFLOAT3* dir, float* outT)
		{
			DirectX::XMFLOAT3 center(mesh.Extents().CenterX, mesh.Extents().CenterY, mesh.Extents().CenterZ);
			auto sphere = DirectX::BoundingSphere(center, mesh.Extents().Radius);
			return sphere.Intersects(XMLoadFloat3(p0), XMLoadFloat3(dir), *outT);
		}

		// Returns true if the given ray (p0, dir) intersects the given mesh, 
		// taking into account the transformation applied to the object.
		// The outT parameter contains the length of the ray at the point of intersection.
		static bool LineHitTest(Mesh& mesh, const DirectX::XMFLOAT3* p0, const DirectX::XMFLOAT3* dir, const DirectX::XMFLOAT4X4* objectWorldTransform, float* outT)
		{
			using namespace DirectX;

			XMMATRIX objInvMatrix = XMLoadFloat4x4(objectWorldTransform);

			objInvMatrix = XMMatrixInverse(nullptr, objInvMatrix);

			XMVECTOR p0Vec = XMVector3TransformCoord(XMLoadFloat3(p0), objInvMatrix);
			XMVECTOR dirVec = XMVector3Normalize(XMVector3TransformNormal(XMLoadFloat3(dir), objInvMatrix));

			XMFLOAT3 p0InObj;
			XMFLOAT3 dirInObj;

			XMStoreFloat3(&p0InObj, p0Vec);
			XMStoreFloat3(&dirInObj, dirVec);

			bool hit = false;
			float closestT = FLT_MAX;
			float t = 0;
			if (LineSphereHitTest(mesh, &p0InObj, &dirInObj, &t))
			{
				for (Mesh::Triangle& triangle : mesh.Triangles())
				{
					XMVECTOR triangleV0 = XMLoadFloat3(&triangle.points[0]);
					XMVECTOR triangleV1 = XMLoadFloat3(&triangle.points[1]);
					XMVECTOR triangleV2 = XMLoadFloat3(&triangle.points[2]);

					if (TriangleTests::Intersects(p0Vec, dirVec, triangleV0, triangleV1, triangleV2, t))
					{
						if (t >= 0 && t < closestT)
						{
							closestT = t;
							hit = true;
						}
					}
				}
			}

			*outT = closestT;
			return hit;
		}
	};
}
