Shader "Unlit/SimpleShader"
{
    Properties
    //contains shader variables (textures, colors etc.) 
    //that will be saved as part of the Material, and displayed in the material inspector.
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    //primarily used to implement shaders for different GPU capabilities
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        // Each SubShader is composed of a number of passes
        //ach Pass represents an execution of the vertex and fragment code for the same object rendered with the material of the shader.
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            // vertex shader inputs
            {
                float4 vertex : POSITION; // clip space position
                float2 uv : TEXCOORD0; // texture coordinate
            };

            struct v2f
                // vertex shader outputs ("vertex to fragment")
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            // texture we will sample

            float4 _MainTex_ST;

            v2f vert (appdata v)
             // vertex shader
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                // transform position to clip space
                // (multiply with model*view*projection matrix)
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                // just pass the texture coordinate
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
                // pixel shader; returns low precision ("fixed4" type)
            // color ("SV_Target" semantic)
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
