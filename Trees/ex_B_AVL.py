import sys
from collections import deque

sys.setrecursionlimit(10 ** 8)

def height(nodes, node_index):
    node = nodes[node_index]
    if node['left'] == -1 and node['right'] == -1:
        return 0

    left_height = right_height = 0
    if node['left'] != -1:
        left_height = 1 + height(nodes, node['left'])
    if node['right'] != -1:
        right_height = 1 + height(nodes, node['right'])

    return max(left_height, right_height)

def dfs(nodes, root):
    stack = deque([root])
    is_avl = True

    while stack:
        node_index = stack.pop()
        node = nodes[node_index]

        if node['left'] != -1:
            left_child = nodes[node['left']]
            if left_child['value'] >= node['value']:
                is_avl = False
                break

            stack.append(node['left'])

        if node['right'] != -1:
            right_child = nodes[node['right']]
            if right_child['value'] <= node['value']:
                is_avl = False
                break

            stack.append(node['right'])

        left_height = 0 if node['left'] == -1 else 1 + height(nodes, node['left'])
        right_height = 0 if node['right'] == -1 else 1 + height(nodes, node['right'])

        if abs(left_height - right_height) > 1:
            is_avl = False
            break

    return is_avl

def is_avl_tree(nodes, root):
    return 1 if dfs(nodes, root) else 0


n, r = map(int, input().split())
nodes = [{'value': i, 'left': -1, 'right': -1} for i in range(n)]

for i in range(n):
    left, right = map(int, sys.stdin.readline().split())
    nodes[i]['left'] = left
    nodes[i]['right'] = right

print(is_avl_tree(nodes, r))