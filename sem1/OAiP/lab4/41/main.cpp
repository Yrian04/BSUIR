#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите n: ";
	int n;
	if (!(cin >> n)) {
		cout << "Ошибка";
		return 0;
	}
	double *a = new double[n];
	cout << "Введите элементы массива: ";
	for (int i = 0; i < n; i++) {
		if (!(cin >> a[i])) {
			cout << "Ошибка";
			return 0;
		}
	}
	double s = 0;
	for (int i = 0; i < n; i++) {
		if (a[i] < 0) {
			break;
		}
		s += a[i];
	}
	cout << "Ответ: " << s;
}
