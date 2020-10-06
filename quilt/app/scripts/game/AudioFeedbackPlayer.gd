extends AudioStreamPlayer

class_name AudioFeedbackPlayer

var correct_clip = "res://assets/audio/game/correct.wav"

var incorrect_clips = [
	"res://assets/audio/game/incorrect_0.wav",
	"res://assets/audio/game/incorrect_1.wav",
	"res://assets/audio/game/incorrect_2.wav",
	"res://assets/audio/game/incorrect_3.wav"
]

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

onready var question = get_parent()

func play_audio_feedback(is_correct, index):
	if (is_correct):
		stream = load(correct_clip)
	else:
		var incorrect_reason = get_incorrect_reason(index)
		stream = load(incorrect_clips[incorrect_reason])
	
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
