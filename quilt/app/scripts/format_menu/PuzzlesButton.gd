extends Button

var puzzles_button_path = "res://assets/sprites/buttons/puzzles_button"
var normal_texture_path = "%s/normal/puzzles_button.png" % puzzles_button_path
var pressed_texture_path = "%s/pressed/puzzles_button_pressed.png" % puzzles_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

const GeneralUtils = preload("../utilities/general.gd")
var general_utils = GeneralUtils.new()

func _ready():
	set_button_icon(normal_texture)

func _on_Puzzles_Button_button_down():
	set_button_icon(pressed_texture)
	pass

func _on_Puzzles_Button_button_up():
	set_button_icon(normal_texture)
	
	if (global.current_level == 1 and global.current_question == 1):
		# global.next_scene = "res://Story.tscn"
		global.next_scene = "res://Game.tscn"
	else:
		global.next_scene = "res://Game.tscn"
	
	general_utils.go_to_scene("res://Loading Screen.tscn", self)
