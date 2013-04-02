#include <Windows.h>
#include <iostream>

void setmem(char** p, int num)
{
    *p = (char*)malloc(num);
}

int main()
{
    char* str = NULL;
    setmem(&str, 100);
    strcpy(str, "Hello");
    printf(str);

    int c;
    c = getchar();
}