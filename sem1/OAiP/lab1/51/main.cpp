#include <iostream>
#include <math.h>;
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	double a;
	cout << "Введите данные: ";
	cin >> a;
	cout << endl << "Ответ: " << (sin(2 * a) + sin(5 * a) - sin(3 * a)) / (cos(a) + 1 - 2 * pow(sin(2 * a), 2)) << ' ' << 2 * sin(a);
	return 0;
}

