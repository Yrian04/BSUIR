#include <iostream>
#include <cmath>
#define PI 3.1415926
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите a, b, h: ";
	const int n = 10;
	double a, b, h;
	cin >> a >> b >> h;
	if (cin.fail()||cin.peek()!='\n') {
		cout << "Ошибка";
		return 0;
	}
	cout << " \tx\ty\ts\td" << endl;
	for (double x = a, int num = 0; x <= b; x+=h) {
		double s = 1, rec = 1;
		for (int k = 1; k <= n; k++) {
			rec *= x / k;
			s += cos(k * PI / 4) * rec;
		}
		double y = exp(x * cos(PI / 4)) * cos(x * sin(PI / 4));
		cout << ++num << "\t" << x << "\t" << y << "\t" << s << "\t" << abs(s - y) << endl;
	}
}