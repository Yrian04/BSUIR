#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include "Header.h"

// a/(b-c)*(d+e)

bool ConvertToRPN(char*, char*, char*, int*);
double ComputeExp(char*, char*, int);
int Prior(char);
double DoOperation(double, double, char);

int main()
{
	printf("Enter expression: ");
	char exp[201], rpn[201], vars[100];
	int n = 0;
	scanf("%s", exp);
	if (!ConvertToRPN(exp, rpn, vars, &n)) {
		printf("Invalid expression");
		return -1;
	}
	printf("Result: %lf", ComputeExp(rpn, vars, n));
}

bool ConvertToRPN(char* exp, char* rpn, char* vars, int* n)
{
	int j = 0;
	char c = exp[0], c1;
	Stack* begin = Create('!');
	for (int i = 0; i < strlen(exp); c = exp[++i]) {
		switch (c)
		{
		case '(':
			begin = Add(begin, c);
			break;
		case ')':
			if (begin->symbol == '!')
				return false;
			begin = OutStack(begin, &c1);
			while (c1 != '(') {
				if (begin->symbol == '!')
					return false;
				rpn[j++] = c1;
				begin = OutStack(begin, &c1);
			}
			break;
		case '+':
		case '-':
		case '*':
		case '/':
			while (begin->symbol != '!' && Prior(c) <= Prior(begin->symbol)) {
				begin = OutStack(begin, &c1);
				rpn[j++] = c1;
			}
			begin = Add(begin, c);
			break;
		default:
			if (!isalpha(c))
				return false;
			rpn[j++] = c;
			vars[(*n)++] = c;
			break;
		}
	}
	while (begin->symbol != '!') {
		begin = OutStack(begin, &c);
		if (c == '(')
			return false;
		rpn[j++] = c;
	}
	rpn[j] = '\0';
	vars[*n] = '\0';
	return true;
}

int Prior(char op) {
	switch (op)
	{
	case '(':
		return 1;
	case '*':
	case '/':
		return 2;
	case '+':
	case '-':
		return 3;
	}
	return 0;
}

int Find(char* str, char c) {
	int i = 0;
	while (str[i] != '\0') {
		if (str[i] == c)
			return i;
		i++;
	}
	return -1;
}

double Compute(char* rpn, char* vars, double* nums, int* i, char op) {
	double a, b;

	switch (rpn[--(*i)])
	{
	case '+':
	case '-':
	case '*':
	case '/':
		a = Compute(rpn, vars, nums, i, rpn[*i]);
		break;
	default:
		a = nums[Find(vars, rpn[*i])];
		break;
	}

	switch (rpn[--(*i)])
	{
	case '+':
	case '-':
	case '*':
	case '/':
		b = Compute(rpn, vars, nums, i, rpn[*i]);
		break;
	default:
		b = nums[Find(vars, rpn[*i])];
	}

	return DoOperation(b, a, op);
}

double ComputeExp(char* rpn, char* vars, int n) {
	double* nums = new double[n];
	for (int i = 0; i < n; i++) {
		printf("Enter %c: ", vars[i]);
		scanf("%lf", nums + i);
	}
	int i = strlen(rpn) - 1;
	return Compute(rpn, vars, nums, &i, rpn[i]);
}

double DoOperation(double a, double b, char op) {
	switch (op)
	{
	case '+':
		return a + b;
	case '-':
		return a - b;
	case '*':
		return a * b;
	case '/':
		return a / b;
	default:
		return 0;
	}
}