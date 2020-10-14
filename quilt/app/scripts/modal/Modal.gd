extends Node2D

class_name CustomModal

var pages = [
	'This is a modal'
]

var open_button_path = ""

var current_page = 0

var content
var text
var popup
var left_button
var right_button

func _init(pages_to_set, button_path_to_set):
	pages = pages_to_set
	open_button_path = button_path_to_set

func _ready():
	var open_button = get_open_button()
	add_child(open_button)
	
	popup = get_popup()
	add_child(popup)

func toggle_modal():
	if (popup.is_visible()):
		popup.hide()
	else:
		popup.popup_centered()

func get_popup():
	var popup = Popup.new()
	
	popup.popup_exclusive = true
	popup.rect_size = global.window_size
	
	var content = get_content()
	popup.add_child(content)
	
	return popup

func get_content():
	content = Sprite.new()
	content.texture = load("res://assets/sprites/modals/modal.png")
	content.position = global.window_center
	
	text = get_text()
	content.add_child(text)
	
	if (pages.size() > 1):
		left_button = get_direction_button("left")
		content.add_child(left_button)
		right_button = get_direction_button("right")
		content.add_child(right_button)
	
	var close_button = get_close_button()
	content.add_child(close_button)
	
	return content

func get_text():
	var text = RichTextLabel.new()
	text.text = pages[0]
	text.rect_size = Vector2(1000, 500)
	text.rect_position = Vector2(-text.rect_size.x / 2, -text.rect_size.y / 2)
	text.rect_clip_content = true
	
	text.set("custom_fonts/normal_font", load("res://assets/fonts/gotham_light.tres"))
	return text

func set_content_for_page():
	text.text = pages[current_page]
	
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
	var button_texture = load("res://assets/sprites/modals/buttons/left_right_button/left_right_button.png")
	
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
	var button_texture = load("res://assets/sprites/modals/buttons/left_right_button/left_right_button_pressed.png")
	button.icon = button_texture

func on_left_right_button_up(button):
	var button_texture = load("res://assets/sprites/modals/buttons/left_right_button/left_right_button.png")
	button.icon = button_texture
	
	if (button.rect_scale.x == -1):
		go_to_page(1)
	else:
		go_to_page(-1)

func go_to_page(dir):
	current_page = current_page + dir
	set_content_for_page()

func get_close_button():
	var button = GenericButton.new()
	var button_texture = load("res://assets/sprites/modals/buttons/close_button/close_button.png")
	
	button.icon = button_texture
	button.rect_position = Vector2(460, -365)
	button.connect("generic_button_down", self, "on_close_button_down")
	button.connect("generic_button_up", self, "on_close_button_up")
	
	return button

func on_close_button_down(button):
	var button_texture = load("res://assets/sprites/modals/buttons/close_button/close_button_pressed.png")
	button.icon = button_texture

func on_close_button_up(button):
	var button_texture = load("res://assets/sprites/modals/buttons/close_button/close_button.png")
	button.icon = button_texture
	toggle_modal()

func get_open_button():
	var button = GenericButton.new()
	var button_texture = load(open_button_path)
	
	button.icon = button_texture
	button.rect_position = Vector2(1958, 10)
	button.connect("generic_button_down", self, "on_open_button_down")
	button.connect("generic_button_up", self, "on_open_button_up")
	
	return button

func on_open_button_down(button):
	var button_texture = load("res://assets/sprites/modals/buttons/open_button/open_button_pressed.png")
	button.icon = button_texture

func on_open_button_up(button):
	var button_texture = load("res://assets/sprites/modals/buttons/open_button/open_button.png")
	button.icon = button_texture
	toggle_modal()
