#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <vector>
#include <cmath>
using namespace std;

void ReadGraph(FILE*, vector<vector<int>>*);

void PrintGraph(vector<vector<int>>);

void DFS(vector<vector<int>>, vector<int>*, vector<bool>*, int root, vector<vector<int>>*);

vector<int> FindRelatedVertexes(vector<vector<int>>, int);

vector<int> FindChildren(vector<vector<int>> tree, int vertex);

vector<vector<int>> FindBackEdges(vector<vector<int>> graph, vector<vector<int>> tree);

vector<int> Reverse(vector<int>);

vector<int> Fup(vector<int> tin, vector<int> time, vector<vector<int>> graph, vector<vector<int>> tree);

vector<vector<int>> FindBridges(vector<vector<int>> graph);

int main() {
	cout << "Enter name of file: ";
	char s[100];
	cin >> s;
	FILE* file = fopen(s, "r");
	vector<vector<int>> graph;
	ReadGraph(file, &graph);
	cout << "Graph:\n";
	PrintGraph(graph);
	vector<vector<int>> bridges = FindBridges(graph);
	cout << "Bridges: ";
	for (int i = 0; i < bridges.size(); i++) {
		cout << bridges[i][0] << " - " << bridges[i][1] << ' ';
	}
}

void ReadGraph(FILE* file, vector<vector<int>>* graph) {
	int vertex1, vertex2, edge;
	while (fscanf(file, "%d: %d %d", &edge, &vertex1, &vertex2) != -1) {
		if (graph->size() < edge) {
			graph->resize(edge);
		}
		if (graph->at(edge - 1).size() == 0) {
			graph->at(edge - 1).resize(2);
		}
		graph->at(edge - 1)[0] = vertex1;
		graph->at(edge - 1)[1] = vertex2;
	}
}

void PrintGraph(vector<vector<int>> graph) {
	for (int i = 0; i < graph.size(); i++) {
		cout << i + 1 << ": " << graph.at(i)[0] << " - " << graph.at(i)[1] << endl;
	}
}

vector<int> FindRelatedVertexes(vector<vector<int>> graph, int vertex) {
	vector<int> relatedVertexes;
	for (int i = 0; i < graph.size(); i++) {
		if (graph[i][0] == vertex) {
			relatedVertexes.push_back(graph[i][1]);
		}
		else if (graph[i][1] == vertex) {
			relatedVertexes.push_back(graph[i][0]);
		}
	}
	return relatedVertexes;
}

vector<int> Reverse(vector<int> v) {
	vector<int> res(v.size());
	for (int i = 0; i < v.size(); res[v[i]-1] = i++ + 1);
	return res;
}

void DFS(vector<vector<int>> graph, vector<int>* tree, vector<bool>* color, int root, vector<vector<int>>* rTree) {
	vector<int> relatedVertexes = FindRelatedVertexes(graph, root);
	color->at(root-1) = true;
	tree->push_back(root);
	for (int i = 0; i < relatedVertexes.size(); i++) {
		if (!color->at(relatedVertexes[i] - 1)) {
			vector<int> v{ root, relatedVertexes[i] };
			rTree->push_back(v);
			DFS(graph, tree, color, relatedVertexes[i], rTree);
		}
	}
}

vector<int> FindChildren(vector<vector<int>> tree, int vertex) {
	vector<int> children;
	for (int i = 0; i < tree.size(); i++) {
		if (tree[i][0] == vertex)
			children.push_back(tree[i][1]);
	}
	return children;
}

vector<vector<int>> FindBackEdges(vector<vector<int>> graph, vector<vector<int>> tree) {
	vector<vector<int>> backEdges;
	for (int i = 0; i < graph.size(); i++) {
		bool flag = false;
		for (int j = 0; j < tree.size() && !flag; j++)
			flag =(graph[i][0] == tree[j][0] && graph[i][1] == tree[j][1]) || (graph[i][0] == tree[j][1] && graph[i][1] == tree[j][0]);
		if (!flag)
			backEdges.push_back(graph[i]);
	}

	return backEdges;
}

vector<int> Fup(vector<int> tin,vector<int> time, vector<vector<int>> graph, vector<vector<int>> tree) {
	vector<int> fup(tin.size());
	vector<vector<int>> backEdges = FindBackEdges(graph, tree);
	for (int i = time.size() - 1; i >= 0; i--) {
		int m;
		vector<int>	backEdgesOfVertex = FindRelatedVertexes(backEdges, time[i]);
		m = tin[time[i]-1];
		for (int j = 0; j < backEdgesOfVertex.size(); m = min(m, tin[backEdgesOfVertex[j++] - 1]));
		vector<int> children = FindChildren(tree, time[i]);
		for (int j = 0; j < children.size(); m = min(m, fup[children[j++] - 1]));
		fup[time[i]-1] = m;
	}
	return fup;
}

vector<vector<int>> FindBridges(vector<vector<int>> graph) {
	vector<int> time;
	vector<vector<int>> treeOfDFS;
	vector<bool> color(graph.size() + 1, false);
	DFS(graph, &time, &color, 1, &treeOfDFS);
	vector<int> tin = Reverse(time);
	vector<int> fup = Fup(tin, time, graph, treeOfDFS);
	vector<vector<int>> bridges;
	for (int i = 0; i < treeOfDFS.size(); i++) {
		if (fup[treeOfDFS[i][1] - 1] > tin[treeOfDFS[i][0] - 1]) {
			bridges.push_back(treeOfDFS[i]);
		}
	}
	return bridges;
}