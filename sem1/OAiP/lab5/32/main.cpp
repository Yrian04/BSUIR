#include <iostream>
#include <vector>
using namespace std;

bool IsSimm(int* a, int n) {
	int f = 0;
	for (int i = 0; i < round(n / 2.); i++) {
		f += a[i] - a[n - i - 1];
	}
	return f == 0;
}

int main()
{
	setlocale(LC_ALL, "ru");
	cout << "Введите n и m: ";
	int n, m;

	if (!(cin >> n >> m) || n < 0 || m < 0) {
		cout << "Ошибка";
		return 0;
	}

	int** a = new int* [n];
	for (int i = 0; i < n; a[i++] = new int[m]);

	cout << "Введите элементы массива:\n";
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			cin >> a[i][j];
			if (cin.fail() || (cin.peek() != '\n' && cin.peek() != ' ')) {
				cout << "Ошибка";
				return 0;
			}
		}
	}


	int* b = new int[n];
	for (int i = 0; i < n; i++) {
		b[i] = false;
	}

	for (int i = 0; i < n; i++) {
		if (IsSimm(a[i], m)) {
			b[i] = true;
		}
	}

	cout << "Ответ: ";
	for (int i = 0; i < n; i++) {
		cout << b[i] << ' ';
	}

	delete[]a;
	delete[]b;
}
