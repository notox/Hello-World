#include <stdio.h>
#include <math.h>

int main()
{
	int i, j, n, r, max;
	int t[400];
	double m[400];

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n); 

	max = 0;
	for (i = 0; i < n; i++)
	{
		scanf("%d\n", t+i);
		max = max > t[i] ? max : t[i];
	}

	m[1] = 1;
	m[2] = 2;	
	for (i = 3; i <= max; i++)
	{
		r = m[i/2]+1;
		r = (i%2 == 1)? r : 2*r;
		
		for (j = i/2 + 1; j < i; j++)
		{
			r += 2*(m[j]+1);
		}
		m[i] = (double)r/(double)i;		
	}

	for (i = 0; i < n; i++)
	{
		printf("%.5f\n", m[t[i]]);
	}

	return 0;
}

