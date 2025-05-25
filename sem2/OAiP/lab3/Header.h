#pragma once

struct Stack
{
	int Num;
	Stack* Next;
};

Stack* Add(Stack*, int);
Stack* Delete(Stack*);
Stack* Create(int);
Stack* CreateRandom(int);
Stack* OutStack(Stack*, int*);
void View(Stack*);
void DeleteAll(Stack**);
void Sort_p(Stack**);
void Sort_info(Stack*);