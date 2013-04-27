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
			used += (r+2*j+1)*(r+2*j+1)-(r+2*j)*(r+2*j);
			if (used > t)
				break;
			result++;
		}

		printf("Case #%d: %d\n", i+1, result);

	}
	return 0;
}

