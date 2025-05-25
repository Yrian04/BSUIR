#include <iostream>
using namespace std;

void Concatenate(char* str1, char* str2) {
	int i = 0, j = 0;
	while (str1[i] != '\0') {
		i++;
	}
	while (str2[j] != '\0') {
		str1[i] = str2[j];
		j++;
		i++;
	}
	str1[i] = '\0';
}

int main()
{
	setlocale(LC_ALL, "ru");
	char str1[100], str2[100];
	printf("Введите 1 строку: ");
	gets_s(str1);
	printf("Введите 2 строку: ");
	gets_s(str2);
	Concatenate(str1, str2);
	Concatenate(str1, str2);
	cout  << "Ответ: " << str1;
}
