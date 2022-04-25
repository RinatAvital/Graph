#pragma once
#include "baseMessage.h"

class StatusMesseage :
    public baseMessage
{
protected:
    short status;//(1-3)
public:
    void parseMessage();
    void parseBack();
    StatusMesseage(int messageId,int messageType,short status);
    StatusMesseage();
    ~StatusMesseage();
    void print();
    unsigned char* getMessageBuffer();
};

