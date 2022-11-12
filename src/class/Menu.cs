class Menu
{
  private Screen screen;
  private List<string> options = new List<string>();
  private int lastRow = 0;
  public int lastColumn = 0;
  public int questionRow = 0;

  public Menu(Screen screen)
  {
    this.screen = screen;
  }

  public void add(string option)
  {
    if (option == "") {
      return;
    }

    this.options.Add(option);
  }

  private void adjustLength()
  {
    int greaterOptionLength = 0;

    // Verificar qual o comprimento da maior opção do menu
    foreach (string option in this.options)
    {
      if (option.Length >= greaterOptionLength) {
        greaterOptionLength = option.Length;
      }
    }

    // Ajustar todas as opções do menu para que tenham o mesmo comprimento.
    for (int counter = 0; counter < this.options.Count; counter++)
    {
      this.options[counter] = this.options[counter].PadRight(greaterOptionLength);
    }
  }

  public void show()
  {
    this.adjustLength();

    int initialColumn = 0;
    int initialRow = 0;
    int menuWidth = this.options[0].Length + 3;
    /*
      `- 2` para que desconte da altura total disponível o pixel já gasto na
      primeira linha da moldura, e também o último pixel da linha final da
      moldura.
    */
    int menuHeight = this.screen.WindowHeight;
    int menuLength = this.options.Count;

    // Mostra um menu lateral, em que estarão as opções.
    this.screen.buildFrame(initialColumn, initialRow, menuWidth, menuHeight);

    int row = initialRow + 1;
    int column = initialColumn + 2;
    foreach (string option in this.options)
    {
      this.screen.write(column, row, option);

      row++;
    }

    this.lastRow = row;
    this.lastColumn = menuWidth;

    this.screen.customInitialColumn(menuWidth + 1);
  }

  private void clearAnswer(int initialColumn, int finalColumn)
  {
    for (int counter = initialColumn; counter < finalColumn; counter++)
    {
      this.screen.write(counter, this.questionRow, " ");
    }
  }

  public string choose()
  {
    string message = "O que deseja fazer: ";

    int row = this.lastRow + 1;
    this.questionRow = row;

    this.clearAnswer(message.Length + 1, this.lastColumn);

    this.screen.write(2, row, message);
    string? answer = Console.ReadLine();

    if (answer == null) {
      answer = "";
    }

    return answer;
  }
}