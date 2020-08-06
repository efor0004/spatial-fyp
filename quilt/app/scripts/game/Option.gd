extends Area2D

class_name Option

var option_file_text = "option_"

onready var animation_player = get_parent().get_parent()
onready var question = animation_player.get_parent()
onready var all_animation_players = get_all_animation_players()

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

func pressed():
	var option_transformations = get_option_transformations()
	var option_rotation = option_transformations["rotation"]
	var option_flip = option_transformations["flip"]
	
	var is_correct = is_correct_answer()
	
	if is_correct:
		if (option_rotation != 0):
			add_option_rotation_animation(option_rotation)
		
		if (option_flip != constants.FLIP_NONE):
			add_option_flip_animation(option_flip)
		
		animation_player.play("Correct")
		yield(animation_player, "animation_finished")
		question.next_question()
		yield(question, "piece_added")
		reset_transformation()
	else:
		animation_player.play("Incorrect")
		yield(animation_player, "animation_finished")

func add_option_flip_animation(option_flip):
	var animation_name = "scale"
	var animation_start_value = Vector2(1, 1)
	var animation_end_value = Vector2(1, 1)
	if (option_flip == constants.FLIP_VERTICAL):
		animation_end_value = Vector2(1, -1)
	elif (option_flip == constants.FLIP_HORIZONTAL):
		animation_end_value = Vector2(-1, 1)
	
	add_option_animation(animation_name, animation_start_value, animation_end_value)

func add_option_rotation_animation(option_rotation):
	var animation_name = "rotation_degrees"
	var animation_start_value = 0
	var animation_end_value = option_rotation
	
	add_option_animation(animation_name, animation_start_value, animation_end_value)

func add_option_animation(animation_name, animation_start_value, animation_end_value):
	var correct_animation = get_correct_animation()
	var num_tracks = correct_animation.get_track_count()
	var new_track_num = num_tracks
	
	correct_animation.add_track(Animation.TYPE_VALUE, new_track_num)
	var path = self.get_path()
	
	var rotation_path = "%s:%s" % [path, animation_name]
	
	var animation_duration = get_translation_duration(correct_animation)
	
	correct_animation.track_set_path(new_track_num, rotation_path)
	correct_animation.track_insert_key(new_track_num, 0, animation_start_value)
	correct_animation.track_insert_key(new_track_num, animation_duration, animation_end_value)

func reset_transformation():
	self.rotation_degrees = 0
	self.scale = Vector2(1, 1)
	
	var correct_animation = get_correct_animation()
	var num_tracks = correct_animation.get_track_count()
	
	while (num_tracks > 4):
		var track_index = num_tracks - 1
		correct_animation.remove_track(track_index)
		num_tracks = correct_animation.get_track_count()

func get_correct_animation():
	var correct_animation = animation_player.get_animation("Correct")
	return correct_animation

func get_translation_duration(animation):
	var duration = animation.track_get_key_time(0, 1)
	return duration

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

func get_option_transformations():
	var current_level_index = global.current_level - 1
	var current_question_index = global.current_shuffled_question - 1
	var current_level_difficulty = global.current_level_difficulty
	
	var level_transformations = constants.level_option_transformations[current_level_index][current_level_difficulty]
	
	if (typeof(level_transformations) == TYPE_ARRAY):
		level_transformations = level_transformations[current_question_index]
	
	return level_transformations

func transform_fabric(fabric_rotation, fabric_flip):
	var fabric = get_node("Fabric Texture")
	fabric.rotation_degrees = -fabric_rotation
	if (fabric_flip == constants.FLIP_VERTICAL):
		fabric.flip_v = true
		fabric.flip_h = false
	elif (fabric_flip == constants.FLIP_HORIZONTAL):
		fabric.flip_h = true
		fabric.flip_v = false
	else:
		fabric.flip_h = false
		fabric.flip_v = false

func set_initial_transformations():
	if (is_correct_answer()):
		var option_transformations = get_option_transformations()
		var option_rotation = option_transformations["rotation"]
		var option_flip = option_transformations["flip"]
		print("transforming fabric")
		print(option_rotation, option_flip)
		transform_fabric(option_rotation, option_flip)
	else:
		transform_fabric(0, constants.FLIP_NONE)

func _on_Question_set_next_question():
	set_initial_transformations()

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
