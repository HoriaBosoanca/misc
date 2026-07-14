#include "SFML/Graphics.hpp"
#include "../include/Player.h"
#include "../include/GameManager.h"

#include <iostream>

GameManager::GameManager() {}

void GameManager::run(){
    // create window
	sf::RenderWindow m_window(sf::VideoMode(screenWidth, screenHeight), "My game");
    // instantiate all necessary 1-time objects
    Player player;
    while (m_window.isOpen()) {

        // handle closing window
        sf::Event event;
        while (m_window.pollEvent(event)) {
            if (event.type == sf::Event::Closed) {
                m_window.close();
            }
        }

        // Rendering:
        // (these method need execution every frame from GameManager and/or window acces)

        m_window.clear(sf::Color::Black);

            // Player:
        player.handleInput(m_window);
        player.addGravity();
        player.updatePos();
        player.render(m_window);

        m_window.display();
    }
}
