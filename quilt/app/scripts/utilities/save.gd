extends Node

var data_file_path = "user://config.cfg"

const GeneralUtils = preload("./general.gd")
var general_utils = GeneralUtils.new()

const Constants = preload("./constants.gd")
var constants = Constants.new()

var DEFAULT_USER_PROGRESS = [
	{
		"difficulty": "normal",
		"index": 1,
		"level": 1,
		"name": "Test",
		"question": 1,
		"question_order": [],
		"shuffled_question": 1
	},
	{
		"difficulty": "normal",
		"index": 2,
		"level": 1,
		"name": "Test",
		"question": 1,
		"question_order": [],
		"shuffled_question": 1
	},
	{
		"difficulty": "normal",
		"index": 3,
		"level": 1,
		"name": "Test",
		"question": 1,
		"question_order": []
	},
	{
		"difficulty": "normal",
		"index": 4,
		"level": 1,
		"name": "Test",
		"question": 1,
		"question_order": []
	},
	{
		"difficulty": "normal",
		"index": 5,
		"level": 1,
		"name": "Test",
		"question": 1,
		"question_order": []
	},
	{
		"difficulty": "normal",
		"index": 6,
		"level": 1,
		"name": "Test",
		"question": 1,
		"question_order": [],
		"shuffled_question": 1
	}
]

func set_state_for_player():
	var state = get_state_for_player(global.character_index)
	global.current_level = state["level"]
	global.current_question = state["question"]
	global.question_order = state["question_order"]
	global.current_level_difficulty = state["difficulty"]
	global.current_shuffled_question = state["shuffled_question"]

func get_state_for_player(character_index):
	var name = "Test"
	var level = 1
	var question = 1
	var difficulty = "normal"
	var question_order = []
	var shuffled_question = 1
	
	var config_info = get_config_info()
	var user_progress = config_info["progress"]
	
	for progress in user_progress:
		var index = progress["index"]
		
		if (index == character_index):
			name = progress["name"]
			level = progress["level"]
			question = progress["question"]
			question_order = progress["question_order"]
			difficulty = progress["difficulty"]
	
	if (question_order.size() <= 0):
		question_order = general_utils.shuffle_question_order(level)
	
	shuffled_question = question_order[question - 1]
	
	return {
		"name": name,
		"level": level,
		"question": question,
		"question_order": question_order,
		"difficulty": difficulty,
		"shuffled_question": shuffled_question
	}

func save_progress():
	var progress = {
		"name": global.character_name,
		"index": global.character_index,
		"level": global.current_level,
		"question": global.current_question,
		"question_order": global.question_order,
		"difficulty": global.current_level_difficulty,
		"shuffled_question": global.current_shuffled_question
	}
	
	set_user_progress(global.character_index, progress)

func set_user_progress(character_index, progress):
	var config_info = get_config_info()
	var config = config_info["config"]
	var user_progress = config_info["progress"]
	
	user_progress[character_index - 1] = progress
	
	config.set_value("game", "user_progress", user_progress)
	
	close_data_file(config)

func get_config_info():
	var config = ConfigFile.new()
	var progress = []
	var error = config.load(data_file_path)
	if (error == OK):
		progress = config.get_value("game", "user_progress", DEFAULT_USER_PROGRESS)
	else:
		progress = DEFAULT_USER_PROGRESS
	
	return {
		"config": config,
		"progress": progress
	}

func close_data_file(config):
	config.save(data_file_path)

func clear_all_data():
	for i in range(1, constants.num_characters + 1):
		clear_character_data(i)

func clear_character_data(character_index):
	var current_state = get_state_for_player(character_index)
	var no_progress = get_no_progress(character_index, current_state["name"])
	set_user_progress(character_index, no_progress)

func get_no_progress(character_index, character_name):
	return {
		"name": character_name,
		"index": character_index,
		"level": 1,
		"question": 1,
		"question_order": [],
		"difficulty": "normal"
	}
