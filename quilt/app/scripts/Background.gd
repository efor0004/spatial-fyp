extends Sprite

class_name ForestBackground

var background_path = "res://assets/screens/forest/forest.png"

func _ready():
	self.z_index = -100
	self.position = global.window_center
	
	var background_texture = load(background_path)
	self.texture = background_texture
