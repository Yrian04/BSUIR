#include <iostream>
#include <string.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	char s[100];
	cout << "Введите число: ";
	cin >> s;
	int f = 0, l = strlen(s);
	for (int i = 0; i < round(l/2.); i++) {
		f += s[i] - s[l - i - 1];
	}
	f == 0 ? cout << "Число симметрично\n" : cout << "Число не симметрично\n";
	int i;
	l > 3 ? i = l - 3 : i = 0;
	for (i; i < l; i++) {
		cout << s[i];
	}
}