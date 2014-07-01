#include <stdio.h>
#include <string.h>

void leftshiftone(char *s, int n) {
	char t = s[0];
	for (int i = 1; i < n; ++i) {
		s[i-1] = s[i];
	}
	s[n-1] = t;
}

void leftshift(char *s, int n, int m) {
	while(m--) {
		leftshiftone(s, n);
	}
}

char *invert(char *start, char *end) {
	char tmp, *ptmp = start;
	while(start != NULL && end != NULL && start < end) {
		tmp = *start;
		*start = *end;
		*end = tmp;
		start++;
		end--;
	}
	return ptmp;
}

char *left(char *s, int n, int m) {
	invert(s, s + (m - 1));
	invert(s + m, s + (n - 1));
	invert(s, s + (n - 1));
	return s;
}

int main() {
	char *s = new char [7];
	s[0] = 'a';
	s[1] = 'b';
	s[2] = 'c';
	s[3] = 'd';
	s[4] = 'e';
	s[5] = 'f';
	s[6] = 'g';

	//leftshift(s, 7, 2);
	left(s, 7, 2);
	return 0;
}

