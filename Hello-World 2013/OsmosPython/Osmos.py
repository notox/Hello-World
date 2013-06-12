re = input()
for ri in xrange(re):
  a, n = map(int, raw_input().split())
  s = map(int, raw_input().split())
  s.sort()
  results = []
 
  rest = n
  operateTimes = 0
  for si in s:
    if a > si:
      a += si;
    elif a == 1:
      operateTimes += rest
      break
    else:   
      ta = a
      addTimes = 0
      while ta <= si:
        ta = 2 * ta - 1
        addTimes = addTimes + 1
      results.append(operateTimes + rest)
      if addTimes > rest:
        operateTimes += rest
        break
      else:
        operateTimes += addTimes
        a = ta + si
    rest -= 1
  results.append(operateTimes)
  results.sort()
  print "Case #" + str(ri + 1) + ": " + str(results[0])