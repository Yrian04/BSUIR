#include <iostream>
#include <math.h>
#define PI 3.1415926
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите z, b: ";
	double z, x, b;
	cin >> z >> b;
	if (z < 1) {
		x = z / b;
		cout << "Первая ветвь" << endl;
	}
	else {
		x = pow(z * b, 1.5);
		cout << "Вторая ветвь" << endl;
	}
	cout << "Ответ: " << -PI - pow(cos(pow(x, 3)), 2) + pow(sin(pow(x, 2)), 3);
}

