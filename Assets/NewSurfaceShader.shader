Shader "Custom/BlinnPhong" {
	Properties{
		
		_MaterialColor("MaterialColor",Color) = (1,1,1,1)
		
		_SpecularStrength("Specular",Range(0,1)) = 0.5
		
		_Gloss("Gloss",Range(1.0,255)) = 20
	}
		SubShader{
			Pass{
				Tags{ "LightingType" = "ForwardBase" }
				LOD 200

		CGPROGRAM
	
		#include "Lighting.cginc"

		
		#pragma vertex vertexShader
		#pragma fragment fragmentShader

		
		fixed4 _MaterialColor;
		float _SpecularStrength;
		float _Gloss;


		
		struct vertexShaderInput {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct vertexShaderOutput {
			float4 pos : SV_POSITION;
			float3 worldNormal : NORMAL;
			float3 worldPos : TEXCOORD1;
		};


		vertexShaderOutput vertexShader(vertexShaderInput v) {
			vertexShaderOutput o;

			
			o.pos = UnityObjectToClipPos(v.vertex);

			
			o.worldNormal = mul(v.normal, (float3x3)unity_WorldToObject);

			
			o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

			return o;
		}

		
		fixed4 fragmentShader(vertexShaderOutput i) : SV_Target{
			
			fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * _MaterialColor;

		fixed3 worldNormal = normalize(i.worldNormal);

		
		fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);

		
		fixed3 lambert = 0.5 * dot(worldNormal, worldLightDir) + 0.5;
	
		fixed3 diffuse = lambert * _MaterialColor.xyz * _LightColor0.xyz;


		fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos.xyz);
	
		fixed3 halfDir = normalize(worldLightDir + viewDir);
	
		fixed3 specular = _LightColor0.rgb * _MaterialColor.rgb * _SpecularStrength * pow(max(0.0, dot(halfDir, worldNormal)), _Gloss);

		fixed3 color = ambient + diffuse + specular;

		return fixed4(color, 1.0);

	}

			ENDCG
		}
	}
		
		FallBack "Diffuse"
}