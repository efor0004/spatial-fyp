extends Node

export var FLIP_HORIZONTAL = "flip-horizontal"
export var FLIP_VERTICAL = "flip-vertical"

# All rotations are clockwise

var level_1_hard_option_rotations = [
	90,
	90,
	90,
	90,
	FLIP_VERTICAL,
	FLIP_VERTICAL,
	FLIP_HORIZONTAL,
	FLIP_HORIZONTAL,
	FLIP_VERTICAL,
	FLIP_VERTICAL,
	FLIP_VERTICAL,
	FLIP_VERTICAL,
	FLIP_VERTICAL
]

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
	{ "normal": 0, "hard": level_1_hard_option_rotations }, # level 1
	{ "normal": level_2_option_rotations } # level 2
]

export(Array) var num_hard_questions_per_level = [
	{ "required": 9, "available": 13 }, # level 1
	{ "required": 0, "available": 0 } # level 2
]

export var questions_per_level = 10

export(Array) var questions_available_per_level = [
	30, # level 1
	20 # level 2
]

export var max_levels = 2
