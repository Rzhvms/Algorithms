from collections import deque

def run_queue(act):
    action = act[0]
    
    if action == '-':
        print(first.popleft())
    elif action == '+':
        second.append(act[1])
    else:
        second.appendleft(act[1])

    if len(second) > len(first):
        i = second.popleft()
        first.append(i)
    

n = int(input())
first = deque()
second = deque()

for i in range(n):
    act = input().split()
    run_queue(act)