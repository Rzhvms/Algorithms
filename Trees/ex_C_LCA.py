from collections import defaultdict

def main():
    n = int(input())
    pred = [int(x) for x in input().split()]
    m = int(input())
    queries = []
    for _ in range(m):
        u, v = map(int, input().split())
        queries.append((u, v))
    
    tree = defaultdict(list)
    for i in range(1, n):
        tree[pred[i-1]].append(i)
    
    depth = [0] * n
    ancestors = [[-1] * n for _ in range(20)]
    
    stack = [(0, -1)]
    while stack:
        node, p = stack.pop()
        ancestors[0][node] = p
        if p != -1:
            depth[node] = depth[p] + 1
        for child in tree[node]:
            stack.append((child, node))
    
    for k in range(1, 20):
        for v in range(n):
            if ancestors[k-1][v] != -1:
                ancestors[k][v] = ancestors[k-1][ancestors[k-1][v]]
    
    def lca(u, v):
        if depth[u] < depth[v]:
            u, v = v, u
        for k in range(19, -1, -1):
            if ancestors[k][u] != -1 and depth[ancestors[k][u]] >= depth[v]:
                u = ancestors[k][u]
        if u == v:
            return u
        for k in range(19, -1, -1):
            if ancestors[k][u] != -1 and ancestors[k][u] != ancestors[k][v]:
                u = ancestors[k][u]
                v = ancestors[k][v]
        return ancestors[0][u]
    
    for u, v in queries:
        print(lca(u, v))


if __name__ == "__main__":
    main()