cmake_minimum_required(VERSION 3.31)
project(opengltest C)

set(CMAKE_C_STANDARD 23)
set(CMAKE_C_STANDARD_REQUIRED ON)

add_subdirectory(lib/glfw)
add_subdirectory(lib/cglm)

file(GLOB SOURCES CONFIGURE_DEPENDS
        src/*.c
        lib/glad/src/glad.c
)
add_executable(opengltest ${SOURCES})

target_include_directories(opengltest PRIVATE
        include
        lib/glad/include
)

target_link_libraries(opengltest PRIVATE
        glfw
        cglm
)

# if using glad generator, rename glad includes to glad/gl.h, remove lib/glad/src/glad.c from sources, remove lib/glad/include from includes and add:
# add_subdirectory(lib/glad_generator/cmake)
# glad_add_library(glad STATIC API gl:core=3.3)
# target_link_libraries(opengltest PRIVATE
#         glad
# )