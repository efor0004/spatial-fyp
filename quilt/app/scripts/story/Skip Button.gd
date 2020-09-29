extends Button

var skip_button_path = "res://assets/sprites/buttons/skip_button"
var normal_texture_path = "%s/normal/skip_button.png" % skip_button_path
var pressed_texture_path = "%s/pressed/skip_button_pressed.png" % skip_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

func _ready():
	set_button_icon(normal_texture)

func _on_Skip_Button_button_down():
	set_button_icon(pressed_texture)

func _on_Skip_Button_button_up():
	set_button_icon(normal_texture)
	get_tree().change_scene("res://Game.tscn")
