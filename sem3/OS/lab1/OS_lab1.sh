#!/bin/bash
for i in $1/*; do
	for j in $2/*; do 
		if cmp -s $i $j; then
			echo "Files $i and $j are equal"
		fi
	done
done

exit 0 

