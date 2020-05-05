extends Sprite

onready var current_level = 1
onready var current_question = 1
onready var questions_per_level = 10
onready var max_levels = 1

onready var question_order = []
onready var option_file_text = "option_"

func _ready():
	question_order = shuffle_list(range(1,questions_per_level + 1))
	set_textures()

func next_question():
	current_question += 1
	
	if (current_question > questions_per_level):
		current_question = 1
		current_level += 1
		shuffle_question_order()
	
	if (current_level > max_levels):
		current_level = 1
		current_question = 1
		shuffle_question_order()
	
	set_textures()

func shuffle_question_order():
	question_order = shuffle_list(range(1,questions_per_level + 1))

func set_textures():
	var children = get_children()
	var shuffled_question = question_order[current_question]
	var base_path = "res://assets/sprites/questions/level_%d/question_%d" % [current_level, shuffled_question]
	
	print("Level %d, Question %d" % [current_level, current_question])
	
	set_holey_quilt_texture(base_path, children)
	set_options_textures(base_path, children)

func set_holey_quilt_texture(base_path, children):
	var holey_quilt = children[0]
	var hole = holey_quilt.get_child(0)
	
	var holey_quilt_path = base_path + "/holey_quilt.png"
	var hole_path = base_path + "/option_1.png"
	
	var holey_quilt_texture = load(holey_quilt_path)
	var hole_texture = load(hole_path)
	
	holey_quilt.set_texture(holey_quilt_texture)
	hole.set_texture(hole_texture)

func set_options_textures(base_path, children):
	var indices = range(1,4)
	var random_indices = shuffle_list(indices)
	for i in indices:
		var option = children[i]
		var option_sprite = option.get_child(0)
		var shape_no = random_indices[i - 1]
		var option_path_suffix = "/option_%d.png" % shape_no
		var option_path = base_path + option_path_suffix
		var option_texture = load(option_path)
		option_sprite.set_texture(option_texture)
		
func shuffle_list(list):
	var list_copy = list.duplicate()
	var shuffled_list = []
	for i in range(list_copy.size()):
		var index_list = range(list_copy.size())
		randomize()
		var x = randi()%index_list.size()
		shuffled_list.append(list_copy[x])
		index_list.remove(x)
		list_copy.remove(x)
	return shuffled_list

func on_option_pressed(sprite_index):
	print("Option %d pressed" % sprite_index)
	var children = get_children()
	var option = children[sprite_index]
	var option_sprite = option.get_child(0)
	var option_texture = option_sprite.get_texture()
	var option_texture_path = option_texture.get_load_path()
	
	var option_index = option_texture_path.find(option_file_text)
	var opt_no_index = option_index + len(option_file_text)
	var opt_no = int(option_texture_path.substr(opt_no_index, 1))
	
	if (opt_no == 1):
		next_question()

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


func _on_ColorPickerButton_color_changed(colour):
	print(colour)
	var children = get_children()
	for child in children:
		var sprite
		if child.get_class() == "Sprite":
			sprite = child
		else:
			sprite = child.get_child(0)
		print(sprite)
		sprite.self_modulate = colour
