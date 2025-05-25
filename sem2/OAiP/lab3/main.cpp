#include <iostream>
#include "Header.h"
using namespace std;

void Solution(Stack**, int);

int main()
{
	int n;
	cout << "Enter number of nodes: ";
	cin >> n;
	Stack* begin = CreateRandom(n);
	cout << "--STACK--\n";
	View(begin);
	Solution(&begin, n);
	cout << "--Solution--\n";
	View(begin);
	DeleteAll(&begin);
}

void Solution(Stack** begin, int n) {
	Stack* prev = new Stack;
	prev->Num = n;
	prev->Next = *begin;
	Stack* answer = prev;
	Stack* node = *begin;
	while (node != nullptr) {
		if (node->Num < 0) {
			node = node->Next;
			delete prev->Next;
			prev->Next = node;
		}
		else {
			prev = node;
			node = node->Next;
		}
	}
	answer = Delete(answer);
	Sort_p(&answer);
	*begin = answer;
}