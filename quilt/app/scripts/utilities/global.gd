extends Node

var character_index = 0
var character_name = ''

var current_level = 1
var current_question = 1
var current_shuffled_question = 1
var question_order = []

var questions_per_level = 10
var questions_available_per_level = 20

var max_levels = 2

var window_size = Vector2(ProjectSettings.get_setting("display/window/size/width"), ProjectSettings.get_setting("display/window/size/height"))
var window_center = window_size / 2
