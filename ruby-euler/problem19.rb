#!/c/Ruby187/bin/ruby

require 'datefunc.rb'

require 'date'
require 'enumerator'

#How many Sundays fell on the first of the month in the 21st century.

#First question. How many mondays were there?

dateFunctions = DateFunctions.new

daysInWeek = Array.new
daysInWeek.push("dummy")
daysInWeek.push("Sunday")
daysInWeek.push("Monday")
daysInWeek.push("Tuesday")
daysInWeek.push("Wednesday")
daysInWeek.push("Thursday")
daysInWeek.push("Friday")
daysInWeek.push("Saturday")

def IncrementDayOfWeek(current)
	current += 1
	
	current = 1 if current == 8
	
	current
end

def IncrementMonthDay(currentMonth, currentDayOfMonth, isLeapYear)

	currentDayOfMonth +=1
	
	daysInMonth = [0,
	31,
	28,
	31,
	30,
	31,
	30,
	31,
	31,
	30,
	31,
	30,
	31]
	
	maxDaysInMonth = daysInMonth[currentMonth]
	
	maxDaysInMonth += 1 if currentMonth == 2 and isLeapYear
		
	if currentDayOfMonth > maxDaysInMonth
		currentMonth += 1
		currentDayOfMonth = 1
	end
	
	currentMonth = 1 if currentMonth == 13

	return currentMonth,currentDayOfMonth
end

currentDayOfWeek = 1
centurySundayCount = 0
firstOfMonthSundayCount = 0

currentMonth = 1
currentDayOfMonth = 0

#Solution from Zach Denton's blog, because I had some bugs and wanted a baseline
bonk = Array.new( Date.new(1901,1,1).enum_for(:upto,(Date.new(2000,12,31))).find_all { |d| d.mday == 1 && d.wday == 0 })
bonkIterator = 0

#Outer loop, representing 100 years
for year in 1900..2000

	#print year.to_s + " " + dateFunctions.IsLeapYear(year).to_s + " Starting on " + daysInWeek[currentDayOfWeek] + "\n"
	
	daysInCurrentYear = 365
	isLeapYear = dateFunctions.IsLeapYear(year)
	
	daysInCurrentYear += 1 if isLeapYear
	
	yearSundayCount = 0
	
	#Loop representing all days in a year
	for day in 1..daysInCurrentYear
	
		currentDayOfWeek = IncrementDayOfWeek(currentDayOfWeek)
		
		currentMonth, currentDayOfMonth = IncrementMonthDay(currentMonth,currentDayOfMonth, isLeapYear)
		
		yearSundayCount +=1 if currentDayOfWeek == 0
	
		if currentDayOfMonth == 1 and currentDayOfWeek == 1 and year > 1900
			firstOfMonthSundayCount += 1 
			mydate = year.to_s + "-" + currentMonth.to_s.rjust(2,'0').to_s + "-" + currentDayOfMonth.to_s
			
			puts mydate.to_s + " bonk: " + bonk[bonkIterator].to_s + " " + daysInWeek[currentDayOfWeek]
			bonkIterator+=1
		end
	end
	
	centurySundayCount += yearSundayCount

end

print "\n Number of first of month sundays: " + firstOfMonthSundayCount.to_s





