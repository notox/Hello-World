#include <string.h>
#include <stdio.h>

int main()
{
	int l,d,n;
	int i,j,k,g,m;
	int s,e;
	int r;

	char dic[5000][17];
	char msg[500];
	bool matched;

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);
	scanf("%d %d %d", &l, &d, &n);
	for (i = 0; i < d; i++)
	{
		scanf("%s", dic[i]);
	}

	for (m = 0; m < n; m++)
	{
		scanf("%s", msg);
		r = 0;
		for(i = 0; i < d; i++)
		{
			// check every word with the message	
			for(j = 0; j < l; j++)
			{
				// is c in gourp j
				char c = dic[i][j];
				matched = false;
				g = 0;
				k = -1;

				// get group index
				while(msg[++k] != '\0')
				{
					if(msg[k] == '(')
					{
						s = k + 1;
						while(msg[++k] != ')') ;
						e = k - 1;
					}
					else
					{
						s = e = k;
					}
					if (g == j)
						break;
					g++;
				}

				// check whether c is in group
				for(k = s; k <= e; k++)
				{
					if(msg[k] == c)
						matched = true;
				}
				if (!matched)
					break;
			}
			if (matched)
				r++;
		}
		printf("Case #%d: %d\n", m+1, r);
	}

	scanf("%d", &r);

	return 0;
}