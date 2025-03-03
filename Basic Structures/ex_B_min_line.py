from collections import deque

n, k = list(map(int, input().split()))
nums = list(map(int, input().split()))

result = []
dq = deque()

for i in range(n):
    while dq and dq[0] < i - k + 1:
        dq.popleft()
    
    while dq and nums[dq[-1]] >= nums[i]:
        dq.pop()
    
    dq.append(i)
    
    if i >= k - 1:
        result.append(nums[dq[0]])

print(*result)