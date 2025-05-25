#include "Header.h"

int height(node* node) {
	return node ? node->height : 0;
}

int balance_factor(node* node) {
	return height(node->right) - height(node->left);
}

void calculate_height(node* node) {
	node->height = std::max(height(node->left), height(node->right)) + 1;
}

node* rotate_right(node* node) {
	struct node* buff = node->left;
	node->left = buff->right;
	buff->right = node;
	calculate_height(node);
	calculate_height(buff);
	return buff;
}

node* rotate_left(node* node) {
	struct node* buff = node->right;
	node->right = buff->left;
	buff->left = node;
	calculate_height(node);
	calculate_height(buff);
	return buff;
}

node* balance_node(node* node) {
	calculate_height(node);
	if (balance_factor(node) > 1) {
		if (balance_factor(node->right) < 0)
			node->right = rotate_right(node->right);
		return rotate_left(node);
	}
	if (balance_factor(node) < -1) {
		if (balance_factor(node->left) > 0)
			node->left = rotate_left(node->left);
		return rotate_right(node);
	}
	return node;
}

node* insert(node* root, int key, char* info) {
	if (!root)
		return new node(key, info);
	if (search(root, key)) {
		printf("Key is already in use!\n");
		return root;
	}
	if (key < root->key)
		root->left = insert(root->left, key, info);
	else
		root->right = insert(root->right, key, info);
	return balance_node(root);
}

void view(node* root, int level) {
	if (root) {
		for (int i = 0; i < level; printf(" "), i++);
		printf("%s[%d]\n", root->info, root->key);
		level++;
		view(root->left, level + 1);
		view(root->right, level + 1);
	}
}

node* search(node* root, int key) {
	if (!root)
		return NULL;
	if (key < root->key)
		return search(root->left, key);
	if (key > root->key)
		return search(root->right, key);
	return root;
}

node* tree_from_array(int* keys, char** infos, int length) {
	node* root = NULL;
	for (int i = 0; i < length; i++)
		root = insert(root, keys[i], infos[i]);
	return root;
}

node* find_min(node* root) {
	return root->left ? find_min(root->left) : root;
}

node* remove_min(node* root) {
	if (!root->left)
		return root->right;
	root->left = remove_min(root->left);
	return balance_node(root);
}

node* remove_node(node* root, int key) {
	if (!root)
		return NULL;
	if (key < root->key)
		root->left =  remove_node(root->left, key);
	if (key > root->key)
		root->right = remove_node(root->right, key);
	else{
		node* left = root->left, * right = root->right;
		delete root;
		if (!right)
			return left;
		node* min = find_min(right);
		min->right = remove_min(right);
		min->left = left;
		return balance_node(min);
	}
	return balance_node(root);
}

void delete_tree(node* root) {
	if (root) {
		delete_tree(root->left);
		delete_tree(root->right);
		delete root;
	}
}

node* delete_branch(node* root, int key) {
	if (!root)
		return NULL;
	if (root->left && root->left->key == key) {
		delete_tree(root->left);
		root->left = NULL;
	}
	if (root->right && root->right->key == key) {
		delete_tree(root->right);
		root->right = NULL;
	}
	root->left = delete_branch(root->left, key);
	root->right = delete_branch(root->right, key);
	return root;
}

node* balance_tree(node* root) {
	if (balance_factor(root) > -2 && balance_factor(root) < 2)
		return root;
	root = balance_node(root);
	return balance_tree(root);
}