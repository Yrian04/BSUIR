#include "Header.h"

node* add(node*);
void search_key(node*);
node* make_from_array();
node* remove(node*);
node* task(node*);
node* get_from_file();

int main()
{
	node* root = NULL;
	while (true) {
		printf("Choose action:\n\t1 - add node\n\t2 - show view\n\t3 - search for key\n\t4 - make from array\n\t5 - remove node\n\t6 - solve task\n\t7 - read from file\n\t0 - exit\n");
		switch (_getch()) {
		case '1':
			root = add(root);
			break;
		case '2':
			view(root, 0);
			break;
		case '3':
			search_key(root);
			break;
		case '4':
			root = make_from_array();
			break;
		case '5':
			root = remove(root);
			break;
		case '6':
			root = task(root);
			root = balance_tree(root);
			break;
		case '7':
			root = get_from_file();
			break;
		case '0':
			delete_tree(root);
			exit(0);
		}
	}
}

node* add(node* root) {
	int key;
	char* info = new char[31];
	printf("Enter info: ");
	gets_s(info, 30);
	printf("Enter key: ");
	scanf("%d", &key);
	rewind(stdin);
	return insert(root, key, info);
}

void search_key(node* root) {
	int key;
	printf("Enter key: ");
	scanf("%d", &key);
	node* res = search(root, key);
	if (res) {
		printf("Result: ");
		puts(res->info);
	}
	else
		printf("Found nothing\n");
}

node* make_from_array() {
	printf("Enter number of elements:");
	int n;
	scanf("%d", &n);
	int* keys = new int[n];
	char** infos = new char*[n];
	for (int i = 0; i < n; i++) {
		infos[i] = new char[31];
		printf("Enter %d key: ", i + 1);
		scanf("%d", keys + i);
		rewind(stdin);
		printf("Enter %d info: ", i + 1);
		gets_s(infos[i], 30);
	}
	return tree_from_array(keys, infos, n);
}

node* remove(node* root) {
	printf("Enter key: ");
	int key;
	scanf("%d", &key);
	return remove_node(root, key);
}

node* task(node* root) {
	printf("Enter key of root of branch for deleting: ");
	int key;
	scanf("%d", &key);
	return delete_branch(root, key);
}

node* get_from_file() {
	FILE* file = fopen("tree.txt", "r");
	node* root = NULL;
	int key;
	char* info = new char[31];
	while (fscanf(file, "%d %s\n", &key, info) != -1){
		root = insert(root, key, info);
		info = new char[31];
		rewind(stdin);
	}
	fclose(file);
	return root;
}