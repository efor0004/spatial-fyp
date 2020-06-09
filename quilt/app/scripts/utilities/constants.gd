extends Node

# All rotations are clockwise

var level_2_option_rotations = [
	90,
	90,
	45,
	45,
	90,
	90,
	180,
	180,
	90,
	180,
	90,
	180,
	270,
	270,
	90,
	90,
	135,
	45,
	45,
	135
]

export(Array) var level_option_rotations = [
	0, # level 1
	level_2_option_rotations # level 2
]
