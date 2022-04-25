#include "DiscoverMessege.h"
#include <stdio.h>
#include <cstring>
#include <stdlib.h>
#include <iostream>

DiscoverMessege::DiscoverMessege(int messageId, int messageType, float distance, float angle, float speed):baseMessage(messageId,messageType)
{
	if (distance >= 500 && distance <= 10000)
		this->distance = distance;
	else
		this->distance = 0;
	this->angle = (angle >= 0 && angle <= 360) ? angle : 0;
	this->speed = (speed >= 0 && speed <= 1000) ? speed : 0;
}

void DiscoverMessege::parseMessage()
{
	if (this->messageBuffer == NULL)
		return;

	std::memcpy((void*)&(this->messageType), (void*)this->messageBuffer, 2);
	std::memcpy((void*)&(this->distance), (void*)(this->messageBuffer+2), 4);
	std::memcpy((void*)&(this->angle), (void*)(this->messageBuffer+6), 4);
	std::memcpy((void*)&(this->speed), (void*)(this->messageBuffer+10), 4);

}

void DiscoverMessege::parseBack()
{
	this->messageBuffer = (unsigned char*)malloc(14);
	if (this->messageBuffer == NULL)
	{
		std::cout << "alocation failed\n";
		exit(1);
	}
	std::memcpy(this->messageBuffer, &(this->messageType), 2);
	std::memcpy((this->messageBuffer + 2), &(this->distance),  4);
	std::memcpy((this->messageBuffer + 6), &(this->angle),  4);
	std::memcpy((this->messageBuffer + 10), &(this->speed),  4);
}

void DiscoverMessege::print()
{
	std::cout << "type: " << this->messageType << "\tdistance: " << this->distance << "\tangle: " << this->angle << "\tspeed:" << this->speed<<"\n";
}

unsigned char* DiscoverMessege::getMessageBuffer()
{
	return this->messageBuffer;
}
