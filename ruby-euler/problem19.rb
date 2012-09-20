#!/c/Ruby187/bin/ruby

require 'datefunc.rb'

#How many Sundays fell on the first of the month in the 21st century.

#First question. How many mondays were there?

dateFunctions = DateFunctions.new

daysInWeek = Array.new
daysInWeek.push("Sunday")
daysInWeek.push("Monday")
daysInWeek.push("Tuesday")
daysInWeek.push("Wednesday")
daysInWeek.push("Thursday")
daysInWeek.push("Friday")
daysInWeek.push("Saturday")
currentDayOfWeek = 0

daysInMonth = Array.new


def IncrementDayOfWeek(current)
	current += 1
	
	current = 0 if current == 7
	
	current
end

centurySundayCount = 0

#Outer loop, representing 100 years
for year in 1900...2000

	print year.to_s + " " + dateFunctions.IsLeapYear(year).to_s + " Starting on " + daysInWeek[currentDayOfWeek] + "\n"
	
	daysInCurrentYear = 365
	
	daysInCurrentYear += 1 if dateFunctions.IsLeapYear(year) == true
	
	yearSundayCount = 0
	
	#Loop representing all days in a year
	for day in 1..daysInCurrentYear
	
		currentDayOfWeek = IncrementDayOfWeek(currentDayOfWeek)
		
		yearSundayCount +=1 if currentDayOfWeek == 0
	
	end
	
	centurySundayCount += yearSundayCount

end