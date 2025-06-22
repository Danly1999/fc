shader_type canvas_item;
uniform sampler2D add_tex : repeat_enable;
uniform sampler2D noise_tex : repeat_enable;
uniform vec2 uvtiling = vec2(1.,1.);
uniform vec4 sinline_tiling = vec4(1.);
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
	vec4 noisetex = texture(noise_tex,UV*.5)*.2;
	vec4 addtex = add_color.a*add_color*(texture(add_tex,UV*uvtiling+noisetex.xy+TIME*vec2(.2,.02))*UV.x+UV.x);
	vec2 rotateUV = rotate(UV,vec2(.5,.5),0.5);
	float sinline = max(0.,sin(rotateUV.r*sinline_tiling.r+(TIME*sinline_tiling.b))*sinline_tiling.g) ;
	//COLOR = vec4(sinline);
    COLOR = maintex+addtex+sinline; // 白色三角形，边缘有平滑
}