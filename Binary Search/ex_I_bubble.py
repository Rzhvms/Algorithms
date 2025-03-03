def bubble_sort_count_iterations(array):
    length = len(array)
    iterations = 0

    for iter_num in range(length):
        had_swaps = False

        for i in range(length - iter_num - 1):
            if array[i] > array[i + 1]:
                array[i], array[i + 1] = array[i + 1], array[i]
                had_swaps = True

        iterations += 1

        if not had_swaps:
            break

    return iterations

n = int(input())
array = list(map(int, input().split()))

result_arr = [0] * n
output = [1]

for i in range(n):
    index = array[i] - 1
    result_arr[index] = 1

    result_arr_copy = result_arr.copy()

    iterations = bubble_sort_count_iterations(result_arr_copy)
    output.append(iterations)

print(" ".join(map(str, output)))