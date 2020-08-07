extends Node

const Constants = preload("../utilities/constants.gd")
var constants = Constants.new()

func shuffle_list(list):
	var list_copy = list.duplicate()
	var shuffled_list = []
	for _i in range(list_copy.size()):
		var index_list = range(list_copy.size())
		randomize()
		var x = randi() % index_list.size()
		shuffled_list.append(list_copy[x])
		index_list.remove(x)
		list_copy.remove(x)
	return shuffled_list

func shuffle_question_order():
	var level_hard_questions_info = constants.num_hard_questions_per_level[global.current_level - 1]
	var hard_questions_required = level_hard_questions_info["required"]
	var hard_questions_available = level_hard_questions_info["available"]
	
	var sliced_shuffled_questions = []
	var questions_available_for_level = constants.questions_available_per_level[global.current_level - 1]
	var shuffled_normal_questions = shuffle_list(range(1, questions_available_for_level + 1))
	
	if (hard_questions_required == 0 || hard_questions_available == 0):
		sliced_shuffled_questions = shuffled_normal_questions.slice(0, constants.questions_per_level - 1)
	else:
		var num_normal_questions = constants.questions_per_level - hard_questions_required
		var sliced_shuffled_normal_questions = shuffled_normal_questions.slice(0, num_normal_questions - 1)
		
		var shuffled_hard_questions = shuffle_list(range(1, hard_questions_available + 1))
		var sliced_shuffled_hard_questions = shuffled_hard_questions.slice(0, hard_questions_required - 1)
		
		sliced_shuffled_questions = sliced_shuffled_normal_questions + sliced_shuffled_hard_questions
	
	return sliced_shuffled_questions

func get_fabric(level, question):
	var fabric_path = "res://assets/sprites/fabrics/level_%d/fabric_%d.jpg" % [level, question]
	return fabric_path
