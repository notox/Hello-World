#include <stdio.h>
#include <math.h>

int main()
{
	int i, j, n, r, t, result, used;

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n); 

	for (i = 0; i < n; i++)
	{
		scanf("%d %d\n", &r, &t);

		result = 0;
		used = 0;
		for (j = 0; ; j++)
		{
			used += 2*r + 4*j + 1;
			if (used > t)
				break;
			result++;
		}

		printf("Case #%d: %d\n", i+1, result);

	}
	return 0;
}

