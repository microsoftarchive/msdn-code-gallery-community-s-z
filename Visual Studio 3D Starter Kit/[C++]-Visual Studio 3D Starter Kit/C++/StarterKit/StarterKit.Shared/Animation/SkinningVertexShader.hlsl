// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved
//----------------------------------------------------------------------

#define MAX_BONES 59

cbuffer MaterialVars : register (b0)
{
    float4 MaterialAmbient;
    float4 MaterialDiffuse;
    float4 MaterialSpecular;
    float4 MaterialEmissive;
    float MaterialSpecularPower;
};

cbuffer LightVars : register (b1)
{
    float4 AmbientLight;
    float4 LightColor[4];
    float4 LightAttenuation[4];
    float3 LightDirection[4];
    float LightSpecularIntensity[4];
    uint IsPointLight[4];
    uint ActiveLights;
}

cbuffer ObjectVars : register(b2)
{
    float4x4 LocalToWorld4x4;
    float4x4 LocalToProjected4x4;
    float4x4 WorldToLocal4x4;
    float4x4 WorldToView4x4;
    float4x4 UVTransform4x4;
    float3 EyePosition;
};

cbuffer MiscVars : register(b3)
{
    float ViewportWidth;
    float ViewportHeight;
    float Time;
};

cbuffer BoneVars : register(b4)
{
    float4x4 Bones[MAX_BONES];
};

struct A2V
{
    float4 pos : POSITION0;
    float3 normal : NORMAL0;
    float4 tangent : TANGENT0;
    float4 color : COLOR0;
    float2 uv : TEXCOORD0;
    uint4 boneIndices : BLENDINDICES0;
    float4 blendWeights : BLENDWEIGHT0;
};

struct V2P
{
    float4 pos : SV_POSITION;
    float4 diffuse : COLOR;
    float2 uv : TEXCOORD0;
    float3 worldNorm : TEXCOORD1;
    float3 worldPos : TEXCOORD2;
    float3 toEye : TEXCOORD3;
    float4 tangent : TEXCOORD4;
    float3 normal : TEXCOORD5;
};

V2P main(A2V vertex)
{
    V2P result;

    float4x4 skinTransform = Bones[vertex.boneIndices.x] * vertex.blendWeights.x;
    skinTransform += Bones[vertex.boneIndices.y] * vertex.blendWeights.y;
    skinTransform += Bones[vertex.boneIndices.z] * vertex.blendWeights.z;
    skinTransform += Bones[vertex.boneIndices.w] * vertex.blendWeights.w;
    
    float4 skinnedPos = mul(vertex.pos, skinTransform);
    float3 skinnedNorm = mul(vertex.normal, (float3x3)skinTransform);
    float3 skinnedTan = mul((float3)vertex.tangent, (float3x3)skinTransform);
    
    // transform point into world space (for eye vector)
    float3 wp = mul(skinnedPos, LocalToWorld4x4).xyz;

    // set output data
    result.pos = mul(skinnedPos, LocalToProjected4x4);
    result.diffuse = vertex.color * MaterialDiffuse;
    result.uv = mul(float4(vertex.uv.x, vertex.uv.y, 0, 1), (float4x2)UVTransform4x4).xy;
    result.worldNorm = mul(skinnedNorm, (float3x3)LocalToWorld4x4);
    result.worldPos = wp;
    result.toEye = EyePosition - wp;
    result.normal = skinnedNorm;
    result.tangent = float4(skinnedTan.xyz, vertex.tangent.w);

    return result;
}