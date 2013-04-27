re = input()
for ri in xrange(re):
  r, t = map(int, raw_input().split())
  used = 0
  j = 0
  while True:
    used += 2*r + 4*j + 1	
    if used > t:
      break
    j = j + 1
	
  print "Case #" + str(ri + 1) + ": " + str(j)