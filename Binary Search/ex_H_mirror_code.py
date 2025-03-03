def get_palindrome(string):
    count = [0] * 26
    for char in string:
        count[ord(char) - ord('A')] += 1
    
    odd_char = ''
    half_palindrome = []
    
    for i in range(26):
        char = chr(ord('A') + i)
        if count[i] % 2 != 0:
            if not odd_char:
                odd_char = char
        half_palindrome.append(char * (count[i] // 2))
    
    half = ''.join(half_palindrome)
    return half + odd_char + half[::-1]


n = int(input())
string = str(input().rstrip())
print(get_palindrome(string))