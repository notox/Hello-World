#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#define FOUND 1

char s[100000000000000];
char e[100000000000000];
char m[100000000000000];

int pow(int n, int e)
{
	int i;
	int r = 1;
	for (i = 0; i<e; i++)
		r *= n;

	return r;
}

int isFair(const char *a)
{
	int len = strlen(a);
	for (int i = 0; i < len/2; ++i)
		if (*(a+i) != *(a+len-i-1))
			return !FOUND;
	return FOUND;
}

void plus1(int j)
{	
	int i;
	int l = strlen(s);
	int k = l - j;
	if (k < 0)
	{
		for (i = l; i >= l; i--)
		{
			m[i+1] = m[i];
		}
		m[0] = '1';
	}

	l = atoi(&s[k]);
	if (l + 1 < 10)
	{
		itoa(l + 1, &s[k], 10);
		return;
	}
	else
	{
		// add a new bit
		s[k] = '0';
	}

	plus1(j+1);					
}

int main()
{
	int i, j, k, n, r; 

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n); 

	for (i = 0; i < n; i++)
	{
		scanf("%s %s\n", s, e);  

		r = 0;
		while(strcmp(s, e) != 0)
		{
			if (!isFair(s))
			{
				plus1(1);
				continue;
			}
			//m = (int)sqrt((double)j);
			if (isFair(s))
				r++;

			plus1(1);
		}

		printf("Case #%d: %d\n", i+1, r);

	}
	return 0;
}

