extends Area2D

class_name Option

var option_file_text = "option_"

onready var animation_player = get_parent().get_parent()
onready var question = animation_player.get_parent()

func pressed():
	var is_correct = is_correct_answer()
	
	if is_correct:
		animation_player.play("Correct")
		yield(animation_player, "stop_waiting")
		question.next_question()
	else:
		animation_player.play("Incorrect")
		yield(animation_player, "stop_waiting")
		print('incorrect')

func is_correct_answer():
	var option_sprite = self.get_child(0)
	var option_shape = option_sprite.get_texture()
	var option_shape_path = option_shape.get_load_path()
	
	var option_index = option_shape_path.find(option_file_text)
	var opt_no_index = option_index + len(option_file_text)
	var opt_no = int(option_shape_path.substr(opt_no_index, 1))
	
	return opt_no == 1

func _input_event(_viewport, event, _shape_idx):
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		pressed()
