#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <conio.h>
#include "Header.h"
using namespace std;

int main()
{
	char fileName[100];
	printf("Use existing file(1) or create new(2)?\n");
	char p;
	while (true) {
		p = _getch();
		if (p == '2') {
			printf("Enter name of new file: ");
			scanf("%s", fileName);
			Create(fileName);
			break;
		}
		if (p == '1') {
			printf("Enter name of file: ");
			scanf("%s", fileName);
			break;
		}
		printf("Try again...\n");
	}
	double income;
	int n, index;
	Student* students = ReadArray(fileName, &n);
	while (true) {
		printf("Choose action:\n\t1 - Create\n\t2 - Add\n\t3 - Print\n\t4 - Selection sort\n\t5 - Quick sort\n\t6 - Linear serch\n\t7 - Binary search\n\t0 - Quit\n");
		switch (_getch())
		{
		case '1':
			printf("Enter name of file: ");
			scanf("%s", fileName);
			Create(fileName);
			continue;
		case '2':
			Add(fileName);
			continue;
		case '3':
			Print(fileName);
			continue;
		case '4':
			SelectionSort(fileName);
			continue;
		case '5':
			QuickSort(fileName);
			continue;
		case '6':
			printf("Enter income of student: ");
			scanf("%lf", &income);
			index = LinearSearch(fileName, income);
			if (index == -1)
				printf("Find nothing\n");
			else {
				students = ReadArray(fileName, &n);
				PrintStudent(students[index]);
			}
			continue;
		case '7':
			printf("Enter income of student: ");
			scanf("%lf", &income);
			index = BinarySearch(fileName, income);
			if (index == -1)
				printf("Find nothing\n");
			else {
				students = ReadArray(fileName, &n);
				PrintStudent(students[index]);
			}
			continue;
		case '0':
			break;
		default:
			printf("Try again...\n");
			continue;
		}
		break;
	}
	return 0;
}