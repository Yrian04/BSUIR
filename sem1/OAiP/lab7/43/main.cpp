#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <stdio.h>
#include <conio.h>

const int LengthOfString = 1024;

bool IsVowel(char ch) {

	switch (ch)
	{
	case 'e':
	case 'y':
	case 'u':
	case 'i':
	case 'o':
	case 'a':
		return true;
		break;
	default:
		return false;
		break;
	}
}

char* Code(char* str) {
	int j = 0;
	char Codedstr[LengthOfString];

	for (int i = 0; i < LengthOfString; i++) {
		if (str[i] == '\0') {
			break;
		}
		if (IsVowel(str[i])||!isalpha(str[i])) {
			Codedstr[j] = str[i];
			j++;
		}
		else {
			Codedstr[j] = str[i];
			j++;
			Codedstr[j] = 'a';
			j++;
		}
	}
	Codedstr[j] = '\0';

	return Codedstr;
}

char* Decode(char* str) {
	int j = 0;
	char Decodedstr[LengthOfString];

	for (int i = 0; i < LengthOfString; i++) {
		if (str[i] == '\0') {
			break;
		}
		if (IsVowel(str[i]) || !isalpha(str[i])) {
			Decodedstr[j] = str[i];
			j++;
		}
		else {
			Decodedstr[j] = str[i];
			j++;
			i++;
		}
	}
	Decodedstr[j] = '\0';

	return Decodedstr;
}

int main()
{
	setlocale(LC_ALL, "ru");
	printf("Что будем делать?\n\t1 - кодировать\n\t2 - декодировать\n");
	FILE* file1 = fopen("Text.txt", "r");
	FILE* file = fopen("Answer.txt", "w");
	char str[LengthOfString];
	while (true) {
		switch (_getch())
		{
		case '1':
			printf("Введите текст: ");
			gets_s(str);
			fprintf(file, "%s", Code(str));
			return 0;
		case '2':
			fgets(str,LengthOfString ,file1);
			printf("Ответ: %s", Decode(str));
			fprintf(file, "%s", Decode(str));
			return 0;
		default:
			break;
		}
	}
	fclose(file);
	fclose(file1);
}