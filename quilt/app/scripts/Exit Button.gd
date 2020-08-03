extends Button

var position = Vector2(20, 20)
var size = Vector2(732, 246)
var scale = 0.5

var exit_button_path = "res://assets/sprites/buttons/exit_button"
var normal_texture_path = "%s/normal/exit_button.png" % exit_button_path
var pressed_texture_path = "%s/pressed/exit_button_pressed.png" % exit_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

func _ready():
	set_position(position)
	set_size(size)
	set_scale(Vector2(scale, scale))
	set_button_icon(normal_texture)
	set_flat(true)
	set_enabled_focus_mode(FOCUS_NONE)

func _on_Exit_Button_button_down():
	set_button_icon(pressed_texture)

func _on_Exit_Button_button_up():
	set_button_icon(normal_texture)
	var current_scene = get_tree().get_current_scene().get_name()
	
	if (current_scene == "Game"):
		get_tree().change_scene("res://Character Menu.tscn")
	elif (current_scene == "Character Menu"):
		get_tree().change_scene("res://Main Menu.tscn")
