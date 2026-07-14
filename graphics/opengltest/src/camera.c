#include "glad/glad.h"
#include "camera.h"
#include "setup.h"
#include "shader.h"
#include "cglm/cglm.h"

mat4 view;
mat4 projection;

void setup_camera(const float fov, const float posZ) {
    glm_mat4_identity(view);
    glm_translate(view, (vec3){0.0f, 0.0f, posZ});
    glm_perspective(fov, (float) WIDTH / HEIGHT, 0.1f, 100.0f, projection);
}

void update_camera() {
    glUniformMatrix4fv(glGetUniformLocation(current_shader_id, "view"), 1, GL_FALSE, (float*) view);
    glUniformMatrix4fv(glGetUniformLocation(current_shader_id, "projection"), 1, GL_FALSE, (float*) projection);
}