extends Node

var save_file_path = "user://savegame.save"

const GeneralUtils = preload("./general.gd")
var general_utils = GeneralUtils.new()

var file = File.new()

func set_state_for_player():
	var saved_data = File.new()
	saved_data.open(save_file_path, File.READ)
	
	var level = 1
	var question = 1
	var question_order = general_utils.shuffle_question_order()
	var difficulty = "normal"
	
	while(saved_data.get_position() < saved_data.get_len()):
		var data = parse_json(saved_data.get_line())
		
		if (!data):
			continue
		
		var index = data["index"]
		
		if (index == global.character_index):
			level = data["level"]
			question = data["question"]
			question_order = data["question_order"]
			difficulty = data["difficulty"]
	
	saved_data.close()
	
	var shuffled_question = question_order[question - 1]
	
	global.current_level = level
	global.current_question = question
	global.question_order = question_order
	global.current_level_difficulty = difficulty
	global.current_shuffled_question = shuffled_question

func save_progress():
	var save_game = File.new()
	
	if (!file.file_exists(save_file_path)):
		# Create file if it's been deleted
		save_game.open(save_file_path, File.WRITE)
		save_game.close()
	
	save_game.open(save_file_path, File.READ_WRITE)
	
	var progress = {
		"index": global.character_index,
		"name": global.character_name,
		"level": global.current_level,
		"question": global.current_question,
		"question_order": global.question_order,
		"difficulty": global.current_level_difficulty
	}
	
	var saved = false
	
	while(save_game.get_position() < save_game.get_len()):
		var data = parse_json(save_game.get_line())
		
		if (!data):
			continue
		
		var index = data["index"]
		
		if (index == global.character_index):
			add_line(save_game, to_json(progress))
			saved = true
			break
	
	if (!saved):
		# New character
		save_game.seek_end()
		add_line(save_game, to_json(progress))
	
	save_game.close()

func add_line(file, line):
	file.store_line(line)
	file.store_line("\n")

func clear_all_data():
	var dir = Directory.new()
	dir.remove(save_file_path)
