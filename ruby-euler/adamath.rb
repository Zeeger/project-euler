#!/c/Ruby187/bin/ruby

class Adamath

	def fact(x)
		prod = 1
		
		while x>0 do
			prod *= x
			x-=1
		end
		
		prod
	end
	
	def pascaltriangle(x)
		fact(2 * x) / (fact(x) * fact(x))
	end
	
	def pow(x,y)
		result = x
		for z in 1..y-1
			result*=x
		end
		
		result
	end

end