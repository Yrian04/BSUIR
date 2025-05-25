#include <iostream>
#include <cmath>
#define PI 3.1415926
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите a, b, h: ";
	double a, b, h;
	if (!(cin >> a >> b >> h)) {
		cout << "Ошибка";
		return 0;
	}
	int num = 0;
	cout << " \tx\ty" << endl;
	for (double x = a; x <= b; x+=h) {
		cout << ++num << "\t" << x << "\t" << x * sin(PI / 4) / (1 - 2 * x * cos(PI / 4) + x * x) << endl;
	}
}
