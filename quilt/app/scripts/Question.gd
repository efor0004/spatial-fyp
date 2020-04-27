extends Sprite

onready var current_level = 1
onready var current_question = 1
onready var questions_per_level = 10
onready var max_levels = 1

func _ready():
	set_textures()

func _on_Next_Button_pressed():
	print("button pressed")
	
	current_question += 1
	
	if (current_question > questions_per_level):
		current_question = 1
		current_level += 1
	
	if (current_level > max_levels):
		current_level = 1
		current_question = 1
	
	set_textures()

func set_textures():
	var children = get_children()
	var base_path = "res://assets/sprites/questions/level_%d/question_%d" % [current_level, current_question]
	
	print("Level %d, Question %d" % [current_level, current_question])
	
	set_holey_quilt_texture(base_path, children)
	set_options_textures(base_path, children)

func set_holey_quilt_texture(base_path, children):
	var holey_quilt = children[0]
	var holey_quilt_path = base_path + "/holey_quilt.png"
	var holey_quilt_texture = load(holey_quilt_path)
	holey_quilt.set_texture(holey_quilt_texture)

func set_options_textures(base_path, children):
	var indices = range(1,4)
	var random_indices = shuffleList(indices)
	print(indices)
	print(random_indices)
	for i in indices:
		var option = children[i]
		var shape_no = random_indices[i - 1]
		var option_path_suffix = "/option_%d.png" % shape_no
		var option_path = base_path + option_path_suffix
		var option_texture = load(option_path)
		option.set_texture(option_texture)
		
func shuffleList(list):
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
