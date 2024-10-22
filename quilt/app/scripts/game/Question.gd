extends Sprite

onready var current_fabric = get_current_fabric()

var quilt_size = 384
var texture_width = 4 * quilt_size
var initial_texture_y = 0
var initial_quilt_texture_offset = Vector2(0, 0)
var initial_options_texture_offset = [Vector2(0, 0), Vector2(0, 0), Vector2(0, 0)]
var x_regions = [quilt_size, quilt_size * 2, quilt_size * 3]

var option_positions = [Vector2(821, 768), Vector2(1256, 768), Vector2(1721, 768)]

var animation_wait_times = {
	"Correct": [5, 6, 8],
	"Incorrect": [4.5, 5.5, 6.5]
}

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

const GeneralUtils = preload("../utilities/general.gd")
var general_utils = GeneralUtils.new()

const SaveUtils = preload("../utilities/save.gd")
var save_utils = SaveUtils.new()

onready var game_scene = get_parent()
onready var progress_quilt = game_scene.get_node("Progress Quilt")
onready var character = game_scene.get_node("Character")
onready var audio_player = get_node("AudioFeedbackPlayer")

var timer

signal piece_added
signal ready_for_options

func _ready():
	if (global.current_level >= constants.max_levels && global.current_question >= constants.questions_per_level):
		general_utils.go_to_scene("res://Progress Screen.tscn", self)
	
	set_textures_for_question()
	set_shapes()
	set_question_fabric()
	save_utils.save_progress()
	progress_quilt.add_all_pieces_for_state()
	emit_signal("ready_for_options")

func next_question():
	add_quilt_piece()
	yield(self, "piece_added")
	
	reset_option_positions()
	
	global.current_question += 1
	
	var level_hard_questions_info = constants.num_hard_questions_per_level[global.current_level - 1]
	var num_normal_questions_for_level = constants.questions_per_level - level_hard_questions_info["required"]
	
	if (global.current_question > constants.questions_per_level):
		if (global.current_level < constants.max_levels):
			global.current_level += 1
			global.current_question = 1
			global.current_level_difficulty = "normal"
		else:
			global.current_question = constants.questions_per_level
			
		global.question_order = general_utils.shuffle_question_order(global.current_level)
		global.current_shuffled_question = global.question_order[global.current_question - 1]
		save_utils.save_progress()
		
		general_utils.go_to_scene("res://Progress Screen.tscn", self)
		return
	
	if (global.current_level_difficulty == "normal" && global.current_question > num_normal_questions_for_level):
		global.current_level_difficulty = "hard"
	
	global.current_shuffled_question = global.question_order[global.current_question - 1]
	
	set_textures_for_question()
	set_shapes()
	set_question_fabric()
	save_utils.save_progress()
	emit_signal("ready_for_options")

func set_textures_for_question():
	set_texture_offsets()
	
	var path = get_question_path()
	var question_texture = load(path)
	
	var holey_quilt = get_holey_quilt_shape()
	holey_quilt.set_texture(question_texture)
	
	for i in range(1,4):
		var option_shape = get_option_shape(i)
		option_shape.set_texture(question_texture)
		
		var option_border = get_option_border(i)
		option_border.visible = true
		option_border.set_texture(question_texture)

func set_texture_offsets():
	var texture_height = get_texture_height()
	
	initial_texture_y = (texture_height - quilt_size) / 2
	initial_quilt_texture_offset = Vector2(576, initial_texture_y)
	initial_options_texture_offset = [Vector2(192, initial_texture_y), Vector2(-192, initial_texture_y), Vector2(-576, initial_texture_y)]

func get_texture_height():
	var questions_available_for_level = constants.questions_available_per_level[global.current_level - 1]
	
	if (global.current_level_difficulty == "hard"):
		questions_available_for_level = constants.num_hard_questions_per_level[global.current_level - 1]["available"]
	
	var file_index = get_file_index_for_question()
	var max_file_index = (questions_available_for_level - (questions_available_for_level % constants.max_questions_per_file)) / constants.max_questions_per_file
	
	var texture_height = 0
	
	if (file_index >= max_file_index):
		var no_questions_in_last_file = questions_available_for_level % constants.max_questions_per_file
		
		if (no_questions_in_last_file <= 0):
			no_questions_in_last_file = constants.max_questions_per_file
		
		texture_height = no_questions_in_last_file * quilt_size
	else:
		texture_height = constants.max_questions_per_file * quilt_size
	
	return texture_height

