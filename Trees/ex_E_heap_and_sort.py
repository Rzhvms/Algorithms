import heapq

n = int(input())
a = list(map(int, input().split()))
    
heapq.heapify(a)
    
sorted_a = []
while a:
    sorted_a.append(heapq.heappop(a))
    
print(' '.join(map(str, sorted_a)))

