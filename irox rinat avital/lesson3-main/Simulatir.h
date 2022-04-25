#pragma once
#include "baseMessage.h"
#include <stdlib.h>
#include "StatusMesseage.h"
#include "DiscoverMessege.h"
#define N 10
class Simulatir
{
protected:
	baseMessage* buffer[N];
public:
	StatusMesseage *createStatusMessage();
	DiscoverMessege* createDiscoverMessage();
	void generateAndSendMessage();

};

