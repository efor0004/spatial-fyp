extends AudioStreamPlayer

class_name AudioFeedbackPlayer

var correct_clip_path = "res://assets/audio/game/correct"

var incorrect_clip_path = "res://assets/audio/game/incorrect"

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

onready var question = get_parent()

func play_audio_feedback(is_correct, index):
	if (is_correct):
		randomize()
		var i = randi() % 10 + 1
		var path = "%s/%d.wav" % [correct_clip_path, i]
		stream = load(path)
	else:
		var incorrect_reason_index = get_incorrect_reason(index)
		var path = "%s/%d.wav" % [incorrect_clip_path, incorrect_reason_index]
		stream = load(path)
	
	play()

func get_option_index(animation_player_index):
	var light2D = question.get_node("AnimationPlayer%d/Layer/Option/Light2D" % animation_player_index)
	var x_offset = light2D.offset.x
	
	if (x_offset == 192):
		return 1
	elif (x_offset == -192):
		return 2
	elif (x_offset == -576):
		return 3
	else:
		return 0

func get_incorrect_reason(animation_player_index):
	var current_level_index = global.current_level - 1
	var current_question_index = global.current_shuffled_question - 1
	var current_level_difficulty = global.current_level_difficulty
	
	var level_incorrect_reasons = constants.level_incorrect_reasons[current_level_index][current_level_difficulty]
	var option_index = get_option_index(animation_player_index)
	
	var incorrect_reason = level_incorrect_reasons[current_question_index][option_index - 2]
	
	return incorrect_reason
