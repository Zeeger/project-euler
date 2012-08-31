#!/c/Ruby187/bin/ruby

# count the number of letters needed to print numbers 1-1000 in words

def sandone(x)
	dealt_with = 0
	digit1 = x % 10
	
	dealt_with+=digit1
	
	digit2 = (x % 100 - digit1) /10
	
	dealt_with+=digit2
	digit3 = (x % 1000 - (digit2 + digit1)) /100
	
	print digit3.to_s + '-' + digit2.to_s + '-' + digit1.to_s + " -- "
	
	print lines[9 + digit1][1] if digit2 == 1
	
	# print lines[20 + digit2][1] + '-' + lines[digit1 + 1][1] + 
	print "\n"
end

def sandtwo(x)
digitarr = Array.new
	
	digitarr = x.to_s.split(//).reverse
	
	print digitarr
	
	wordhash = Hash.newAKr
	
	for y in 0..digitarr.size-1
	
		wordhash[y] = lineHash[digitarr[y]]
#		lines[digitarr[y].to_i-1][1] unless digitarr[y].to_i-1 < 0
		
		if y==1 and digitarr[y] == 1
			# we're on the second digit. Blank out the first and write the override
			#wordhash[y] = lines[digitarr[0].to_i+9][1]
			
			wordhash[y] = lineHash[0]
			wordhash[0] = nil
		#elsif y==1 and digitarr[y] > 1
		end
	end
end

lines = Array.new

lineHash = Hash.new

File.open('input/prob17.dat','r') do |f1|
	while line = f1.gets
		lines.push(line.split(' '))
		
		linearray = line.split(' ')
		
		lineHash[linearray[0]] = linearray[1]
	end
end

#lines.each do |line|
	#print line
#end

for x in 1..120
	
	unless lineHash[x.to_s].nil?
		print lineHash[x.to_s] + "\n"
	else
		
		#powerOfTenDivisor
		potd = 10
		cur = x
		concatnum = ''
		
		while (cur*10) >= potd
		
			#print cur.to_s + "\n"
			remainder = cur % potd
			
			concatnum+=lineHash[remainder.to_s] unless lineHash[remainder.to_s].nil?
			
			if cur/100 == 1..9 and cur%100 == 0
				print "fooobar " + cur.to_s + " "
			end
			
			cur-=remainder
			potd*=10
		end
		
		print concatnum + "\n"
	end
	
	
	# print "\n" + wordhash.to_s + "\n"
end

