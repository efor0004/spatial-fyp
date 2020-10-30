extends Node2D

const SaveUtils = preload("res://scripts/utilities/save.gd")
var save_utils = SaveUtils.new()

const GeneralUtils = preload("res://scripts/utilities/general.gd")
var general_utils = GeneralUtils.new()

var delete_button_path = "res://assets/sprites/modals/buttons/delete_button/delete_button.png"
var delete_button_pressed_path = "res://assets/sprites/modals/buttons/delete_button/delete_button_pressed.png"
var delete_modal_text = """[center]Are you sure you want to delete
all saved progress?[/center]"""

var bold_font = load("res://assets/fonts/gotham_bold.tres")
var delete_font = bold_font

var delete_modal

func _ready():
	delete_modal = ConfirmModal.new(delete_button_path, delete_button_pressed_path, delete_modal_text)
	delete_font.size = 36
	delete_modal.text_font = delete_font
	delete_modal.connect("ok", self, "clear_data")
	add_child(delete_modal)
	
	var character_modal = ConfirmModal.new("", "", "Play as animal", false)
	bold_font.size = 48
	character_modal.text_font = bold_font
	character_modal.connect("ok", self, "play_as_character")
	add_child(character_modal)

func clear_data():
	save_utils.clear_all_data()
	delete_modal.toggle_modal()

func play_as_character():
	general_utils.go_to_scene("res://Format Menu.tscn", self)
