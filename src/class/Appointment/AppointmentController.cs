class AppointmentController
{
  public List<Appointment> appointments = new List<Appointment>();
  private Screen screen;
  private Form form;

  public AppointmentController(Screen screen, Form form)
  {
    this.screen = screen;
    this.form = form;
  }

  private Appointment createForm()
  {
    int initialColumn = this.screen.InitialColumn + 1;
    int initialRow = 1;

    Appointment appointment = this.form.createAppointment(initialRow);

    return appointment;
  }

  public Appointment add()
  {
    Appointment appointment = this.createForm();

    this.appointments.Add(appointment);

    return appointment;
  }
}