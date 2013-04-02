#include <string>
#include <iostream>

using namespace std;

int main()
{
    string test("=asdfgb");
    string match("ba");
    if (test.find(match) != string::npos)
    {
        cout << "Find.." << endl;
    }
    int i = 0;
    cin >> i;
    return 0;
}