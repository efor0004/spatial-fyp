extends Node2D

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

const GeneralUtils = preload("../utilities/general.gd")
var general_utils = GeneralUtils.new()

const SaveUtils = preload("../utilities/save.gd")
var save_utils = SaveUtils.new()

onready var quilt = get_node("Quilt")
onready var character = get_node("Character")
onready var finished_text = get_node("FinishedText")

var delete_button_path = "res://assets/sprites/modals/buttons/delete_button/delete_button.png"
var delete_button_pressed_path = "res://assets/sprites/modals/buttons/delete_button/delete_button_pressed.png"
var bold_font = load("res://assets/fonts/gotham_bold.tres")

var delete_modal

func _ready():
	var current_level = global.current_level - 1
	var quilt_path = "res://assets/screens/progress/quilt/level_%d.png" % current_level
	var character_path = "res://assets/screens/progress/characters/%d.png" % global.character_index
	
	if (global.current_level >= constants.max_levels && global.current_question >= constants.questions_per_level):
		quilt_path = "res://assets/screens/progress/quilt/level_%d.png" % constants.max_levels
		finished_text.visible = true
	else:
		finished_text.visible = false
	
	var quilt_texture = load(quilt_path)
	quilt.texture = quilt_texture
	
	var character_texture = load(character_path)
	character.texture = character_texture
	
	var character_name = constants.character_names[global.character_index - 1]
	var delete_modal_text = """[center]Are you sure you want to delete
	all saved progress for
	%s?[/center]""" % character_name
	delete_modal = ConfirmModal.new(delete_button_path, delete_button_pressed_path, delete_modal_text, true, Vector2(987, 1250))
	bold_font.extra_spacing_top = 150
	bold_font.extra_spacing_bottom = -bold_font.extra_spacing_top + 20
	delete_modal.text_font = bold_font
	delete_modal.connect("ok", self, "clear_data")
	add_child(delete_modal)

func clear_data():
	save_utils.clear_character_data(global.character_index)
	general_utils.go_to_scene("res://Format Menu.tscn", self)
