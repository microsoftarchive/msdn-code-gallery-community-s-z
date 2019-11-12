// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

// *** Why do I need both the DGSL and the HLSL shader? ***
//
// The DGSL shaders are compiled using the Shader Graph Content Pipeline
// to Pixel Shader Model 4.0 (ps_4_0), which is only supported in devices
// that support Direct3D Feature Level 10.0.
//
// Since some older PCs, most ARM devices and Windows Phone 8 only support
// Direct3D Feature Level 9.1 or 9.3, you have to supply a fallback shader for
// those levels. 
//
// The Starter Kit will automatically look for a fallback shader if your device 
// does not support Feature Level 10.0 or higher. To do that, it will look for 
// a compiled shader with the same name as the DGSL file. 
// (e.g. GlowEffect.dgsl --> GlowEffect.cso)
// 
// NOTE: Please make sure not to use underscores (_) or dots (.) in your filenames, since 
// these characters are added to the DGSL filename in the Shader Graph Content Pipeline.
//
// This shader can be adapted from the DGSL by opening the DGSL shader on the 
// Shader Designer, selecting the Advanced menu -> Export.
// From the exported HLSL, you can change or remove features that are not compatible
// with your target feature level. 
// In this case we changed the exported HLSL to not use the Fresnel effect (line 275)
// so it would fit a Pixel Shader Model 4.0 Level 9.1 shader.
//
// Also, if you use the default Visual Studio material shaders (Phong/Lambert/Unlit),
// don't forget to add a fallback for them as well. You can find the DGSL source for those effects
// in the folder <Visual Studio install folder>\Common7\IDE\Extensions\Microsoft\VsGraphics\Assets\Effects\
//
// For more information on Direct3D Feature Levels please see:
// http://msdn.microsoft.com/en-us/library/windows/desktop/ff476876(v=vs.85).aspx
//

Texture2D Texture1 : register( t0 );
Texture2D Texture2 : register( t1 );
Texture2D Texture3 : register( t2 );
Texture2D Texture4 : register( t3 );
Texture2D Texture5 : register( t4 );
Texture2D Texture6 : register( t5 );
Texture2D Texture7 : register( t6 );
Texture2D Texture8 : register( t7 );

TextureCube CubeTexture1 : register( t8 );
TextureCube CubeTexture2 : register( t9 );
TextureCube CubeTexture3 : register( t10 );
TextureCube CubeTexture4 : register( t11 );
TextureCube CubeTexture5 : register( t12 );
TextureCube CubeTexture6 : register( t13 );
TextureCube CubeTexture7 : register( t14 );
TextureCube CubeTexture8 : register( t15 );

SamplerState TexSampler : register( s0 );

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

