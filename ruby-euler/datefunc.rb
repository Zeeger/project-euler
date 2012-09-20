#!/c/Ruby187/bin/ruby

class DateFunctions
	#A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
	def IsLeapYear(year)
		if (year % 4 == 0) and not ((year % 100 == 0) and (year % 400 != 0))
			true
		else
			false
		end
	end

end