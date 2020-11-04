extends CustomModal

class_name PaginationModal

var pages = [
	'This is a modal'
]

var left_right_button_path = "res://assets/sprites/modals/buttons/left_right_button/left_right_button.png"
var left_right_button_pressed_path = "res://assets/sprites/modals/buttons/left_right_button/left_right_button_pressed.png"

var current_page = 0

var left_button
var right_button

func _init(pages_to_set, button_path_to_set, pressed_button_path_to_set).(button_path_to_set, pressed_button_path_to_set):
	pages = pages_to_set

func add_buttons():
	if (pages.size() > 1):
		left_button = get_direction_button("left")
		self.content.add_child(left_button)
		right_button = get_direction_button("right")
		self.content.add_child(right_button)

func get_text_content():
	return pages[current_page]

func set_content_for_page():
	self.text.bbcode_text = pages[current_page]
	
	if (current_page == 0):
		left_button.visible = false
		right_button.visible = true
	elif (current_page == pages.size() - 1):
		left_button.visible = true
		right_button.visible = false
	else:
		left_button.visible = true
		right_button.visible = true

func get_direction_button(direction):
	var button = GenericButton.new()
	var button_texture = load(left_right_button_path)
	
	button.icon = button_texture
	
	if (direction == "right"):
		button.rect_scale = Vector2(-1, 1)
		button.rect_position = Vector2(560, 265)
	else:
		button.visible = false
		button.rect_position = Vector2(-575, 265)
	
	button.connect("generic_button_down", self, "on_left_right_button_down")
	button.connect("generic_button_up", self, "on_left_right_button_up")
	
	return button

func on_left_right_button_down(button):
	var button_texture = load(left_right_button_pressed_path)
	button.icon = button_texture

func on_left_right_button_up(button):
	var button_texture = load(left_right_button_path)
	button.icon = button_texture
	
	if (button.rect_scale.x == -1):
		go_to_page(1)
	else:
		go_to_page(-1)

func go_to_page(dir):
	current_page = current_page + dir
	set_content_for_page()
