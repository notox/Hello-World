re = input()
for ri in xrange(re):
  r, t = map(int, raw_input().split())
  used = 0
  j = max(int(((t/2)**0.5 + 1 - 2*r)/2), 1)
  while True:
    used = (2*j + 2*r - 1) * j	
    if used > t:
      break
    j = j + 1
	
  print "Case #" + str(ri + 1) + ": " + str(j-1)