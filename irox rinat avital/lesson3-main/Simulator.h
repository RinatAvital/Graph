#pragma once
#include "Camera.h"
#include<thread>
#include<stdio.h>
#include<iostream>

#define N 4
class Simulator
{
	protected:
		Camera** arrCamera;
		
	public:
		Simulator();
		void ThreadRunCamera();
		void printValueAllCamera();
};

