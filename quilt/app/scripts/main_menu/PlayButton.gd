extends Button

var play_button_path = "res://assets/sprites/buttons/play_button"
var normal_texture_path = "%s/normal/play_button.png" % play_button_path
var pressed_texture_path = "%s/pressed/play_button_pressed.png" % play_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

func _ready():
	set_button_icon(normal_texture)

func _on_Play_Button_button_down():
	set_button_icon(pressed_texture)

func _on_Play_Button_button_up():
	set_button_icon(normal_texture)
	global.player_name = "Test"
	get_tree().change_scene("res://Game.tscn")
