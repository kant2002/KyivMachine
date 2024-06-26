Функціонал: Операція віднімання

  Сценарій: Звичайне віднімання
  Дано пам'ять заповнена значенями 1
  І ячейка 5 містить 300
  А також  ячейка 18 містить 100
  І ячейка 100 містить команду '02 0005 0022 0002'
  І регістр лічільник команд містить 100
  Якщо виконати команді
  Тоді ячейка 2 містить 200
  А також лічільник команд містить 101

  Сценарій: Звичайне віднімання 2
  Дано пам'ять заповнена значенями 1
  І ячейка 5 містить -300
  А також  ячейка 18 містить 100
  І ячейка 100 містить команду '02 0005 0022 0002'
  І регістр лічільник команд містить 100
  Якщо виконати команді
  Тоді ячейка 2 містить -400
  А також лічільник команд містить 101

  Сценарій: Віднімання із переповненням
  Дано пам'ять заповнена значенями 1
  І ячейка 5 містить мінімальне негативне число
  А також  ячейка 18 містить максимальне позітивне число
  І ячейка 100 містить команду '02 0005 0022 0002'
  І регістр лічільник команд містить 100
  Якщо виконати команді
  Тоді лічільник команд містить 102

  Сценарій: Віднімання із переповненням і аварійною зупинкою
  Дано пам'ять заповнена значенями 1
  І ячейка 5 містить мінімальне негативне число
  А також  ячейка 18 містить максимальне позітивне число
  І ячейка 100 містить команду '02 0005 0022 0002'
  І регістр лічільник команд містить 100
  І аварійна зупинка включена
  Якщо виконати команді
  Тоді лічільник команд містить 102
