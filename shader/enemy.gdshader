shader_type canvas_item;

float SkewTriGrid(vec2 uv, out vec2 id)
{
    // 手动实现 mat2 变换
    uv = vec2(
        1.0 * uv.x + (-1.0/1.73) * uv.y,
        0.0 * uv.x + (2.0/1.73) * uv.y
    );
    id = floor(uv.xy);
    vec3 g = vec3(uv, 1.0 - uv.x - uv.y);
    g = fract(g);
    float lg = length(g);
    vec3 g2 = abs(2.0 * fract(g) - 1.0); // distance to borders
    float edge = max(max(g2.x, g2.y), g2.z);
    return 1.0 - edge;
}

void fragment() {
    vec2 id;
    float tri = SkewTriGrid(UV, id);
        COLOR = vec4(vec3(tri), 1.0); // 白色三角形，边缘有平滑66
}