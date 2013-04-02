#include <iostream>

#define COUNT 50
#define MAX 10000

int d[COUNT];
int p[COUNT];
int e[COUNT][COUNT];
int G[COUNT];

int ExtractMin(int G[])
{
    int t = MAX;
    int u = 0;
    for (int i = 0; i < COUNT; i++)
    {
        if (G[i] == -1)
            continue;
        
        if (d[i] < t)
        {
            t = d[i];
            u = i;
        }
    }
    G[u] = -1;
    return u;
}

void Relax(int u, int v)
{
    if (d[v] > d[u] + e[u][v])
    {
        d[v] = d[u] + e[u][v];
        p[v] = u;
    }
}

void Dijkstra(int G[], int s, int t)
{
    for (int j = 0; j < COUNT; j++)
    {
        d[j] = MAX;
        p[j] = -1;
    }
    d[s] = 0;

    for (int i = 0; i < COUNT; i++)
    {
        int u = ExtractMin(G);

        for (int j = 0; j < COUNT; j++)
        {
            if (G[j] == -1)
                continue;

            Relax(u, j);
        }
    }
}

void Initialize()
{
    for (int i = 0; i < COUNT; i++)
        for (int j = 0; j < COUNT; j++)
            e[i][j] = MAX;

    e[1][2] = 7;
    e[2][1] = 7;

    e[1][3] = 9;
    e[3][1] = 9;

    e[1][6] = 14;
    e[6][1] = 14;

    e[2][3] = 10;
    e[3][2] = 10;

    e[2][4] = 15;
    e[4][2] = 15;

    e[3][4] = 11;
    e[4][3] = 11;

    e[3][6] = 2;
    e[6][3] = 2;

    e[4][5] = 6;
    e[5][4] = 6;

    e[5][6] = 9;
    e[6][5] = 9;

    for (int i = 0; i < COUNT; i++)
        G[i] = -1;

    G[1] = 1;
    G[2] = 2;
    G[3] = 3;
    G[4] = 4;
    G[5] = 5;
    G[6] = 6;
}

int main()
{
    Initialize();

    int s = 5;
    int t = 0;
    std::cin >> t;

    Dijkstra(G, s, t);
    std::cout << d[t] << std::endl;
    int i = t;
    std::cout << t << std::endl;
    while(p[i] != -1)
    {
        std::cout << p[i] << std::endl;
        i = p[i];
    }

    std::cin >> t;

    return 0;
}