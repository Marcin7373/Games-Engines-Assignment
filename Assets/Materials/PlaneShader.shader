Shader "Custom/PlaneShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;

			struct Input {
				float2 uv_MainTex;
				float3 worldPos;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;

			void surf(Input IN, inout SurfaceOutputStandard o) {

				float red = IN.worldPos.y / 0.9;
				float green = 2.5 - IN.worldPos.y / 1.3;
				if (red > 2) {
					red = 2;
				}

				o.Albedo = float3(red, green, 0.5);
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
			}
			ENDCG
		}
			FallBack "Diffuse"
}
