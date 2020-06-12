extends Node2D

const SaveUtils = preload("res://scripts/utilities/save.gd")
var save_utils = SaveUtils.new()

func _on_Delete_Button_button_up():
	var confirmation_popup = ConfirmationModal.new()
	confirmation_popup.dialog_text = "Are you sure you want to delete all saved progress?"
	confirmation_popup.popup_centered()
	add_child(confirmation_popup)
	confirmation_popup.open()
	yield(confirmation_popup, "confirmed")
	save_utils.clear_all_data()
