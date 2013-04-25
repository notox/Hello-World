#include <string.h>
#include <stdio.h>
#include <math.h>
#include <time.h>

#define FOUND 1

int isFair2(const char *a)
{
	int len = strlen(a);
	for (int i = 0; i < len/2; ++i)
		if (*(a+i) != *(a+len-i-1))
			return !FOUND;
	return FOUND;
}

int main()
{
	int i, n;
	char s[14];
	double d;

	clock_t now;
	now = clock();

	n = 100000;
	d = 9.0;
	for (i = 0; i < n; i++)
	{
		sprintf(s, "%lf", d);
	}
	clock_t now2;
	now2 = clock();
	printf("%d s\n", now2 - now);

	now = clock();

	for (i = 0; i < n; i++)
	{
		sprintf(s, "%.0lf", d);	
	}

	now2 = clock();
	printf("%d s\n", now2 - now);

	now = clock();

	for (i = 0; i < n; i++)
	{
		isFair2(s);	
	}

	now2 = clock();
	printf("%d s\n", now2 - now);

	scanf("%d", &n);

	return 0;
}

