#include <iostream>
using namespace std;

int NOD_r(int n, int m) {
	if (n == 0) {
		return m;
	}
	if (m % n == 0) {
		return n;
	}
	return NOD_r(m % n, n);
}

int NOD(int n, int m) {
	if (n == 0) {
		return m;
	}
	while (m % n != 0) {
		int l = n;
		n = m % n;
		m = l;
	}
	return n;
}

int main()
{
	setlocale(LC_ALL, "ru");
	cout << "Введите n и m: ";
	int n, m;
	if (!(cin >> n >> m)) {
		cout << "Ошибка";
		return 0;
	}
	cout << "Ответ: " << NOD(m, n) << ' ' << NOD_r(m, n);
}
