def run_stack(operation, stack):
    if operation[0] == 1:
        if len(stack) == 0:
            min_value = operation[1]
        else:
            min_value = min(operation[1], stack[-1][1])
        stack.append((operation[1], min_value))

    elif operation[0] == 2:
        stack.pop()
    
    else:
        print(stack[-1][1])


n = int(input())
stack = []

for i in range(n):
    operation = list(map(int, input().split()))
    run_stack(operation, stack)