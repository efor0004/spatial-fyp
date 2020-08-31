extends Button

var back_button_path = "res://assets/sprites/buttons/back_button"
var normal_texture_path = "%s/normal/back_button.png" % back_button_path
var pressed_texture_path = "%s/pressed/back_button_pressed.png" % back_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

onready var palette = get_parent()

func _ready():
	set_button_icon(normal_texture)

func _on_Back_Button_button_down():
	set_button_icon(pressed_texture)

func _on_Back_Button_button_up():
	set_button_icon(normal_texture)
	palette.back()
