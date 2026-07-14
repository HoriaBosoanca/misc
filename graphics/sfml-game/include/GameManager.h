#pragma once

class GameManager
{
public:
	GameManager();
    void run();

	constexpr static int screenWidth{800};
	constexpr static int screenHeight{600};
private:
	sf::RenderWindow m_window;
};
