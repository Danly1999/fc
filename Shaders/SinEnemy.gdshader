shader_type canvas_item;
#define S smoothstep
uniform sampler2D _PointTex : repeat_enable;
uniform sampler2D _PointMaskTex : repeat_enable;
uniform sampler2D _NoiseTex : repeat_enable;
uniform vec2 _NoiseTiling = vec2(1.);
uniform vec4 _NoiseScale = vec4(1.);
uniform float height = 0.2;
uniform float weight = 20;
uniform float speed = 2;
uniform float _Distance = 0.1;
uniform float _Range = 1.5;

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	vec4 maintex = texture(TEXTURE,UV);
	vec2 uv = vec2(1.,2.)*(UV-0.5);
	float distanceMask = pow(1.-abs(UV.x-0.5),3.);
	uv.y += S(1., 0., abs(uv.x*_Range)) * sin(TIME * speed + uv.x * weight) * height;
	float s = .06 * S(-10., 4., abs(uv.x));
	float down =  S(s, 0., (uv.y) - _Distance*distanceMask);
	float up = 1.-S(s, 0., (uv.y) + _Distance*distanceMask);
	float noise = pow(abs(UV.y-0.5)*_NoiseScale.x,_NoiseScale.y);
	noise *= pow(texture(_NoiseTex,UV*_NoiseTiling+vec2(0,TIME*0.1)).r*_NoiseScale.z,_NoiseScale.w);
	noise *= max(abs(UV.x-0.5),0.1);
	float a = pow(length((UV-0.5)*vec2(1.5,1.))*2.,1.)*noise;
	float pointTex = texture(_PointTex,UV*vec2(.3,.6)+vec2(TIME*0.01,0)).r;
	float pointMaskTex = texture(_PointMaskTex,UV*vec2(2,4)+TIME*0.2).r;
	pointTex = smoothstep(min(pow(pointMaskTex*2.,2.),1.),pointTex,1.)*0.4;
	//COLOR = vec4(vec3(noise),1.);
	COLOR = vec4(vec3(max(noise,down*up)+pointTex),1.0-a);
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
