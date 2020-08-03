extends Modal

class_name CharacterModal

func _init():
	var button = ModalButton.new(width, height, 3)
	add_child(button)
