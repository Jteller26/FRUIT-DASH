Shader "452/BombShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
        //inspector view for x and y
        _XSpeed("X Speed", Range(0,10)) = 5
        _YSpeed("Y Speed", Range(0,10)) = 5

        //inspector for the chnages to the flame effect
        _Speed("Flame Speed", Range(-80, 80)) = 1
        _Frequency("Flame Frequency", Range(0, 5)) = 2
        _Amplitude("Flame Amplitude", Range(0, 0.5)) = 0.1
    }
    SubShader
    {
        Tags {            
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert addshadow alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        // all vaibles for the flame effect
        fixed4 _Color;
        fixed _XSpeed;
        fixed _YSpeed;

        fixed _Speed;
        fixed _Frequency;
        fixed _Amplitude;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        // Creates the moving flame effect
        void vert(inout appdata_full v)
        {
            float time = _Time * _Speed;

            float flameValue = cos(time + v.vertex.x * _Frequency) * _Amplitude;

            v.vertex.xyz = float3(v.vertex.x,v.vertex.y - flameValue, v.vertex.z);
            v.normal.xyz = normalize(float3(v.normal.x - flameValue,v.normal.y + flameValue, v.normal.z));
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed2 movedUV = IN.uv_MainTex;

            movedUV.x += _XSpeed * _Time.x;
            movedUV.y += _YSpeed * _Time.x;
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, movedUV) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
