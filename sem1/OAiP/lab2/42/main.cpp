#include <math.h>
#include <iostream>
#include <conio.h>
#define PI 3.1415926
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите z, a, b: ";
	double z, f, x, a, b;
	if (!(cin >> z >> a >> b)) {
		cout << "Ошибка";
		return 0;
	}
	if (z < 0) {
		cout << "Ошибка";
		return 0;
	}
	if (z < 1) {
		cout << "Ветвь 1";
		x = z;
	}
	else {
		x = pow(z, 1.5);
		cout << "Ветвь 2";
	}
	cout << "\nВыберите функцию(2x, x^2, x/3): ";
	switch (_getch())
	{
		case '0':
			f = 2 * x;
			break;

		case '2':
			f = x * x;
			break;
		
		case '3':
			f = x / 3;
			break;

		default:
			cout << "Ошибка";
			return 0;
	}
	cout << "Ответ: " << -PI * f + a * pow(cos(pow(x, 3)), 2) + b * pow(sin(pow(x, 2)), 3);
}
