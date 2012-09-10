#!/c/Ruby187/bin/ruby

# count the number of letters needed to print numbers 1-1000 in words

require 'adamath.rb'

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
	
	wordhash = Hash.new
	
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

def threeDigitWords(lineHash,threeDigitNum)

	if threeDigitNum.to_s.size > 3
		threeDigitNum = threeDigitNum.to_s.split(//)[(threeDigitNum.to_s.size-3)...threeDigitNum.to_s.size]
	end

	concat = ""
	threeDigitString = threeDigitNum.to_s
	
	while threeDigitString.split(//).size < 3
		threeDigitString = "0" + threeDigitString
	end
	
	firstDigit = threeDigitString.split(//)[0]
	
	if firstDigit.to_i > 0 	
		concat+=lineHash[firstDigit]
		concat+=lineHash[100.to_s]
	end
	
	twoDigits = threeDigitString.to_i % 100
	
	unless lineHash[twoDigits.to_s].nil?
		concat+=lineHash[twoDigits.to_s] unless lineHash[twoDigits.to_s].nil?
	else
		tenDigit = threeDigitString.split(//)[1]
		oneDigit = threeDigitString.split(//)[2]
		
		concat+=lineHash[(tenDigit.to_i * 10).to_s] unless lineHash[tenDigit].nil?
		concat+=lineHash[oneDigit] unless lineHash[oneDigit].nil?
	end
	
	concat
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

adamath = Adamath.new

totalCharNum = 0

for x in 1..1000
	
	concatnum = ''
	
	reversedNumber = x.to_s.reverse
	
	segmentOfThree = 0
	
	
	
	while reversedNumber.size >= 1
		
		currentReversedNumber = ""
		
		if segmentOfThree == 0 && reversedNumber.size > 2
		
			if reversedNumber[0...2].reverse.to_i > 0
				concatnum+="and"
			end
		end
		
		if reversedNumber.size >= 3
			currentReversedNumber = reversedNumber[0...3]
			reversedNumber = reversedNumber[3...reversedNumber.size]
		else
			currentReversedNumber = reversedNumber
			reversedNumber = ""
		end
		
		if segmentOfThree > 0
			power = adamath.pow(10,segmentOfThree*3)
			
			concatnum = lineHash[power.to_s] + concatnum unless lineHash[power.to_s].nil?
		end
		
		concatnum = threeDigitWords(lineHash,currentReversedNumber.reverse.to_i) + concatnum
		
		segmentOfThree+=1
		
		totalCharNum += concatnum.size
	end
	
	print concatnum + concatnum.size.to_s + "\n"

	
end

print "Total Characters: " + totalCharNum.to_s

