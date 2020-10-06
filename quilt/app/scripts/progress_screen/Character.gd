extends Sprite

func _ready():
	var path = "res://assets/screens/progress/characters/%d.png" % global.character_index
	var character_texture = load(path)
	self.texture = character_texture 
