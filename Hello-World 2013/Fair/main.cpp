#include <string.h>
#include <stdio.h>
#include <math.h>
#include <time.h>

#define FOUND 1

int getValue(double m, int i)
{
	double t = m / pow(10.0, i);
	modf(t, &t);
	t = fmod(t, 10);
	int v = (int)t;

	return v;
}

int isFair1(double m)
{
	int i,j;
	double k;
	int n = 1;
	k = m;

	while (k != 0)
	{
		k /= 10;
		modf(k, &k);

		if (k != 0)
			n++;
	}

	for(i = 0; i<n; i++)
	{
		if (i == n/2)
			return FOUND;

		if (getValue(m, i) != getValue(m, n-(i+1)))
			return !FOUND;
	}
	return FOUND;
}

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
	int i, n, r;
	double s1;
	char s2[15]; 

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n); 

	clock_t now;
	now = clock();

	for (i = 0; i < n; i++)
	{
		scanf("%lf\n", &s1);
		r = isFair1(s1);	
		printf("Case #%d: %d\n", i+1, r); 
	}
	clock_t now2;
	now2 = clock();
	printf("%d s\n", now2 - now);

	now = clock();

	for (i = 0; i < n; i++)
	{
		scanf("%s\n", s2);
		r = isFair2(s2); 
		printf("Case #%d: %d\n", i+1, r); 
	}

	now2 = clock();
	printf("%d s\n", now2 - now);

	return 0;
}

