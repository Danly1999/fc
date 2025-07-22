shader_type spatial;

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	ALBEDO = vec3(1.,0.5,0.5);
	METALLIC = 1.;
	ROUGHNESS = 0.2;
	SPECULAR = 0.1;
	CLEARCOAT = 0.8;
	EMISSION = vec3(1.,0.5,0.5);
}

//void light() {
//	// Called for every pixel for every light affecting the material.
//	// Uncomment to replace the default light processing function with this one.
//}
