#include <iostream>

int main()
{
    int arr[] = {6,7,8,9,10};
    int *ptr = arr;
    *(ptr++)+=123;
    printf("%d, %d", arr[0], arr[1]);
    printf("%d, %d", *ptr, *(++ptr));

    int c;
    c = getchar();
}