#pragma once

struct Student
{
	char *surname;
	char *group;

	//key
	int year; 
};

Student* Create(char*, char*, int);
void DoubleHashingAdd(Student*, Student**);
Student* DoubleHashingSearch(int, Student**);