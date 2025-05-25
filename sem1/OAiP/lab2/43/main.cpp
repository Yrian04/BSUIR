#include <iostream>
#include <cmath>
using namespace std;

double Max(double a, double b) {
	if (a > b) {
		return a;
	}
	else {
		return b;
	}
}

double Min(double a, double b) {
	if (a < b) {
		return a;
	}
	else {
		return b;
	}
}

int main()
{
	setlocale(LC_ALL, "Russian");
	double x, y, z;
	cout << "Введите x, y, z: ";
	if (!(cin >> x >> y >> z)) {
		cout << "Ошибка";
		return 0;
	}
	if (Min(x + y + z, x * y * z) == 0) {
		cout << "Ошибка";
		return 0;
	}
	cout << "Ответ: " << Max(x + y + z, x * y * z) / Min(x + y + z, x * y * z);
}