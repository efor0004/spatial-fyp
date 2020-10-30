extends CustomModal

class_name ConfirmModal

var ok_button_path = "res://assets/sprites/modals/buttons/ok_button/ok_button.png"
var ok_button_pressed_path = "res://assets/sprites/modals/buttons/ok_button/ok_button_pressed.png"

signal ok

var modal_text

func _init(button_to_set, pressed_button_to_set, text_to_set, show_open_button=true, open_button_position=Vector2(1958, 10)).(button_to_set, pressed_button_to_set, show_open_button, open_button_position):
	modal_text = text_to_set

func add_buttons():
	var ok_button = get_ok_button()
	self.content.add_child(ok_button)

func get_text_content():
	return modal_text

func get_ok_button():
	var button = GenericButton.new()
	var button_texture = load(ok_button_path)
	button.icon = button_texture
	
	button.rect_position = Vector2(-107.5, 225)
	
	button.connect("generic_button_down", self, "on_ok_button_down")
	button.connect("generic_button_up", self, "on_ok_button_up")
	
	return button

func on_ok_button_down(button):
	var button_texture = load(ok_button_pressed_path)
	button.icon = button_texture

func on_ok_button_up(button):
	var button_texture = load(ok_button_path)
	button.icon = button_texture
	self.emit_signal("ok")
