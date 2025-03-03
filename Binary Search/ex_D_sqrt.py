from math import sqrt

def get_sqrt(number):
    a = 0
    b = number
    big_num = 1e-6
    while b - a > big_num:
        x = (a + b) / 2
        if x**2 + sqrt(x+1) < number:
            a = x
        else:
            b = x
    return (a + b) / 2

number = float(input())
print(get_sqrt(number))