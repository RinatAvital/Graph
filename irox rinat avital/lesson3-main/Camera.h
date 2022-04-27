#pragma once
#include<stdio.h>
#include<stdlib.h>
#include "baseMessage.h"
#include "Buffer.h"

//מחלקת - camera מצלמה :
//משתנים:
//מזהה מצלמה(char)
//מערך של הודעות(מחלקה שכבר מימשתן)
//אובייקט מסוג buffer
//isActive - האם המצלמה בפעילות
//פונקציות :
//פונקציה generate - פונקציה שמייצרת הודעה מנתונים אקראיים ומוסיפה למערך  ההודעות  יכולה גם לחולל מספר הודעות
//פונקציה sendToBuffer - עוברת על כל מערך ההודעות, ממירה את נתוני ההודעות לבייטים מעבירה את הנתונים מהמערך של ההודעות לbuffer, ומאפסת את מערך ההודעות
//פונקציה run - קוראת ל generate ו  send  לסירוגין בלולאה כל עוד isActive שוה ל true כמו כן בפונקציה יהיה
//פונקציה stop  מעדכנת את isActive ל false
//
#define N 4

class Camera
{
	protected:
		char cameraId;
		baseMessage** bufferMessage=NULL;
		int indexMessage;
		int numOfMessege = 0;
		Buffer* buffer;
		bool isActive;
		//static int count;

	public:
		Camera(char CameraId);
		~Camera();
		void generate();
		void sendToBuffer();
		void run();
		void stop();
		unsigned char** getBufferValue();
		int getOfNumOfMessege();






};

