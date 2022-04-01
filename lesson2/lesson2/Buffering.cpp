#include <iostream>
#include <random>

using namespace std;


double getProb()
{
	return (double)rand() / ((double)RAND_MAX + 1);
}

int* generateData(int*& inbuf, int& count)
{
	int Rand = (rand() % 9) + 1;
	inbuf[count] = Rand;
	count++;
	int length = sizeof(inbuf);
	if(count>length)//is full
	{
		count = 0;
		return inbuf;
	}
	else//not full
	{
		return NULL;
	}
}

void processData(int*& outbuf, int& count, int& total)
{
	if (outbuf == NULL)
	{
		return;
	}
	else
	{
		total += outbuf[count];
	}
	if (outbuf[count]!=NULL)
	{
		free(outbuf);
	}
	
	return;
}

const int BUFSIZE = 10;
const int ITERATIONS = 50;

int main()
{
	int* fillbuffer = new int[BUFSIZE];
	int fillcnt = 0;
	int* processbuffer = NULL;
	int processcnt = 0;
	int tcount = 0;
	for (int i = 0; i < ITERATIONS; i++)
	{
		int* temp;
		if (getProb() <= 0.40)
		{
			temp = generateData(fillbuffer, fillcnt);
			if (temp != NULL)
				processbuffer = temp;
		}
		if (getProb() <= 0.60)
			processData(processbuffer, processcnt, tcount);
		cout << fillcnt << '\t' << processcnt << endl;
	}
	cout << "Total value: " << tcount << endl;
	return 0;
}


