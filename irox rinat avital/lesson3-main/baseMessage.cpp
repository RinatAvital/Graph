#include "baseMessage.h"
#include <stdio.h>
#include <stdlib.h>


baseMessage::baseMessage( int messageId, int messageType)
{
	this->messageId = messageId;
	if(messageType==1||messageType==2)
		this->messageType = messageType;
}
