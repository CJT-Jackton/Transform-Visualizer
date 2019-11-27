Shader "Unlit/NDCSpaceShader"
{
    Properties
    {
        _MainColor("Color", Color) = (0.5,0.5,0.5,1.0)
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
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            uniform float4x4 _MVPMatrix;

            float4 _MainColor;

            v2f vert (appdata v)
            {
                v2f o;
                //o.vertex = UnityObjectToClipPos(v.vertex);
                o.vertex = mul(unity_ObjectToWorld, v.vertex);
                o.vertex = mul(_MVPMatrix, o.vertex);
                o.vertex = o.vertex / o.vertex.w;
                o.vertex = mul(UNITY_MATRIX_VP, float4(o.vertex.xyz, 1.0));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _MainColor;
                return col;
            }
            ENDCG
        }
    }
}
