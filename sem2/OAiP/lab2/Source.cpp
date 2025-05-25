#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "Header.h"
#include <io.h>

FILE* Create(char* name) {
	FILE* file = fopen(name, "wb");
	fclose(file);
	return file;
}

void Add(char* fileName) {
	Student student;
	printf("Enter the second name, group, median mark and income of student: ");
	scanf("%s %s %lf %lf", &student.secondName, &student.group, &student.medianMark, &student.income);
	FILE* file = fopen(fileName, "ab");
	fwrite(&student, sizeof(Student), 1, file);
	fclose(file);
}

int SizeOfFile(FILE* file) {
	return _filelength(_fileno(file)) / sizeof(Student);
}

Student* ReadArray(char* fileName, int* n) {
	FILE* file = fopen(fileName, "rb");
	*n = SizeOfFile(file);
	Student* students = new Student[*n];
	fread(students, sizeof(Student), *n, file);
	fclose(file);
	return students;
}

void WriteArray(char* fileName, Student* students, int n) {
	FILE* file = fopen(fileName, "wb");
	fwrite(students, sizeof(Student), n, file);
	fclose(file);
}

void PrintStudent(Student student) {
	printf("--- %s ---\nGroup: %s\nMedian mark: %lf\nIncome: %lf\n",
		student.secondName, student.group, student.medianMark, student.income);
}

void Print(char* fileName) {
	int n;
	Student* students = ReadArray(fileName, &n);
	if (n == 0) {
		printf("There is nothing\n");
		return;
	}
	for (int i = 0; i < n; i++) {
		PrintStudent(students[i]);
	}
	delete[] students;
}

int LinearSearch(char* fileName, double income) {
	int n;
	Student* students = ReadArray(fileName, &n);
	for (int i = 0; i < n; i++)
		if (students[i].income == income) {
			delete[] students;
			return i;
		}
	delete[] students;
	return -1;
}

void SelectionSort(char* fileName) {
	int n;
	Student* students = ReadArray(fileName, &n);
	for (int i = 0; i < n; i++) {
		int minIndex = i;
		for (int j = i + 1; j < n; j++)
			if (students[j].income < students[minIndex].income)
				minIndex = j;
		Student buffer = students[i];
		students[i] = students[minIndex];
		students[minIndex] = buffer;
	}
	WriteArray(fileName, students, n);
	delete[] students;
}

void QuickSort(Student* students, int left, int right) {
	if (right <= left)
		return;
	int i = left, j = right, x = students[(left + right) / 2].income;
	while (i <= j) {
		while (students[i].income < x) i++;
		while (students[j].income > x) j--;
		if (i <= j) {
			Student buffer = students[i];
			students[i] = students[j];
			students[j] = buffer;
			i++; j--;
		}
	}
	QuickSort(students, left, j);
	QuickSort(students, i, right);
	return;
}

void QuickSort(char* fileName) {
	int n;
	Student* students = ReadArray(fileName, &n);
	QuickSort(students, 0, n-1);
	WriteArray(fileName, students, n);
}

int BinarySearch(Student* students, double income, int left, int right) {
	if (left == right)
		return left;
	int i = (left + right) / 2;
	if (students[i].income < income)
		return BinarySearch(students, income, i+1, right);
	return BinarySearch(students, income, left, i);
}

int BinarySearch(char* fileName, double income) {
	int n;
	Student* students = ReadArray(fileName, &n);
	int index = BinarySearch(students, income, 0, n - 1);
	if (students[index].income != income)
		index = -1;
	delete[] students;
	return index;
}