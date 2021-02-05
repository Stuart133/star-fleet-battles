#version 460 core
layout (location = 0) in vec3 aPosition;

void main()
{
  gl_position = vec4(aPosition, 1.0);
}
