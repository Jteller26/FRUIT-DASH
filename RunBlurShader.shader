Shader "452/RunBlurrShader"
{
    Properties
    {

    }
    SubShader
    {
        Tags { 
            "RenderType"="Transparent"
            "Queue"="Transparent"
             }
        LOD 100

        GrabPass {}
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex: POSITION;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _GrabTexture;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                // grabbing screen
                o.uv = ComputeGrabScreenPos(o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the grab texture
                fixed4 col = tex2Dproj(_GrabTexture, i.uv);

                // Getting colors for bordering pixels
                fixed4 topCol = tex2Dproj(_GrabTexture, i.uv + float4(0, -.01, 0 ,0));
                fixed4 bottomCol = tex2Dproj(_GrabTexture, i.uv + float4(0, .01, 0 ,0));
                fixed4 leftCol = tex2Dproj(_GrabTexture, i.uv + float4(0, 0, -0.01 ,0));
                fixed4 rightCol = tex2Dproj(_GrabTexture, i.uv + float4(0, 0, 0 ,-0.01));

                // Averaging out pixel color with neighbors (blurring)
                fixed4 finalCol = (col + topCol + bottomCol + leftCol + rightCol) / 5;

                // Reducing the overall color slightly to emphasize the effect
                float colorMod = .95;
                finalCol *= colorMod;
                return finalCol;
            }
            ENDCG
        }
    }
}
