#!/bin/bash

if [ ! -f $1 ]; then
	echo "File not exist"
	exit 1
fi

if gcc $1 -o $2 >> log; then
	./$2
else
	cat log
fi