struct A2V
{
    float4 pos : POSITION0;
    float3 normal : NORMAL0;
    float4 tangent : TANGENT0;
    float4 color : COLOR0;
    float2 uv : TEXCOORD0;
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

struct P2F
{
    float4 fragment : SV_Target;
};

//
// desaturate
//
float3 Desaturate(
    float3 color, 
    float3 luminance, 
    float percent
    )
{
    float3 desatColor = dot(color, luminance);
    return lerp(color, desatColor, percent);
}

//
// fresnel falloff
//
float Fresnel(
    float3 surfaceNormal,
    float3 toEye,
    float exp
    )
{
    float x = 1 - saturate(dot(surfaceNormal, toEye));
    return pow(x, exp);
}

//
// panning offset
//
float2 PanningOffset(
    float2 sourceUV,
    float time,
    float speedX,
    float speedY
    )
{
    float2 uvOffset = float2(time, time) * float2(speedX, speedY);

    return sourceUV + uvOffset;
}

//
// parallax offset
//
float2 ParallaxOffset(
    float2 sourceUV,
    float height,
    float depthScale,
    float depthPlane,
    float3 tangentCameraVector
    )
{
    float bias = -(depthScale * depthPlane);
    float heightAdj = (depthScale * height) + bias;

    return sourceUV + (tangentCameraVector.xy * heightAdj);
}

//
// rotate offset
//
float2 RotateOffset(
    float2 sourceUV,
    float time,
    float centerX,
    float centerY,
    float speed
    )
{
    float2 ray = sourceUV - float2(centerX, centerY);
    float theta = time * speed;

    float cosTheta = cos(theta);
    float sinTheta = sin(theta);

    float2x2 rotMatrix = float2x2(float2(cosTheta, -sinTheta), float2(sinTheta, cosTheta));

    return mul(rotMatrix, ray) + float2(centerX, centerY);
}

//
// lambert lighting function
//
float3 LambertLighting(
    float3 lightNormal,
    float3 surfaceNormal,
    float3 materialAmbient,
    float3 lightAmbient,
    float3 lightColor,
    float3 pixelColor
    )
{
    // compute amount of contribution per light
    float diffuseAmount = saturate(dot(lightNormal, surfaceNormal));
    float3 diffuse = diffuseAmount * lightColor * pixelColor;

    // combine ambient with diffuse
    return saturate((materialAmbient * lightAmbient) + diffuse);
}

//
// specular contribution function
//
float3 SpecularContribution(
    float3 toEye,
    float3 lightNormal,
    float3 surfaceNormal,
    float3 materialSpecularColor,
    float materialSpecularPower,
    float lightSpecularIntensity,
    float3 lightColor
    )
{
    // compute specular contribution
    float3 vHalf = normalize(lightNormal + toEye);
    float specularAmount = saturate(dot(surfaceNormal, vHalf));
    specularAmount = pow(specularAmount, max(materialSpecularPower,0.0001f)) * lightSpecularIntensity;
    float3 specular = materialSpecularColor * lightColor * specularAmount;
    
    return specular;
}

//
// combines a float3 RGB value with an alpha value into a float4
//
float4 CombineRGBWithAlpha(float3 rgb, float a) 
{ 
    return float4(rgb.r, rgb.g, rgb.b, a); 
}

P2F main(V2P pixel)
{
    P2F result;

    // we need to normalize incoming vectors
    float3 surfaceNormal = normalize(pixel.normal);
    float3 surfaceTangent = normalize(pixel.tangent.xyz);
    float3 worldNormal = normalize(pixel.worldNorm);
    float3 toEyeVector = normalize(pixel.toEye);

    // construct tangent matrix
    float3x3 localToTangent = transpose(float3x3(surfaceTangent, cross(surfaceNormal, surfaceTangent) * pixel.tangent.w, surfaceNormal));
    float3x3 worldToTangent = mul((float3x3)WorldToLocal4x4, localToTangent);

    // transform some vectors into tangent space
    float3 tangentLightDir = normalize(mul(LightDirection[0], worldToTangent));
    float3 tangentToEyeVec = normalize(mul(toEyeVector, worldToTangent));

    // BEGIN GENERATED CODE
    float3 local1 = LambertLighting(tangentLightDir, float3(0.000000f,0.000000f,1.000000f), MaterialAmbient.rgb, AmbientLight.rgb, LightColor[0].rgb, pixel.diffuse.rgb);
    float3 local4 = SpecularContribution(tangentToEyeVec, tangentLightDir, float3(0.000000f,0.000000f,1.000000f), MaterialSpecular.rgb, MaterialSpecularPower, LightSpecularIntensity[0], LightColor[0].rgb);
    float3 local5 = mad(local1, Texture1.Sample(TexSampler, pixel.uv).rgb, local4);
    float local6 = 1; // Used to be: Fresnel(float3(0.000000f,0.000000f,1.000000f), tangentToEyeVec, 0.100000f);
    float3 local10 = lerp(float4(0.000000f,0.000000f,0.000000f,0.000000f).rgb, float4(1.000000f,0.000000f,0.000000f,1.000000f).rgb, Time);
    float3 local11 = local6 * local10;
    float3 local12 = local5 + local11;
    float local13 = Texture1.Sample(TexSampler, pixel.uv).a * pixel.diffuse.a;
    result.fragment = CombineRGBWithAlpha(local12, local13);
    // END GENERATED CODE

    if (result.fragment.a == 0.0f) discard;

    return result;
}

