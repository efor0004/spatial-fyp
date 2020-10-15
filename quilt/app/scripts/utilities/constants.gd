extends Node

var level_1_incorrect_reasons = [
	[2, 0],
	[2, 0],
	[2, 0],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	# 10 ^
	[2, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[1, 2],
	# 20 ^
	[2, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[1, 2],
	[1, 2],
	[1, 2],
	[3, 2],
	[2, 2],
	[1, 2],
	# 30 ^
]

var level_1_hard_incorrect_reasons = [
	[2, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[1, 2],
	[1, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	# 10 ^
	[1, 2],
	[2, 2],
	[1, 2]
]

var level_2_incorrect_reasons = [
	[1, 2],
	[2, 2],
	[0, 2],
	[0, 2],
	[0, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	# 10 ^
	[2, 2],
	[2, 2],
	[0, 2],
	[0, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	# 20 ^
	[2, 1],
	[2, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[1, 2],
	[2, 2],
	# 30 ^
	[1, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 0],
	[1, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	# 40 ^
	[2, 2],
	[0, 2]
]

var level_2_hard_incorrect_reasons = [
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[1, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	# 10 ^
	[2, 2],
	[2, 2],
	[1, 2],
	[0, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	[1, 2],
	[0, 2],
	# 20 ^
	[2, 2],
	[1, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[0, 2],
	[0, 2],
	[2, 2]
	# 30 ^
]

var level_3_incorrect_reasons = [
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[0, 2],
	# 10 ^
	[1, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[1, 2],
	# 20 ^
	[2, 2],
	[1, 2],
	[2, 2],
	[1, 2],
	[1, 2],
	[2, 2],
	[2, 1],
	[2, 2],
	[2, 0],
	[0, 2],
	# 30 ^
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 0],
	[2, 2],
	[2, 2],
	[2, 2],
	[1, 2],
	# 40 ^
]

var level_4_incorrect_reasons = [
	[3, 2],
	[2, 3],
	[0, 2],
	[0, 1],
	[1, 2],
	[2, 2],
	[2, 2],
	[3, 2],
	[3, 1],
	[3, 1],
	# 10 ^
	[2, 3],
	[2, 3],
	[3, 2],
	[2, 3],
	[2, 2],
	[3, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	# 20 ^
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 1],
	[2, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 3],
	# 30 ^
	[2, 2],
	[1, 2],
	[3, 3],
	[2, 2],
	[2, 2],
	[2, 2],
	[3, 2],
	[2, 2]
]

var level_5_incorrect_reasons = [
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	# 10 ^
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[0, 1],
	# 20 ^
	[2, 2],
	[2, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[0, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	[2, 0],
	# 30 ^
	[2, 2],
	[2, 2],
	[1, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	# 40 ^
	[0, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[0, 2],
	[2, 2]
]

var level_6_incorrect_reasons = [
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 1],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 1],
	[1, 2],
	[2, 2],
	# 10 ^
	[1, 2],
	[2, 2],
	[2, 2],
	[1, 2],
	[2, 0],
	[0, 0],
	[2, 2],
	[2, 3],
	[3, 2],
	[3, 2],
	# 20 ^
	[3, 2],
	[0, 1],
	[3, 2],
	[1, 2],
	[2, 2],
	[0, 2],
	[1, 2],
	[3, 0],
	[2, 2],
	[3, 0],
	# 30 ^
	[3, 2],
	[2, 2],
	[2, 2],
	[3, 0],
	[0, 2],
	[2, 1],
	[0, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	# 40 ^
	[2, 3],
	[2, 2],
	[2, 3],
	[2, 3],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 3],
	[2, 2],
	[3, 0],
	# 50 ^
	[2, 2],
	[2, 1],
	[2, 3],
	[2, 2],
	[2, 2],
	[2, 1]
]

var level_7_incorrect_reasons = [
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	# 10 ^
	[0, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	# 20 ^
	[2, 2],
	[2, 1],
	[2, 2],
	[2, 0],
	[2, 2],
	[1, 2],
	[0, 2],
	[2, 2],
	[2, 0],
	[0, 2],
	# 30 ^
	[0, 2]
]

var level_8_incorrect_reasons = [
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 1],
	[2, 2],
	[0, 2],
	[0, 2],
	[1, 2],
	[0, 2],
	[1, 2],
	# 10 ^
	[0, 2],
	[1, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	# 20 ^
	[3, 2],
	[3, 2],
	[2, 2],
	[2, 2],
	[0, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[3, 2],
	[2, 2],
	# 30 ^
	[3, 2],
	[2, 1],
	[3, 2],
	[3, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 0],
	[2, 2],
	[2, 2],
	# 40 ^
	[2, 2],
	[2, 2],
	[2, 2]
]

var level_9_incorrect_reasons = [
	[2, 2],
	[2, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 1],
	[2, 2],
	# 10 ^
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[1, 2]
	# 20 ^
]

var level_9_hard_incorrect_reasons = [
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	# 10 ^
	[2, 2],
	[2, 2],
	[2, 1],
	[2, 2],
	[2, 1]
]

var level_10_incorrect_reasons = [
	[2, 2],
	[1, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	# 10 ^
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 1],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 1],
	# 20 ^
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 1],
	[2, 2],
	[2, 2],
	# 30 ^
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 2],
	[2, 3],
	[2, 2],
	[2, 2],
	[3, 2],
	# 40 ^
	[2, 2],
	[1, 2],
	[2, 2],
	[2, 3],
	[2, 2],
	[3, 2],
	[2, 2],
	[2, 2]
]

export(Array) var level_incorrect_reasons = [
	{ "normal": level_1_incorrect_reasons, "hard": level_1_hard_incorrect_reasons }, # level 1
	{ "normal": level_2_incorrect_reasons, "hard": level_2_hard_incorrect_reasons }, # level 2
	{ "normal": level_3_incorrect_reasons }, # level 3
	{ "normal": level_4_incorrect_reasons }, # level 4
	{ "normal": level_5_incorrect_reasons }, # level 5
	{ "normal": level_6_incorrect_reasons }, # level 6
	{ "normal": level_7_incorrect_reasons }, # level 7
	{ "normal": level_8_incorrect_reasons }, # level 8
	{ "normal": level_9_incorrect_reasons, "hard": level_9_hard_incorrect_reasons }, # level 9
	{ "normal": level_10_incorrect_reasons } # level 10
]

export var FLIP_NONE = "flip-none"

# All rotations are clockwise

var level_1_option_rotations = 0

var level_1_hard_option_rotations = [
	90,
	90,
	90,
	90,
	90,
	90,
	180,
	180,
	90,
	90,
	90,
	90,
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

var level_3_option_rotations = [
	20,
	-20,
	-135,
	135,
	135,
	-135,
	-45,
	45,
	135,
	-135,
	-45,
	45,
	135,
	-135,
	45,
	-135,
	135,
	135,
	-135,
	135,
	-135,
	-135,
	135,
	-135,
	135,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0
]

var level_4_option_rotations = 0

var level_5_option_rotations = [
	-90,
	90,
	180,
	90,
	180,
	-90,
	180,
	90,
	-90,
	-90,
	180,
	0,
	90,
	-90,
	180,
	90,
	90,
	-90,
	180,
	180,
	90,
	-90,
	-90,
	180,
	90,
	0,
	-90,
	180,
	90,
	180,
	90,
	-90,
	180,
	-90,
	90,
	-90,
	180,
	90,
	90,
	-90,
	-90,
	90,
	-90,
	90,
	90,
	-90
]

var level_6_option_rotations = [
	90,
	-90,
	90,
	-90,
	90,
	-90,
	90,
	-90,
	90,
	-90,
	90,
	-90,
	90,
	90,
	-90,
	-90,
	90,
	-90,
	90,
	-90,
	90,
	90,
	-90,
	-90,
	-90,
	90,
	90,
	-90,
	90,
	-90,
	-90,
	90,
	-90,
	90,
	90,
	-90,
	-90,
	-90,
	-90,
	90,
	90,
	-90,
	90,
	-90,
	90,
	-90,
	90,
	-90,
	-90,
	90,
	-90,
	90,
	90,
	-90,
	-90,
	90
]

var level_7_option_rotations = [
	-45,
	45,
	-45,
	45,
	-45,
	45,
	-45,
	45,
	45,
	-45,
	45,
	-45,
	45,
	-45,
	45,
	-45,
	-45,
	45,
	45,
	-45,
	45,
	-25,
	-30,
	-20,
	-25,
	160,
	-30,
	75,
	-20,
	65,
	25,
]

var level_8_option_rotations = [
	-45,
	135,
	-135,
	45,
	180,
	90,
	-90,
	180,
	160,
	180,
	180,
	-60,
	-110,
	160,
	-110,
	-160,
	180,
	-100,
	165,
	115,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180,
	180
]

var level_9_option_rotations = 0

var level_9_hard_option_rotations = [
	-90,
	180,
	90,
	90,
	-90,
	180,
	90,
	-90,
	180,
	-90,
	180,
	90,
	45,
	45,
	-45
]

var level_10_option_rotations = [
	90,
	-90,
	90,
	180,
	180,
	-90,
	-90,
	0,
	180,
	-90,
	180,
	90,
	180,
	90,
	-90,
	-90,
	180,
	90,
	-90,
	180,
	90,
	-90,
	180,
	90,
	-90,
	180,
	90,
	90,
	90,
	-90,
	180,
	90,
	-90,
	180,
	90,
	-90,
	-90,
	180,
	90,
	90,
	-90,
	180,
	90,
	90,
	-90,
	-90,
	180,
	90
]

export(Array) var level_option_rotations = [
	{ "normal": level_1_option_rotations, "hard": level_1_hard_option_rotations }, # level 1
	{ "normal": level_2_option_rotations, "hard": level_2_hard_option_rotations }, # level 2
	{ "normal": level_3_option_rotations }, # level 3
	{ "normal": level_4_option_rotations }, # level 4
	{ "normal": level_5_option_rotations }, # level 5
	{ "normal": level_6_option_rotations }, # level 6
	{ "normal": level_7_option_rotations }, # level 7
	{ "normal": level_8_option_rotations }, # level 8
	{ "normal": level_9_option_rotations, "hard": level_9_hard_option_rotations }, # level 9
	{ "normal": level_10_option_rotations } # level 10
]

var hard_questions_per_level = 4

export(Array) var num_hard_questions_per_level = [
	{ "required": hard_questions_per_level, "available": 13 }, # level 1
	{ "required": hard_questions_per_level, "available": 30 }, # level 2
	{ "required": 0, "available": 0 }, # level 3
	{ "required": 0, "available": 0 }, # level 4
	{ "required": 0, "available": 0 }, # level 5
	{ "required": 0, "available": 0 }, # level 6
	{ "required": 0, "available": 0 }, # level 7
	{ "required": 0, "available": 0 }, # level 8
	{ "required": hard_questions_per_level, "available": 15 }, # level 9
	{ "required": 0, "available": 0 } # level 10
]

export var questions_per_level = 10

export(Array) var questions_available_per_level = [
	30, # level 1
	42, # level 2
	39, # level 3
	39, # level 4
	46, # level 5
	56, # level 6
	31, # level 7
	43, # level 8
	20, # level 9
	48 # level 10
]

export var max_levels = 10

export var max_questions_per_file = 10

export var num_characters = 6

export var character_names = ['Owl', 'Chameleon', 'Goat', 'Frog', 'Monkey', 'Rabbit']
