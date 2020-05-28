extends Sprite

var current_level = 1
var current_question = 1
var current_shuffled_question = 1
var current_fabric = ''

var questions_per_level = 10

var question_order = []
var option_positions = [Vector2(821, 768), Vector2(1256, 768), Vector2(1721, 768)]

const FileUtils = preload("utilities/files.gd")
onready var file_utils = FileUtils.new()

onready var max_levels = file_utils.get_number_of_levels()

const GeneralUtils = preload("utilities/general.gd")
onready var general_utils = GeneralUtils.new()

onready var progress_quilt = get_parent().get_node("Progress Quilt")

signal piece_added

func _ready():
	randomise_question_fabric()
	question_order = general_utils.shuffle_list(range(1,questions_per_level + 1))
	set_shapes()

func next_question():
	add_quilt_piece()
	yield(self, "piece_added")
	
	reset_option_positions()
	
	current_question += 1
	
	if (current_question > questions_per_level):
		current_question = 1
		current_level += 1
		shuffle_question_order()
	
	if (current_level > max_levels):
		current_level = 1
		current_question = 1
		shuffle_question_order()
	
	set_shapes()
	randomise_question_fabric()

func shuffle_question_order():
	question_order = general_utils.shuffle_list(range(1,questions_per_level + 1))

func set_shapes():
	current_shuffled_question = question_order[current_question - 1]
	var question_path = get_question_path()
	
	set_holey_quilt_shape()
	set_options_shapes(question_path)

func get_level_path():
	return "res://assets/sprites/questions/level_%d/" % current_level

func get_question_path():
	var level_path = get_level_path()
	return str(level_path, "question_%d" % current_shuffled_question)

func get_holey_quilt_path():
	var question_path = get_question_path()
	return question_path + "/holey_quilt.png"

func get_holey_quilt():
	var holey_quilt = get_node("Layer1/HoleyQuilt")
	return holey_quilt

func get_holey_quilt_fabric():
	var holey_quilt_fabric = get_node("Layer1/HoleyQuilt/Fabric Texture")
	return holey_quilt_fabric

func get_holey_quilt_shape():
	var holey_quilt_shape = get_node("Layer1/HoleyQuilt/Light2D")
	return holey_quilt_shape

func set_holey_quilt_shape():
	var holey_quilt_shape = get_holey_quilt_shape()
	
	var holey_quilt_path = get_holey_quilt_path()
	
	var shape = load(holey_quilt_path)
	holey_quilt_shape.set_texture(shape)

func set_options_shapes(base_path):
	var indices = range(1,4)
	var random_indices = general_utils.shuffle_list(indices)
	for i in indices:
		var node_path = "AnimationPlayer%d/Layer%d/Option %d/Light2D" % [i, i+1, i]
		var option_mask = get_node(node_path)
		var shape_no = random_indices[i - 1]
		var option_path_suffix = "/option_%d.png" % shape_no
		var option_path = base_path + option_path_suffix
		var option_shape = load(option_path)
		option_mask.set_texture(option_shape)

func randomise_question_fabric():
	var fabric_path = file_utils.get_random_fabric_path()
	current_fabric = fabric_path
	
	set_question_fabric(fabric_path)

func set_question_fabric(fabric_path):
	var fabric = load(fabric_path)
	var holey_quilt_fabric = get_holey_quilt_fabric()
	holey_quilt_fabric.set_texture(fabric)
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer%d/Option %d/Fabric Texture" % [i, i+1, i]
		var option_fabric = get_node(node_path)
		option_fabric.set_texture(fabric)

func reset_option_positions():
	var holey_quilt = get_holey_quilt()
	holey_quilt.visible = true
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer%d/Option %d" % [i, i+1, i]
		var option = get_node(node_path)
		option.visible = true
		option.transform.origin = option_positions[i - 1]

func add_quilt_piece():
	var holey_quilt = get_holey_quilt()
	holey_quilt.visible = false
	
	for i in range(1,4):
		var node_path = "AnimationPlayer%d/Layer%d/Option %d" % [i, i+1, i]
		var option = get_node(node_path)
		option.visible = false
	
	progress_quilt.add_quilt_piece(current_fabric)
	
	progress_quilt.animate_quilt_piece(current_question)
	yield(progress_quilt, "done_animating")
	emit_signal("piece_added")
