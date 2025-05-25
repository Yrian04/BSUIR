#include <iostream>
#include <conio.h>
using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	int first[100], second[100], len1, len2;
	cout << "Введите мощность первого множества: ";	                                        //1 запрашиваем у пользователя мощность первого множества
	cin >> len1;									        //2 запрашиваем у пользователя элементы первого множества
	cout << "Введите элементы первого множества: ";	
	for (int i = 0; i < len1; cin >> first[i++]);	
	cout << "Введите мощность второго множества: ";	                                        //3 запрашиваем у пользователя мощность второго множества
	cin >> len2;
	cout << "Введите элементы второго множества: ";	                                        //4 запрашиваем у пользователя элементы второго множества
	for (int i = 0; i < len2; cin >> second[i++]);
	char choise;
	do {
		cout << "Выберете операцию:\n\t1 - объединение\n\t2 - пересечение\n";	        //5 запрашиваем операцию у пользователя
		int C[200], lenc = 0;								//6 создём пустое множесво С
		int a, b;
		switch (_getch())								//7
		{
		case '1':
			for (int i = 0; i < len1; C[i] = first[i++]);				//8.1 добавляем элементы первого множесва во множество С 
			lenc += len1;
			for (int i = 0; i < len1; C[i] = first[i++]);
			a = second[0];								//8.2 возмём первый элемент второго множества 
			for (int i = 0; i < len2;) {
				b = C[0];							//8.3 возмём первый элемент множества С
				for (int j = 0; j < lenc;) {
					if (a == b)						//8.4
						break;
					if (j == lenc - 1)					//8.5
						C[lenc++] = a;
					else
						b = C[++j];
				}
				a = second[++i];						//8.6
			}
			break;
		case '2':
			a = first[0];								//9.1
			for (int i = 0; i < len1;) {							
				b = second[0];							//9.2
				for (int j = 0; j < len2;) {
					if (a == b)						//9.3
						C[lenc++] = a;
					b = second[++j];					//9.4
				}
				a = first[++i];							//9.5
			}
			break;
		default:
			cout << "Ошибка";
			return 0;
		}
		cout << "Ответ: ";								//10
		for (int i = 0; i < lenc; cout << C[i++] << ' ');
		cout << "\nЖелаете выполнить ещё одну операцию над множествами?(Yes/No)\n";	//11
		choise = _getch();
	} while (choise == 'y' || choise == 'Y');
}
