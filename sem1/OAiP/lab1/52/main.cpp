#include <iostream>
#include <math.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	double a;
	cout << "Введите значения: ";

	cin >> a;
	if (cin.fail() || cin.peek() != '\n') {
		cout << "Ошибка";
		return 0;
	}

	if (sin(2 * a) == -1 or tan(a) == -1 or cos(a) == 0) {
		cout << "Ошибка";
		return 0;
	}

	cout << "Ответ: " << (1 - 2 * pow(sin(a), 2)) / (1 + sin(2 * a)) << ' ' << (1 - tan(a)) / (1 + tan(a));
	return 0;
}