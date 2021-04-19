Shader "Unlit/Grid"
{
    //The main difference is calculating a screenspace distance to the nearest gridline in each direction separately, 
    //and then taking the minimum of these two distances.
    Properties
    {
        _GridColour("Grid Colour", color) = (1, 1, 1, 1)
        _BaseColour("Base Colour", color) = (1, 1, 1, 0)
        _GridSpacing("Grid Spacing", float) = 0.1
        _LineThickness("Line Thickness", float) = 1
    }
        SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _GridColour;
            fixed4 _BaseColour;
            float _GridSpacing;
            float _LineThickness;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = mul(unity_ObjectToWorld, v.vertex).xz / _GridSpacing;
                //o.uv.x = o.uv.x + (_Time.y * _Speed);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 wrapped = frac(i.uv) - 0.5f;
                float2 range = abs(wrapped);

                float2 speeds;
                speeds = fwidth(i.uv);
                /* // Euclidean norm gives slightly more even thickness on diagonals
                float4 deltas = float4(ddx(i.uv), ddy(i.uv));
                speeds = sqrt(float2(
                            dot(deltas.xz, deltas.xz),
                            dot(deltas.yw, deltas.yw)
                         ));
                */  // Cheaper Manhattan norm in fwidth slightly exaggerates thickness of diagonals

                float2 pixelRange = range / speeds;
                float lineWeight = saturate(min(pixelRange.x, pixelRange.y) - _LineThickness);

                return lerp(_GridColour, _BaseColour, lineWeight);
                /*
                pos.x = lerp(i.uv.x, i.uv.y, _Direction);
				pos.y = lerp(i.uv.y, 1 - i.uv.x, _Direction);

				pos.x += sin(pos.y * _WarpTiling * PI * 2) * _WarpScale;
				pos.x *= _Tiling;

				fixed value = floor(frac(pos.x) + _Position);
				return lerp(_Color1, _Color2, value);*/
            }
            ENDCG
        }
    }
}
