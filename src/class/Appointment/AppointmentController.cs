class AppointmentController
{
  public List<Appointment> appointments = new List<Appointment>();
  private Screen screen;

  public AppointmentController(Screen screen)
  {
    this.screen = screen;
  }

  private Appointment createForm()
  {
    int initialColumn = this.screen.InitialColumn + 1;
    int initialRow = 1;

    DateTime now = DateTime.Now;

    string label;
    int column;

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

    Appointment appointment = new Appointment(client, name, company, isExtraWork, startHour);

    initialRow += count;
    this.screen.write(initialColumn, initialRow, "→ Cadastro realizado com sucesso!");

    return appointment;
  }

  public Appointment add()
  {
    Appointment appointment = this.createForm();

    this.appointments.Add(appointment);

    return appointment;
  }

  public void list()
  {

  }
}