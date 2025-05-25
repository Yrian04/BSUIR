#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	int **a;
	int n, m;

	cout << "Введите количество строк и столбцов: ";
	if (!(cin >> n >> m)) {
		cout << "Ошибка";
		return 0;
	}

	a = new int *[n];
	for (int i = 0; i < n; i++) {
		a[i] = new int[m];
	}

	cout << "Введите элементы массива: " << endl;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			if (!(cin >> a[i][j])) {
				cout << "Ошибка";
				return 0;
			}
		}
	}

	int num = 0;
	for (int i = 0; i < m; i++) {
		int mul = 1;
		for (int j = 0; j < n; j++) {
			mul *= a[j][i];
		}
		if (mul == 0) {
			num++;
		}
	}
	cout << "Ответ: " << num;
}
