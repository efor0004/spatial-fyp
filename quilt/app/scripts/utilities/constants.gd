extends Node

export var FLIP_NONE = "flip-none"

# All rotations are clockwise

var level_1_option_rotations = 0

var level_1_hard_option_rotations = [
	90,
	90,
	90,
	90,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
]

var level_2_option_rotations = [
	90,
	90,
	45,
	-22.5,
	-45,
	45,
	45,
	-45,
	-45,
	-22.5,
	22.5,
	45,
	-15,
	180,
	-45,
	45,
	45,
	22.5,
	22.5,
	45,
	-45,
	45,
	-45,
	-90,
	90,
	-45,
	45,
	180,
	180,
	180,
	180,
	180,
	90,
	180,
	0,
	-90,
	90,
	90,
	180,
	180,
	180,
	-90,
	-22.5
]

var level_2_hard_option_rotations = [
	-22.5,
	22.5,
	180,
	22.5,
	90,
	-90,
	90,
	-90,
	90,
	-90,
	90,
	-90,
	45,
	-45,
	45,
	-45,
	180,
	-90,
	90,
	-45,
	45,
	-45,
	45,
	-90,
	90,
	-90,
	90,
	45,
	-45,
	45
]

export(Array) var level_option_rotations = [
	{ "normal": level_1_option_rotations, "hard": level_1_hard_option_rotations }, # level 1
	{ "normal": level_2_option_rotations, "hard": level_2_hard_option_rotations } # level 2
]

var hard_questions_per_level = 4

export(Array) var num_hard_questions_per_level = [
	{ "required": hard_questions_per_level, "available": 13 }, # level 1
	{ "required": hard_questions_per_level, "available": 30 } # level 2
]

export var questions_per_level = 10

export(Array) var questions_available_per_level = [
	30, # level 1
	42 # level 2
]

export var max_levels = 2

export var max_questions_per_file = 10
