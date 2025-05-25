#include <iostream>
using namespace std;

struct List {
	int Num;
	List* Next, * Prev;
};

void CreateList(List**, List**, int);
void AddToEnd(List**, int);
void AddToBegin(List**, int);
int OutFromEnd(List**);
int OutFromBegin(List**);
void ViewFromEnd(List*);
void ViewFromBegin(List*);
void DeleteAll(List**, List**);
void Solution(List**, List**);

int main()
{
	int n;
	cout << "Enter number of nodes: ";
	cin >> n;
	List* begin, * end;
	CreateList(&begin, &end, rand() % 101 - 50);
	for (int i = 0; i < n-1; i++) {
		AddToEnd(&end, rand() % 101 - 50);
	}
	cout << "--List--\n";
	ViewFromBegin(begin);
	Solution(&begin, &end);
	cout << "--Answer--\n";
	ViewFromBegin(begin);
	DeleteAll(&begin, &end);
}

void Solution(List** begin, List** end) {
	AddToBegin(begin, 0);
	AddToEnd(end, 0);
	List* node = (*begin)->Next;
	while (node->Next != nullptr)
	{
		if (node->Num < 0) {
			node = node->Next;
			node->Prev = node->Prev->Prev;
			delete node->Prev->Next;
			node->Prev->Next = node;
		}
		else {
			node = node->Next;
		}
	}
	OutFromBegin(begin);
	OutFromEnd(end);
}

void CreateList(List** begin, List** end, int in) {
	List* t = new List;
	t->Num = in;
	t->Next = nullptr;
	t->Prev = nullptr;
	*begin = t;
	*end = t;
}

void AddToEnd(List** end, int in) {
	List* t = new List;
	t->Num = in;
	t->Next = nullptr;
	t->Prev = *end;
	(*end)->Next = t;
	*end = t;
}

void AddToBegin(List** begin, int in) {
	List* t = new List;
	t->Num = in;
	t->Next = *begin;
	t->Prev = nullptr;
	(*begin)->Prev = t;
	*begin = t;
}

int OutFromEnd(List** end) {
	List* t = *end;
	*end = (*end)->Prev;
	int n = t->Num;
	delete t;
	(*end)->Next = nullptr;
	return n;
}

int OutFromBegin(List** begin) {
	List* t = *begin;
	*begin = (*begin)->Next;
	int n = t->Num;
	delete t;
	(*begin)->Prev = nullptr;
	return n;
}

void ViewFromEnd(List* end) {
	if (end == nullptr)
		return;
	while (end != nullptr) {
		cout << end->Num << endl;
		end = end->Prev;
	}
	end = end->Prev;
}

void ViewFromBegin(List* begin) {
	if (begin == nullptr)
		return;
	while (begin->Next != nullptr)
	{
		cout << begin->Num << endl;
		begin = begin->Next;
	}
	cout << begin->Num << endl;
}

void DeleteAll(List** begin, List** end) {
	List* node = *begin;
	while (node != nullptr) {
		List* t = node;
		node = node->Next;
		delete t;
	}
	*begin = nullptr;
	*end = nullptr;
}