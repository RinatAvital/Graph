#pragma once
#include<stdio.h>
#include<stdlib.h>
#include "baseMessage.h"
#include "Buffer.h"

//����� - camera ����� :
//������:
//���� �����(char)
//���� �� ������(����� ���� ������)
//������� ���� buffer
//isActive - ��� ������ �������
//�������� :
//������� generate - ������� ������� ����� ������� ������� ������� �����  �������  ����� �� ����� ���� ������
//������� sendToBuffer - ����� �� �� ���� �������, ����� �� ����� ������� ������� ������ �� ������� ������ �� ������� �buffer, ������ �� ���� �������
//������� run - ����� � generate �  send  �������� ������ �� ��� isActive ��� � true ��� �� �������� ����
//������� stop  ������ �� isActive � false
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

