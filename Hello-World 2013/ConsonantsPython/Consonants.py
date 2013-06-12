def calcConsonants(consonants):
    nvalue = 0
    consonantsLen = len(consonants)
    for i in range(1, consonantsLen):
        nvalue += (consonants[i]-consonants[i-1])*(consonants[consonantsLen-1]-consonants[i])
            
    return nvalue
 
re = input()
for ri in xrange(re):
    name, n = raw_input().split()
    intn = int(n)
    nvalue = 0
    nameLen = len(name)
    consonants = []   
    vowels = "aioue"
    
    i = 0
    containConsonant = 0
    consonants.append(-1)
    while i < nameLen:
        if len(set(name[i]).intersection(set(vowels))) == 0:
            if containConsonant < intn: 
                containConsonant += 1            
            if containConsonant == intn:
                consonants.append(i-intn+1)            
        else:
            containConsonant = 0
        i += 1
    consonants.append(nameLen-intn+1)   
    
    nvalue = calcConsonants(consonants)
    
    print "Case #" + str(ri + 1) + ": " + str(nvalue)