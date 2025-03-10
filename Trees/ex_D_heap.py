import heapq

n = int(input())
heap = []
for _ in range(n):
    tuple = [int(x) for x in input().split()]
    if tuple[0] == 0:
        x = int(tuple[1])
        heapq.heappush(heap, -x)
    else:
        print(-heapq.heappop(heap))