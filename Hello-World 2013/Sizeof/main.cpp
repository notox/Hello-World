#include <iostream>
#include <string>

using namespace std;

class Test
{
public:
	virtual ~ Test() {} ;
};

int main()
{
	cout << sizeof(Test) << endl;

	int i; 
	cin >> i;

	return 0;
}