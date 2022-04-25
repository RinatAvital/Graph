#include "Simulatir.h"
#include <iostream>

StatusMesseage* Simulatir::createStatusMessage()
{
	static int id = 0;
	id++;
	return new StatusMesseage(id,1,rand()%3+1);
	
}

DiscoverMessege* Simulatir::createDiscoverMessage()
{
	static int id =99;
	id++;
	return new DiscoverMessege(id, 2, rand() % 9500 + 500, rand() % 361   ,rand() % 1001  );
}

void Simulatir::generateAndSendMessage()
{
	std::cout << "before:\n";

	for (int i = 0; i < N; i++) {
		(rand() % 2 + 1 == 1)? buffer[i] = createStatusMessage(): buffer[i] = createDiscoverMessage();
		buffer[i]->print();
	}
	std::cout << "after:\n";
	for (int i = 0; i < N; i++) {
		buffer[i]->parseBack();
		buffer[i]->parseMessage();
		buffer[i]->print();
		buffer[i]->~baseMessage();
	}
	
}

