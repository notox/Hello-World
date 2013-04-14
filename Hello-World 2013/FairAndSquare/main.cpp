#include <string.h>
#include <stdio.h>
#include <math.h>

#define FOUND 1

int getValue(double m, int i)
{
	double t = m / pow(10.0, i);
	modf(t, &t);

	int v = (int)t;
	v %= 10;
	
	return v;
}

int isFair(double m)
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

double nextFair(double d)
{
	// Not implemented
	return 0.0;
}

int main()
{
	int i, n, r;
	double j, k, s, e;
	bool sqrtFound;

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n); 

	for (i = 0; i < n; i++)
	{
		scanf("%lf %lf\n", &s, &e);  

		r = 0;
		sqrtFound = false;
		for (j = s; j <= e; j++)
		{
			if (sqrtFound)
			{
				k = k+1;
				j = k*k;
				if (j > e)
					break;
			}
			else
			{
				k = floor(sqrt((double)j));

				if (k*k != j)
					continue;
				else
					sqrtFound = true;
			}

			if (isFair(j) && isFair(k))
				r++;
		}

		printf("Case #%d: %d\n", i+1, r);

	}
	return 0;
}

