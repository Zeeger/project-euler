#!/c/Ruby187/bin/ruby

lineArray = Array.new

#File.open('input/prob18.dat','r') do |file1|
File.open('input/prob67.dat','r') do |file1|
	while line = file1.gets
	
		lineArray.push(line.split(' '))
	
	end
end

revLineArray = lineArray.reverse

sumArray = Array.new

revLineArray.each do |rLine|
	rLine.each do |curI|
		print curI.to_i.to_s + ","
	end
	
	print "\n"
end

gets
	

for currentLineIndex in 0...revLineArray.size

	#print currentLineIndex 
	#print "\n"
	
	sumArray.push(Array.new)
		
	for currentNumberIndex in 0...revLineArray[currentLineIndex].size
	
		#Write the current numbers to a new line in the sum array
		
		sumArray[currentLineIndex].push(revLineArray[currentLineIndex][currentNumberIndex].to_i)
		
		#sumArray now has a new line in it
		# that new line has the number from the next line up in the pyramid
		
		unless sumArray[currentLineIndex-1].nil?
			firstNum = 0
			
			unless currentLineIndex==0 || sumArray[currentLineIndex-1][currentNumberIndex].nil?
				firstNum = sumArray[currentLineIndex-1][currentNumberIndex].to_i
			end
			
			secndNum = 0
			
			unless currentLineIndex==0 || sumArray[currentLineIndex-1][currentNumberIndex + 1].nil?
				secndNum = sumArray[currentLineIndex-1][currentNumberIndex + 1].to_i
			end
			
			winner = firstNum
			winner = secndNum if secndNum > firstNum
			
			#print sumArray[currentLineIndex-1][currentNumberIndex].to_s + "\n"
			#print sumArray[currentLineIndex][currentNumberIndex].to_s + "\n"
			#print sumArray.size.to_s + "\n"
			#print (currentLineIndex-1).to_s + " Winner: " + winner.to_s + " First: " + firstNum.to_s + " Second: " + secndNum.to_s
			
			sumArray[currentLineIndex][currentNumberIndex] += winner
			
		end
		
		#sumArray.each do |line|
		#line.each do |seq|
		#	print seq.to_s + "."
		#end
		
		#print "_\n"
		#end
		
		
	end
	
	
	
	#gets

end

sumArray.each do |line|
		line.each do |seq|
			print seq.to_s + "."
		end
		
		print "_\n"
	end

#sumArray.each do |num|
#	print num.to_s + " - "
#end