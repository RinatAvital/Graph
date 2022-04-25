#include <iostream>
#include <bitset>
using namespace std;


//-------------23

#define SIZE_INT sizeof(int) * 8


int circularShift(unsigned n, int k, bool isLeftShift)
{
    if (isLeftShift) {
        return (n << k) | (n >> (SIZE_INT - k));
    }
    return (n >> k) | (n << (SIZE_INT - k));
}

int main()
{
    unsigned n = 150;
    int shift = 4;
    cout << "Left Shift  " << bitset<32>(circularShift(n, shift, true)) << endl;
    cout << "Right Shift " << bitset<32>(circularShift(n, shift, false)) << endl;

    return 0;
}



//------------24
int findBits(int x, int y) {
    return (x | y) - (x & y);
}

int main()
{
    int x = 65;
    int y = 80;

    cout << "first number " << bitset<8>(x) << endl;
    cout << "second number " << bitset<8>(y) << endl;

    cout << "\nXOR is " << bitset<8>(findBits(x, y));

    return 0;
}

//---------------20
inline int swapAdjacentBits(int n) {
    return (((n & 0xAAAAAAAA) >> 1) | ((n & 0x55555555) << 1));
}

int main()
{
    int n = 761622921;

    cout << n << " in binary is " << bitset<32>(n) << endl;
    n = swapAdjacentBits(n);
    cout << n << " in binary is " << bitset<32>(n) << endl;

    return 0;
}


//-------------41
int findSquare(int num)
{
    num = abs(num);
    int sq = num;
    for (int i = 1; i < num; i++) {
        sq = sq + num;
    }
    return sq;
}

int main()
{
    cout << findSquare(8) << " " << findSquare(-4);
    return 0;
}

//--------------47
int findMin(int x, int y) {
    return y ^ ((x ^ y) & -(x < y));
}

int findMax(int x, int y) {
    return x ^ ((x ^ y) & -(x < y));
}

int main()
{
    int x = 10, y =10;

    cout << "min(" << x << ", " << y << ") is " << findMin(x, y) << endl;
    cout << "max(" << x << ", " << y << ") is " << findMax(x, y) << endl;

    return 0;
}
