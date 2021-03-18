Shader "Unlit/SampleStripe2"
{
	Properties{
		_Color1("Color 1", Color) = (0,0,0,1)
		_Color2("Color 2", Color) = (1,1,1,1)
		_Tiling("Tiling", Range(1, 500)) = 10
		_Speed("Speed", Range(1,10)) = 10
	}

		SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			fixed4 _Color1;
			fixed4 _Color2;
			int _Tiling;
			float _Speed; 

			struct appdata
				// vertex buffer에서 가져오는 정보를 정한다.
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
				// vertex shader에서 계산된 정보를 pixel shader로 넘기는 데이터 타입을 결정한다.
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;

			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				o.uv.x = o.uv.x + _Speed;
				//.o.uv.x = o.uv.x + _Time.x;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float pos = i.uv.x * _Tiling;
				return floor(frac(pos) + 0.5);
			}

			ENDCG
		}
	}
}
