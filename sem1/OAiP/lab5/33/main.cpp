#include <iostream>
using namespace std;

int MAX(int* a, int n) {
	int m = a[0];
	for (int i = 1; i < n; i++) {
		m = max(a[i], a[i - 1]);
	}
	return m;
}

void Change(int *a, int *b, int n) {
	for (int i = 0; i < n; i++) {
		int c = a[i];
		a[i] = b[i];
		b[i] = c;
	}
}

void Change(int a, int b) {
	int c = a;
	a = b;
	b = c;
}

int main()
{
	setlocale(LC_ALL, "ru");
	cout << "Введите n, m:";
	int n, m;
	if (!(cin >> n >> m) || n < 0 || m < 0) {
		cout << "Ошибка";
		return 0;
	}

	int** a = new int* [n];
	for (int i = 0; i < n;i++) {
		a[i] = new int[m];
	}

	cout << "Введите элементы массива:\n";
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			if (!(cin >> a[i][j])) {
				cout << "Ошибка";
				return 0;
			}
		}
	}

	int* MaxEl = new int[n];
	for (int i = 0; i < n; i++) {
		MaxEl[i] = MAX(a[i], n);
	}

	for (int i = 1; i < n; i++) {
		int j = i;
		while ((MaxEl[i - 1] > MaxEl[i]) && (j > 0)) {\
			if (MaxEl[j - 1] > MaxEl[j]) {
				Change(MaxEl[j - 1], MaxEl[j]);
				Change(a[j - 1], a[j], m);
				j--;
			}
		}
	}

	cout << "Ответ:\n";
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			cout << a[i][j] << ' ';
		}
		cout << endl;
	}
}
