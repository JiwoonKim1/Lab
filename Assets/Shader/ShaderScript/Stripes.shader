﻿Shader "Unlit/Stripes"
{
	Properties{
		_Color1("Color 1", Color) = (0,0,0,1)
		_Color2("Color 2", Color) = (1,1,1,1)
		_Tiling("Tiling", Range(1, 500)) = 10
		_Direction("Direction", Range(0, 1)) = 0
		_WarpScale("Warp Scale", Range(0, 1)) = 0
		_WarpTiling("Warp Tiling", Range(1, 10)) = 1
		_Position("Position", Range(0,1)) = 0.5

		_Speed("Speed", Range(0,5)) = 0.5

	}

		SubShader
	{
		Cull off
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			fixed4 _Color1;
			fixed4 _Color2;
			int _Tiling;
			float _Direction;
			float _WarpScale;
			float _WarpTiling;
			float _Position;

			float _Speed;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;

			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.uv.x = o.uv.x + (_Time.y * _Speed);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				const float PI = 3.14159;

				float2 pos;
				pos.x = lerp(i.uv.x, i.uv.y, _Direction);
				pos.y = lerp(i.uv.y, 1 - i.uv.x, _Direction);

				//pos.x += sin(pos.y * _WarpTiling * PI * 2) * _WarpScale;
				pos.x *= _Tiling;

				fixed value = floor(frac(pos.x) + _Position);
				return lerp(_Color1, _Color2, value);
			}

			ENDCG
		}
	}
}
