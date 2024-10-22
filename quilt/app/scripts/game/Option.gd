extends Area2D

class_name Option

var option_file_text = "option_"

onready var animation_player = get_parent().get_parent()
onready var question = animation_player.get_parent()
onready var scene = get_tree().current_scene
onready var all_animation_players = get_all_animation_players()

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

func pressed():
	var option_rotation = get_option_rotation()
	
	var is_correct = is_correct_answer()
	
	if is_correct:
		if (option_rotation != 0):
			add_option_rotation_animation()
		
		animation_player.play("Correct")
		yield(animation_player, "animation_finished")
		question.next_question()
		yield(question, "piece_added")
		reset_animations()
	else:
		animation_player.play("Incorrect")
		yield(animation_player, "animation_finished")

func add_option_rotation_animation():
	var animation_name = "rotation_degrees"
	var animation_start_value = self.rotation_degrees
	var animation_end_value = 0
	
	add_option_animation(animation_name, animation_start_value, animation_end_value)

func add_option_animation(animation_name, animation_start_value, animation_end_value):
	var correct_animation = get_correct_animation()
	var num_tracks = correct_animation.get_track_count()
	var new_track_num = num_tracks
	
	correct_animation.add_track(Animation.TYPE_VALUE, new_track_num)
	var path = self.get_path()
	
	var rotation_path = "%s:%s" % [path, animation_name]
	
	var animation_start_time = get_transformation_animation_start_time()
	var animation_end_time = animation_start_time + 1
	
	correct_animation.track_set_path(new_track_num, rotation_path)
	correct_animation.track_insert_key(new_track_num, animation_start_time, animation_start_value)
	correct_animation.track_insert_key(new_track_num, animation_end_time, animation_end_value)

func get_transformation_animation_start_time():
	var child_no = animation_player.get_index()
	
	if (child_no == 1):
		return 1
	elif (child_no == 2):
		return 2
	elif (child_no == 3):
		return 3
	else:
		return 0

func reset_animations():
	var correct_animation = get_correct_animation()
	var num_tracks = correct_animation.get_track_count()
	
	while (num_tracks > 4):
		var track_index = num_tracks - 1
		correct_animation.remove_track(track_index)
		num_tracks = correct_animation.get_track_count()

func get_correct_animation():
	var correct_animation = animation_player.get_animation("Correct")
	return correct_animation

func is_correct_answer():
	var option_index = get_option_index()
	
	return option_index == 1

func get_option_index():
	var option_sprite = self.get_node("Light2D")
	var x_offset = option_sprite.offset.x
	
	if (x_offset == 192):
		return 1
	elif (x_offset == -192):
		return 2
	elif (x_offset == -576):
		return 3
	else:
		return 0

func get_option_rotation():
	var current_level_index = global.current_level - 1
	var current_question_index = global.current_shuffled_question - 1
	var current_level_difficulty = global.current_level_difficulty
	
	var level_rotations = constants.level_option_rotations[current_level_index][current_level_difficulty]
	
	var option_rotation = 0
	
	if (typeof(level_rotations) == TYPE_ARRAY):
		option_rotation = level_rotations[current_question_index]
	else:
		option_rotation = level_rotations
	
	return option_rotation

func transform_option(option_rotation):
	self.rotation_degrees = -option_rotation

func set_initial_transformations():
	if (is_correct_answer()):
		var option_rotation = get_option_rotation()
		transform_option(option_rotation)
	else:
		transform_option(0)

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
	var list = []
	
	for node in question.get_children():
		if node is AnimationPlayer:
			list.append(node)
	
	return list

func _on_Question_ready_for_options():
	set_initial_transformations()
