#!/c/Ruby187/bin/ruby

# Solve longest collatz conjecture where the initial number is under 1 000 000

require 'collatz.rb'

def givenext(x)
	x*2
end

currentnum = 0

def sandone
	for x in 0..10

		# If number is even, divide by 2
		# If number is odd, multiple by 3 and add 1
		
		# Going to try and do this by solving for reverse
		# If the current number *2 is even <- already found an issue with this approach
		# I'd find myself constantly making decisions on whether to multiply or subtract 1 and divide
		
		# It's worth a shot to at least attempt to subtract one and divide by 3 whenever possible
		
		print givenext(x).to_s + "\n"
		
		dork = CollatzFunctions.new
		
		print dork.next(x)
		x+=1
	end
end

collatz = CollatzFunctions.new

highest_seq_count = 0
highest_seq_initial = 0

for x in 1..1_000_000
	current_term_count = 1
	current_term = x
	
	while current_term > 1 do
		current_term = collatz.next(current_term)
		current_term_count+=1
	end
	
	if current_term_count > highest_seq_count
		highest_seq_count = current_term_count
		highest_seq_initial = x
		print "High count: " + highest_seq_count.to_s + ' High init: ' + highest_seq_initial.to_s + "\n"
	end
end