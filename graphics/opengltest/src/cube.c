#include "cube.h"
#include "shader.h"
#include "glad/glad.h"

void register_cube(Cube* cube) {
	// gen VAO
	glGenVertexArrays(1, &cube->CUBE_VAO);
	glBindVertexArray(cube->CUBE_VAO);

	// gen VBO
	constexpr float vertices[24] = {
		-0.5f, -0.5f, -0.5f, // 0
		 0.5f, -0.5f, -0.5f, // 1
		 0.5f, -0.5f,  0.5f, // 2
		-0.5f, -0.5f,  0.5f, // 3

		-0.5f,  0.5f, -0.5f, // 4
		 0.5f,  0.5f, -0.5f, // 5
		 0.5f,  0.5f,  0.5f, // 6
		-0.5f,  0.5f,  0.5f, // 7
	};
	glGenBuffers(1, &cube->CUBE_VBO);
	glBindBuffer(GL_ARRAY_BUFFER, cube->CUBE_VBO);
	glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);
	glEnableVertexAttribArray(0);
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(float) * 3, nullptr);

	// gen EBO
	constexpr unsigned int indices[36] = {
		// Bottom face
		0, 1, 2,
		2, 3, 0,

		// Top face
		4, 7, 6,
		6, 5, 4,

		// Front face
		3, 2, 6,
		6, 7, 3,

		// Back face
		0, 1, 5,
		5, 4, 0,

		// Left face
		0, 3, 7,
		7, 4, 0,

		// Right face
		1, 5, 6,
		6, 2, 1
	};
	glGenBuffers(1, &cube->CUBE_EBO);
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, cube->CUBE_EBO);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indices), indices, GL_STATIC_DRAW);

	// initialize rotation
	glm_mat4_identity(cube->model);
}

void draw_cube(const Cube* cube) {
	glBindVertexArray(cube->CUBE_VAO);
	glBindBuffer(GL_ARRAY_BUFFER, cube->CUBE_VBO);
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, cube->CUBE_EBO);

	glUniformMatrix4fv(glGetUniformLocation(current_shader_id, "model"), 1, GL_FALSE, (float*) cube->model);
	glDrawElements(GL_TRIANGLES, 36, GL_UNSIGNED_INT, nullptr);
}

void set_position_and_rotation(Cube* cube, vec3 position, vec3 radians) {
	glm_mat4_identity(cube->model);
	glm_translate(cube->model, position);
	glm_rotate_y(cube->model, radians[0], cube->model);
	glm_rotate_x(cube->model, radians[1], cube->model);
	glm_rotate_z(cube->model, radians[2], cube->model);
}