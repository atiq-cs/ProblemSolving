//http://www.lintcode.com/en/problem/3-sum-closest/#
public class Solution {
    /**
     * @param numbers: Give an array numbers of n integer
     * @param target : An integer
     * @return : return the sum of the three integers, the sum closest target.
     */
    public int threeSumClosest(int[] numbers ,int target) {
        // write your code here
        int result = Integer.MAX_VALUE;
        int closet = Integer.MAX_VALUE;
        int left = -1, right = -1;
        Arrays.sort(numbers);
        
        for(int i = 0; i < numbers.length; i++){
            left = i + 1;
            right = numbers.length - 1;
            
            while(left < right){
                int sum = numbers[left] + numbers[right] + numbers[i];
                if(Math.abs(target - sum) < result){
                    result = Math.abs(target - sum);
                    closet = sum;
                }
                if(sum > target)
                    right--;
                else{
                    left++;    
                }
            }
        }
        
        return closet;
    }
}

