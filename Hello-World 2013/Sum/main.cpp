#include <iostream>
#include <string>

using namespace std;

// n^2
void forceSum(int *arr, int n, int sum) {
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < n; ++j) {
			if (arr[i] + arr[j] == sum && i != j) {
				cout << arr[i] << "+" << arr[j] << endl;
				return;
			}
		}
	}
}

// n^2
void forceSum2(int *arr, int n, int sum) {
	for (int i = 0; i < n; ++i) {
		int num = sum - arr[i];
		for (int j = 0; j < n; ++j) {
			if (num == arr[j] && i != j) {
				cout << arr[i] << "+" << arr[j] << endl;
				return;
			}
		}
	}
}

#define NotFound (-1)
int binarySearch(int *arr, int n, int x) {
	int low, high, mid;
	low = 0;
	high = n-1;
	while (low <= high) {
		mid = (low + high)/2;
		if (arr[mid] < x)
			low = mid + 1;
		else if (arr[mid] > x)
			high = mid - 1;
		else
			return mid;
	}
	return NotFound;
}

// nlogn
void binarySearchSum(int *arr, int n, int sum) {
	for (int i = 0; i < n; ++i) {
		int num = sum - arr[i];
		if(binarySearch(arr, n, num) != NotFound) {
			cout << arr[i] << "+"<< num << endl;
			return;
		}
	}
}

int twoEndSearch(int *arr, int n, int sum) {
	int *subArr = new int[n];
	for (int i = 0; i < n; ++i) {
		subArr[i] = sum - arr[i];
	}

	for (int i = 0, j = n - 1; i < j;) {
		if(arr[i] < subArr[j])
			i++;
		else if(arr[i] > subArr[j])
			j--;
		else
			return i;
	}
	return NotFound;
}

int twoEndSearch2(int *arr, int n, int sum) {
	int *start = arr;
	int *end = arr + n - 1;
	while (start < end) {
		if (*start + *end > sum)
			end--;
		else if (*start + *end < sum)
			start++;
		else
			return start - arr;
	}
	return NotFound;
}

// n
void twoEndSearchSum(int *arr, int n, int sum) {
	int i = twoEndSearch(arr, n, sum);
	if (NotFound != i) {
		cout << arr[i] << "+"<< sum - arr[i] << endl;
	}
	i = twoEndSearch2(arr, n, sum);
	if (NotFound != i) {
		cout << arr[i] << "+"<< sum - arr[i] << endl;
	}
}

int compare (const void * a, const void * b)
{
	return (*(int*)a - *(int*)b);
}

int main() {
	int arr[] = {1, 2, 4, 7, 11, 15};
	forceSum(arr, 6, 15);
	forceSum2(arr, 6, 15);
	binarySearchSum(arr, 6, 15);
	twoEndSearchSum(arr, 6, 15);

	int arrDisorder[] = {11, 4, 2, 7, 1, 15};
	qsort(arrDisorder, 6, sizeof(int), compare);
	twoEndSearchSum(arrDisorder, 6, 15);
	return 0;
}

