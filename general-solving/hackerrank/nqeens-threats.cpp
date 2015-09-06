/***************************************************************************
*   Problem Name:   Find max number of threats
*   Problem URL :   
*   Date        :   
*
*   Domain      :   Upwork coding contest
*                  
*   Desc        :   Max threats for n queens problem
*                   First implementation is DP, however this is not a good DP Problem
*
*   Complexity  :   
*   Author      :   Atiq Rahman
*   Status      :   Terminated due to timeout (Test case and 3 and 6)
*   Notes       :   Simple approach
 *                   Gives good solution here..
 ***************************************************************************/

int maxThreats(vector<int> a) {
	int n = a.size();

	int max_threats = 0;
	// 
	for (int i = 0; i<n; i++) {
		int num_threats = 0;
		// for each queen
		// check row, max 1 queen in single row

		// check column, can be multiple queens in same column
		// find the first queen
		// our queen's postion
		int col_value = a[i];
		// need to find queens from (i-1, col) to (0, col)
		for (int row = i - 1; row >= 0; row--) {
			if (a[row] == col_value) {
				num_threats++;
				break;
			}
		}
		// need to find queens from (i+1, col) to (n-1, col)
		for (int row = i + 1; row<n; row++) {
			if (a[row] == col_value) {
				num_threats++;
				break;
			}
		}

		// check diag, 2 parts
		// first part
		// 
		for (int row = i - 1; row >= 0; row--) {
			if (a[row] == col_value - row + i) {
				num_threats++;
				break;
			}
		}

		for (int row = i - 1; row >= 0; row--) {
			if (a[row] == col_value + row - i) {
				num_threats++;
				break;
			}
		}

		for (int row = i + 1; row<n; row++) {
			if (a[row] == col_value - row + i) {
				num_threats++;
				break;
			}
		}

		for (int row = i + 1; row<n; row++) {
			if (a[row] == col_value + row - i) {
				num_threats++;
				break;
			}
		}

		// get max
		max_threats = std::max(num_threats, max_threats);

	}

	return max_threats;
}
