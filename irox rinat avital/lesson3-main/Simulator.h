#pragma once
#include "Camera.h"
#include<thread>
#include<stdio.h>
#include<iostream>

class Simulator
{
	protected:
		Camera** arrCamera;
		
	public:
		Simulator();
		void ThredRunCamera();
};

