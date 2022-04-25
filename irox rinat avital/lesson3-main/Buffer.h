#pragma once

class Buffer
{
protected:
	unsigned char** buffer;
	int count;

public:
	void addToBuffer(unsigned char* newMessege);
	unsigned char** getBuffer();
	void cleanBuffer();
	Buffer();
	~Buffer();





};


