def search_nearest_number(list_nums, x):
    left = 0
    right = len(list_nums) - 1
    while left <= right:
        mid = (left + right) // 2
        if list_nums[mid] < x:
            left = mid + 1
        else:
            right = mid - 1
        
    if left == 0:
        return list_nums[0]
    if left == len(list_nums):
        return list_nums[-1]
    if abs(list_nums[left - 1] - x) <= abs(list_nums[left] - x):
        return list_nums[left - 1]
    else:
        return list_nums[left]


n, k = map(int, input().split())
list_nums = list(map(int, input().split()))
k_list = list(map(int, input().split()))

for i in k_list:
    print(search_nearest_number(list_nums, i))






