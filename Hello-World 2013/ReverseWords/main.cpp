#include <string.h>
#include <stdio.h>

int main()
{
	int i, j, k, l, m, n;
	char in[1000];
	char out[1000];
	int index[1000];

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n);

	for (i = 0; i < n; i++)
	{
		gets(in);
		j = -1;
		k = 0;
		index[k++] = -1;
		while(in[++j] != '\0')
		{
			if (in[j] == ' ')
				index[k++] = j;
		}
		index[k] = j;

		m = 0;
		for (l = k; l > 0; l--)
		{
			for (j = index[l-1] + 1; j < index[l]; j++)
			{
				out[m] = in[j];
				m++;
			}
			if (l == 1)
				out[m++] = '\0';
			else
				out[m++] = ' ';
		}

		printf("Case #%d: %s\n", i+1, out);
	}

	return 0;
}