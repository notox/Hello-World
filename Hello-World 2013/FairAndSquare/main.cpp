#include <string.h>
#include <stdio.h>
#include <math.h>

#define FOUND 1

int isFair(const char *a)
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
	double j, k, s, e;
	char h[14];
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

			sprintf(h, "%.0lf", k);
			if (!isFair(h))
				continue;
			sprintf(h, "%.0lf", j);
			if (isFair(h))
				r++;
		}

		printf("Case #%d: %d\n", i+1, r);

	}
	return 0;
}

