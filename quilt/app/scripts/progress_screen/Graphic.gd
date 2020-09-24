extends Node2D

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

onready var quilt = get_node("Quilt")

func _ready():
	var current_level = global.current_level - 1
	var path = "res://assets/screens/progress/quilt/level_%d.png" % current_level
	
	if (global.current_level >= constants.max_levels && global.current_question >= constants.questions_per_level):
		path = "res://assets/screens/progress/quilt/level_%d.png" % constants.max_levels
	
	var quilt_texture = load(path)
	quilt.texture = quilt_texture
