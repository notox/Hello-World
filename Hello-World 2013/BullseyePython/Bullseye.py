re = input()
for ri in xrange(re):
    r, t = map(int, raw_input().split())
    begin = max(int((t**0.5 + 1 - 2*r)/2), 1)
    end = max(int((t/2)**0.5), 1)
    j = 1
    while begin <= end:
        i = (begin + end)/2
        used = (2*i + 2*r - 1) * i	
        if used < t:
            begin = i + 1
            j = i
        elif used > t:
            end = i - 1
        else:
            j = i
            break
            
    print "Case #" + str(ri + 1) + ": " + str(j)