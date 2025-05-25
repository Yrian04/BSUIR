P = 9721
g = 0
powers = True
while powers and g < P:
    g += 1
    powers = set(i for i in range(1, P))
    for i in range(P):
        if (a := (g ** i) % P) in powers:
            powers.remove(a)
        else:
            break
print(f'GF({P}) = {g}')

A = int(input('Enter Alice\'s secret key: ')) % P
print('Alice\'s public key:  ', g_A := g ** A % P)

B = int(input('Enter Bob\'s secret key: ')) % P
print('Bob\'s public key:  ', g_B := g ** B % P)

print('General secret: ', g_A ** B % P, g_B ** A % P)
