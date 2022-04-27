#include "Simulator.h"


Simulator::Simulator()
{
	arrCamera = (Camera**)malloc(sizeof(Camera*) * N);
	for (int i = 0; i < N; i++)
	{
		arrCamera[i] = new Camera(char(i+'a'));
	}
	
}



void Simulator::ThreadRunCamera()
{
	char c;
	std::thread threadCamera[N];
	//std::thread* threadCamera = (std::thread*)malloc(sizeof(std::thread) * N);
	for (int i = 0; i < N; i++)
	{
		 threadCamera[i]= std::thread(&Camera::run, *(arrCamera[i]));
		 //threadCamera[i].join();
	}

	std::cin >> c;
	for (int i = 0; i < N; i++)
	{
		arrCamera[i]->stop();
		threadCamera[i].detach();
	}
	
	
}

void Simulator::printValueAllCamera()
{
	for (int i = 0; i < N; i++)
	{
		unsigned char** results = arrCamera[i]->getBufferValue();
		std::cout << std::endl;
		std::cout << "camera number: " << i << std::endl;
		for (int j = 0; j < 4; j++)
		{
			std::cout << j + 1<<": " << results[j] << std::endl;
		}
		
	}
}
