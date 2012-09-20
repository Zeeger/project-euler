#!/c/Ruby187/bin/ruby

#Problem 28

def SolveCorners(x)

	sum = 1
	lastnumused = 1
	
	for y in 2..x
	
		interval = y * 2 - 2
		
		multiplicity = lastnumused + (interval * 2.5)
	
		sum += (4 * multiplicity)
		
		lastnumused = lastnumused + (interval * 4)
	
	end

	sum
end

print "Solve for 1001: " + SolveCorners(gets.to_i).to_s