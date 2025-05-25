#pragma once

#define _CRT_SECURE_NO_WARNINGS
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>
#include <conio.h>

struct node {
	int key;
	node* left;
	node* right;
	int height;
		
	char* info;

	node(int key, char* info) {
		this->key = key;
		left = right = NULL;
		this->info = info;
		height = 1;
	}
};

node* balance_node(node*);
node* insert(node*, int, char*);
void view(node*, int);
node* search(node*, int);
node* tree_from_array(int*, char**, int);
node* remove_node(node*, int);
void delete_tree(node*);
node* delete_branch(node*, int);
node* balance_tree(node*);