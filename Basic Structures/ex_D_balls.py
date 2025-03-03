n = int(input())
line = list(map(int, input().split()))

cnt = 0
stack = []

for i in range(n):
    if len(stack) == 0:
        stack.append((line[i], 1))
        continue

    if stack[-1][0] == line[i]:
        stack.append((line[i], stack[-1][1] + 1))

    elif stack[-1][1] >= 3:
        cnt += stack[-1][1]
        for _ in range(stack[-1][1]):
            stack.pop()

        if len(stack) == 0 or stack[-1][0] != line[i]:
            stack.append((line[i], 1))
            continue

        elif stack[-1][0] == line[i]:
            stack.append((line[i], stack[-1][1] + 1))
    else:
        stack.append((line[i], 1))


while len(stack) > 0 and stack[-1][1] >= 3:
    cnt += stack[-1][1]
    for _ in range(stack[-1][1]):
        stack.pop()

print(cnt)
