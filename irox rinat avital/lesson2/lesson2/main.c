#include <stdio.h>
void main()
{
	//----------------------------3
	int m = 300;
	float fx = 300.60;
	char cht = 'z';

	printf("\n\n Pointer : Demonstrate the use of & and * operator :\n");
	printf("--------------------------------------------------------\n");

	int* pt1;
	float* pt2;
	char* pt3;
	pt1 = &m;
	pt2 = &fx;
	pt3 = &cht;
	printf(" m = %d\n", m);
	printf(" fx = %f\n", fx);
	printf(" cht = %c\n", cht);
	printf("\n Using & operator :\n");
	printf("-----------------------\n");
	printf(" address of m = %p\n", &m);
	printf(" address of fx = %p\n", &fx);
	printf(" address of cht = %p\n", &cht);
	printf("\n Using & and * operator :\n");
	printf("-----------------------------\n");
	printf(" value at address of m = %d\n", *(&m));
	printf(" value at address of fx = %f\n", *(&fx));
	printf(" value at address of cht = %c\n", *(&cht));
	printf("\n Using only pointer variable :\n");
	printf("----------------------------------\n");
	printf(" address of m = %p\n", pt1);
	printf(" address of fx = %p\n", pt2);
	printf(" address of cht = %p\n", pt3);
	printf("\n Using only pointer operator :\n");
	printf("----------------------------------\n");
	printf(" value at address of m = %d\n", *pt1);
	printf(" value at address of fx= %f\n", *pt2);
	printf(" value at address of cht= %c\n\n", *pt3);

	}


	//--------------------------------8

	void changePosition(char* ch1, char* ch2)
	{
		char tmp;
		tmp = *ch1;
		*ch1 = *ch2;
		*ch2 = tmp;
	}
	void charPermu(char* cht, int stno, int endno)
	{
		int i;
		if (stno == endno)
			printf("%s  ", cht);
		else
		{
			for (i = stno; i <= endno; i++)
			{
				changePosition((cht + stno), (cht + i));
				charPermu(cht, stno + 1, endno);
				changePosition((cht + stno), (cht + i));
			}
		}
	}

	int main()
	{
		char str[] = "abcd";
		printf("\n\n Pointer : Generate permutations of a given string :\n");
		printf("--------------------------------------------------------\n");
		int n = strlen(str);
		printf(" The permutations of the string are : \n");
		charPermu(str, 0, n - 1);
		printf("\n\n");
		return 0;
	}
         //-------------------------------14
	void main()
	{
	//int arr[] = { 25,45,89,15,15,82 };

		int* a, i, j, tmp, n;
		printf("\n\n Pointer : Sort an array using pointer :\n");
		printf("--------------------------------------------\n");

		printf(" Input the number of elements to store in the array : ");
		scanf("%d", &n);

		printf(" Input %d number of elements in the array : \n", n);
		for (i = 0; i < n; i++)
		{
			printf(" element - %d : ", i + 1);
			scanf("%d", a + i);
		}
		for (i = 0; i < n; i++)
		{
			for (j = i + 1; j < n; j++)
			{
				if (*(a + i) > *(a + j))
				{
					tmp = *(a + i);
					*(a + i) = *(a + j);
					*(a + j) = tmp;
				}
			}
		}
		printf("\n The elements in the array after sorting : \n");
		for (i = 0; i < n; i++)
		{
			printf(" element - %d : %d \n", i + 1, *(a + i));
		}
		printf("\n");
	}
	
	

	//----------------------------17
	void main()
	{
	int n, i, arr1[15];
		int* pt;
		printf("\n\n Pointer : Print the elements of an array in reverse order :\n");
		printf("----------------------------------------------------------------\n");

		printf(" Input the number of elements to store in the array (max 15) : ");
		scanf("%d", &n);
		pt = &arr1[0];  // pt stores the address of base array arr1 
		printf(" Input %d number of elements in the array : \n", n);
		for (i = 0; i < n; i++)
		{
			printf(" element - %d : ", i + 1);
			scanf("%d", pt);//accept the address of the value
			pt++;
		}

		pt = &arr1[n - 1];

		printf("\n The elements of array in reverse order are :");

		for (i = n; i > 0; i--)
		{
			printf("\n element - %d : %d  ", i, *pt);
			pt--;
		}
		printf("\n\n");
	}
	

	//-----------------------------22

	void main() 
	{
		char str1[50];
		char revstr[50];
		char* stptr = str1;
		char* rvptr = revstr;
		int i = -1;
		printf("\n\n Pointer : Print a string in reverse order :\n");
		printf("------------------------------------------------\n");
		printf(" Input a string : ");
		scanf("%s", str1);
		while (*stptr)
		{
			stptr++;
			i++;
		}
		while (i >= 0)
		{
			stptr--;
			*rvptr = *stptr;
			rvptr++;
			--i;
		}
		*rvptr = '\0';
		printf(" Reverse of the string is : %s\n\n", revstr);
		return 0;
	}

	


