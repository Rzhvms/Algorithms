def get_max_value(list_nums):
    prev = [0] * (n + 1)
    first = []
    second = []

    for i in range(n):
        prev[i + 1] = prev[i] + list_nums[i]

    left_border = [-1] * n
    for i in range(n):
        while first and list_nums[first[-1]] >= list_nums[i]:
            first.pop()
        if first:
            left_border[i] = first[-1]
        else:
            left_border[i] = -1
        first.append(i)


    right_border = [n] * n
    for i in range(n - 1, -1, -1):
        while second and list_nums[second[-1]] >= list_nums[i]:
            second.pop()
        if second:
            right_border[i] = second[-1]
        else:
            right_border[i] = n
        second.append(i)


    max_value = 0
    for i in range(n):
        l = left_border[i] + 1
        r = right_border[i] - 1
        current_sum = prev[r + 1] - prev[l]
        current_product = current_sum * list_nums[i]
        if current_product > max_value:
            max_value = current_product

    print(max_value)


n = int(input())
list_nums = list(map(int, input().split()))
get_max_value(list_nums)