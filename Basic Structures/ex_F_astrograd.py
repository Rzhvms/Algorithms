def run_queue(actions):
    action = actions[0]

    if action == 1:
        stack.append(actions[1])
    elif action == 2:
        stack.pop(0)
    elif action == 3:
        stack.pop()
    elif action == 4:
        index = stack.index(actions[1])
        print(index)
    elif action == 5:
        print(stack[0])

n = int(input())
stack = []

for i in range(n):
    actions = list(map(int, input().split()))
    run_queue(actions)

