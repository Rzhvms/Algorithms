from collections import deque

n = int(input())
p = [int(x) for x in input().split()]

adj = [[] for _ in range(n)]
for i in range(1, n):
    adj[p[i - 1]].append(i)
    adj[i].append(p[i - 1])

def bfs(start):
    dist = [-1] * n
    dist[start] = 0
    q = deque([start])
    farthest_node = start
    while q:
        node = q.popleft()
        for neighbor in adj[node]:
            if dist[neighbor] == -1:
                dist[neighbor] = dist[node] + 1
                q.append(neighbor)
                farthest_node = neighbor
    return farthest_node, dist

farthest_from_root, depth = bfs(0)

farthest_from_farthest, distances = bfs(farthest_from_root)
diameter = max(distances)

height = max(depth)

print(height, diameter)
print(' '.join(map(str, depth)))
