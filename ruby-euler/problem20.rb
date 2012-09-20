#!/c/Ruby187/bin/ruby

#	-Problem 20-
#n! means n × (n - 1) × ... × 3 × 2 × 1
#
#For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
#and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
#
#Find the sum of the digits in the number 100!

require 'adamath.rb'

adamath = Adamath.new

fact100 = adamath.fact(100)

fact100array = fact100.to_s.split(//)

sum = 0

fact100array.each do |num|
	sum+=num.to_i
end

print sum