func set_shapes():
	set_holey_quilt_shape()
	set_options_shapes()

func get_question_path():
	var file_index = get_file_index_for_question()
	
	return "res://assets/sprites/questions/level_%d/%s/pngs/%d.png" % [global.current_level, global.current_level_difficulty, file_index]

func get_file_index_for_question():
	var division = float(global.current_shuffled_question) / float(constants.max_questions_per_file)
	var file_index = ceil(division) - 1
	
	if (file_index < 0):
		file_index = 0
	
	return file_index

func get_holey_quilt():
	var holey_quilt = get_node("Layer/HoleyQuilt")
	return holey_quilt

func get_holey_quilt_fabric():
	var holey_quilt_fabric = get_node("Layer/HoleyQuilt/Fabric Texture")
	return holey_quilt_fabric

func get_holey_quilt_shape():
	var holey_quilt_shape = get_node("Layer/HoleyQuilt/Light2D")
	return holey_quilt_shape

func get_new_y_offset(y_offset):
	var question_index = get_question_index()
	
	var new_y_offset = y_offset - (question_index * quilt_size)
	return new_y_offset

func get_new_y_region():
	var question_index = get_question_index()
	
	var new_y_region = question_index * quilt_size
	return new_y_region

func get_question_index():
	var question_index = fmod(global.current_shuffled_question, constants.max_questions_per_file)
	
	if (question_index == 0):
		question_index = constants.max_questions_per_file - 1
	else:
		question_index = question_index - 1
	
	return question_index

func set_holey_quilt_shape():
	var holey_quilt_shape = get_holey_quilt_shape()
	
	var x_offset = initial_quilt_texture_offset.x
	var y_offset = initial_quilt_texture_offset.y
	
	var new_y_offset = get_new_y_offset(y_offset)
	
	holey_quilt_shape.offset = Vector2(x_offset, new_y_offset)

func set_options_shapes():
	var indices = range(1,4)
	var random_indices = general_utils.shuffle_list(indices)
	for i in indices:
		var option_mask = get_option_shape(i)
		var shape_no = random_indices[i - 1]
		
		var offset = initial_options_texture_offset[shape_no - 1]
		var x_offset = offset.x
		var y_offset = offset.y
		
		var new_y_offset = get_new_y_offset(y_offset)
		option_mask.offset = Vector2(x_offset, new_y_offset)
		
		var option_border = get_option_border(i)
		
		var x_region = x_regions[shape_no - 1]
		var new_y_region = get_new_y_region()
		
		option_border.region_rect = Rect2(x_region, new_y_region, quilt_size, quilt_size)

func get_option_shape(i):
	var node_path = "AnimationPlayer%d/Layer/Option/Light2D" % i
	var option_mask = get_node(node_path)
	return option_mask

func get_option_border(i):
	var node_path = "AnimationPlayer%d/Layer/Option/Border" % i
	var option_border = get_node(node_path)
	return option_border

func set_question_fabric():
	current_fabric = get_current_fabric()
	var fabric = load(current_fabric)
	var holey_quilt_fabric = get_holey_quilt_fabric()
	holey_quilt_fabric.set_texture(fabric)
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer/Option/Fabric Texture" % i
		var option_fabric = get_node(node_path)
		option_fabric.set_texture(fabric)

func get_current_fabric():
	var fabric_path = general_utils.get_fabric(global.current_level, global.current_question)
	return fabric_path

func reset_option_positions():
	var holey_quilt = get_holey_quilt()
	holey_quilt.visible = true
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer/Option" % i
		var option = get_node(node_path)
		option.visible = true
		option.transform.origin = option_positions[i - 1]

func add_quilt_piece():
	
	progress_quilt.add_pre_animation_piece(current_fabric)
	
	var holey_quilt = get_holey_quilt()
	holey_quilt.visible = false
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer/Option" % i
		var option = get_node(node_path)
		option.visible = false
	
	progress_quilt.animate_quilt_piece()
	yield(progress_quilt, "done_animating")
	emit_signal("piece_added")

func _on_AnimationPlayer_animation_started(animation_name, index):
	var is_correct = animation_name == "Correct"
	timer = Timer.new()
	add_child(timer)
	timer.wait_time = animation_wait_times[animation_name][index - 1]
	timer.connect("timeout", self, "_feedback", [is_correct, index])
	timer.start()

func _feedback(is_correct, index):
	timer.stop()
	remove_child(timer)
	audio_player.play_audio_feedback(is_correct, index)
	character.on_option(is_correct)
