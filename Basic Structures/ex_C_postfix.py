input_arr = list(input().split())
stack = []

for elem in input_arr:
    if elem.isdigit():
        stack.append(elem)
    else:
        a = int(stack.pop())
        b = int(stack.pop())
        if elem == '+':
            stack.append(a + b)
        elif elem == '-':
            stack.append(b - a)
        elif elem == '*':
            stack.append(a * b)

print(*stack)