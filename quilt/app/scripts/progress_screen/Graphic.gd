extends Sprite

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

func _ready():
	var current_level = global.current_level - 1
	var path = "res://assets/screens/progress/level_%d.png" % current_level
	
	if (global.current_level >= constants.max_levels && global.current_question >= constants.questions_per_level):
		path = "res://assets/screens/progress/all_levels.png"
	
	var graphic_texture = load(path)
	self.texture = graphic_texture
