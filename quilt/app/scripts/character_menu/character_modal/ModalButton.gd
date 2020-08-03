extends Button

class_name ModalButton

func _init(parent_width, parent_height, scale):
	var button_size = Vector2(150, 50)
	self.text = "Begin as character %d" % global.character_index
	self.rect_size = button_size
	self.rect_scale = Vector2(scale, scale)
	button_size = button_size * scale
	self.rect_position = Vector2(parent_width / 2 - button_size.x / 2, parent_height / 2 - button_size.y / 2)

func _pressed():
	get_tree().change_scene("res://Game.tscn")
