Screen screen = new Screen();
Menu menu = new Menu();

// Constrói uma janela que preenche o espaço inteiro disponível.
screen.buildFrame(0, 0, screen.WindowWidth, screen.WindowHeight);

menu.add("Bater Ponto [C]");
menu.add("Consultar Ponto [R]");
menu.add("Sugerir Alteração [U]");
menu.add("Remover Horário Registrado [D]");
menu.add("Ajuda [H]");
menu.add("Sair [Q]");
menu.show();

Console.ReadKey();