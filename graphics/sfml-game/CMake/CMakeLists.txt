cmake_minimum_required(VERSION 3.22)
set(CMAKE_CXX_STANDARD 17)
project(test)

# add source files
add_executable(test 
${PROJECT_SOURCE_DIR}/../src/main.cpp
${PROJECT_SOURCE_DIR}/../src/GameManager.cpp
${PROJECT_SOURCE_DIR}/../src/Player.cpp
)

# add headers
    # personal
target_include_directories(test PRIVATE ${PROJECT_SOURCE_DIR}/../include)


# SFML
    # includes
target_include_directories(test PRIVATE ${PROJECT_SOURCE_DIR}/../SFML/include)
    # libraries
target_link_libraries(test 
    ${PROJECT_SOURCE_DIR}/../SFML/lib/libsfml-graphics.so
    ${PROJECT_SOURCE_DIR}/../SFML/lib/libsfml-window.so
    ${PROJECT_SOURCE_DIR}/../SFML/lib/libsfml-system.so
)
