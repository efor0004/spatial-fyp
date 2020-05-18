extends Node

func shuffle_list(list):
	var list_copy = list.duplicate()
	var shuffled_list = []
	for i in range(list_copy.size()):
		var index_list = range(list_copy.size())
		randomize()
		var x = randi() % index_list.size()
		shuffled_list.append(list_copy[x])
		index_list.remove(x)
		list_copy.remove(x)
	return shuffled_list
