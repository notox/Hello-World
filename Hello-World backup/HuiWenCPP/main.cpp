#include <iostream>

int huiwen(const char *a)
{
    int len = strlen(a);
    const char *b = a + len - 1;
    for (int i = 0; i < len/2; ++i)
        if (*a++ != *b--)
            return 0;
    return 1;
}

int huiwen2(const char *a)
{
    int len = strlen(a);
    for (int i = 0; i < len/2; ++i)
        if (*(a+i) != *(a+len-i-1))
            return 0;
    return 1;
}

int main()
{
    char *a = "taast";
    if (huiwen2(a))
        printf("It is weihui");

    int c;
    c = getchar();
    return 0;
}