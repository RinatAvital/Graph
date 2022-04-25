#include "Buffer.h"
#include <stdio.h>
#include<stdlib.h>
#include<string.h>

Buffer::Buffer()
{
	buffer = NULL;
	count = 0;
}

void Buffer::addToBuffer(unsigned char* newMessege)
{
	buffer = (unsigned char**)realloc(buffer, sizeof(unsigned char*) * ++count);
	if (buffer == NULL)
		exit(1);
	buffer[count - 1] = newMessege;
}

unsigned char** Buffer::getBuffer()
{
	return buffer;
}

void Buffer::cleanBuffer()
{
	free(buffer);
	count = 0;

}


