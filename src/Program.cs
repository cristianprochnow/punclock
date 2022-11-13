Screen screen = new Screen();
Menu menu = new Menu(screen);
Help help = new Help(screen);

// Constrói uma janela que preenche o espaço inteiro disponível.
screen.buildFrame(0, 0, screen.WindowWidth, screen.WindowHeight);

menu.add("Bater Ponto [C]");
menu.add("Consultar Ponto [R]");
menu.add("Sugerir Alteração [U]");
menu.add("Remover Horário Registrado [D]");
menu.add("Ajuda [H]");
menu.add("Sair [Q]");
menu.show();

while (true) {
  string answer = menu.choose();

  if (answer == "") {
    answer = "Q";
  }
  answer = answer.ToUpper();

  if (answer == "C") {
    screen.write(screen.InitialColumn, 4, "Show demais");
  }
  else if (answer == "R") {

  }
  else if (answer == "U") {

  }
  else if (answer == "D") {

  }
  else if (answer == "H") {
    screen.clearFrame(screen.InitialColumn, 0, screen.WindowWidth, screen.WindowHeight);
    help.list();
  }
  else if (answer == "Q") {
    break;
  }
}

Console.Clear();
