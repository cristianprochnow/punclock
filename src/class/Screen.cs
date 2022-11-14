class Screen
{
  private ConsoleColor background;
  private ConsoleColor color;
  private int sizeToAvoidError = 1;
  public int WindowWidth
  {
    get {
      return Console.WindowWidth - this.sizeToAvoidError;
    }
  }
  public int WindowHeight
  {
    get {
      return Console.WindowHeight - this.sizeToAvoidError;
    }
  }

  public int InitialColumn = 0;

  public Screen()
  {
    this.background = ConsoleColor.Black;
    this.color = ConsoleColor.White;

    this.setUpScreen();
  }

  public void clearFrame(int initialColumn, int initialRow, int finalColumn, int finalRow)
  {
    initialColumn++;
    initialRow++;
    finalColumn--;
    finalRow--;

    for (int column = initialColumn; column < finalColumn; column++)
    {
      for (int row = initialRow; row < finalRow; row++)
      {
        this.write(column, row, " ");
      }
    }
  }

  private void setUpScreen()
  {
    Console.BackgroundColor = this.background;
    Console.ForegroundColor = this.color;

    Console.Clear();
  }

  public void customInitialColumn(int startPoint)
  {
    this.InitialColumn = startPoint;
  }

  public void buildFrame(int initialColumn, int initialRow, int finalColumn, int finalRow)
  {
    // Desenha a linha superior;
    for (int column = initialColumn; column < finalColumn; column++)
    {
      this.write(column, initialRow, "-");
    }
    // Desenha a linha de baixo que fecha o molde.
    for (int column = initialColumn; column < finalColumn; column++)
    {
      /*
        `-1` apenas para corrigir o fechamento da moldura, que estava ficando
        uma linha para baixo do limite da lateral.
      */
      this.write(column, finalRow - 1, "-");
    }
    // Desenha a linha da esquerda.
    for (int row = initialRow; row < finalRow; row++)
    {
      string character = "|";
      if (row == initialRow || row == (finalRow - 1)) {
        character = "+";
      }

      this.write(initialColumn, row, character);
    }
    // Desenha a linha da direita.
    for (int row = initialRow; row < finalRow; row++)
    {
      string character = "|";
      if (row == initialRow || row == (finalRow - 1)) {
        character = "+";
      }

      this.write(finalColumn, row, character);
    }
  }

  public void write(int column, int row, string content)
  {
    Console.SetCursorPosition(column, row);
    Console.Write(content);
  }

  public string ask(int column, int row, string question)
  {
    string? response;

    this.write(column, row, question);
    row++;
    this.write(column, row, "→");
    Console.SetCursorPosition(column + 2, row);
    response = Console.ReadLine();

    if (response == null) {
      response = "";
    }

    return response;
  }
}