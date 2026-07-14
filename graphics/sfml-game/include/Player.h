#pragma once

#include "SFML/Graphics.hpp"

class Player
{
public:
	Player();

	// methods
	void render(sf::RenderWindow& window);
	void handleInput(sf::RenderWindow& window);
	void addGravity();
	void updatePos();
private:
	// fields

		// look
	sf::RectangleShape m_playerBody;
	float m_sideLength{50.0f};
	sf::Color m_color{ sf::Color::Yellow };

		// position
	double m_posx;
	double m_posy;

		// physics
	double m_speed{ 4.0f };
	double m_baseGravity{ 0.01f };
	double m_tempGravity{ 0.0f };

	// methods
	void initBody();
};

