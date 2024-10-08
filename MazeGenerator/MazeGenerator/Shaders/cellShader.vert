#version 460 core

layout (location = 0) in vec3 vertexPosition;
layout (location = 1) in vec2 uvCoords;

uniform mat4 model;
uniform mat4 projection;
uniform mat4 view;

out vec2 _uvCoords;

void main()
{
	gl_Position = vec4(vertexPosition, 1.0f) * model * view * projection;
	_uvCoords = uvCoords;
}