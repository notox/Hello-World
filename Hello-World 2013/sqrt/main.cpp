#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>

#define FOUND 1

int mysqrt(const char *ja, char *ka)
{
	int i,j;
	int len = strlen(ja);
	int g = (len+1)/2;
	int m, n, h;
	char s1, s2, s3[2];

	if (len%2 == 1)
	{
		s1 = ja[0];
		m = atoi(&s1);
	}
	else
	{
		s1 = ja[0];
		s2 = ja[1];
		m = atoi(&s1)*10 + atoi(&s2); 
	}

	for (i = 0; i < 10; i++)
	{
		if ((h = i*i) <= m && m < (i+1)*(i+1))
		{
			n = i;
			itoa(i, s3, 10);
			ka[0] = s3[0];
			break;
		}
	}	

	for (i = 1; i < g; i++)
	{
		if (len%2 == 1)
		{
			s1 = ja[2*i-1];
			s2 = ja[2*i];
			m = (h ? (m % h) * 100 : h) * 100 + atoi(&s1)*10 + atoi(&s2);
		}
		else
		{
			s1 = ja[2*i];
			s2 = ja[2*i+1];
			m = (h ? (m % h) * 100 : h) + atoi(&s1)*10 + atoi(&s2);
		}

		for (j = 0; j < 10; j++)
		{
			if ((h = (n * 20 + j)*j) <= m && m < (n * 20 + j + 1)*(j + 1))
			{
				n = n*10 + j;
				itoa(j, s3, 10);
				ka[i] = s3[0];
				break;
			}
			if (j == 9)
			{
				return 0;
			}
		}	
	}
	ka[g] = '\0';

	return (h == 0) || (m%h == 0);	
}

int main()
{
	int i, n, r;
	double s1;
	char s2[15], s3[15]; 

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n); 

	clock_t now;
	now = clock();

	for (i = 0; i < n; i++)
	{
		scanf("%lf\n", &s1);
		sqrt(s1);	
	}
	clock_t now2;
	now2 = clock();
	printf("%d s\n", now2 - now);

	now = clock();

	for (i = 0; i < n; i++)
	{
		scanf("%s\n", s2);
		mysqrt(s2, s3); 
	}

	now2 = clock();
	printf("%d s\n", now2 - now);

	return 0;
}

