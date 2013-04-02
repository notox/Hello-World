#include <string>
#include <iostream>

using namespace std;

int main(int argc, char** args)
{
    for (int i = 0; i < argc; ++i)
    {
        cout << args[i] << endl;
    }
}