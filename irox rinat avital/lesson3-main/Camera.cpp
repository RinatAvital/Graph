#include "Camera.h"
#include<stdio.h>
#include<stdlib.h>
#include "DiscoverMessege.h"
#include "StatusMesseage.h"



Camera::Camera(char cameraId)
{
	this->cameraId = cameraId;
	indexMessage = -1;
	bufferMessage = NULL;
	buffer = new Buffer();
	isActive = true;
}

StatusMesseage* createStatusMessage()
{
	static int id = 0;
	id++;
	return new StatusMesseage(id, 1, rand() % 3 + 1);

}

DiscoverMessege* createDiscoverMessage()
{
	static int id = 99;
	id++;
	return new DiscoverMessege(id, 2, rand() % 9500 + 500, rand() % 361, rand() % 1001);
}



Camera::~Camera()
{
	free(buffer);
	free(bufferMessage);
}

void Camera::generate()
{
	int count = rand() % 6 + 1;
	for (int i = 0; i < count; i++)
	{
		bufferMessage= (baseMessage**)realloc(bufferMessage, sizeof(baseMessage*) * (++indexMessage + 1));
		(rand() % 2 + 1 == 1) ? bufferMessage[indexMessage] = createStatusMessage() : bufferMessage[indexMessage] = createDiscoverMessage();
		
	}


}

void Camera::sendToBuffer()
{
	for (int i = 0; i <= indexMessage; i++)
	{
		bufferMessage[i]->parseBack();
		buffer->addToBuffer(bufferMessage[i]->getMessageBuffer());
		//bufferMessage[i]->~baseMessage();
		free(bufferMessage[i]);
	}
	free(bufferMessage);
	bufferMessage = NULL;
	indexMessage = -1;

}

void Camera::run()
{
	while (isActive) 
	{
		generate();
		sendToBuffer();
	}
}

void Camera::stop()
{
	isActive = false;
}



