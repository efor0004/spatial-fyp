extends Button

var continue_button_path = "res://assets/sprites/buttons/continue_button"
var normal_texture_path = "%s/normal/continue_button.png" % continue_button_path
var pressed_texture_path = "%s/pressed/continue_button_pressed.png" % continue_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

onready var is_last_level = false

const Constants = preload("../utilities/constants.gd")

func _ready():
	var constants = Constants.new()
	if (global.current_level >= constants.max_levels && global.current_question >= constants.questions_per_level):
		is_last_level = true
		self.visible = false
	else:
		self.visible = true
		set_button_icon(normal_texture)

func _on_Continue_Button_button_down():
	if (not is_last_level):
		set_button_icon(pressed_texture)

func _on_Continue_Button_button_up():
	if (not is_last_level):
		set_button_icon(normal_texture)
		get_tree().change_scene("res://Game.tscn")
