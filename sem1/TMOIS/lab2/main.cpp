#include <iostream>
#include <conio.h>
using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	bool flag = true;
	int first[100], second[100], len1, len2;
	do {
		cout << "Выберите способ задания множетва:\n\t1 - перечисление\n\t2 - высказвание\n"; //1
		switch (_getch())//2, 3
		{
		case '1':
			cout << "Введите мощность первого множества: ";//4
			cin >> len1;
			cout << "Введите элементы первого множества: ";//5
			for (int i = 0; i < len1; cin >> first[i++]);
			cout << "Введите мощность второго множества: ";//6
			cin >> len2;
			cout << "Введите элементы второго множества: ";//7
			for (int i = 0; i < len2; cin >> second[i++]);
			break;//8
		case '2':
			int n1, m1, n2, m2;
			do {
				cout << "Введите границы диапозона n1, m1 для первого множества(-10 <= n1 < m1 <= 10): ";//9
				cin >> n1 >> m1;
				if (n1 > m1 || n1 > 10 || n1 < -10 || m1 > 10 || m1 < -10) { // 10
					cout << "Попробуйте снова...\n";
					continue;
				}
				for (int i = n1, j = 0; i <= m1; first[j++] = i * i + 30 * i++ - 1); //11
				len1 = m1 - n1 + 1;
				break;
			} while (true);
			do {
				cout << "Введите границы диапозона n2, m2 для второго множества(-10 <= n2 < m2 <= 10): ";//12
				cin >> n2 >> m2;
				if (n2 > m2 || n2 > 10 || n2 < -10 || m2 > 10 || m2 < -10) { ///13
					cout << "Попробуйте снова...\n";
					continue;
				}
				for (int i = n2, j = 0; i <= m2; second[j++] = i * i - 40 * i++ + 5); //14
				len2 = m2 - n2 + 1;
				break;
			} while (true);
			break;
		default:
			cout << "Попробуйте снова...\n";
			continue;
		}
		break;
	} while (true);
	char choise;
	do { 
		int **C = new int*[10000], lenc = 0; // 15
		for (int i = 0; i < 10000; C[i++] = new int);
		int D[100], lend = 0;
		int E[100], lene = 0;
		int a, b;
		cout << "Выберете операцию:\n\t1 - объединение\n\t2 - пересечение\n\t3 - разность\n\t4 - симметрическая разность\n\t5 - дополнение\n\t6 - декартово произведение\n"; // 16
		switch (_getch()) //17, 18, 19, 20, 21, 22
		{
		case '1':
			for (int i = 0; i < len1; C[i][0] = first[i++]); //23.1
			lenc += len1;
			a = second[0];//23.2
			for (int i = 0; i < len2;) {
				b = C[0][0]; //23.3
				for (int j = 0; j < lenc;) {
					if (a == b)//23.4
						break;
					if (j == lenc - 1)//23.5
						C[lenc++][0] = a;
					else
						b = C[++j][0];//23.6
				}
				a = second[++i];//23.7
			}
			break;//23.8
		case '2':
			a = first[0];//24.1
			for (int i = 0; i < len1;) {
				b = second[0];//24.2
				for (int j = 0; j < len2;) {
					if (a == b)//24.3
						C[lenc++][0] = a;
					b = second[++j];//24.4
				}
				a = first[++i];//24.5
			}
			break;//24.6
		case '3':
			a = first[0];//25.1
			for (int i = 0; i < len1;) {
				b = second[0];//25.2
				for (int j = 0; j < len2;) {
					if (a == b)//25.3
						break;
					if (j != len2 - 1) { //25.4
						b = second[++j];
						continue;
					}
					else { //25.5
						C[lenc++][0] = a;
						break;
					}
				}
				a = first[++i];//25.6
			}
			break;//25.7
		case '4':
			a = first[0];//26.2
			for (int i = 0; i < len1;) {
				b = second[0];//26.3
				for (int j = 0; j < len2;) {
					if (a == b)//26.4
						break;
					if (j != len2 - 1) {//26.5
						b = second[++j];
						continue;
					}
					else {
						D[lend++] = a;//26.6
						break;
					}
				}
				a = first[++i]; //26.7
			}
			a = second[0];//26.9
			for (int i = 0; i < len1;) {
				b = first[0];//26.10
				for (int j = 0; j < len2;) {
					if (a == b)//26.11
						break;
					if (j != len2 - 1) {//26.12
						b = first[++j];
						continue;
					}
					else {
						E[lene++] = a;//26.13
						break;
					}
				}
				a = second[++i];//26.14
			}
			for (int i = 0; i < lend; C[i][0] = D[i++]);//26.15
			lenc += lend;
			a = E[0];//26.16
			for (int i = 0; i < lene;) {
				b = C[0][0];//26.17
				for (int j = 0; j < lenc;) {
					if (a == b)//26.18
						break;
					if (j == lenc - 1)//26.19
						C[lenc++][0] = a;
					else
						b = C[++j][0];//16.20
				}
				a = E[++i];//26.21
			}
			break;//26.22
		case '5':
			int U[2001];//27.1
			for (int i = -1000; i < 1001; U[i + 1000] = i++);
			a = U[0];//27.2
			for (int i = 0; i < 2001;) {
				b = first[0];//27.3
				for (int j = 0; j < len1;) {
					if (a == b)//27.4
						break;
					if (j != len1 - 1) {//27.5
						b = first[++j];
						continue;
					}
					else {
						C[lenc++][0] = a; //27.6
						break;
					}
				}
				a = U[++i];//27.7
			}
			break;//27.8
		case '6':
			delete[] C;
			C = new int*[10000];
			for (int i = 0; i < 10000; C[i++] = new int[2])
			a = first[0];//28.1
			for (int i = 0; i < len1;) {
				b = second[0];//28.2
				for (int j = 0; j < len2;) {
					int* cortege = new int[2];//28.3
					cortege[0] = a;
					cortege[1] = b;
					C[lenc++] = cortege;
					b = second[++j];//28.4
				}
				a = first[++i];//28.5
			}
			flag = false;
			break;
		default:
			cout << "Попробуйте снова...\n";
			continue;
		}
		cout << "Ответ: ";
		if (flag)//29
			for (int i = 0; i < lenc; cout << C[i++][0] << ' ');
		else
			for (int i = 0; i < lenc; i++)
				cout << '<' << C[i][0] << ',' << C[i][1] << '>' << endl;
		cout << "\nЖелаете выполнить ещё одну операцию над множествами?(Yes/No)\n";//30
		choise = _getch();
	} while (choise == 'y' || choise == 'Y');
	return 0; // 31
}
