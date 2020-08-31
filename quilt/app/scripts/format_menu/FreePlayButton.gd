extends Button

var free_play_button_path = "res://assets/sprites/buttons/free_play_button"
var normal_texture_path = "%s/normal/free_play_button.png" % free_play_button_path
var pressed_texture_path = "%s/pressed/free_play_button_pressed.png" % free_play_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

func _ready():
	set_button_icon(normal_texture)

func _on_Free_Play_Button_button_down():
	set_button_icon(pressed_texture)

func _on_Free_Play_Button_button_up():
	set_button_icon(normal_texture)
	get_tree().change_scene("res://Free Play.tscn")
