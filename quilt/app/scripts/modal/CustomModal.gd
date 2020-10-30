extends Node2D

class_name CustomModal

var show_open_button

var open_button_path
var open_button_pressed_path
var open_button_position

var content
var text
var text_font = load("res://assets/fonts/gotham_light.tres")
var popup

func _init(button_path_to_set="", pressed_button_path_to_set="", show_open_button=true, open_button_position=Vector2(1958, 10)):
	self.show_open_button = show_open_button
	if (show_open_button):
		self.open_button_position = open_button_position
		open_button_path = button_path_to_set
		open_button_pressed_path = pressed_button_path_to_set

func _ready():
	if (show_open_button):
		var open_button = get_open_button()
		add_child(open_button)
	
	popup = get_popup()
	add_child(popup)

func toggle_modal():
	if (popup.is_visible()):
		popup.hide()
	else:
		set_text()
		popup.popup_centered()

func get_popup():
	var popup = Popup.new()
	
	popup.popup_exclusive = true
	popup.rect_size = global.window_size
	
	var content = get_content()
	popup.add_child(content)
	
	add_buttons()
	
	return popup

func add_buttons():
	pass

func get_content():
	content = Sprite.new()
	content.texture = load("res://assets/sprites/modals/modal.png")
	content.position = global.window_center
	
	text = get_text()
	content.add_child(text)
	
	var close_button = get_close_button()
	content.add_child(close_button)
	
	return content

func get_text():
	var text = RichTextLabel.new()
	text.bbcode_enabled = true
	text.bbcode_text = get_text_content()
	text.rect_size = Vector2(1000, 500)
	text.rect_position = Vector2(-text.rect_size.x / 2, -text.rect_size.y / 2)
	text.rect_clip_content = true
	
	text.set("custom_fonts/normal_font", text_font)
	return text

func set_text():
	text.set("custom_fonts/normal_font", text_font)
	text.bbcode_text = get_text_content()

func get_text_content():
	return 'This is a modal'

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
	button.rect_position = open_button_position
	button.connect("generic_button_down", self, "on_open_button_down")
	button.connect("generic_button_up", self, "on_open_button_up")
	
	return button

func on_open_button_down(button):
	var button_texture = load(open_button_pressed_path)
	button.icon = button_texture

func on_open_button_up(button):
	var button_texture = load(open_button_path)
	button.icon = button_texture
	toggle_modal()
