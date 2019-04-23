﻿

Shader "Custom/Material2"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white" {}
		_Direction("Coverage Direction", Vector) = (0,1,0)
		_Intensity("Intensity", Range(0,1)) = 1
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vertexFunc
			#pragma fragment fragmentFunc
			#include "UnityCG.cginc"

			struct v2f 
			{
				float4 pos : SV_POSITION;
				float3 normal : NORMAL;
				float2 uv_Main : TEXCOORD0;
			};
		
			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vertexFunc(appdata_full v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv_Main = TRANSFORM_TEX(v.texcoord, _MainTex);
					
				o.normal = mul(unity_ObjectToWorld, v.normal);
				return o;
			}

			float3 _Direction;
			fixed _Intensity;

			fixed4 fragmentFunc(v2f i) : COLOR
			{
				fixed dir = dot(normalize(i.normal), _Direction);
				if (dir < 1 - _Intensity)
				{
					dir = 0;

				}

				fixed4 tex1 = tex2D(_MainTex, i.uv_Main);

				return tex1;
			}
			ENDCG
		}
	}
}