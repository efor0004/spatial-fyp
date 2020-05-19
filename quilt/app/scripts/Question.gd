extends Sprite

onready var current_level = 1
onready var current_question = 1
onready var current_shuffled_question = 1
onready var current_fabric = ''

onready var initial_quilt_piece_x = 1136
onready var quilt_piece_x = initial_quilt_piece_x
onready var quilt_piece_y = 0

onready var questions_per_level = 10
onready var max_levels = 1
onready var quilt_size = 384

onready var question_order = []
onready var option_file_text = "option_"
onready var all_fabrics_path = "res://assets/sprites/fabrics"

const FileUtils = preload("utilities/files.gd")
onready var file_utils = FileUtils.new()

const GeneralUtils = preload("utilities/general.gd")
onready var general_utils = GeneralUtils.new()

func _ready():
	randomise_question_fabric()
	question_order = general_utils.shuffle_list(range(1,questions_per_level + 1))
	set_shapes()

func next_question():
	add_quilt_piece()
	
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
	var level_path = get_level_path()
	var question_path = get_question_path()
	
	print("Level %d, Question %d" % [current_level, current_question])
	
	set_holey_quilt_shape(level_path, question_path)
	set_options_shapes(question_path)

func get_level_path():
	return "res://assets/sprites/questions/level_%d/" % current_level

func get_question_path():
	var level_path = get_level_path()
	return str(level_path, "question_%d" % current_shuffled_question)

func get_holey_quilt_path():
	var question_path = get_question_path()
	return question_path + "/holey_quilt.png"

func get_holey_quilt_fabric():
	var holey_quilt = get_child(0)
	var holey_quilt_fabric = holey_quilt.get_child(1)
	return holey_quilt_fabric

func get_holey_quilt_shape():
	var holey_quilt = get_child(0)
	var holey_quilt_shape = holey_quilt.get_child(0)
	return holey_quilt_shape

func get_quilt_square():
	var path = "res://assets/sprites/questions/square.png"
	var square = load(path)
	return square

func get_current_fabric():
	var fabric = load(current_fabric)
	return fabric

func set_holey_quilt_shape(level_path, question_path):
	var holey_quilt_shape = get_holey_quilt_shape()
	
	var holey_quilt_path = get_holey_quilt_path()
	
	var shape = load(holey_quilt_path)
	holey_quilt_shape.set_texture(shape)

func set_options_shapes(base_path):
	var indices = range(1,4)
	var random_indices = general_utils.shuffle_list(indices)
	for i in indices:
		var option = get_child(i)
		var option_mask = option.get_child(0)
		var shape_no = random_indices[i - 1]
		var option_path_suffix = "/option_%d.png" % shape_no
		var option_path = base_path + option_path_suffix
		var option_shape = load(option_path)
		option_mask.set_texture(option_shape)

func on_option_pressed(sprite_index):
	var children = get_children()
	var option = children[sprite_index]
	var option_sprite = option.get_child(0)
	var option_shape = option_sprite.get_texture()
	var option_shape_path = option_shape.get_load_path()
	
	var option_index = option_shape_path.find(option_file_text)
	var opt_no_index = option_index + len(option_file_text)
	var opt_no = int(option_shape_path.substr(opt_no_index, 1))
	
	if (opt_no == 1):
		next_question()

func randomise_question_fabric():
	var fabrics = file_utils.get_files_in_directory(all_fabrics_path)
	
	randomize()
	var x = randi() % fabrics.size()
	var file_name = fabrics[x]
	var fabric_path = "%s/%s" % [all_fabrics_path, file_name]
	current_fabric = fabric_path
	
	set_question_fabric(fabric_path)

func add_quilt_piece():
	var scale = 0.25
	var width_height = quilt_size * scale
	
	var piece = Sprite.new()
	var mask = Light2D.new()
	mask.mode = Light2D.MODE_MIX
	mask.scale = Vector2(scale,scale)
	
	var fabric = Sprite.new()
	fabric.region_enabled = true
	fabric.region_rect = Rect2(0, 0, quilt_size, quilt_size)
	fabric.scale = Vector2(scale,scale)
	
	var fabric_canvas = CanvasItemMaterial.new()
	fabric_canvas.blend_mode = BLEND_MODE_MIX
	fabric_canvas.light_mode = CanvasItemMaterial.LIGHT_MODE_LIGHT_ONLY
	
	piece.add_child(mask)
	fabric.material = fabric_canvas
	piece.add_child(fabric)
	
	var piece_shape = get_quilt_square()
	mask.set_texture(piece_shape)
	
	var piece_fabric = get_current_fabric()
	fabric.set_texture(piece_fabric)
	
	var piece_size_x = width_height
	
	quilt_piece_x = quilt_piece_x + piece_size_x

	if current_question == 1:
		quilt_piece_x = initial_quilt_piece_x
		var piece_size_y = width_height
		if quilt_piece_y == 0:
			quilt_piece_y = quilt_piece_y + piece_size_y / 2
		else:
			quilt_piece_y = quilt_piece_y + piece_size_y
	
	var new_piece_pos = Vector2(quilt_piece_x, quilt_piece_y)
	print(new_piece_pos)
	piece.transform.origin = new_piece_pos
	
	add_child(piece)

func set_question_fabric(fabric_path):
	var fabric = load(fabric_path)
	var holey_quilt_fabric = get_holey_quilt_fabric()
	holey_quilt_fabric.set_texture(fabric)
	
	for i in range(1,4):
		var option = get_child(i)
		var option_fabric = option.get_child(2)
		option_fabric.set_texture(fabric)

func _on_Option_1_input_event(viewport, event, shape_idx):
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		on_option_pressed(1)


func _on_Option_2_input_event(viewport, event, shape_idx):
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		on_option_pressed(2)


func _on_Option_3_input_event(viewport, event, shape_idx):
	if event is InputEventMouseButton \
	and event.button_index == BUTTON_LEFT \
	and event.is_pressed():
		on_option_pressed(3)
