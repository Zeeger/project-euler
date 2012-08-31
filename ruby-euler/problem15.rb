#!/c/Ruby187/bin/ruby

require 'adamath.rb'

def brokentriangle(x)
	2 * ((x * (x-1)) + 1)
end

adamath = Adamath.new

# input = gets.to_i

for x in 1..20
	print x.to_s + ' ' + brokentriangle(x).to_s + ' ' + adamath.pascaltriangle(x).to_s + "\n"
end

