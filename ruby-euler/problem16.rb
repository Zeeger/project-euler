#!/c/Ruby187/bin/ruby

require 'adamath.rb'

adamath = Adamath.new

two_to_the_thousandth = adamath.pow(2,1000).to_s

sum = 0

two_to_the_thousandth.split(//).each do |digit|
	sum+=digit.to_i
end

print sum.to_s