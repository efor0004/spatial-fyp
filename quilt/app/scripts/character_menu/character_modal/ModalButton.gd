extends Button

class_name ModalButton

const GeneralUtils = preload("../../utilities/general.gd")
var general_utils = GeneralUtils.new()

func _init(parent_width, parent_height, scale):
	var button_size = Vector2(150, 50)
	self.text = "Begin as character %d" % global.character_index
	self.rect_size = button_size
	self.rect_scale = Vector2(scale, scale)
	button_size = button_size * scale
	self.rect_position = Vector2(parent_width / 2 - button_size.x / 2, parent_height / 2 - button_size.y / 2)

func _pressed():
	general_utils.go_to_scene("res://Format Menu.tscn", self)