shader_type canvas_item;
uniform bool _UseAdd = false;
uniform bool _InvertAddUV = false;
uniform sampler2D _AddTex : repeat_enable;
uniform vec4 _AddTexTiling = vec4(1.,1.,0.,0.);
uniform vec4 _AddMaskScale = vec4(1.,1.,1.,1.);
uniform bool _UseNoise = false;
uniform sampler2D _NoiseTex : repeat_enable;
uniform vec4 _NoiseTexTiling = vec4(1.,1.,0.,0.);
uniform float _NoiseScale = 0.2;
uniform bool _UseSin = false;
uniform vec4 sinline_tiling = vec4(1.5,0.995,10.0,0.0);
uniform vec4 add_color :source_color = vec4(1.,1.,1.,1.);

// uv: 要旋转的uv坐标
// pivot: 旋转中心点
// rotation: 旋转的弧度
vec2 rotate(vec2 uv, vec2 pivot, float rotation) {
	mat2 rotation_matrix = mat2(vec2(cos(rotation), -sin(rotation)), vec2(sin(rotation), cos(rotation)));
	return rotation_matrix * (uv - pivot) + pivot;
}

void fragment() {
	vec4 maintex = texture(TEXTURE,UV);
	vec4 noisetex = texture(_NoiseTex,UV*_NoiseTexTiling.rg+TIME*_NoiseTexTiling.ba)*_NoiseScale*vec4(float(_UseNoise));
	float adduv = pow(UV.r*_AddMaskScale.r,_AddMaskScale.g);
	float subuv = pow(UV.r*_AddMaskScale.b,_AddMaskScale.a);
	vec4 addtex = vec4(float(_UseAdd))*add_color.a*add_color*(texture(_AddTex,(_InvertAddUV?UV.gr:UV.rg)*_AddTexTiling.rg+noisetex.xy+TIME*_AddTexTiling.ba)+adduv)*subuv;
	vec2 rotateUV = clamp(rotate(UV,vec2(.5,.5),0.5),0,1.);
	vec4 sinline = vec4(float(_UseSin))*add_color*max(0.,pow(sin(rotateUV.r*sinline_tiling.r+(sinline_tiling.a))*sinline_tiling.g,sinline_tiling.b)) ;
	//COLOR = vec4(sinline);
    COLOR = maintex + (1.-maintex.a)*(addtex + sinline); // 白色三角形，边缘有平滑
}