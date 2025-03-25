def calculate_hash(current_hash, number):
    mod1, mod2 = 2**64, 10**9 + 9
    return (
        (current_hash[0] + (number * 7 * 17) % mod1) % mod1,
        (current_hash[1] * (number + 19 * 31) % mod2) % mod2
    )


def compute_hashes(arr):
    n = len(arr)
    hashes = [[] for _ in range(n)]

    for i in range(n):
        h = (0, 1)
        for j in range(n - i):
            h = calculate_hash(h, arr[i + j])
            hashes[j].append(h)

    return hashes


n = int(input())
first_arr = list(map(int, input().split()))
m = int(input())
second_arr = list(map(int, input().split()))

hashes_first = compute_hashes(first_arr)
hashes_second = compute_hashes(second_arr)

hash_set = {h for row in hashes_first for h in row}
max_length = max((i + 1 for i, row in enumerate(hashes_second) if any(h in hash_set for h in row)), default=0)

print(max_length)
