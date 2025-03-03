from sys import stdout

n = int(input())

def query(x):
    print(x)
    stdout.flush()
    return input()

def guess_number(n):
    left = 1
    right = n
    while left <= right:
        mid = (left + right) // 2
        response = query(mid)
        if response == '<':
            right = mid - 1
        elif response == '>=':
            left = mid + 1
    print(f'! {right}')
    stdout.flush()

guess_number(n)

