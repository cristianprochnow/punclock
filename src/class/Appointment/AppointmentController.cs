class AppointmentController
{
  public List<Appointment> appointments = new List<Appointment>();
  private AppointmentTableWidth appointmentTableWidth = new AppointmentTableWidth();
  private Screen screen;
  private int key = new Random().Next();
  private int lastId = 0;
  private int position;

  public AppointmentController(Screen screen)
  {
    this.screen = screen;
    this.position = this.key;
    int id = this.lastId;

    id++;
    this.appointments.Add(new Appointment(
      id,
      "Show Demais",
      "Ainda Melhor",
      "Topzera",
      true,
      "17:56"
    ));
    id++;
    this.appointments.Add(new Appointment(
      id,
      "Ainda Melhor que Antes",
      "Outra Versão",
      "Não Acredito",
      false,
      "19:20"
    ));
    this.lastId = id;
  }

  private Appointment createForm(Appointment? editionAppointment = null)
  {
    int initialColumn = this.screen.InitialColumn + 1;
    int initialRow = 1;

    DateTime now = DateTime.Now;

    string label;
    int column;

    int id = this.lastId;
    if (editionAppointment != null) {
      id = editionAppointment.id;
    }
    else {
      id++;
      this.lastId = id;
    }

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
    label = "Seu nome";
    if (editionAppointment != null) {
      label += " ("+editionAppointment.name+") ";
    }
    string name = this.screen.ask(initialColumn, initialRow, label);
    initialRow += count;
    label = "Prestador de Serviço";
    if (editionAppointment != null) {
      label += " ("+editionAppointment.company+") ";
    }
    string company = this.screen.ask(initialColumn, initialRow, label);
    initialRow += count;
    label = "Cliente do Serviço";
    if (editionAppointment != null) {
      label += " ("+editionAppointment.client+") ";
    }
    string client = this.screen.ask(initialColumn, initialRow, label);
    initialRow += count;
    label = "Hora Inicial do Serviço";
    if (editionAppointment != null) {
      label += " ("+editionAppointment.startTime+") ";
    }
    string startHour = this.screen.ask(initialColumn, initialRow, label);
    initialRow += count;
    string flgExtraWork = this.screen.ask(initialColumn, initialRow, "É hora extra? (S/N)");

    bool isExtraWork = (flgExtraWork.ToUpper() == "S");

    Appointment appointment = new Appointment(id, client, name, company, isExtraWork, startHour);

    initialRow += count;
    if (editionAppointment == null) {
      this.screen.write(initialColumn, initialRow, "→ Cadastro realizado com sucesso! =]");
    }

    return appointment;
  }

  public Appointment add()
  {
    this.clear();

    Appointment appointment = this.createForm();

    this.appointments.Add(appointment);

    return appointment;
  }

  private void setTableWidth()
  {
    foreach (Appointment appointment in this.appointments)
    {
      if (appointment.id.ToString().Length >= this.appointmentTableWidth.id) {
        this.appointmentTableWidth.id = appointment.id.ToString().Length;
      }

      if (appointment.name.Length >= this.appointmentTableWidth.name) {
        this.appointmentTableWidth.name = appointment.name.Length;
      }

      if (appointment.client.Length >= this.appointmentTableWidth.client) {
        this.appointmentTableWidth.client = appointment.client.Length;
      }

      if (appointment.company.Length >= this.appointmentTableWidth.company) {
        this.appointmentTableWidth.company = appointment.company.Length;
      }

      if (appointment.date.Length >= this.appointmentTableWidth.date) {
        this.appointmentTableWidth.date = appointment.date.Length;
      }

      if (appointment.time.Length >= this.appointmentTableWidth.time) {
        this.appointmentTableWidth.time = appointment.time.Length;
      }

      if (appointment.startTime.Length >= this.appointmentTableWidth.startTime) {
        this.appointmentTableWidth.startTime = appointment.startTime.Length;
      }
    }
  }

  public void list()
  {
    this.clear();
    this.setTableWidth();

    int defaultInitialColumn = this.screen.InitialColumn + 1;
    int defaultGap = 4;
    int initialColumn = defaultInitialColumn;
    int initialRow = 1;
    string content;

    if (this.appointments.Count == 0) {
      this.screen.write(initialColumn, initialRow, "Nenhum registro encontrado! =/");
      return;
    }

    string label;

    label = "ID";
    this.screen.write(initialColumn, initialRow, label);

    if (this.appointmentTableWidth.id <= label.Length) {
      this.appointmentTableWidth.id = label.Length;
    }

    label = "NOME";
    initialColumn += this.appointmentTableWidth.id + defaultGap;
    this.screen.write(initialColumn, initialRow, label);

    if (this.appointmentTableWidth.name <= label.Length) {
      this.appointmentTableWidth.name = label.Length;
    }

    label = "COMPANHIA";
    initialColumn += this.appointmentTableWidth.name + defaultGap;
    this.screen.write(initialColumn, initialRow, label);

    if (this.appointmentTableWidth.company <= label.Length) {
      this.appointmentTableWidth.company = label.Length;
    }

    label = "DATA";
    initialColumn += this.appointmentTableWidth.company + defaultGap;
    this.screen.write(initialColumn, initialRow, label);

    if (this.appointmentTableWidth.date <= label.Length) {
      this.appointmentTableWidth.date = label.Length;
    }

    label = "HORA INÍCIO";
    initialColumn += this.appointmentTableWidth.date + defaultGap;
    this.screen.write(initialColumn, initialRow, label);

    if (this.appointmentTableWidth.startTime <= label.Length) {
      this.appointmentTableWidth.startTime = label.Length;
    }

    label = "HORA FIM";
    initialColumn += this.appointmentTableWidth.startTime + defaultGap;
    this.screen.write(initialColumn, initialRow, label);

    if (this.appointmentTableWidth.time <= label.Length) {
      this.appointmentTableWidth.time = label.Length;
    }

    label = "HORA EXTRA";
    initialColumn += this.appointmentTableWidth.time + defaultGap;
    this.screen.write(initialColumn, initialRow, "HORA EXTRA");

    initialRow++;

    foreach (Appointment appointment in this.appointments)
    {
      initialRow++;
      initialColumn = defaultInitialColumn;

      content = appointment.id.ToString();
      this.screen.write(initialColumn, initialRow, content);

      initialColumn += this.appointmentTableWidth.id + defaultGap;
      content = appointment.name.ToString();
      this.screen.write(initialColumn, initialRow, content);

      initialColumn += this.appointmentTableWidth.name + defaultGap;
      content = appointment.company.ToString();
      this.screen.write(initialColumn, initialRow, content);

      initialColumn += this.appointmentTableWidth.company + defaultGap;
      content = appointment.date.ToString();
      this.screen.write(initialColumn, initialRow, content);

      initialColumn += this.appointmentTableWidth.date + defaultGap;
      content = appointment.startTime.ToString();
      this.screen.write(initialColumn, initialRow, content);

      initialColumn += this.appointmentTableWidth.startTime + defaultGap;
      content = appointment.time.ToString();
      this.screen.write(initialColumn, initialRow, content);

      initialColumn += this.appointmentTableWidth.time + defaultGap;
      content = (appointment.isExtraWork) ? "X" : "";
      this.screen.write(initialColumn, initialRow, content);
    }
  }

  public string askChange(string ask)
  {
    int initialColumn = this.screen.InitialColumn - 1;

    this.list();
    this.screen.buildFrame(
      initialColumn,
      this.screen.WindowHeight - 4,
      this.screen.WindowWidth,
      this.screen.WindowHeight
    );
    string answer = this.screen.ask(initialColumn + 2, this.screen.WindowHeight - 3, ask);

    return answer;
  }

  private void clear()
  {
    this.screen.clearFrame(this.screen.InitialColumn, 0, this.screen.WindowWidth, this.screen.WindowHeight);
  }

  public void update(bool delete = false)
  {
    this.clear();

    int initialColumn = this.screen.InitialColumn - 1;
    string operation;

    this.list();
    if (delete) {
      operation = "excluir";
    }
    else {
      operation = "editar";
    }
    string answer = this.askChange("Insira o ID do registro que deseja "+operation);

    this.get(Convert.ToInt32(answer));

    if (this.position == this.key) {
      this.screen.write(initialColumn + 2, this.screen.WindowHeight - 5, "Registro não encontrado! =/");
      return;
    }

    if (delete) {
      operation = "Exclusão";
      this.appointments.RemoveAt(this.position);
    }
    else {
      operation = "Edição";
      this.clear();
      this.appointments[this.position] = this.createForm(this.appointments[this.position]);
    }
    this.screen.write(initialColumn + 2, this.screen.WindowHeight - 5, operation+" realizada com sucesso! =]");
    this.position = this.key;
  }

  public void get(int id)
  {
    for (int counter = 0; counter < this.appointments.Count; counter++)
    {
      Appointment appointment = this.appointments[counter];

      if (appointment.id == id) {
        this.position = counter;

        break;
      }
    }
  }
}