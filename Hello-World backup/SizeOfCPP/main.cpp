#include <string>
#include <iostream>

using namespace std;

int main()
{
    char hello[] = "Hello";
    cout << sizeof(hello) << endl;//6
    cout << sizeof(*hello) << endl;//1
    cout << sizeof(&hello) << endl;//4
    char world[100];
    cout << sizeof(world) << endl;//100
    cout << sizeof("Hello") << endl;//6
    cout << sizeof(int*) << endl;//4
    cout << sizeof(char*) << endl;//4

    char hi[] = "Hi";
    cout << sizeof(hi) << endl;//3

    int b = 0;
    cin >> b;
}