class Menu
{
  private Screen screen = new Screen();
  private List<string> options = new List<string>();

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
  }

  public void choose()
  {}
}