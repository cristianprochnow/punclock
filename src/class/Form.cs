class Form
{
  private Screen screen;
  public int lastRow;
  public int initialColumn;

  public Form(Screen screen)
  {
    this.screen = screen;
    this.initialColumn = this.screen.InitialColumn + 1;
  }

  public Appointment createAppointment(int initialRow)
  {
    DateTime now = DateTime.Now;

    string label;
    int column;

    int initialColumn = this.initialColumn;

    label = "Data: ";
    column = initialColumn;
    this.screen.write(column, initialRow, label);
    column += label.Length;
    this.screen.write(column, initialRow, DateTimeHelper.getDateNow());
    label = "Hora: ";
    column = (this.screen.WindowWidth - initialColumn) / 2;
    this.screen.write(column, initialRow, label);
    column += label.Length;
    this.screen.write(column, initialRow, DateTimeHelper.getTimeNow());

    int count = 3;
    initialRow += count;
    string name = this.screen.ask(initialColumn, initialRow, "Seu nome");
    initialRow += count;
    string company = this.screen.ask(initialColumn, initialRow, "Prestador de Serviço");
    initialRow += count;
    string client = this.screen.ask(initialColumn, initialRow, "Clinte do Serviço");
    initialRow += count;
    string startHour = this.screen.ask(initialColumn, initialRow, "Hora Inicial do Serviço");
    initialRow += count;
    string flgExtraWork = this.screen.ask(initialColumn, initialRow, "É hora extra? (S/N)");

    bool isExtraWork = (flgExtraWork.ToUpper() == "S");

    this.lastRow = initialRow;

    Appointment appointment = new Appointment(client, name, company, isExtraWork, startHour);

    return appointment;
  }
}