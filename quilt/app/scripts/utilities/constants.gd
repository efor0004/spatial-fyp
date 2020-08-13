extends Node

export var FLIP_HORIZONTAL = "flip-horizontal"
export var FLIP_VERTICAL = "flip-vertical"
export var FLIP_NONE = "flip-none"

# All rotations are clockwise

var level_1_option_transformations = { "rotation": 0, "flip": FLIP_NONE }

var level_1_hard_option_transformations = [
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 0, "flip": FLIP_HORIZONTAL },
	{ "rotation": 0, "flip": FLIP_HORIZONTAL },
	{ "rotation": 0, "flip": FLIP_VERTICAL },
	{ "rotation": 0, "flip": FLIP_VERTICAL },
	{ "rotation": 0, "flip": FLIP_HORIZONTAL },
	{ "rotation": 0, "flip": FLIP_HORIZONTAL },
	{ "rotation": 0, "flip": FLIP_HORIZONTAL },
	{ "rotation": 0, "flip": FLIP_HORIZONTAL },
	{ "rotation": 0, "flip": FLIP_HORIZONTAL }
]

var level_2_option_transformations = [
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": -22.5, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": -22.5, "flip": FLIP_NONE },
	{ "rotation": 22.5, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": -15, "flip": FLIP_NONE },
	{ "rotation": 180, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": 22.5, "flip": FLIP_NONE },
	{ "rotation": 22.5, "flip": FLIP_NONE }
]

var level_2_hard_option_transformations = [
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": -90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": 0, "flip": FLIP_VERTICAL },
	{ "rotation": 0, "flip": FLIP_VERTICAL },
	{ "rotation": 0, "flip": FLIP_VERTICAL },
	{ "rotation": 0, "flip": FLIP_VERTICAL },
	{ "rotation": 0, "flip": FLIP_VERTICAL },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 0, "flip": FLIP_HORIZONTAL },
	{ "rotation": -90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 180, "flip": FLIP_NONE },
	{ "rotation": 180, "flip": FLIP_NONE },
	{ "rotation": 180, "flip": FLIP_NONE },
	{ "rotation": 0, "flip": FLIP_VERTICAL },
	{ "rotation": -20, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": 0, "flip": FLIP_HORIZONTAL },
	{ "rotation": -90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": -90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": -90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": 45, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": -45, "flip": FLIP_NONE },
	{ "rotation": 20, "flip": FLIP_NONE },
	{ "rotation": 52, "flip": FLIP_NONE },
	{ "rotation": 0, "flip": FLIP_NONE },
	{ "rotation": 20, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": -90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": -90, "flip": FLIP_NONE },
	{ "rotation": -90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
	{ "rotation": -90, "flip": FLIP_NONE },
	{ "rotation": 90, "flip": FLIP_NONE },
]

export(Array) var level_option_transformations = [
	{ "normal": level_1_option_transformations, "hard": level_1_hard_option_transformations }, # level 1
	{ "normal": level_2_option_transformations, "hard": level_2_hard_option_transformations } # level 2
]

export(Array) var num_hard_questions_per_level = [
	{ "required": 4, "available": 13 }, # level 1
	{ "required": 4, "available": 53 } # level 2
]

export var questions_per_level = 10

export(Array) var questions_available_per_level = [
	30, # level 1
	19 # level 2
]

export var max_levels = 2
