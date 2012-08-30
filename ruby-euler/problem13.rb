#!/c/Ruby187/bin/ruby

# Problem 13: Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.

print "Attempting to solve problem 13\n"

lines = Array.new
lineindex = 0

File.open('input\prob13.dat', 'r') do |f1|
	while line = f1.gets
		firstthree = line
		#[0..7]
		
		print firstthree + ' ' + lineindex.to_s + ' - '
		
		lines.push(firstthree.to_i)
		
		lineindex+=1
	end
end

endgame = 0

lines.each do |line|
	print line
	endgame += line
end

#for x in 0..5
#	endgame += lines[x]
#	print "\n" + lines[x].to_s + " " + endgame.to_s
#end

print "\nFirst 10 of endgame is " + endgame.to_s[0..9] + "\n"
print "\n" + endgame.to_s