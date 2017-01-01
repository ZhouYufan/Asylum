/*
Description

When you place decals such as bullet holes or text meshes exactly onto the surface of other objects, 
you'll usually see what's known as 'Z-fighting'. This is an effect caused by lack of depth resolution in the graphics card, 
and it results in parts of one object being hidden by the other in an apparently random way. 
It looks like an ugly flickering pattern which changes as the camera or objects move. 
It's possible to reduce the effect by moving the decal object away from the surface of the other object, 
but sometimes this leaves the decal visibly floating off the surface.

This shader helps to rectify the situation by using the Offset command to artificially move the rendered 
object's depth values closer to the camera. The object itself doesn't move, but its faces are drawn 
slightly forward so that they end up clear of the surface they're lying on.

BlendedDecal requires a texture (which, if it has an alpha channel, will be masked appropriately)
and has a colour option which can be used to tint the texture or adjust the transparency.

Usage

Place this shader somewhere in your Assets folder hierarchy, create a material which uses it and apply it to the relevant objects.
*/

Shader "BlendedDecal"
{
	Properties
	{
		_Color ("Tint", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
	}
	
	SubShader
	{
		Lighting Off
		ZTest LEqual
		ZWrite Off
		Tags {"Queue" = "Transparent"}
		Pass
		{
			Alphatest Greater 0
			Blend SrcAlpha OneMinusSrcAlpha
			Offset -1, -1
			SetTexture [_MainTex]
			{
				ConstantColor[_Color]
				Combine texture * constant
			}
		}
	}
}