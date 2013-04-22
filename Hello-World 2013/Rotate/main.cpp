#include <string.h>
#include <stdio.h>

int m, n;
char map[51][51];
char rmap[51][51];

bool isWin(char c)
{
	int j, k, r;	

	for (j = 0; j < m; j++)
	{
		r = 0;
		for (k = 0; k < m; k++)
		{
			if (rmap[j][k] == c)
			{
				r++;
				if (r == n)
					return true;
			}
			else
			{
				r = 0;
			}
		}
	}

	for (j = 0; j < m; j++)
	{
		r = 0;
		for (k = 0; k < m; k++)
		{
			if (rmap[k][j] == c)
			{
				r++;
				if (r == n)
					return true;
			}
			else
			{
				r = 0;
			}
		}
	}

	for (j = 0; j <= m - n; j++)
	{
		r = 0;
		for (k = 0; k < m; k++)
		{
			if (j+k < m && rmap[j+k][k] == c)
			{
				r++;
				if (r == n)
					return true;
			}
			else
			{
				r = 0;
			}
		}
	}

	for (j = 0; j <= m - n; j++)
	{
		r = 0;
		for (k = 0; k < m; k++)
		{
			if (j+k < m && rmap[k][j+k] == c)
			{
				r++;
				if (r == n)
					return true;
			}
			else
			{
				r = 0;
			}
		}
	}

	for (j = 0; j <= m - n; j++)
	{
		r = 0;
		for (k = 0; k < m; k++)
		{
			if (j+k < m && rmap[m-k-1][j+k] == c)
			{
				r++;
				if (r == n)
					return true;
			}
			else
			{
				r = 0;
			}
		}
	}

	for (j = 0; j <= m - n; j++)
	{
		r = 0;
		for (k = 0; k < m; k++)
		{
			if (j+k < m && rmap[m-j-k-1][k] == c)
			{
				r++;
				if (r == n)
					return true;
			}
			else
			{
				r = 0;
			}
		}
	}

	return false;
}

int main()
{
	int i, j, k, g, t;
	bool r, b;

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &t);

	for (i = 0; i < t; i++)
	{
		scanf("%d %d\n", &m, &n);		
		
		for (j = 0; j < m; j++)
			scanf("%s\n", map[j]);

		for (j = 0; j < m; j++)
		{
			for (k = 0; k < m; k++)
			{
				rmap[j][k] = map[m-k-1][j];
			}
			rmap[j][k] = '\0';
		}

		for (j = 0; j < m; j++)
		{
			for (k = m - 1; k >= 0; k--)
			{
				if (rmap[k][j] != '.')
				{
					for (g = m; g >= k; g--)
					{
						if (rmap[g][j] == '.')
						{
							rmap[g][j] = rmap[k][j];
							rmap[k][j] = '.';
							break;
						}						
					}
				}
			}
		}

		r = isWin('R');
		b = isWin('B');
		printf("Case #%d: ", i+1);
		if (r & b)
			printf("Both");
		else if (r)
			printf("Red");
		else if (b)
			printf("Blue");
		else
			printf("Neither");
		printf("\n");		
	}
	return 0;
}

