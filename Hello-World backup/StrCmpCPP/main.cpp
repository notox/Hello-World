#include <iostream>

int strcmp(char *source, char *dest)
{
    while(*source++ == *dest++)
        if (*source == '\0')
            return 0;
    return -1;
}

int main()
{
    char *source = "Hello";
    char *dest1 = "Hello";
    char *dest2 = "World";

    printf("%d", strcmp(source, dest1));
    printf("%d", strcmp(source, dest2));

    int c;
    c = getchar();
}