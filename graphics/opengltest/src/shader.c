#include "shader.h"
#include <malloc.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "glad/glad.h"

unsigned int current_shader_id = -1;

unsigned int compile_shader(unsigned int type, const char* source){
    const unsigned int id = glCreateShader(type);
    glShaderSource(id, 1, &source, nullptr);
    glCompileShader(id);

    int result;
    glGetShaderiv(id, GL_COMPILE_STATUS, &result);
    if (result == GL_FALSE) {
        int length;
        glGetShaderiv(id, GL_INFO_LOG_LENGTH, &length);
        char* message = malloc(length * sizeof(char));
        glGetShaderInfoLog(id, length, &length, message);
        printf("Failed to compile %s shader: %s\n", type == GL_VERTEX_SHADER ? "vertex" : "fragment", message);
        glDeleteShader(id);
        return 0;
    }

    return id;
}

unsigned int create_shader(const char* vertexShader, const char* fragmentShader){
    const unsigned int program = glCreateProgram();
    const unsigned int vs = compile_shader(GL_VERTEX_SHADER, vertexShader);
    const unsigned int fs = compile_shader(GL_FRAGMENT_SHADER, fragmentShader);

    glAttachShader(program, vs);
    glAttachShader(program, fs);
    glLinkProgram(program);
    glValidateProgram(program);

    glDeleteShader(vs);
    glDeleteShader(fs);

    return program;
}

char* get_shader_source(const char* path)
{
    FILE* source_file = fopen(path, "r");
    if (!source_file) {
        fprintf(stderr, "Failed to locate shader files. Are you running this from the project directory?\n");
        exit(-1);
    }

    fseek(source_file, 0, SEEK_END);
    long fsize = ftell(source_file);
    fseek(source_file, 0, SEEK_SET);

    char* buffer = malloc(fsize + 1);
    memset(buffer, 0, fsize + 1);
    fread(buffer, 1, fsize, source_file);
    buffer[fsize] = '\0';

    fclose(source_file);

    return buffer;
}

void use_shader(const char* vertexShader, const char* fragmentShader) {
    const char* vs = get_shader_source(vertexShader);
    const char* fs = get_shader_source(fragmentShader);
    const unsigned int shader = create_shader(vs, fs);
    free((void*) vs);
    free((void*) fs);
    glUseProgram(shader);

    current_shader_id = shader;
}