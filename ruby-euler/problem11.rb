#!/c/Ruby187/bin/ruby

# Problem 11: Take a 20x20 grid of numbers and find the highest product of 4 hor/ver/diag numbers in that grid.

# Got the answer, but totally got rooked by the forward slash diagonals

print "Attempting to solve problem 11\n"

lines = Array.new

File.open('input\prob11.dat', 'r') do |f1|
	while line = f1.gets
		lines.push(line.split(' '))
	end
end

print "\n\n Array of lines has " << lines.size.to_s << ' elements. Each with ' + lines[1].size.to_s + " elements.\n"

#lines.each do |line|
#	line.each do |num|
#		print num << ' - '
#	end
#end

print "Start by calculating the horizontal numbers.\n"

# initialize the highest product
highestproduct = 0

# Just do for horizontally initially

#lines.each do |horizontalline|
#	for x in 0..horizontalline.size-4
#	
#		productblock = horizontalline[x]
#		product = horizontalline[x].to_i
#	
#		for y in 1..3
#			productblock << " " << horizontalline[x+y]
#			product *= horizontalline[x+y].to_i
#			highestproduct = product if product > highestproduct
#		end
#	
#		print productblock + ' = ' + product.to_s + "\n"
#	end
#end

highvprod = 0
highhprod = 0
highdprod = 0
highddprod = 0

# We can improve on this list. We should go top-down and left-right

numberofproducts = 0

for x in 0..lines.size-1
	for y in 0..lines[x].size-1
	
		hprod = lines[x][y].to_i
		vprod = hprod
		dprod = hprod
		ddprod = hprod

		hseq = lines[x][y]
		vseq = lines[x][y]
		dseq = lines[x][y]
		ddseq = lines[x][y]

		highcoords = x.to_s << ', ' << y.to_s

		for z in 1..3

			unless x+z > lines.size-1
				vprod*=lines[x+z][y].to_i unless x+z > lines.size-1
				vseq += ' ' + lines[x+z][y]
			end
			
			unless y+z > lines.size-1
				 hprod*=lines[x][y+z].to_i unless y+z > lines.size-1
				hseq += ' ' + lines[x][y+z]
			end
			
			unless (y+z > lines.size-1) or (x+z > lines.size-1)
				 dprod*=lines[x+z][y+z].to_i unless (y+z > lines.size-1) or (x+z > lines.size-1)
				dseq += ' ' + lines[x+z][y+z]
			end

			unless (x+z > lines.size-1) or (y-z < 0)
				ddprod*=lines[x+z][y-z].to_i
				ddseq += ' ' + lines[x+z][y-z]
			end
		end

		highhprod = hprod if hprod > highhprod 
		highvprod = vprod if vprod > highvprod 
		highdprod = dprod if dprod > highdprod 
		highddprod = ddprod if ddprod > highddprod

		if highhprod > highestproduct
			print highcoords + ' ' + hseq + ' ' + hprod.to_s + "\n"
			highestproduct = highhprod
		end
		
		if highvprod > highestproduct
			print highcoords + ' ' + vseq + ' ' + vprod.to_s + "\n"
			highestproduct = highvprod
		end

		if highdprod > highestproduct
			print highcoords + ' ' + dseq + ' ' + dprod.to_s + "\n"
			highestproduct = highdprod
		end

		if highddprod > highestproduct
			print highcoords + ' ' + ddseq + ' ' + ddprod.to_s + "\n"
			highestproduct = highddprod
		end
	end
end

print highvprod.to_s + "\n"
print highhprod.to_s + "\n"
print highdprod.to_s + "\n"

print 'highest product = ' + highestproduct.to_s + ' num of prods ' + numberofproducts.to_s + "\n"