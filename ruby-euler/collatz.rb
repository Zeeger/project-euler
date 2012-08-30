#!/c/Ruby187/bin/ruby

# Collatz funcs

class CollatzFunctions

	def next(x)
		# print "Collatz x = " + x.to_s + "\n"
		
		# y = 1
		
		# unless x.nil? 
			# y = x/2 if x%2 == 0
			# y = x*3 + 1 if x%2 == 1
		# end
		
		# y
		
		#OR, Here's a simpler way of doing a return.
		# the return value is always the last result
		# It doesn't need to be held in a var, as it gets thrown out
		# when we leave the method anyhow.
		
		if x%2 == 0
			x/2
		else
			x*3 + 1
		end
	end

end