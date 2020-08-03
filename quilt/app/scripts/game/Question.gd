extends Sprite

onready var current_fabric = get_current_fabric()

var quilt_size = 384
var initial_texture_y = 0
var initial_quilt_texture_offset = Vector2(0, 0)
var initial_options_texture_offset = [Vector2(0, 0), Vector2(0, 0), Vector2(0, 0)]

var option_positions = [Vector2(821, 768), Vector2(1256, 768), Vector2(1721, 768)]

const Constants = preload("../utilities/constants.gd")
onready var constants = Constants.new()

const GeneralUtils = preload("../utilities/general.gd")
var general_utils = GeneralUtils.new()

const SaveUtils = preload("../utilities/save.gd")
var save_utils = SaveUtils.new()

onready var progress_quilt = get_parent().get_node("Progress Quilt")

signal piece_added
signal set_next_question

func _ready():
	save_utils.set_state_for_player()
	set_textures_for_level()
	set_shapes()
	set_question_fabric()
	save_utils.save_progress()
	progress_quilt.add_all_pieces_for_state()

func next_question():
	add_quilt_piece()
	yield(self, "piece_added")
	
	reset_option_positions()
	
	global.current_question += 1
	
	var level_hard_questions_info = constants.num_hard_questions_per_level[global.current_level - 1]
	var num_normal_questions_for_level = constants.questions_per_level - level_hard_questions_info["required"]
	
	if (global.current_level_difficulty == "normal" && global.current_question > num_normal_questions_for_level):
		global.current_level_difficulty = "hard"
		set_textures_for_level()
	
	if (global.current_question > constants.questions_per_level):
		global.current_question = 1
		global.current_level += 1
		
		if (global.current_level > constants.max_levels):
			global.current_level = 1
			global.current_question = 1
		
		set_textures_for_level()
		global.question_order = general_utils.shuffle_question_order()
	
	set_shapes()
	set_question_fabric()
	emit_signal("set_next_question")
	save_utils.save_progress()

func set_textures_for_level():
	set_texture_offsets()
	
	var path = get_level_path()
	var level_texture = load(path)
	
	var holey_quilt = get_holey_quilt_shape()
	holey_quilt.set_texture(level_texture)
	
	for i in range(1,4):
		var option_shape = get_option_shape(i)
		option_shape.set_texture(level_texture)

func set_texture_offsets():
	var questions_available_for_level = constants.questions_available_per_level[global.current_level - 1]
	
	if (global.current_level_difficulty == "hard"):
		questions_available_for_level = constants.num_hard_questions_per_level[global.current_level - 1]["available"]
	
	var texture_height = questions_available_for_level * quilt_size
	
	initial_texture_y = (texture_height - quilt_size) / 2
	initial_quilt_texture_offset = Vector2(576, initial_texture_y)
	initial_options_texture_offset = [Vector2(192, initial_texture_y), Vector2(-192, initial_texture_y), Vector2(-576, initial_texture_y)]

func set_shapes():
	global.current_shuffled_question = global.question_order[global.current_question - 1]
	
	set_holey_quilt_shape()
	set_options_shapes()

func get_level_path():
	if (global.current_level_difficulty == "hard"):
		return "res://assets/sprites/questions/level_%d_hard.png" % global.current_level
	
	return "res://assets/sprites/questions/level_%d.png" % global.current_level

func get_holey_quilt():
	var holey_quilt = get_node("Layer1/HoleyQuilt")
	return holey_quilt

func get_holey_quilt_fabric():
	var holey_quilt_fabric = get_node("Layer1/HoleyQuilt/Fabric Texture")
	return holey_quilt_fabric

func get_holey_quilt_shape():
	var holey_quilt_shape = get_node("Layer1/HoleyQuilt/Light2D")
	return holey_quilt_shape

func get_new_y_offset(y_offset):
	var new_y_offset = y_offset - (quilt_size * (global.current_shuffled_question - 1))
	return new_y_offset

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

func get_option_shape(i):
	var node_path = "AnimationPlayer%d/Layer%d/Option %d/Light2D" % [i, i+1, i]
	var option_mask = get_node(node_path)
	return option_mask

func set_question_fabric():
	current_fabric = get_current_fabric()
	var fabric = load(current_fabric)
	var holey_quilt_fabric = get_holey_quilt_fabric()
	holey_quilt_fabric.set_texture(fabric)
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer%d/Option %d/Fabric Texture" % [i, i+1, i]
		var option_fabric = get_node(node_path)
		option_fabric.set_texture(fabric)

func get_current_fabric():
	var fabric_path = general_utils.get_fabric(global.current_level, global.current_question)
	return fabric_path

func reset_option_positions():
	var holey_quilt = get_holey_quilt()
	holey_quilt.visible = true
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer%d/Option %d" % [i, i+1, i]
		var option = get_node(node_path)
		option.visible = true
		option.transform.origin = option_positions[i - 1]

func add_quilt_piece():
	
	progress_quilt.add_pre_animation_piece(current_fabric)
	
	var holey_quilt = get_holey_quilt()
	holey_quilt.visible = false
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer%d/Option %d" % [i, i+1, i]
		var option = get_node(node_path)
		option.visible = false
	
	progress_quilt.animate_quilt_piece()
	yield(progress_quilt, "done_animating")
	emit_signal("piece_added")
