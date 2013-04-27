#include <stdio.h>
#include <math.h>

int main()
{
	int i, n, k, r;
	int na[10000];

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	while (true)
	{
		scanf("%d %d\n", &n, &k);
		if (n == 0)
			break;

		r = 0;
		for (i = 0; i < n; i++)
		{
			scanf("%d", na + i);
		}

		printf("%d\n", r);

	}
	return 0;
}

