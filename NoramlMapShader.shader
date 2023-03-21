Shader "452/NoramlMapShader"
{
    Properties
    {
        //inspector for the bomb material
        _Color ("Color", Color) = (1,1,1,1)
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Smoothness ("Normal Smoothness", Range(0,3)) = 1
        _Intensity ("Normal Intensity", Range(0,3)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _NormalMap;

        struct Input
        {
            float2 uv_NormalMap;
        };

        //varibles for the matertial of the bomb
        fixed4 _Color;
        float _Smoothness;
        float _Intensity;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = _Color.rgb;

            float3 normalMap = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));

            normalMap.xy *= _Smoothness;
            normalMap.x *= _Intensity;


            o.Normal = normalize(normalMap.rgb);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
