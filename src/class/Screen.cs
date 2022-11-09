class Screen {
  private ConsoleColor background;
  private ConsoleColor color;

  public Screen() {
    this.background = ConsoleColor.Black;
    this.color = ConsoleColor.White;

    this.setUpScreen();
  }

  private void setUpScreen() {
    Console.BackgroundColor = this.background;
    Console.ForegroundColor = this.color;

    Console.Clear();
  }

  public void buildFrame(int initialColumn, int initialRow, int finalColumn, int finalRow) {

  }
}