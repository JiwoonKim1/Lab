Shader "Unlit/WaveProgress"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Progress("Progress", Range(0.0, 1)) = 0
    }
        SubShader
        {
            Tags { "RenderType" = "Transparent" }
            LOD 100
            Blend SrcAlpha OneMinusSrcAlpha

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // make fog work
                #pragma multi_compile_fog

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    UNITY_FOG_COORDS(1)
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                uniform float _Progress;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }


                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv);

                    float sinWave = _Progress + (sin(i.uv.x * 6 + _Time.y * 4.7) + sin(i.uv.x * 8 + _Time.y * 5) + sin((i.uv.x - 0.003) * 7.5 + _Time.y * 5.3)) * 0.05;
                    float pwidth = length(float2(ddx(i.uv.x), ddy(i.uv.y)));
                    float wave = (1 + smoothstep(sinWave, sinWave - pwidth * 1.5, i.uv.y)) / 2;
                    col.rgb = col.rgb * wave;
                    return col;
                }
                ENDCG
            }
        }
}
