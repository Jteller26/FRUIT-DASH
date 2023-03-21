Shader "452/WatermelonShaderVF"
{
    Properties
    {
        _MainTex ("Albedo", 2D) = "red" {}      
        _NoiseTex ("Noise", 2D) = "white" {}
        _Intensity ("Intensity", Float) = 2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float3 wPos: TEXCOORD1;
                float3 wNormal: TEXCOORD2;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _NoiseTex;
            float4 _MainTex_ST;
            float _Intensity;
            
            v2f vert (appdata v)
            {
                
                v2f o;
                // get clip coords
                o.vertex = UnityObjectToClipPos(v.vertex);
                // transform main texture
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                // get world normals
                o.wNormal = UnityObjectToWorldNormal(v.normal);
                // get world position
                o.wPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                
                return o;
                
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // sample the noise
                fixed3 noiseMap = tex2D(_NoiseTex, i.uv);

                // get noise map based on normals
                noiseMap -= half3(0.5,0.5,0.5);
                noiseMap = normalize((normalize(noiseMap) + i.wNormal));

                // get view direction
                half3 direction = normalize(i.wPos - _WorldSpaceCameraPos);
                // get color shift based on view direction
                half colorShift =  (1 - dot(noiseMap, -direction)) * 2;
                // adjust intensity of color shift
                colorShift = pow(saturate(colorShift), _Intensity);
                // modify final color with color shift
                col += half4(colorShift * .1, colorShift * .2, colorShift, 0);
                
                return col;
            }
            ENDCG
        }
    }
}
