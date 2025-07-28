class_name Cone extends Node2D 

signal on_click(node) #сигнал нажатия на колбу


@export var level = -1
var bloods = ["Blood4", "Blood3", "Blood2", "Blood1"]


func _ready() -> void:
	for i in level+1:
		get_node(bloods[i]).show()

func clear():
	$Blood1.color = Color.ALICE_BLUE
	$Blood2.color = Color.ANTIQUE_WHITE
	$Blood3.color = Color.AZURE
	$Blood4.color = Color.BEIGE
	$Blood1.hide()
	$Blood2.hide()
	$Blood3.hide()
	$Blood4.hide()
	level = -1





func push(color) -> void: #добавить цвет в колбу
	if(level<3):
		level+=1
		get_node(bloods[level]).color = color
		get_node(bloods[level]).show()


func pop(): #взять цвет из колбы
	if(level>=0):
		get_node(bloods[level]).hide()
		level-=1
		return get_node(bloods[level+1]).color
	return null


func _on_area_2d_input_event(viewport: Node, event: InputEvent, shape_idx: int) -> void: #функция реагирубщая на нажатие по колбе
	if(InputEventMouseButton and event.is_pressed()):
		on_click.emit(self) #вызов сигнала

func up_color():
	if(level==-1):
		return null
	return get_node(bloods[level]).color

func selected():
	$Sprite2D.show()
	
func un_selected():
	$Sprite2D.hide()
	
	
func is_finish():
	if(level == -1):
		return true
	var color = get_node(bloods[3]).color
	for i in 3:
		if get_node(bloods[i]).color != color:
			return false
	return true


func _on_touch_screen_button_pressed() -> void:
	on_click.emit(self) #вызов сигнала
