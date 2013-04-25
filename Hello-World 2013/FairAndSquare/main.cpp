#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#define FOUND 1
#define OK 1

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

char* plus(char *ja, int n)
{
	int i, j, h;
	int len = strlen(ja);
	char s1;
	char s2[2];

	j = n;
	for (i = 0; i < len + 1; i++)
	{
		if (len == i)
		{
			for (j = 0; j < len; j++)
			{
				ja[len+1-j] = ja[len-j];
			}
			ja[0] = '1';
			break;
		}

		s1 = ja[len-1-i];
		j += atoi(&s1);
		if (j < 10)
		{
			itoa(j, s2, 10);
			ja[len-1-i] = s2[0];
			break;
		}
		else
		{
			itoa(j%10, s2, 10);
			ja[len-1-i] = s2[0];
			j = j/10;
		}
	}

	return ja;
}

int isFair(const char *a)
{
	int len = strlen(a);
	for (int i = 0; i < len/2; ++i)
		if (*(a+i) != *(a+len-i-1))
			return !FOUND;
	return FOUND;
}

int main()
{
	int i, n, r;
	double j, k, s, e;

	char ja[14];
	char ka[14];
	char ea[14];

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n); 

	for (i = 0; i < n; i++)
	{
		scanf("%s %s\n", ja, ea);
		s = atof(ja);
		e = atof(ea);

		r = 0;
		for (j = s; j <= e; j++)
		{
			if (mysqrt(ja, ka) && isFair(ja) && isFair(ka))
				r++;

			plus(ja, 1);
		}

		printf("Case #%d: %d\n", i+1, r);

	}
	return 0;
}

