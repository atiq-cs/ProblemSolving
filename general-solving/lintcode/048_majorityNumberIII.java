/***************************************************************************************************
* URL   : majority-number-iii
* Author: Tianshu Bao (tianshubao1), commit#47b65e92b
* Date  : 2015-06-05
***************************************************************************************************/
public class Solution {
    /**
     * @param nums: A list of integers
     * @param k: As described
     * @return: The majority number
     */
    public int majorityNumber(ArrayList<Integer> nums, int k) {
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        for(int i = 0; i < nums.size(); i++){
            int digit = nums.get(i);
            if(map.containsKey(digit))
                map.put(digit, map.get(digit) + 1);
            else if(map.size() < k)
                map.put(digit, 1);
            else
                removeKey(map);
        }
        
        Set<Integer> key = map.keySet();
        int max = 0;
        int maxKey = 0;
        for(int value : key){
            int count = 0;
            for(int num : nums){
                if(num == value)
                    count++;
            }
            if(count > max){
                max = count;
                maxKey = value;
            }
        }
        
        return maxKey;
    }
    
    private void removeKey(Map<Integer, Integer> map){
        Set<Integer> set = map.keySet();
        List<Integer> removeList = new ArrayList<Integer>();
        for(int value : set){
            int count = map.get(value);
            if(map.get(value) > 1)
                map.put(value, count - 1);
            else
                // map.remove(value);
                removeList.add(value);
        }
        for (int key : removeList) {
            map.remove(key);
        }        
    }
}

