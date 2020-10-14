extends Sprite

class_name Divider

func _input(event):
	if self.visible \
	and event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT:
		get_tree().set_input_as_handled()
