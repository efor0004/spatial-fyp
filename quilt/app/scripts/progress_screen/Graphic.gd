extends Node2D

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

onready var quilt = get_node("Quilt")
onready var character = get_node("Character")

func _ready():
	var current_level = global.current_level - 1
	var quilt_path = "res://assets/screens/progress/quilt/level_%d.png" % current_level
	var character_path = "res://assets/screens/progress/characters/%d.png" % global.character_index
	
	if (global.current_level >= constants.max_levels && global.current_question >= constants.questions_per_level):
		quilt_path = "res://assets/screens/progress/quilt/level_%d.png" % constants.max_levels
	
	var quilt_texture = load(quilt_path)
	quilt.texture = quilt_texture
	
	var character_texture = load(character_path)
	character.texture = character_texture
