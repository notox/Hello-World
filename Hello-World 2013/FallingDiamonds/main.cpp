#include <stdio.h>
#include <math.h>

int main()
{
	int n, t, r, x, y, i, j;
    double result;
    int xlevel, ylevel;
    double p[100][100];

	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n); 

	for (t = 0; t < n; t++)
	{
		scanf("%d %d %d\n", &r, &x, &y);
        xlevel = 0;
		i = r;
		while (i > 0)
		{
			i = i - 4*xlevel - 1;
			if (i <= 0)
				break;
			xlevel++;
		}
        ylevel = r - (2*xlevel-1)*xlevel;
        result = 0.0;		
     
        for(i = 0; i < 100; i++)
        {
            for(j = 0; j < 100; j++)
            {
                p[i][j] = 0.0;
            }
        }
        
        if (abs(x)+y < 2*xlevel)
        {
            result = 1.0;
        }
        else if (abs(x)+y == 2*xlevel)
        {
            for (i = 0; i < y + 1; i++)
            {
                for (j = 1; j < ylevel + 1; j++)
                {
                    if(0 == i)
                    {
                        p[i][j] = p[i][j-1] + 1.0/pow(2.0,j);

						if (j >= 2*xlevel+1)
						{
							p[i][j] = 1.0;
						}
                    }
                    else 
                    {
                        if (i + 1 > j)
						{
                            p[i][j] = 0.0;
						}
                        else if (i + 1 == j)
						{
                            p[i][j] = 1.0/pow(2.0,j);

							if (j == 2*xlevel + 1)
								p[i][j] = 0.0;
						}							
                        else
						{
                            p[i][j] = p[i][j-1] + (p[i-1][j-1]-p[i][j-1])/2;
							
							if (j >= 2*xlevel+1)
							{
								if (p[i-1][j-1] == 1.0)
								{
									p[i][j] = 1.0;
								}
								else
								{
									if (2*(i+1) > j + 1)
									{
										p[i][j] = 0.0;
									}
									else
									{
										p[i][j] = 1.0/pow(2.0,4*xlevel-j);
									}
								}
							}
						}
                    }
                }
            }
            result = p[y][ylevel];
        }
        
		printf("Case #%d: %.10f\n", t+1, result);

	}
	return 0;
}

