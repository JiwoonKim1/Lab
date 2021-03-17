// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/SampleStripe"
{
	Properties
	{
		_Color1("Color 1", Color) = (0,0,0,1)
		_Color2("Color 2", Color) = (1,1,1,1)
		_Tiling("Tiling", Range(1, 500)) = 10
		_Direction("Direction", Range(0, 1)) = 0
		
		_BackgroundTex("BackgroundTex", 2D) = "black"{}
		_StripeTex("StripeTex", 2D) = "white"{}
	}

		SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			// vertex shader
			// this time instead of using "appdata" struct, just spell inputs manually,
			// and instead of returning v2f struct, also just return a single output
			// float4 clip position
			float4 vert(float4 vertex : POSITION) : SV_POSITION
			{
				return UnityObjectToClipPos(vertex);
			}

			// color from the material
			fixed4 _Color1;

			// pixel shader, no inputs needed
			fixed4 frag() : SV_Target
			{
				return _Color1; // just return it
			}

			ENDCG
		}
		
		Pass
		{
				/*
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _StripeTex;
			fixed4 _Color2;
			int _Tiling;

			struct appdata
			// vertex shader inputs
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			// vertex shader outputs ("vertex to fragment")
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert(appdata v)
			// vertex shader
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				//float pos = (i.uv.x) * (_Tiling); //원본
				//return floor(frac(pos) + _Position); //원본 결과는 0,1
				float pos = (i.uv.x) * (_Tiling);
				return floor(frac(pos) + 0.5);
			}

			void surf(v2f IN, inout v2f o)
			{
				fixed4 c = tex2D(_StripeTex, float2(IN.uv.x + _Time.y, IN.uv.y)) * _Color2;
				//o.Albedo = c.rgb;
				//o.Alpha = c.a;
			}

			ENDCG
			
			//Tags { "RenderType" = "Opaque" }
			//LOD 200
			*/
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma surface surf Standard
			//#pragma target 3.0

			int _Tiling;
			sampler2D _StripeTex;
			fixed4 _Color2;

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
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float pos = (i.uv.x) * (_Tiling); //원본
				fixed4 c = tex2D(_StripeTex, float2(i.uv.x + _Time.y, i.uv.y)) * _Color2;
				return c;
				//return floor(frac(pos) + _Position); //원본 결과는 0,1
			}

			/*
				fixed4 frag(v2f i) : SV_Target
			{
				//float pos = (i.uv.x) * (_Tiling); //원본
				//return floor(frac(pos) + _Position); //원본 결과는 0,1
				float pos = (i.uv.x) * (_Tiling);
				return floor(frac(pos) + 0.5);
			}

				void surf(v2f IN, inout v2f o)
			{
				fixed4 c = tex2D(_StripeTex, float2(IN.uv.x + _Time.y, IN.uv.y)) * _Color2;
				//o.Albedo = c.rgb;
				//o.Alpha = c.a;
			}
			*/
			ENDCG
		}
	}
}
