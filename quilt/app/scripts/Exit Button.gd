extends Button

class_name ExitButton

var position = Vector2(20, 20)
var size = Vector2(360, 120)

var exit_button_path = "res://assets/sprites/buttons/exit_button"
var normal_texture_path = "%s/normal/exit_button.png" % exit_button_path
var pressed_texture_path = "%s/pressed/exit_button_pressed.png" % exit_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

const GeneralUtils = preload("utilities/general.gd")
var general_utils = GeneralUtils.new()

func _ready():
	set_position(position)
	set_size(size)
	set_button_icon(normal_texture)
	set_flat(true)
	set_enabled_focus_mode(FOCUS_NONE)

func _on_Exit_Button_button_down():
	set_button_icon(pressed_texture)

func _on_Exit_Button_button_up():
	set_button_icon(normal_texture)
	var current_scene = get_tree().get_current_scene().get_name()
	
	if (current_scene == "Game"):
		general_utils.go_to_scene("res://Format Menu.tscn", self)
	elif (current_scene == "Character Menu"):
		general_utils.go_to_scene("res://Main Menu.tscn", self)
	elif (current_scene == "Progress Screen"):
		general_utils.go_to_scene("res://Character Menu.tscn", self)
	elif (current_scene == "Format Menu"):
		general_utils.go_to_scene("res://Character Menu.tscn", self)
	elif (current_scene == "Free Play"):
		general_utils.go_to_scene("res://Format Menu.tscn", self)
	elif (current_scene == "Story"):
		general_utils.go_to_scene("res://Format Menu.tscn", self)
	else:
		general_utils.go_to_scene("res://Main Menu.tscn", self)
