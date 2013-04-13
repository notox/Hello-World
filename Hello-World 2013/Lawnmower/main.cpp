#include <string.h>
#include <stdio.h>

int m[100][100];
int h, w;

int main()
{
	int i, j, k, l, n;
	bool im1, im2;

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n);

	for (i = 0; i < n; i++)
	{
		scanf("%d %d\n", &h, &w);


		for (j = 0; j < h; j++)
		{
			for (k = 0; k < w; k++)
			{
				scanf("%d", &(m[j][k]));
			}
		}

		for (j = 0; j < h; j++)
		{
			for (k = 0; k < w; k++)
			{				
				im1 = true;
				im2	= true;
				for (l = 0; l < h; l++)
				{
					if (m[j][k] < m[l][k] && j != l)
					{
						im1 = false;
						break;
					}
				}

				for (l = 0; l < w; l++)
				{
					if (m[j][k] < m[j][l] && k != l)
					{
						im2 = false;
						break;
					}
				}
				if (!im1 && !im2)
					break;
			}
			if (!im1 && !im2)
				break;
		}

		if (!im1 && !im2)
			printf("Case #%d: NO\n", i+1);
		else
			printf("Case #%d: YES\n", i+1);
	}
	return 0;
}

