#include <iostream>
#include <math.h>
using namespace std;

int main() //набор инструкций
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите z, y, z: ";
	double x, y, z;

	if (!(cin >> x >> y >> z)) {
		cout << "Ошибка";
		return 0;
	}

	if (x - 2 * y * abs(1 + pow(x * y, 2)) == 0 or z == 0 or cos(1. / z) == 0) {
		cout << "Ошибка";
		return 0;
	}

	cout << "Ответ: " << (1 + pow(sin(x + y), 2)) / abs(x - 2 * y / (1 + pow(x * y, 2))) * pow(x, abs(y)) + pow(cos(atan(1. / z)), 2);

	return 0;
}