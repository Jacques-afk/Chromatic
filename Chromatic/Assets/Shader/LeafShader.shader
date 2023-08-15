Shader "Custom/LeafShader"
{
    Properties
    {
        _BaseMap("BaseMap", 2D) = "white" {}
        _Color("Color", Color) = (1, 1, 1, 1)
    }
        SubShader
        {
            Tags { "RenderType" = "TransparentCutout" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _BaseMap;
                float4 _Color;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                half4 frag(v2f i) : SV_Target
                {
                    half4 albedo = tex2D(_BaseMap, i.uv) * _Color;
                    clip(albedo.a - 0.5);
                    return albedo;
                }
                ENDCG
            }
        }
            Fallback "Transparent/Cutout/Diffuse"
}
