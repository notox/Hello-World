#include <string.h>
#include <stdio.h>

int main()
{
	int l,d,n;
	int i,j,k,g,m;
	int s[17];
	int e[17];
	int r;

	char dic[5000][17];
	char msg[500];
	bool matched;

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d %d %d", &l, &d, &n);
	for (i = 0; i < d; i++) scanf("%s", dic[i]);

	for (m = 0; m < n; m++)
	{
		scanf("%s", msg);
		r = 0;
		g = 0;
		k = -1;

		// get group index
		while(msg[++k] != '\0')
		{
			if(msg[k] == '(')
			{
				s[g] = k + 1;
				while(msg[++k] != ')') ;
				e[g] = k - 1;
			}
			else
			{
				s[g] = e[g] = k;
			}
			g++;
		}

		for(i = 0; i < d; i++)
		{
			for (j = 0; j < l; j++)
			{
				matched = false;
				// check whether char is in group
				for(k = s[j]; k <= e[j]; k++)
				{
					if(msg[k] == dic[i][j])
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