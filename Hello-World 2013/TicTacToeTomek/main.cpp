#include <string.h>
#include <stdio.h>

#define WIN 1
#define COMPLETE 1

char map[4][5];

int isOk(int j, int k, char c)
{	 
	return (map[j][k] == c || map[j][k] == 'T');
}

int isWin(char c)
{
	int j,k;
	bool winr, winc;
	bool win1, win2; 

	win1 = true;
	win2 = true;
	for (j = 0; j < 4; j++)
	{
		winr = true;
		winc = true; 
		for (k = 0; k < 4; k++)
		{
			if (!isOk(j,k,c))
				winr = false;

			if (!isOk(k,j,c))
				winc = false;
		}

		if (winr || winc)
			return WIN;

		if (!isOk(j,j,c))
			win1 = false;

		if (!isOk(j,3-j,c))
			win2 = false;
	}		

	if (win1 || win2)
		return WIN;

	return !WIN;
}

int isComplete()
{
	int j, k;

	for (j = 0; j < 4; j++)
		for (k = 0; k < 4; k++)
			if (map[j][k] == '.')
				return !COMPLETE;
	return COMPLETE;
}

int main()
{
	int i, j, n;
	
	freopen("a.in","r",stdin);
	freopen("a.out","w",stdout);

	scanf("%d\n", &n);

	for (i = 0; i < n; i++)
	{
		for (j = 0; j < 4; j++)
			scanf("%s\n", map[j]);

		printf("Case #%d: ", i+1);

		if (isWin('O'))
			printf("O won\n");
		else if (isWin('X'))
			printf("X won\n");
		else if (isComplete())
			printf("Draw\n");
		else
			printf("Game has not completed\n");
	}
	return 0;
}

