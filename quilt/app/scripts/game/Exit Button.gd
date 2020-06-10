extends Button

var exit_button_path = "res://assets/sprites/buttons/exit_button"
var normal_texture_path = "%s/normal/exit_button.png" % exit_button_path
var pressed_texture_path = "%s/pressed/exit_button_pressed.png" % exit_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

func _ready():
	set_button_icon(normal_texture)

func _on_Exit_Button_button_down():
	set_button_icon(pressed_texture)

func _on_Exit_Button_button_up():
	set_button_icon(normal_texture)
	get_tree().change_scene("res://Main Menu.tscn")
