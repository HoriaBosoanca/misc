#include <stdio.h>
#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include <setup.h>
#include "cube.h"
#include "loop.h"

int main() {
	GLFWwindow* window = setup();

	start();

	while (!glfwWindowShouldClose(window)) {
		glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
		glClear(GL_COLOR_BUFFER_BIT);

		update();

		glfwSwapBuffers(window);
		glfwPollEvents();
	}

	glfwTerminate();
	return 0;
}
