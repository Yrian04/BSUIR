#include <iostream>
using namespace std;

void Move(int *a, int k, int n) {
	for (int i = 0; i < n - k; i++) {
		a[i] = a[i + k];
	}
	for (int i = n - k; i < n; i++) {
		a[i] = 0;
	}
}

int main()
{
	setlocale(LC_ALL, "Russian");

	int n;
	cout << "Введите n: ";
	if (!(cin >> n)||cin.peek()!='\n') {
		cout << "Ошибка";
		return 0;
	}

	int* a = new int[n];
	cout << "Введите элементы массива: ";
	for (int i = 0; i < n; i++) {
		if (!(cin >> a[i]) || cin.peek() != '\n') {
			cout << "Ошибка";
			return 0;
		}
	}

	int k;
	cout << "Введите k: ";
	if (!(cin >> k)) {
		cout << "Ошибка";
		return 0;
	}

	Move(a, k, n);

	cout << "Ответ: ";
	for (int i = 0; i < n; i++) {
		cout << a[i] << ' ';
	}
}
