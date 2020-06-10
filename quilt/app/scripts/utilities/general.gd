extends Node

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
	var shuffled_questions = shuffle_list(range(1, global.questions_available_per_level + 1))
	global.question_order = shuffled_questions.slice(0, global.questions_per_level + 1)

func get_fabric(level, question):
	var fabric_path = "res://assets/sprites/fabrics/level_%d/fabric_%d.jpg" % [level, question]
	return fabric_path
