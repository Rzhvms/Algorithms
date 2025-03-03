def binary_search(list_nums, x):
    left = 0
    right = len(list_nums) - 1
    while left <= right:
        middle = (left + right) // 2
        if list_nums[middle] == x:
            return True
        elif list_nums[middle] < x:
            left = middle + 1
        else: 
            right = middle - 1
    return False 


n, k = map(int, input().split())
list_nums = list(map(int, input().split()))
k_list = list(map(int, input().split()))

for i in k_list:
    if binary_search(list_nums, i):
        print('YES')
    else:
        print('NO')
