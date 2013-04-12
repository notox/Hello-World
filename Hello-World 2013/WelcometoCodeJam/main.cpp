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

		printf("Case #%d: %d\n", m+1, r);
	}

	scanf("%d", &r);

	return 0;
}