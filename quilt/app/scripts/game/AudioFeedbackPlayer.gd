extends AudioStreamPlayer

class_name AudioFeedbackPlayer

var correct_clip = "res://assets/audio/game/correct.wav"

var incorrect_clips = [
	"res://assets/audio/game/incorrect_0.wav",
	"res://assets/audio/game/incorrect_1.wav",
	"res://assets/audio/game/incorrect_2.wav",
	"res://assets/audio/game/incorrect_3.wav"
]

onready var question = get_parent()

func play_audio_feedback(index):
	var is_correct = is_correct_answer(index)
	
	if (is_correct):
		stream = load(correct_clip)
	else:
		var option_index = get_option_index(index)
		stream = load(incorrect_clips[option_index])
	
	play()

func is_correct_answer(index):
	var option_index = get_option_index(index)
	
	return option_index == 1

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
