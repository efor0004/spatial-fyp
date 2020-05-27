extends Node

var questions_path = "res://assets/sprites/questions"
var fabrics_path = "res://assets/sprites/fabrics"
var num_fabrics = 14
var directory_util = Directory.new()

func get_files_in_directory(path):
	var files = []
	var dir = Directory.new()
	dir.open(path)
	dir.list_dir_begin()

	while true:
		var file = dir.get_next()
		if file == "":
			break
		elif not file.begins_with(".") and not file.ends_with(".import"):
			files.append(file)

	dir.list_dir_end()

	return files

func get_number_of_levels():
	var files_in_questions_folder = get_files_in_directory(questions_path)
	var num_levels = 0
	
	for file in files_in_questions_folder:
		var file_path = "%s/%s" % [questions_path, file]
		var is_dir = directory_util.dir_exists(file_path)
		if is_dir:
			num_levels += 1
	
	if num_levels == 0:
		return 1
	else:
		return num_levels
	
func get_random_fabric_path():
	randomize()
	var x = (randi() % (num_fabrics - 1)) + 1
	var file_name = "fabric_%d.jpg" % x
	var fabric_path = "%s/%s" % [fabrics_path, file_name]
	
	return fabric_path
