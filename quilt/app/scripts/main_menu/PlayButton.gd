extends Button

class_name PlayButton

var play_button_path = "res://assets/sprites/buttons/play_button"
var normal_texture_path = "%s/normal/play_button.png" % play_button_path
var pressed_texture_path = "%s/pressed/play_button_pressed.png" % play_button_path

onready var normal_texture = load(normal_texture_path)
onready var pressed_texture = load(pressed_texture_path)

const GeneralUtils = preload("../utilities/general.gd")
var general_utils = GeneralUtils.new()

var next_scene = "res://Character Menu.tscn"

func _ready():
	set_button_icon(normal_texture)

func _on_Play_Button_button_down():
	set_button_icon(pressed_texture)

func _on_Play_Button_button_up():
	set_button_icon(normal_texture)
	general_utils.go_to_scene(next_scene, self)
