#include <iostream>
#include "Header.h"
using namespace std;

Stack* Add(Stack* begin, int num) {
	Stack* node = new Stack;
	node->Num = num;
	node->Next = begin;
	return node;
}

Stack* Delete(Stack* begin) {
	Stack* t = begin->Next;
	delete begin;
	return t;
}

Stack* OutStack(Stack* begin, int* num) {
	if (begin == nullptr){
		num = nullptr;
		return nullptr;
	}
	Stack* node = begin;
	*num = node->Num;
	begin = begin->Next;
	delete node;
	return begin;
}

Stack* Create(int n) {
	Stack* t = new Stack;
	t->Next = nullptr;
	t->Num = n;
	return t;
}

Stack* CreateRandom(int n) {
	Stack* node = new Stack;
	node->Num = rand() % 101 - 50;
	node->Next = nullptr;
	for (int i = 0; i < n - 1; i++) {
		node = Add(node, rand() % 101 - 50);
	}
	return node;
}

void DeleteAll(Stack** begin) {
	*begin = Add(*begin, 5);
	while (*begin != nullptr) {
		Stack* t = *begin;
		*begin = (*begin)->Next;
		delete t;
	}
}

void Sort_p(Stack** p) {
	*p = Add(*p, 0);
	Stack* t = NULL, * t1, * r;
	if (*p == NULL) return;
	if ((*p)->Next == NULL) return;
	if ((*p)->Next->Next == NULL) return;
	do {
		for (t1 = *p; t1->Next->Next != t; t1 = t1->Next)
			if (t1->Next->Num > t1->Next->Next->Num) {
				r = t1->Next->Next;
				t1->Next->Next = r->Next;
				r->Next = t1->Next;
				t1->Next = r;
			}
		t = t1->Next;
	} while ((*p)->Next->Next != t);
	int n;
	*p = OutStack(*p, &n);
}

void Sort_info(Stack* p) {
	if (p == NULL || p->Next == NULL)
		return;
	Stack* t = NULL, * t1;
	int r;
	do {
		for (t1 = p; t1->Next != t; t1 = t1->Next)
			if (t1->Num > t1->Next->Num) {
				r = t1->Num;
				t1->Num = t1->Next->Num;
				t1->Next->Num = r;
			}
		t = t1;
	} while (p->Next != t);
}

void View(Stack* begin) {
	Stack* node = begin;
	while (node != NULL) {
		cout << node->Num << endl;
		node = node->Next;
	}
}