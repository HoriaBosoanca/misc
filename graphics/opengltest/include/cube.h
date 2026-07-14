#ifndef CUBE_H
#define CUBE_H

#include "cglm/call/mat4.h"

typedef struct {
    unsigned int CUBE_VAO;
    unsigned int CUBE_VBO;
    unsigned int CUBE_EBO;

    mat4 model;
} Cube;

void register_cube(Cube* cube);
void draw_cube(const Cube* cube);
void set_position_and_rotation(Cube* cube, vec3 position, vec3 radians);

#endif //CUBE_H
