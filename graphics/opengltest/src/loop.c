#include "glad/glad.h"
#include "GLFW/glfw3.h"
#include "loop.h"
#include "camera.h"
#include "cube.h"
#include "shader.h"
#include "cglm/cglm.h"

Cube cube;
Cube cube2;

void start() {
    use_shader("assets/shaders/default_vert.vert", "assets/shaders/default_frag.frag");
    setup_camera(45.0f, -10.0f);

    register_cube(&cube);
    register_cube(&cube2);
}

void update() {
    update_camera();

    const vec3 position = {2.0f, 2.0f, 0.0f}, position2 = {-2.0f, -2.0f, 0.0f}, rotation = {M_PI/4.0f, M_PI/4.0f, M_PI/4.0f};
    set_position_and_rotation(&cube, position, rotation);
    draw_cube(&cube);
    set_position_and_rotation(&cube2, position2, rotation);
    draw_cube(&cube2);
}