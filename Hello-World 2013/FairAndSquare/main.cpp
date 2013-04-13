#include <string.h>
#include <stdio.h>
#include <math.h>

#define FOUND 1

int pow(int n, int e)
{
	int i;
	int r = 1;
	for (i = 0; i<e; i++)
		r *= n;

	return r;
}

int isFair(int m)
{
	int i,j,k;
	int n = 1;
	k = m;
	while((k /= 10) != 0)
		n++;

	for(i = 0; i<n; i++)
	{
		if (i == n/2)
			return FOUND;
		
		if ((m/pow(10, i))%10 != (m/pow(10, n-(i+1)))%10)
			return !FOUND;
	}
	return FOUND;
}

int main()
{
	int i, j, k, s, e, n, r;

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n); 

	for (i = 0; i < n; i++)
	{
		scanf("%d %d\n", &s, &e);  

		r = 0;
		for (j = s; j <= e; j++)
		{
			if (!isFair(j))
				continue;
			int k = (int)sqrt((double)j);
			if (k*k == j && isFair(k))
				r++;
		}

		printf("Case #%d: %d\n", i+1, r);

	}
	return 0;
}

