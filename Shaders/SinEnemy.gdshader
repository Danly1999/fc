shader_type canvas_item;
#define S smoothstep
uniform sampler2D _RampTex : repeat_enable;
uniform sampler2D _Ramp2Tex : repeat_enable;
uniform sampler2D _PointTex : repeat_enable;
uniform vec4 _PointColor : source_color;
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
float circles(vec2 uv)
{
    vec2 mouse = vec2(1.5,1.8);
	vec2 offset = vec2(cos(TIME/2.0)*mouse.x,sin(TIME/2.0)*mouse.y);;

	vec3 light_color = vec3(0.9, 0.65, 0.5);
	float light = 0.1 / distance(normalize(uv), uv);
	
	if(length(uv) < 1.0){
		light *= 0.1 / distance(normalize(uv-offset), uv-offset);
	}
	return clamp(light,0.,1.);
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
	pointTex = smoothstep(min(pow(pointMaskTex*2.,2.),1.),pointTex,1.)*down*up*15.*pow(abs(UV.x-0.5),2.);
	vec3 rampcolor = texture(_RampTex,vec2(clamp(noise,0.,1.),0.)).rgb;
	vec3 sincolor = texture(_Ramp2Tex,vec2(clamp(down*up,0.0,0.99),0.)).rgb;
	float eyes = circles((UV-0.5-sin(vec2(TIME*1.2,TIME*0.8))*0.02)*vec2(6.,12.)*down*up);
	COLOR = vec4((mix(rampcolor,sincolor*1.3,down*up)+eyes+pointTex*_PointColor.rgb*5.),1.0-clamp(a,0,1.));
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
