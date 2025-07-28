extends CanvasLayer


func _on_button_start_pressed() -> void:
	$ButtonStart.hide()
	$ButtonEasy.show()
	$ButtonAverage.show()
	$ButtonHard.show()
	$PanelContainer/LabelStart.text = "Выберите уровень сложности:"


func _on_button_easy_pressed() -> void:
	get_tree().change_scene_to_file("res://game3/game3.tscn")


func _on_button_average_pressed() -> void:
	get_tree().change_scene_to_file("res://game6/game6.tscn")


func _on_button_hard_pressed() -> void:
	get_tree().change_scene_to_file("res://game9/game9.tscn")
