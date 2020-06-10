extends Node

var save_file_path = "user://savegame.save"

const GeneralUtils = preload("./general.gd")
var general_utils = GeneralUtils.new()

func set_state_for_player():
	print("Retrieving data for %s" % global.player_name)
	
	var saved_data = File.new()
	saved_data.open(save_file_path, File.READ)
	
	var level = 1
	var question = 1
	var question_order = general_utils.shuffle_question_order()
	
	while(saved_data.get_position() < saved_data.get_len()):
		var data = parse_json(saved_data.get_line())
		print(data)
		var name = data["name"]
		
		if (name == global.player_name):
			level = data["level"]
			question = data["question"]
			question_order = data["question_order"]
	
	saved_data.close()
	
	var shuffled_question = question_order[question - 1]
	
	global.current_level = level
	global.current_question = question
	global.question_order = question_order
	global.current_shuffled_question = shuffled_question

func save_progress():
	var save_game = File.new()
	save_game.open(save_file_path, File.WRITE_READ)
	
	var progress = {
		"name": global.player_name,
		"level": global.current_level,
		"question": global.current_question,
		"question_order": global.question_order
	}
	
	save_game.store_line(to_json(progress))
	
	# if (save_game.get_len() == 0):
		
	
	save_game.close()
