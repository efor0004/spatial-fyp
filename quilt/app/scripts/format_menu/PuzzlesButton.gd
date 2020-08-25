extends Button

var puzzles_button_path = "res://assets/sprites/buttons/puzzles_button"
var normal_texture_path = "%s/normal/puzzles_button.png" % puzzles_button_path
var pressed_texture_path = "%s/pressed/puzzles_button_pressed.png" % puzzles_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

func _ready():
	set_button_icon(normal_texture)

func _on_Puzzles_Button_button_down():
	set_button_icon(pressed_texture)

func _on_Puzzles_Button_button_up():
	set_button_icon(normal_texture)
	get_tree().change_scene("res://Game.tscn")
