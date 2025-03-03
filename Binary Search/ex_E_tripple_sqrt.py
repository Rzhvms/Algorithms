def get_tripple_sqrt(a, b, c, d):
    def f(x):
        return a * x**3 + b * x**2 + c * x + d
    
    left = -1e6
    right = 1e6

    while f(left) * f(right) > 0:
        left *= 2
        right *= 2

    while right - left > 1e-6:
        m = (right + left) / 2
        if f(m) == 0:
            return m
        if f(left) * f(m) < 0:
            right = m
        else:
            left = m

    return (left + right) / 2


coefficients = list(map(int, input().split()))
a = coefficients[0]
b = coefficients[1]
c = coefficients[2]
d = coefficients[3]

x = get_tripple_sqrt(a, b, c, d)
print(f'{x:.20f}')