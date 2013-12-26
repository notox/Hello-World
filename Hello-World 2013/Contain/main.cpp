#include <string>
#include <iostream>

using namespace std;

int forceContain(string longstr, string shortstr){
	int i, j;
	for (i = 0; i < shortstr.length(); ++i) {
		for (j = 0; j < longstr.length(); ++j) {
			if (shortstr[i] == longstr[j])
				break;
		}
		if (j == longstr.length())
			return 1;
	}
	return 0;
}

int hashContain(string longstr, string shortstr) {
	int hash[26] = {0};
	int num = 0;

	for (int i = 0; i < shortstr.length(); ++i) {
		int index = shortstr[i] - 'A';
		if (hash[index] == 0) {
			hash[index] = 1;
			num++;
		}
	}

	for (int j = 0; j < longstr.length(); ++j) {
		int index = longstr[j] - 'A';
		if (hash[index] == 1) {
			hash[index] = 0;
			num--;
			if (num == 0)
				return 0;
		}
	}

	return (num == 0)? 0 : 1;
}

int main() {
	string longstr = "ABCDEFGHI";
	string shortstr = "CDE";

	int f = forceContain(longstr, shortstr);
	int h = hashContain(longstr, shortstr);
	return 0;
}


//#include <stdio.h>
//
//int contain(char *l, int ll, char *s, int sl){
//	int i, j;
//	for (i = 0; i < sl; ++i) {
//		for (j = 0; j < ll; ++j) {
//			if (s[i] == l[j])
//				break;
//		}
//		if (j == ll) {
//			return 1;
//		}
//	}
//	return 0;
//}
//
//int main() {
//	char *l = new char[9];
//	char *s = new char[3];
//
//	l[0] = 'a';
//	l[1] = 'b';
//	l[2] = 'c';
//	l[3] = 'd';
//	l[4] = 'e';
//	l[5] = 'f';
//	l[6] = 'g';
//	l[7] = 'i';
//	l[8] = 'h';
//
//	s[0] = 'a';
//	s[1] = 'b';
//	s[2] = 'x';
//
//	contain(l, 9, s, 3);
//
//	return 0;
//}
