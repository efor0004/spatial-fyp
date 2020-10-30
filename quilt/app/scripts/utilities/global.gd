extends Node

var character_index = 0

var current_level = 1
var current_question = 1
var current_shuffled_question = 1
var question_order = []
var current_level_difficulty = "normal"

var window_size = Vector2(ProjectSettings.get_setting("display/window/size/width"), ProjectSettings.get_setting("display/window/size/height"))
var window_center = window_size / 2

var next_scene = "res://Main Menu.tscn"
