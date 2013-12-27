#include <iostream>

using namespace std;

int MaxSum(int* A, int n)
{
	int maximum = A[0];
	int sum=0;
	for(int i = 0; i < n; i++)
	{
		for(int j = i; j < n; j++)
		{
			for(int k = i; k <= j; k++)
			{
				sum += A[k];
			}
			if(sum > maximum)
				maximum = sum;

			sum=0;
		}
	}
	return maximum;
}

int MaxSum2(int* A, int n)
{
	int maximum = A[0];
	int sum=0;
	for(int i = 0; i < n; i++)
	{
		for(int j = i; j < n; j++)
		{
			sum += A[j];

			if(sum > maximum)
				maximum = sum;
		}
		sum=0;
	}
	return maximum;
}

int main() {
	int arr[] = {1, -2, 3, 10, -4, 7, 2, -5};

	int sum = MaxSum(arr, sizeof(arr)/sizeof(arr[0]));
	cout << sum << endl;

	sum = MaxSum2(arr, sizeof(arr)/sizeof(arr[0]));
	cout << sum << endl;

	return 0;
}
