#include <string.h>
#include <stdio.h>

int main()
{
	int i, j, k, n, w, h;
	int m[100][100];
	int b[100][100];

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n);

	for (i = 0; i < n; i++)
	{
		scanf("%d %d\n", &w, &h);

		for (j = 0; j < w; j++)
		{
			for (k = 0; k < h; k++)
			{
				scanf("%d", &(m[j][k]));
			}
		}

		for (j = 0; j < w; j++)
		{
			for (k = 0; k < h; k++)
			{
				m[j][k];

				if (j == 1 && k == 1)
				{
					b[j][k] = 1;
					continue;
				}
			}
		}

		printf("Case #%d:\n", i+1);
		for (j = 0; j < w; j++)
		{
			for (k = 0; k < h; k++)
			{
				printf("%d", b[j][k]);
				if (k + 1 != h)
					printf(" ");
			}
			printf("\n");
		}
	}
	return 0;
}