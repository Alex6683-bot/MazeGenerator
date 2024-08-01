#version 460 core

uniform float left;
uniform float right;
uniform float top;
uniform float bottom;
uniform float outlineWidth;
uniform vec3 outlineColor;
uniform vec3 backgroundColor;

in vec2 _uvCoords;

out vec4 FragColor;
vec3 finalColor;

void main()
{
	FragColor = max(max(step(1 - outlineWidth, _uvCoords.x) * right, step(_uvCoords.x, outlineWidth) * left),
				max(step(1 - outlineWidth, _uvCoords.y) * right, step(_uvCoords.y, outlineWidth) * left)) * vec4(outlineColor, 1.0f);
	//FragColor = vec4(vec3(_uvCoords.x), 1.0f);
	//FragColor = vec4(_uvCoords, 0.0f, 1.0f);
}