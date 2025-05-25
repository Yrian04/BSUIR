#include <iostream>
#include "Header.h"
using namespace std;

Stack* Add(Stack* begin, char num) {
	Stack* node = new Stack;
	node->symbol = num;
	node->Next = begin;
	return node;
}

Stack* OutStack(Stack* begin, char* num) {
	if (begin == nullptr)
		return nullptr;
	Stack* node = begin;
	*num = node->symbol;
	begin = begin->Next;
	delete node;
	return begin;
}

Stack* Create(char n) {
	Stack* t = new Stack;
	t->Next = nullptr;
	t->symbol = n;
	return t;
}

void DeleteAll(Stack** begin) {
	*begin = Add(*begin, ' ');
	while (*begin != nullptr) {
		Stack* t = *begin;
		*begin = (*begin)->Next;
		delete t;
	}
}