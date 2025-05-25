#include <iostream>
#include <cmath>
#define PI 3.1415926
using namespace std;

double Y(double x) {
	return exp(x * cos(PI / 4)) * cos(x * sin(PI / 4));
}

double S(double x, int n) {
	double s = 1, rec = 1;
	for (int k = 1; k <= n; k++) {
		rec *= x / k;
		s += cos(k * PI / 4) * rec;
	}
	return s;
}

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
	cout << " \tx\ty\ts\tn" << endl;
	for (double x = a; x <= b; x+=h) {
		int n = 0;
		double d;
		do {
			d = abs(Y(x) - S(x, n));
			n++;
		} while (d >= 0.0001);
		cout << ++num << "\t" << x << "\t" << Y(x) << "\t" << S(x, n) << "\t" << n << endl;
	}
}