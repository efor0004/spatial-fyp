extends Node

onready var character_menu = get_parent()
onready var character = get_node("Sprite")

func _ready():
	character.play("idle")

func pressed():
	var character_no = get_index() + 1
	global.character_index = character_no
	
	var popup = CharacterModal.new()
	character_menu.add_child(popup)
	popup.open()

func _input_event(_viewport, event, _shape_idx):
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		pressed()
