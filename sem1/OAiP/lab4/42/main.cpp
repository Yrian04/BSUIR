#include <iostream>
#include <conio.h>
#include <stdlib.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите n: ";
	int n = 0;
	cin >> n;
	if (cin.fail() || cin.peek() != '\n') {
		cout << "Ошибка";
		return 0;
	}
	double *a = new double[n];
	while (true) {
		cout << "Ввод с клавиатуры?(y/n)\n";
		char ch = _getch();
		if (ch == 'y') {
			cout << "Введите элементы массива: ";
			for (int i = 0; i < n; i++) {
				cin >> a[i];
				if (cin.fail() || (cin.peek() != '\n' && cin.peek() != ' ')) {
					cout << "Ошибка";
					return 0;
				}
			}
			break;
		}
		else if (ch == 'n') {
			cout << "\nЭлементы массива: ";
			for (int i = 0; i < n; i++) {
				a[i] = rand();
				cout << a[i] << ' ';
			}
			cout << endl;
			break;
		}
	}
	double s = 0;
	bool find = false;
	for (int i = 0; i < n; i++) {
		if (!find) {
			find = a[i] >= 0;
		}
		if (find) {
			if (a[i] < 0) {
				break;
			}
			s += a[i];
		}
	}
	cout << "Ответ: " << s;
}
