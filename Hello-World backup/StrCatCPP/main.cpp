#include <iostream>
#include "string.h"

int main()
{
    char hello[100];
    char *hello2;// = (char*)malloc(100);
    hello[0] = '\0';
    //char *hello = "Hello ";
    char *world = "World";

    hello2 = strcat(hello, world);

    printf("%s", hello2);
    printf("%s", hello);
    printf("%s", world);
    //printf("%s", helloWorld);
    
    int c;
    c = getchar();
}