#pragma once

struct Stack
{
	char symbol;
	Stack* Next;
};

Stack* Add(Stack*, char);
Stack* Create(char);
Stack* OutStack(Stack*, char*);
void DeleteAll(Stack**);