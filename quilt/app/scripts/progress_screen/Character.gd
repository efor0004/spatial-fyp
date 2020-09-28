extends Sprite

func _ready():
	var path = "res://assets/screens/progress/"
	var character_texture = load(path)
	self.texture = character_texture 
