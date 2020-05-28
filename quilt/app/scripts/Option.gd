extends Area2D

class_name Option

var option_file_text = "option_"

onready var animation_player = get_parent().get_parent()
onready var question = animation_player.get_parent()
onready var all_animation_players = get_all_animation_players()

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
	var option_sprite = self.get_node("Light2D")
	var option_shape = option_sprite.get_texture()
	var option_shape_path = option_shape.get_load_path()
	
	var option_index = option_shape_path.find(option_file_text)
	var opt_no_index = option_index + len(option_file_text)
	var opt_no = int(option_shape_path.substr(opt_no_index, 1))
	
	return opt_no == 1

func _input_event(_viewport, event, _shape_idx):
	if is_animation_happening():
		return
	
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		pressed()

func is_animation_happening():
	var is_animating = false
	
	for anim in all_animation_players:
		if anim.is_playing():
			is_animating = true
			break
	
	return is_animating

func get_all_animation_players():
	var all_animation_players = []
	
	for node in question.get_children():
		if node is AnimationPlayerWait:
			all_animation_players.append(node)
	
	return all_animation_players
