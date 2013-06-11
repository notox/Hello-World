def calcConsonants(consonants, nameLen, n):
    nvalue = 0
    if n == 0:
        return nvalue
        
    nvalue += calcConsonants(consonants, nameLen, n - 1)
    
    consonantsLen = len(consonants)
    for i in range(0, consonantsLen-n+1):
        preview = 0        
        if i == 0:
            preview = consonants[i]
        else:
            preview = consonants[i] - consonants[i-1] - 1
        
        next = 0
        if i == consonantsLen-n:
            next = nameLen - 1 - consonants[i+n-1] - intn + 1
        else:
            next = consonants[i+n] - consonants[i+n-1] - 1   
        
        if next > 0 and preview > 0:
            nvalue += (preview+1)*(next+1)
        elif next == 0 and preview == 0:
            nvalue += 1
        elif next == 0:
            nvalue += (preview + 1)       
        elif preview == 0:
            nvalue += (next + 1)  
    return nvalue

re = input()
for ri in xrange(re):
    name, n = raw_input().split()
    intn = int(n)
    nvalue = 0
    nameLen = len(name)
    consonants = []   
    vowels = ['a', 'o', 'i', 'e', 'u']

    for i in range(0, nameLen - intn + 1):
        substring = name[i:intn+i]
        if reduce(lambda x,y: x and y, map(lambda x: substring.find(x) < 0, vowels)):
            consonants.append(i)
        
    nvalue = calcConsonants(consonants, nameLen, len(consonants))

    print "Case #" + str(ri + 1) + ": " + str(nvalue)