/***************************************************************************
*   Problem Name:   Duronto Eagle
*   Problem Link :  http://www.spoj.com/problems/DRNTEAGL/
***************************************************************************/

#include <iostream>
#include <cmath>
using namespace std;

int main() {
    // your code goes here
    int T;
    cin >> T;
    for (int i = 1; i <= T; i++) {
        int N;
        cin >> N;
        int maxIndex = 1;
        double maxDistance = -1.0;
        for (int j = 1; j <= N; j++) {
            int x, y;
            cin >> x >> y;
            double distance = sqrt(x*x + y*y);
            if (distance > maxDistance) {
                maxDistance = distance;
                maxIndex = j;
            }
        }
        cout << "Case " << i << ": " << maxIndex << endl;
    }
    return 0;
}