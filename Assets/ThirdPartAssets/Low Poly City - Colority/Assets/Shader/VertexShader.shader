Shader "Colority/VertexShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		_EmissionLM ("Emission (Lightmapper)", Float) = 1
		_EmissionMap ("Emission Map", 2D) = "black" {}
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

        float _EmissionLM;
        sampler2D _EmissionMap;

        struct Input
        {
            float2 uv_EmissionMap;
            half4 color : COLOR;
        };

        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = IN.color.rgb * IN.color.rgb * _Color;

            // Emission
            fixed4 c = tex2D (_EmissionMap, IN.uv_EmissionMap);
            o.Alpha = c.a;
            o.Emission = _EmissionLM * _Color * c;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
