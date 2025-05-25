#include <iostream>
using namespace std;

int sign(double a) {
	return a < 0 ? -1 : 1;
}

int main()
{
	int n;
	cout << "Enter n: ";
	cin >> n;

	double** a = new double* [n];
	cout << "Enter A:\n";
	for (int i = 0; i < n; i++) {
		a[i] = new double[n];
		for (int j = 0; j < n; j++) {
			cin >> a[i][j];
		}
		rewind(stdin);
	}

	double* b = new double[n];
	cout << "Enter b:\n";
	rewind(stdin);
	for (int i = 0; i < n; i++) {
		cin >> b[i];
	}

	double* x = new double[n];

	double del;

	int* d = new int[n];
	d[0] = sign(a[0][0]);

	double** s = new double* [n];
	for (int i = 0; i < n; i++)
		s[i] = new double[n];
	s[0][0] = sqrt(a[0][0]);

	/*for (int k = 0; k < n; k++) {
		double l = a[k][k];
		for (int i = 0; i < k; i++)
			l -= d[i] * s[i][k] * s[i][k];
		s[k][k] = sqrt(abs(l));
		d[k] = sign(l);
		for (int j = k; j < n; j++) {
			l = a[k][j];
			for (int i = 0; i < n; i++)
				l -= d[i] * s[i][k] * s[i][j];
			s[k][j] = l / (s[k][k] * d[k]);
		}
	}*/

	for (int k = 0; k < n; k++) {
		del = a[k][k];
		for (int i = 0; i < k; i++)
			del -= d[i] * s[i][k] * s[i][k];
		d[k] = sign(del);
		s[k][k] = sqrt(abs(del));
		for (int j = k + 1; j < n; j++) {
			del = a[k][j];
			for (int i = 0; i < k; i++)
				del -= d[i] * s[i][k] * s[i][k];
			s[k][j] = del / (s[k][k] * d[k]);
		}
	}

	double* y = new double[n];
	y[0] = b[0] / (s[0][0] * d[0]);
	for (int i = 1; i < n; i++) {
		del = b[i];
		for (int k = 0; k < i; k++)
			del += s[k][i] * y[k];
		y[i] = del / s[i][i];
	}


	x[n-1] = y[n-1] / s[n-1][n-1];
	for (int i = n - 1; i > -1; i--) {
		del = y[i];
		for (int k = i; k < n; k++)
			del -= x[k] * s[i][k];
		x[i] = del / s[i][i];
	}

	cout << "Answer:\n";
	for (int i = 0; i < n; i++)
		cout << x[i] << endl;
}
