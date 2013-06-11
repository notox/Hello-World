def calcNvalue(preview, next):
    nvalue = 0
    if next > 0 and preview > 0:
        nvalue = (preview+1)*(next+1)
    elif next == 0 and preview == 0:
        nvalue = 1
    elif next == 0:
        nvalue = (preview + 1)       
    elif preview == 0:
        nvalue = (next + 1) 
       
    return nvalue

def calcConsonants(consonants, nameLen):
    nvalue = 0
    consonantsLen = len(consonants)
    for j in range(1, consonantsLen+1):
        for i in range(0, consonantsLen-j+1):
            preview = 0        
            if i == 0:
                preview = consonants[i]
            else:
                preview = consonants[i] - consonants[i-1] - 1
            
            next = 0
            if i == consonantsLen-j:
                next = nameLen - 1 - consonants[i+j-1] - intn + 1
            else:
                next = consonants[i+j] - consonants[i+j-1] - 1  
           
            nvalue += calcNvalue(preview, next)
            
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
    
    nvalue = calcConsonants(consonants, nameLen)

    print "Case #" + str(ri + 1) + ": " + str(nvalue)