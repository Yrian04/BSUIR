#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "Header.h"
#include <cstring>
using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	Student** students = new Student * [7];
	Student** H = new Student * [20];
	for (int i = 0; i < 20; H[i++] = nullptr);
	FILE* file = fopen("D:\\in.txt", "r");
	for (int i = 0; i < 7; i++) {
		char* surname = new char[20], * group = new char[7];
		int year;
		fscanf(file, "%s\n%s\n%d", surname, group, &year);
		students[i] = Create(surname, group, year);
		DoubleHashingAdd(students[i], H);
	}
	printf("Enter year for searching: ");
	int year;
	scanf("%d", &year);
	printf("------STUDENTS-------");
	for (int i = 0; i < 7; i++)
		printf("\n\tSurname: %s\n\tGroup: %s\n\tYear: %d", students[i]->surname, students[i]->group, students[i]->year);
	cout << "\n------HASH_TABLE------";
	for (int i = 0; i < 20; i++)
		if (H[i])
			printf("\n\tSurname: %s\n\tGroup: %s\n\tYear: %d", H[i]->surname, H[i]->group, H[i]->year);
		else
			printf("\n\tNULL");
	printf("\n-----FOUND-----");
	Student* found = DoubleHashingSearch(year, H);
	if (found)
		printf("\n\tSurname: %s\n\tGroup: %s\n\tYear: %d\n", found->surname, found->group, found->year);
	else
		printf("\nNothig");

	delete[] students;
}

Student* Create(char* surname, char* group, int year) {
	Student* student = new Student;
	student->surname = surname;
	student->group = group;
	student->year = year;
	return student;
}

void DoubleHashingAdd(Student* student, Student** H) {
	int i = student->year % 20;
	while (H[i] != nullptr) {
		i -= 1 + (student->year % 18);
		i = i < 0 ? i + 20 : i;
	}
	H[i] = student;
}

Student* DoubleHashingSearch(int key, Student** H) {
	int i = key % 20;
	while (H[i] != nullptr) {
		if (H[i]->year == key)
			return H[i];
		i -= 1 + (key % 18);
		i = i < 0 ? i + 20 : i;
	}
	return nullptr;
}
