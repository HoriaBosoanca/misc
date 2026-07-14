#include "SFML/Graphics.hpp"
#include "../include/Player.h"
#include "../include/GameManager.h"

// debbug:
#include <iostream>
#define printpos std::cout << "Player pos: " << m_posx << " " << m_posy << "\n";

// publics

Player::Player() {
    initBody();
}

void Player::updatePos(){
    m_posx = m_playerBody.getPosition().x - GameManager::screenWidth / 2 + (m_sideLength / 2);
    m_posy = -1 * (m_playerBody.getPosition().y - GameManager::screenHeight / 2 + (m_sideLength / 2));
}

void Player::addGravity() {
    m_tempGravity += m_baseGravity;
    if (!(m_posy < -1 * GameManager::screenHeight / 2 + m_sideLength / 2)){
        m_playerBody.move(0.0, m_tempGravity);
    }
}

void Player::render(sf::RenderWindow& window) {
    window.draw(m_playerBody);
}

void Player::handleInput(sf::RenderWindow& window) {
    if (sf::Keyboard::isKeyPressed(sf::Keyboard::Space)) {
        m_tempGravity = 0;
        m_playerBody.move(0.0, -m_speed);
    }
    if (sf::Keyboard::isKeyPressed(sf::Keyboard::A)) {
        m_playerBody.move(-m_speed, 0.0);
    }
    if (sf::Keyboard::isKeyPressed(sf::Keyboard::D)) {
        m_playerBody.move(m_speed, 0.0);
    }
}

// privates

void Player::initBody() {
    m_playerBody.setSize(sf::Vector2f(m_sideLength, m_sideLength));
    m_playerBody.setPosition(0, 0);
    m_playerBody.setFillColor(m_color);
}
