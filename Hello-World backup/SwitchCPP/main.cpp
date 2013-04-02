#include <string>
#include <iostream>

using namespace std;

#define print(x) printf("the no, "#x",is ")

int main()
{
    int a = 0;
    switch (a)
    {
    case 1:
        cout << "0.1" << endl;
    }
    cout << "The end!" << endl;

    print(1);

    int b = 0;
    cin >> b;
}