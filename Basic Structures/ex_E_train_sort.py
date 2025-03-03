def sort_train(nums):
    stack, actions = [], []
    v_current, v_num, cnt = 1, 1, 0

    for vagon in nums:
        if stack and vagon > stack[-1]:
            print(0)
            return

        stack.append(vagon)
        flag = False

        while stack and stack[-1] == v_current:
            stack.pop()
            v_current += 1
            cnt += 1
            flag = True

        if flag:
            actions.extend([(1, v_num), (2, cnt)])
            v_num, cnt = 1, 0
        else:
            v_num += 1
    
    output = [str(len(actions))] + [f"{a} {b}" for a, b in actions]
    print("\n".join(output))


n = int(input())
nums = list(map(int, input().split()))
sort_train(nums)

    
