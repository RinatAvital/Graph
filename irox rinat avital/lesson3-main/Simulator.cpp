#include "Simulator.h"


Simulator::Simulator()
{
	arrCamera = (Camera**)malloc(sizeof(Camera*) * N);
	for (int i = 0; i < N; i++)
	{
		arrCamera[i] = new Camera(char(i));
	}
}

void Simulator::ThredRunCamera()
{
	char c;
	std::thread* threadCamera = (std::thread*)malloc(sizeof(std::thread*) * N);
	for (int i = 0; i < N; i++)
	{
		 threadCamera[i]= std::thread(&Camera::run, arrCamera[i], i);
	}

	std::cin >> c;
	for (int i = 0; i < N; i++)
	{
		arrCamera[i]->stop();
	}
	
}
