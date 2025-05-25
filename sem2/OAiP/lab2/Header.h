#pragma once
#include <stdio.h>

struct Student
{
	char secondName[20];
	char group[7];
	double medianMark;
	double income;
};

FILE* Create(char*);

void Add(char*);

void PrintStudent(Student);

void Print(char*);

int SizeOfFile(FILE*);

Student* ReadArray(char*, int*);

void WriteArray(char*, Student*, int n);

int LinearSearch(char*, double);

void SelectionSort(char*);

void QuickSort(char*);

int BinarySearch(char*, double);