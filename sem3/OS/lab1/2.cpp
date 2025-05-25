#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main()
{
	string str;
	
	getline(cin, str);
	
		cout << str;
		ofstream f;
		f.open("log");
		f << str;	
		
	return 0;
}
