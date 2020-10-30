extends Node

onready var character_menu = get_parent()
onready var character = get_node("Sprite")

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

func _ready():
	character.play("idle")

func pressed():
	var character_no = get_index() + 1
	global.character_index = character_no
	var character_name = constants.character_names[global.character_index - 1]
	
	var character_modal = character_menu.get_child(character_menu.get_child_count() - 1)
	character_modal.modal_text = "[center]Play as %s[/center]" % character_name
	character_modal.toggle_modal()

func _input_event(_viewport, event, _shape_idx):
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		pressed()
