class Help
{
  private List<string> tips = new List<string>();
  private Screen screen;

  public Help(Screen screen)
  {
    this.screen = screen;

    this.setRules();
  }

  private void add(string tip)
  {
    this.tips.Add(tip);
  }

  private void setRules()
  {
    this.add("Bem-vindo(a) ao Punclock, o app perfeito para bater pontos e organizar tarefas.");
    this.add("");
    this.add("Opções do menu:");
    this.add("");
    this.add("1. Bater Ponto [C]");
    this.add("a. É por aqui que você vai poder cadastrar seus horários para bater o ponto e assim registrar o que foi feito.");
    this.add("");
    this.add("2. Consultar Ponto [R]");
    this.add("a. Por meio da listagem dos pontos feitos e visualizar tudo.");
    this.add("");
    this.add("3. Sugerir Alteração [U]");
    this.add("a. Realizar alterações no registro do ponto, visto que o lançamento de informações erradas pode ocorrer.");
    this.add("");
    this.add("4. Remover Horário Registrado [D]");
    this.add("a. Remover algum ponto que esteja errado.");
  }

  public void list()
  {
    int initialColumn = this.screen.InitialColumn + 1;

    for (int index = 0; index < this.tips.Count; index++)
    {
      int row = index + 1;
      string tip = this.tips[index];

      this.screen.write(initialColumn, row, tip);
      Console.ReadKey();
    }
  }
}